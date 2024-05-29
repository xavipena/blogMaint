using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blogs.Classes;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Drawing;
using System.ComponentModel;
using System.IO.Pipelines;
using Mysqlx;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Blogs
{
    public partial class Form1 : Form
    {
        // To draw window when click on top bar
        // -----------------------------------------------

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // -----------------------------------------------

        Singleton Gdata = Singleton.GetInstance();
        bool loading = false;

        public Form1()
        {
            InitializeComponent();
            
            SetUpForm();

            // Make it rounded
            RoundBorderForm(this);

            loading = true;
            Cursor.Current = Cursors.WaitCursor;
            Gdata.db = DBConnect(Gdata.currentSet);
            Gdata.dbCommon = Gdata.db;
            Gdata.Lang = Language.CASTELLA;
            Gdata.testMode = true;
            LoadBlogs();
            Loaders.LoadCombo(cbSet, Combos.BLOG_SET);
            SetDefaultValues();
            LoadFormsInContainer();
            ShowSelectedForm(Panels.Id.HOME);
            Cursor.Current = Cursors.Default;
        }

        public static void RoundBorderForm(Form frm)
        {

            Rectangle Bounds = new Rectangle(0, 0, frm.Width, frm.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            frm.Region = new Region(path);
            frm.Show();
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

            // Remove border
            this.FormBorderStyle = FormBorderStyle.None;
        }

        /// <summary>
        /// Default form values for initialization
        /// </summary>
        private void SetDefaultValues()
        {
            lblTitle.Text = Texts.DESCRIPTION;
            lblMode.Text = Modes.Text.EMPTY;
            lblLang.Text = Language.Name.CASTELLA;
            lblSelected.Text = Panels.Name.HOME;
            lblMessage.Text = Messages.READY;
            lblDesc.Text = Readers.GetBlogDescription();
            Gdata.maintMode = Modes.Status.EMPTY;
            Gdata.Lang = Language.CASTELLA;
            loading = false;
        }

        private void LoadFormsInContainer()
        {
            pnlContainer.Controls.Clear();
            AddFormToContainer(new FormHome());
            AddFormToContainer(new FormArticle());
            AddFormToContainer(new FormReadingTime());
            AddFormToContainer(new FormTranslate());
            AddFormToContainer(new FormLinking());
            AddFormToContainer(new FormSettings());
        }
         
        private void AddFormToContainer(Form FrmType)
        {
            FrmType.Owner = this;
            FrmType.Dock = DockStyle.Fill;
            FrmType.TopLevel = false;
            FrmType.TopMost = true;
            FrmType.FormBorderStyle = FormBorderStyle.None;
            pnlContainer.Controls.Add(FrmType);
        }

        private void ShowSelectedForm(int frm)
        {

            if (pnlContainer.Controls.Count > 0)
            {
                // Hide all
                foreach (Control ctrl in pnlContainer.Controls)
                {
                    ctrl.Hide();
                }
                // Set current
                pnlContainer.Controls[frm].Show();
            }
        }

        /// <summary>
        /// Connect to database using the connecion class
        /// </summary>
        /// <param name="bSet"></param>
        /// <returns></returns>
        private DBConnection DBConnect(string bSet)
        {
            if (Gdata.db != null)
            {
                if (Gdata.currentSet == bSet)
                {
                    return Gdata.db;
                }
            }

            DBConnection dbCon = new DBConnection();
            dbCon.SetDatabase(bSet);
            if (dbCon.DBConnect())
            {
                Gdata.currentSet = bSet;
                lblMessage.Text = Messages.CONNECTED;
                return dbCon;
            }
            else
            {
                lblMessage.Text = "No es pot connectar a la base de dades";
                return null;
            }
        }

        /// <summary>
        /// Load blogs list
        /// </summary>
        private void LoadBlogs()
        {
            Singleton Gdata = Singleton.GetInstance();

            //Build a list
            var dataSource = new List<cbOption>();

            // load the list
            string sql = "select blog, name " +
                         "from project_blogs where status = 'A' and lang = '" + Gdata.Lang + "' and ga4 = '" + Gdata.currentSet + "'";

            dataSource = Readers.LoadList(sql, Gdata.dbCommon);
            if (dataSource != null)
            {
                //Setup data binding
                cbBlogs.DataSource = dataSource;
                cbBlogs.DisplayMember = "entityName";
                cbBlogs.ValueMember = "entityValue";
                cbBlogs.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            Gdata.currentBlog = Int32.Parse(dataSource[0].entityValue);
        }

        /// <summary>
        /// Close app
        /// </summary>
        private void CleanUp()
        {
            if (Gdata.db.IsOpen) Gdata.db.DBClose();
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
            // Gdata control

            bool NeedSave = false;

            // Control for any form in process
            // ---------------------------------------------------------------------------
            // Code here...
            // ---------------------------------------------------------------------------

            if (NeedSave)
            {
                if (MessageBox.Show("No estan gravats els canvis." + Environment.NewLine + "Continua?", "Confirma",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return true;
                }
            }
            return false;
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


        // ---------------------------------------------------------------------------
        // Events
        // on grid cell click
        // ---------------------------------------------------------------------------


        private void btnChangeLang_Click(object sender, EventArgs e)
        {
            // No background change because no form shows up
            Singleton Gdata = Singleton.GetInstance();
            Gdata.Lang = Gdata.Lang == Language.CASTELLA ? Language.CATALA : Language.CASTELLA;
            lblLang.Text = Gdata.Lang == Language.CASTELLA ? Language.Name.CASTELLA : lblLang.Text = Language.Name.CATALA;
            
            // change in child form
            FormArticle formArticle = new FormArticle();
            formArticle.ChangeLang = Gdata.Lang;
        }

        private void UpdateCurrentTab()
        {
            lblMessage.Text = "Falta codi a... UpdateCurrentTab()";
        }

        // ---------------------------------------------------------------------------
        // Selection from List Boxes
        // ---------------------------------------------------------------------------

        private void cbSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            Singleton Gdata = Singleton.GetInstance();
            cbOption op = cbSet.SelectedItem as cbOption;
            Gdata.db = DBConnect(op.entityValue);

            // Load blogs for new set
            LoadBlogs();
        }

        private void cbBlogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Restart all for a new blog
            Singleton Gdata = Singleton.GetInstance();
            Gdata.IDarticle = 0;
            cbOption op = cbBlogs.SelectedItem as cbOption;
            Gdata.currentBlog = Int32.Parse(op.entityValue);

            loading = true;
            Cursor.Current = Cursors.WaitCursor;
            lblDesc.Text = Readers.GetBlogDescription();

            ShowSelectedForm(Panels.Id.ARTICLE);
            // Load blog articles
            FormArticle frm = pnlContainer.Controls[Panels.Id.ARTICLE] as FormArticle;
            frm.LoadArticlesGrid();

            loading = false;
            Cursor.Current = Cursors.Default;
        }

        // ---------------------------------------------------------------------------
        // Left menu buttons
        // ---------------------------------------------------------------------------

        private void btnTabSelector_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTabSelector);
            lblSelected.Text = Panels.Name.ARTICLE;
            ShowSelectedForm(Panels.Id.ARTICLE);
        }

        private void btnTabTime_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTabTime);
            lblSelected.Text = Panels.Name.READTIME;
            ShowSelectedForm(Panels.Id.READTIME);
        }

        private void btnTagChain_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTabChain);
            lblSelected.Text = Panels.Name.LINKING;
            ShowSelectedForm(Panels.Id.LINKING);
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTranslate);
            lblSelected.Text = Panels.Name.TRANSLATION;
            ShowSelectedForm(Panels.Id.TRANSLATION);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            HighlightButton(btnSettings);
            lblSelected.Text = Panels.Name.SETTINGS;
            ShowSelectedForm(Panels.Id.SETTINGS);
        }

        private void HighlightButton(Button btn)
        {
            foreach (Control ctrl in LeftMenu.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    ctrl.BackColor = Colors.MenuOptionColor;
                }
            }
            btn.BackColor = Colors.MenuOptionColorSelected;
        }

        // ---------------------------------------------------------------------------
        // Drag event
        // ---------------------------------------------------------------------------

        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void btnNewArticle_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Encara no està llest";
        }
    }
}
