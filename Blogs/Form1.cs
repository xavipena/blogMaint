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
        // Import dll to make form borders round
        // -----------------------------------------------

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

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
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            RoundBorderForm(this);

            loading = true;
            Cursor.Current = Cursors.WaitCursor;
            Gdata.db = DBConnect(Gdata.currentSet);
            Gdata.dbCommon = Gdata.db;
            LoadBlogs();
            Loaders.LoadCombo(cbSet, Combos.BLOG_SET);
            LoadCombos();
            SetDefaultValues();
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

            // Load default form

            pnlContainer.Controls.Clear();
            FormHome FrmHome = new FormHome()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            FrmHome.FormBorderStyle = FormBorderStyle.None;
            pnlContainer.Controls.Add(FrmHome);
            FrmHome.Show();
        }

        /// <summary>
        /// Default form values for initialization
        /// </summary>
        private void SetDefaultValues()
        {
            lblTitle.Text = Texts.DESCRIPTION;
            lblMode.Text = Modes.Text.EMPTY;
            lblLang.Text = Language.Name.CASTELLA;
            lblSelected.Text = Panels.MAIN;
            lblMessage.Text = Messages.READY;
            lblDesc.Text = Readers.GetBlogDescription();
            Gdata.maintMode = Modes.Status.EMPTY;
            Gdata.Lang = Language.CASTELLA;
            loading = false;
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
        /// Load all combos in app using a common loading routine
        /// </summary>
        private void LoadCombos()
        {
            if (!Gdata.db.IsConnected) return;
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
        }



        /// <summary>
        /// Close app
        /// </summary>
        private void CleanUp()
        {
            if (Gdata.db.IsOpen) Gdata.db.DBClose();
        }






        /// <summary>
        /// Update message labels depending on current thread
        /// </summary>
        /// <param name="message"></param>
        private void UpdateMessage(string message)
        {
            if (lblMessage.InvokeRequired)
            {
                lblMessage.BeginInvoke((MethodInvoker)delegate ()
                {

                    lblMessage.Text = message;
                });
            }
            else
            {
                lblMessage.Text = message;
            }
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
            Singleton Gdata = Singleton.GetInstance();
            Gdata.Lang = Gdata.Lang == Language.CASTELLA ? Language.CATALA : Language.CASTELLA;
            lblLang.Text = Gdata.Lang == Language.CASTELLA ? Language.Name.CATALA : lblLang.Text = Language.Name.CASTELLA;
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
            // Restart all for a new blog
            Singleton Gdata = Singleton.GetInstance();
            Gdata.IDarticle = 0;
            cbOption op = cbBlogs.SelectedItem as cbOption;
            Gdata.currentBlog = Int32.Parse(op.entityValue);

            loading = true;
            Cursor.Current = Cursors.WaitCursor;
            LoadCombos();
            loading = false;
            Cursor.Current = Cursors.Default;

            lblDesc.Text = Readers.GetBlogDescription();

        }

        // ---------------------------------------------------------------------------
        // Left menu buttons
        // ---------------------------------------------------------------------------

        private void btnTabSelector_Click(object sender, EventArgs e)
        {
            btnTabSelector.BackColor = Color.FromArgb(46, 51, 73);
            lblSelected.Text = Panels.ARTICLE;

            pnlContainer.Controls.Clear();
            FormArticle FrmArticle = new FormArticle()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            FrmArticle.FormBorderStyle = FormBorderStyle.None;
            pnlContainer.Controls.Add(FrmArticle);
            FrmArticle.Show();
        }

        private void btnTabTime_Click(object sender, EventArgs e)
        {
            btnTabTime.BackColor = Color.FromArgb(46, 51, 73);
            lblSelected.Text = Panels.READTIME;

            pnlContainer.Controls.Clear();
            FormReadingTime FrmReading = new FormReadingTime() {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true 
            }; 
            FrmReading.FormBorderStyle = FormBorderStyle.None;
            pnlContainer.Controls.Add(FrmReading);
            FrmReading.Show();
        }

        private void btnTagChain_Click(object sender, EventArgs e)
        {
            btnTabChain.BackColor = Color.FromArgb(46, 51, 73);
            lblSelected.Text = Panels.LINKING;

            pnlContainer.Controls.Clear();
            FormLinking FrmLinking = new FormLinking()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            FrmLinking.FormBorderStyle = FormBorderStyle.None;
            pnlContainer.Controls.Add(FrmLinking);
            FrmLinking.Show();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            btnTabChain.BackColor = Color.FromArgb(46, 51, 73);
            lblSelected.Text = Panels.TRANSLATION;

            pnlContainer.Controls.Clear();
            FormTranslate FrmTranslate = new FormTranslate()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            FrmTranslate.FormBorderStyle = FormBorderStyle.None;
            pnlContainer.Controls.Add(FrmTranslate);
            FrmTranslate.Show();
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
    }
}
