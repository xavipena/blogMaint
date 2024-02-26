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

namespace Blogs
{
    public partial class Form1 : Form
    {
        DBConnection dbCon;
        string lang = "es";
        int currentBlog = 0;

        public Form1()
        {
            InitializeComponent();
            SetUpForm();
            DefineGrids();
            DBConnect();
            LoadBlogs();
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
        }

        private void DefineGrids()
        {
            dgvArticles.Rows.Clear();
            dgvArticles.ColumnCount = 4;
            dgvArticles.AllowUserToAddRows = false;

            dgvArticles.Columns[0].Name = "ID";
            dgvArticles.Columns[0].Width = 40;
            dgvArticles.Columns[1].Name = "Títol";
            dgvArticles.Columns[1].Width = 400;
            dgvArticles.Columns[2].Name = "Temps";
            dgvArticles.Columns[2].Width = 50;
            dgvArticles.Columns[3].Name = "Mots";
            dgvArticles.Columns[3].Width = 50;
        }

        private void DBConnect()
        {
            dbCon = DBConnection.Instance();
            dbCon.Server = "qahz995.diaridigital.net";
            dbCon.DatabaseName = "qahz995";
            dbCon.UserName = "qahz995";
            dbCon.Password = "CrisRami2023";
            if (dbCon.DBConnect())
            {
                lblMessage.Text = "Connectat";
            }
            else
            {
                lblMessage.Text = "No es pot connectar a la base de dades";
            }
        }

        /// <summary>
        /// Load combo box with salespersons
        /// </summary>
        private void LoadBlogs()
        {
            if (!dbCon.IsConnected) return;

            //Build a list
            var dataSource = new List<cbOption>();

            // load the list
            dataSource = GetBlogs();

            //Setup data binding
            cbBlogs.DataSource = dataSource;
            cbBlogs.DisplayMember = "entityName";
            cbBlogs.ValueMember = "entityValue";

            // readonly
            cbBlogs.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadArticles(int blog)
        {
            dbCon.DBOpen();

            string sql = "select IDarticle, title, readTime, wordCount " +
                         "from articles where IDblog = " + blog + " and status = 'A' and lang = '" + lang + "'";
            var cmd = new MySqlCommand(sql, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] aRow = new string[]
                {
                    reader.GetInt32(0).ToString(),
                    reader.GetString(1),
                    reader.GetInt32(2).ToString(),
                    reader.GetInt32(3).ToString()
                };
                dgvArticles.Rows.Add(aRow);
            }

            dbCon.DBClose();
        }

        private List<cbOption> GetBlogs()
        { 
            var list = new List<cbOption>();
            dbCon.DBOpen();

            string sql = "select blog, name " +
                         "from project_blogs where status = 'A' and lang = '" + lang + "' and ga4 = 'A'";
            var cmd = new MySqlCommand(sql, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbOption op = new cbOption()
                {
                    entityValue = reader.GetInt32(0).ToString(),
                    entityName = reader.GetString(1)
                };
                list.Add(op);
            }

            dbCon.DBClose();
            return list;
        }

        // ---------------------------------------------------------------------------
        // Routines
        // ---------------------------------------------------------------------------

        private int GetWordCount(int IDarticle)
        {
            dbCon.DBOpen();

            string artText = string.Empty;
            int wordCount = 0;

            string sql = "select text " +
                         "from article_details where IDarticle = " + IDarticle + " and lang = '" + lang + "' and status = 'A'";
            var cmd = new MySqlCommand(sql, dbCon.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                artText = reader.GetString(0);
                string[] words = artText.Split(' ');
                wordCount += words.Length;
            }

            dbCon.DBClose();
            return wordCount;
        }

        // ---------------------------------------------------------------------------
        // Events
        // ---------------------------------------------------------------------------

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbBlogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadArticlesGrid();
        }

        private void LoadArticlesGrid() 
        { 
            dgvArticles.Rows.Clear();
            cbOption op = cbBlogs.SelectedItem as cbOption;
            currentBlog = Int32.Parse(op.entityValue);
            LoadArticles(currentBlog);
        }

        private void btnWords_Click(object sender, EventArgs e)
        {
            int IDarticle = 0;
            foreach (DataGridViewRow row in dgvArticles.SelectedRows)
            {
                // Search details and count words
                int ID = Int32.Parse(row.Cells[0].Value.ToString());
                int w = GetWordCount(ID);
                int m = (w / 235) + 1;
                label2.Text = "ID" +ID + ": " + w + " mots; "+ m + " mins";
                // update
                UpdateArticle(ID, w, m);
                LoadArticlesGrid();
            }
            if (IDarticle == 0)
            {
                lblMessage.Text = "Res seleccionat";
            }
        }

        private void UpdateArticle(int IDarticle, int words, int time)
        {
            dbCon.DBOpen();

            string sql = "update articles " +
                         "set readTime = @val1, wordCount = @val2 " +
                         "where IDblog = @par1 and IDarticle = @par2";

            var cmd = new MySqlCommand(sql, dbCon.Connection);
            cmd.Parameters.AddWithValue("@par1", currentBlog);
            cmd.Parameters.AddWithValue("@par2", IDarticle);
            cmd.Parameters.AddWithValue("@val1", words);
            cmd.Parameters.AddWithValue("@val2", time);
            cmd.ExecuteNonQuery();

            dbCon.DBClose();
        }
    }
}
