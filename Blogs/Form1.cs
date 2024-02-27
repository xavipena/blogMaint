using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blogs.Classes;
using System.Xml.Linq;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Messaging;

namespace Blogs
{
    public partial class Form1 : Form
    {
        bool NeedToSave = false;
        Singleton Gdata = Singleton.GetInstance();
        bool[] done = new bool[Constants.NUM_TABS];
        bool loading = false;

        public Form1()
        {
            InitializeComponent();
            SetUpForm();
            DefineGrids();
            Gdata.db = DBConnect();
            LoadCombos();
            tbES.Text = Language.CASTELLA;
            tbCA.Text = Language.CATALA;
        }

        // ---------------------------------------------------------------------------
        // Config
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Set up the form
        /// </summary>
        private void SetUpForm()
        {
            lblTitle.Text = "Manteniment de blocs";

            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            tabControl1.Click += new EventHandler(tabControl_Click);
        }

        private void DefineGrids()
        {
            dgvArticles.Rows.Clear();
            dgvArticles.ColumnCount = 5;
            dgvArticles.AllowUserToAddRows = false;

            dgvArticles.Columns[0].Name = "ID";
            dgvArticles.Columns[0].Width = 40;
            dgvArticles.Columns[1].Name = "Títol";
            dgvArticles.Columns[1].Width = 400;
            dgvArticles.Columns[2].Name = "Temps";
            dgvArticles.Columns[2].Width = 50;
            dgvArticles.Columns[3].Name = "Mots";
            dgvArticles.Columns[3].Width = 50;
            dgvArticles.Columns[4].Name = "Mod";
            dgvArticles.Columns[4].Width = 40;

            dgvSelector.Rows.Clear();
            dgvSelector.ColumnCount = 3;
            dgvSelector.AllowUserToAddRows = false;

            dgvSelector.Columns[0].Name = "ID";
            dgvSelector.Columns[0].Width = 40;
            dgvSelector.Columns[1].Name = "Secció";
            dgvSelector.Columns[1].Width = 100;
            dgvSelector.Columns[2].Name = "Títol";
            dgvSelector.Columns[2].Width = 400;
        }

        private DBConnection DBConnect()
        {
            DBConnection dbCon = DBConnection.Instance();
            dbCon.Server = "qahz995.diaridigital.net";
            dbCon.DatabaseName = "qahz995";
            dbCon.UserName = "qahz995";
            dbCon.Password = "CrisRami2023";
            if (dbCon.DBConnect())
            {
                lblMessage.Text = "Connectat";
                return dbCon;
            }
            else
            {
                lblMessage.Text = "No es pot connectar a la base de dades";
                return null;
            }
        }

        /// <summary>
        /// Load combo box with salespersons
        /// </summary>
        private void LoadCombos()
        {
            if (!Gdata.db.IsConnected) return;
            LoadBlogs();

            LoadComboBox(cbHeadType, "select distinct type, type from articles");
            Loaders.LoadCombo(cbHeadStatus, Combos.STATUS);
            Loaders.LoadCombo(cbHeadLang, Combos.LANGUAGE);
            Loaders.LoadCombo(cbHeadAuthor, Combos.AUTHOR);

            Loaders.LoadCombo(cbTextStatus, Combos.STATUS);
            Loaders.LoadCombo(cbTextLang, Combos.LANGUAGE);
            Loaders.LoadCombo(cbTextType, Combos.SECTION_TYPE);
        }
        private void LoadBlogs()
        {
            Singleton Gdata = Singleton.GetInstance();

            //Build a list
            var dataSource = new List<cbOption>();

            // load the list
            string sql = "select blog, name " +
                         "from project_blogs where status = 'A' and lang = '" + Gdata.Lang + "' and ga4 = 'A'";

            dataSource = Readers.LoadList(sql);

            //Setup data binding
            cbBlogs.DataSource = dataSource;
            cbBlogs.DisplayMember = "entityName";
            cbBlogs.ValueMember = "entityValue";
            cbBlogs.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadArticleSections()
        {
            Singleton Gdata = Singleton.GetInstance();
            loading = true;

            //Build a list
            var dataSource = new List<cbOption>();

            // load the list
            string sql = "select position, section from article_details " +
                         "where IDarticle = " + Gdata.IDarticle + " and status = 'A' and lang = '" + Gdata.Lang + "'";

            dataSource = Readers.LoadList(sql);

            //Setup data binding
            lbTextSections.DataSource = dataSource;
            lbTextSections.DisplayMember = "entityName";
            lbTextSections.ValueMember = "entityValue";

            loading = false;
            // Fill first section on tab
            FillTabTexts(Int32.Parse(dataSource[0].entityValue));

        }

        // ---------------------------------------------------------------------------
        // Generic ComboBox loader
        // ---------------------------------------------------------------------------

        private void LoadComboBox(System.Windows.Forms.ComboBox combobox, string sql)
        {
            if (combobox == null) return;
            if (sql == string.Empty) return;

            List<cbOption> list = new List<cbOption>();
            Singleton Gdata = Singleton.GetInstance();
            Gdata.db.DBOpen();
            try
            {
                using (var cmd = new MySqlCommand(sql, Gdata.db.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cbOption op = new cbOption()
                        {
                            entityValue = reader.GetString(0),
                            entityName = reader.GetString(1)
                        };
                        list.Add(op);
                    }

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            finally
            {
                Gdata.db.DBClose();
            }
            combobox.DataSource = null;
            combobox.DataSource = list;
            combobox.ValueMember = "entityValue";
            combobox.DisplayMember = "entityName";
            // Readonly, not editable
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ---------------------------------------------------------------------------
        // Load data
        // ---------------------------------------------------------------------------

        private void LoadArticles()
        {
            Gdata.db.DBOpen();

            string sql = "select IDarticle, title, readTime, wordCount, type " +
                         "from articles where IDblog = " + Gdata.currentBlog + " and status = 'A' and lang = '" + Gdata.Lang + "'";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] aRow = new string[]
                {
                    reader.GetInt32(0).ToString(),
                    reader.GetString(1),
                    reader.GetInt32(2).ToString(),
                    reader.GetInt32(3).ToString(),
                    string.Empty
                };
                dgvArticles.Rows.Add(aRow);
                string[] selRow = new string[]
                {
                    reader.GetInt32(0).ToString(),
                    reader.GetString(4),
                    reader.GetString(1)
                };
                dgvSelector.Rows.Add(selRow);
            }

            Gdata.db.DBClose();
        }

        // ---------------------------------------------------------------------------
        // Routines
        // ---------------------------------------------------------------------------

        private void UpdateTableArticle()
        {
            foreach (DataGridViewRow row in dgvArticles.Rows)
            {
                if (row.Cells[4].Value.ToString() == Marks.MODIFIED)
                {
                    UpdateRow(row);
                }
            }
        }

        private void UpdateRow(DataGridViewRow row)
        {
            string sql = "update articles " +
                        "set readTime = @val1, wordCount = @val2 " +
                        "where IDblog = @par1 and IDarticle = @par2";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.currentBlog);
            cmd.Parameters.AddWithValue("@par2", row.Cells[0].Value);
            cmd.Parameters.AddWithValue("@val1", row.Cells[2].Value);
            cmd.Parameters.AddWithValue("@val2", row.Cells[3].Value);
            cmd.ExecuteNonQuery();
        }

        private void SetReadTimeFor(DataGridViewRow row)
        {
            // Search details and count words
            int ID = Int32.Parse(row.Cells[0].Value.ToString());
            int w = Workers.GetWordCount(ID);
            int m = (w / Articles.WORDS_PER_MIN) + 1;
            // update
            row.Cells[2].Value = m;
            row.Cells[3].Value = w;
            row.Cells[4].Value = Marks.MODIFIED;
            NeedToSave = true;
        }

        // ---------------------------------------------------------------------------
        // Save
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Remind user to save the file
        /// </summary>
        /// <returns></returns>
        private bool ForgotToSave()
        {
            if (NeedToSave)
            {
                if (MessageBox.Show("No estan gravats els canvis." + Environment.NewLine + "Sortir?", "Confirma",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Close app
        /// </summary>
        private void CleanUp()
        {
            if (Gdata.db.IsOpen) Gdata.db.DBClose();
        }

        private void LoadArticlesGrid()
        {
            dgvArticles.Rows.Clear();
            dgvSelector.Rows.Clear();

            cbOption op = cbBlogs.SelectedItem as cbOption;
            Gdata.currentBlog = Int32.Parse(op.entityValue);
            lblDesc.Text = Readers.GetBlogDescription();
            LoadArticles();
        }

        // ---------------------------------------------------------------------------
        // Change tab
        // ---------------------------------------------------------------------------

        private void ClearDoneArray()
        {
            for (int i = 0; i < tabControl1.Controls.Count; i++)
            {
                done[i] = false;
            }
        }
        private void tabControl_Click(object sender, EventArgs e)
        {
            if (!done[tabControl1.SelectedIndex])
            {
                switch (tabControl1.SelectedIndex)
                {
                    case Tabs.HEADER:
                        FillTabHead();
                        break;
                    case Tabs.SECTIONS:
                        // Once the article sections is completed, the rest of the tab is filled
                        // with the selected section:
                        // LoadArticleSections() --> FillTabText()
                        LoadArticleSections();
                        break;
                }
                done[tabControl1.SelectedIndex] = true;
            }
        }

        // ---------------------------------------------------------------------------
        // Fill tabs
        // ---------------------------------------------------------------------------

        private void FillTabHead()
        {
            List<string> list = new List<string>();
            list = Readers.GetTabHeader();
            if (list != null)
            {
                cbHeadType.Text = list[0];
                dtpHeadDate.Text = list[1];
                dtpHeadPub.Text = list[2];
                dtpHeadUpdate.Text = list[3];
                tbHeadExcerpt.Text = list[5];
                cbHeadStatus.Text = list[6];    
                cbHeadAuthor.Text = list[7];
                cbHeadLang.Text = list[8];
                tbHeadPrev.Text = list[9];
                tbHeadNext.Text = list[10];
                tbHeadTime.Text = list[11];
                tbHeadWords.Text = list[12];
            }
        }

        private void FillTabTexts(int section)
        {
            List<string> list = new List<string>();
            list = Readers.GetTabTexts(section);
            if (list != null)
            {
                tbTextDetail.Text = list[4];
                tbTextPos.Text = list[2];
                cbTextType.Text = list[3];
                cbTextStatus.Text = list[5];
                cbTextLang.Text = list[6];
            }
        }

        // ---------------------------------------------------------------------------
        // Events
        // ---------------------------------------------------------------------------

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ForgotToSave()) return;
            CleanUp();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ForgotToSave()) return;
            CleanUp();
            Application.Exit();
        }

        private void cbBlogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArticlesGrid();
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool noData = true;
            foreach (DataGridViewRow row in dgvArticles.SelectedRows)
            {
                SetReadTimeFor(row);
                noData = false;
            }
            if (noData)
            {
                lblMessage.Text = "Res seleccionat";
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnWordsAll_Click(object sender, EventArgs e)
        {
            if (dgvArticles.Rows.Count == 0)
            {
                lblMessage.Text = "No hi ha articles";
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            int x = 0;
            foreach (DataGridViewRow row in dgvArticles.Rows)
            {
                if (Int32.Parse(row.Cells[2].Value.ToString()) == 0
                 || Int32.Parse(row.Cells[3].Value.ToString()) == 0)
                {
                    SetReadTimeFor(row);
                    x += 1;
                }
            }
            if (x > 0)
            {
                //LoadArticlesGrid();
                lblMessage.Text = x + " articles actualitzats";
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            UpdateTableArticle();
            NeedToSave = false;
            LoadArticlesGrid();
        }

        private void dgvSelector_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the article selected and fill the header
            int IDarticle = Int32.Parse(dgvSelector.Rows[e.RowIndex].Cells[0].Value.ToString());
            Singleton Gdata = Singleton.GetInstance();
            Gdata.IDarticle = IDarticle;

            tbArticle.Text = IDarticle.ToString();
            tbTitle.Text = Readers.GetTitle(Language.CASTELLA);
            tbTitleCA.Text = Readers.GetTitle(Language.CATALA);
        }

        private void btnArtDetails_Click(object sender, EventArgs e)
        {
            if (tbArticle.Text == string.Empty) return;
            FillTabHead();
            tabControl1.SelectedIndex = Tabs.HEADER;
        }

        private void lbTextSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Load Text tab
            // get the selected section
            cbOption op = lbTextSections.SelectedItem as cbOption;
            FillTabTexts(Int32.Parse(op.entityValue));
        }

        private void btnChangeLang_Click(object sender, EventArgs e)
        {
            if (tbCA.Text == string.Empty) return;

            Singleton Gdata = Singleton.GetInstance();
            Gdata.Lang = Gdata.Lang == Language.CASTELLA ? Language.CATALA : Language.CASTELLA;
            ClearDoneArray();
            LoadArticlesGrid();
        }
    }
}
