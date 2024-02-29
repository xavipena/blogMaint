﻿using MySql.Data.MySqlClient;
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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
//using static System.Net.Mime.MediaTypeNames;

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
            loading = true;
            Gdata.db = DBConnect(Gdata.currentSet);
            Gdata.dbCommon = Gdata.db;
            LoadBlogs();
            Loaders.LoadCombo(cbSet, Combos.BLOG_SET);
            LoadCombos();
            tbES.Text = Language.CASTELLA;
            tbCA.Text = Language.CATALA;
            lblMessage.Text = Messages.READY;
            lblDesc.Text = Readers.GetBlogDescription();
            loading = false;
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


            dgvMetadata.Rows.Clear();
            dgvMetadata.ColumnCount = 4;
            dgvMetadata.AllowUserToAddRows = false;

            dgvMetadata.Columns[0].Name = "ID";
            dgvMetadata.Columns[0].Width = 40;
            dgvMetadata.Columns[1].Name = "Propietat";
            dgvMetadata.Columns[1].Width = 100;
            dgvMetadata.Columns[2].Name = "Valor";
            dgvMetadata.Columns[2].Width = 200;
            dgvMetadata.Columns[3].Name = "Descripció";
            dgvMetadata.Columns[3].Width = 350;
        }

        private DBConnection DBConnect(string bSet)
        {
            if (Gdata.db != null)
            {
                if (Gdata.currentSet == bSet)
                {
                    return Gdata.db;
                }
            }

            //DBConnection dbCon = new DBConnection.Instance();
            DBConnection dbCon = new DBConnection();
            dbCon.SetDatabase(bSet);
            if (dbCon.DBConnect())
            {
                Gdata.currentSet = bSet;
                lblMessage.Text = Messages.CONNECTED;
                lblDatabase.Text = Gdata.currentSet == BlogSet.TECHNICAL ? dBServers.TECHNICAL : dBServers.PERSONAL;
                return dbCon;
            }
            else
            {
                lblMessage.Text = "No es pot connectar a la base de dades";
                return null;
            }
        }

        /// <summary>
        /// Load all combos in app
        /// </summary>
        private void LoadCombos()
        {
            if (!Gdata.db.IsConnected) return;

            LoadComboBox(cbHeadType, "select distinct type, type from articles");

            Loaders.LoadCombo(cbHeadStatus, Combos.STATUS);
            Loaders.LoadCombo(cbHeadLang, Combos.LANGUAGE);
            Loaders.LoadCombo(cbHeadAuthor, Combos.AUTHOR);

            Loaders.LoadCombo(cbTextStatus, Combos.STATUS);
            Loaders.LoadCombo(cbTextLang, Combos.LANGUAGE);
            Loaders.LoadCombo(cbTextType, Combos.SECTION_TYPE);

            Loaders.LoadCombo(cbImageStatus, Combos.STATUS);
            Loaders.LoadCombo(cbImageLang, Combos.LANGUAGE);

            Loaders.LoadCombo(cbLinkStatus, Combos.STATUS);
            Loaders.LoadCombo(cbLinkLang, Combos.LANGUAGE);

            Loaders.LoadCombo(cbRefStatus, Combos.STATUS);

            Loaders.LoadCombo(cbQuoteStatus, Combos.STATUS);
            Loaders.LoadCombo(cbQuoteLang, Combos.LANGUAGE);

            Loaders.LoadCombo(cbCodeStatus, Combos.STATUS);
            LoadCodeLanguages();
        }

        private void LoadBlogs()
        {
            Singleton Gdata = Singleton.GetInstance();

            //Build a list
            var dataSource = new List<cbOption>();

            // load the list
            string sql = "select blog, name " +
                         "from project_blogs where status = 'A' and lang = '" + Gdata.Lang + "' and ga4 = '" + Gdata.currentSet + "'";

            dataSource = Readers.LoadList(sql);
            if (dataSource != null)
            {
                //Setup data binding
                cbBlogs.DataSource = dataSource;
                cbBlogs.DisplayMember = "entityName";
                cbBlogs.ValueMember = "entityValue";
                cbBlogs.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void LoadCodeLanguages()
        {
            cbCodeLanguage.DataSource = Readers.LoadLangTypes();
            cbCodeLanguage.DisplayMember = "entityName";
            cbCodeLanguage.ValueMember = "entityValue";
            cbCodeLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Load each list of article sections as selector for each tab
        /// </summary>
        private void LoadArticleSections()
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return;
            loading = true;

            //Build a list
            var dataSource = new List<cbOption>();

            // load the list
            string sql = "select position, section from article_details " +
                         "where IDarticle = " + Gdata.IDarticle + " and status = 'A' and lang = '" + Gdata.Lang + "'";

            dataSource = Readers.LoadList(sql);
            if (dataSource != null)
            {
                // Setup data binding
                lbTextSections.DataSource = dataSource;
                lbTextSections.DisplayMember = "entityName";
                lbTextSections.ValueMember = "entityValue";

                lbImageSections.DataSource = dataSource;
                lbImageSections.DisplayMember = "entityName";
                lbImageSections.ValueMember = "entityValue";

                lbLinkSections.DataSource = dataSource;
                lbLinkSections.DisplayMember = "entityName";
                lbLinkSections.ValueMember = "entityValue";

                lbQuoteSections.DataSource = dataSource;
                lbQuoteSections.DisplayMember = "entityName";
                lbQuoteSections.ValueMember = "entityValue";

                lbCodeSections.DataSource = dataSource;
                lbCodeSections.DisplayMember = "entityName";
                lbCodeSections.ValueMember = "entityValue";

                // References, get list
                dataSource = Readers.LoadRefList();
                lbRefSections.DataSource = dataSource;
                lbRefSections.DisplayMember = "entityName";
                lbRefSections.ValueMember = "entityValue";
            }
            loading = false;
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
                Gdata.ErrorText = ex.Message;
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
        // Routines to update time/words
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
            lblMessage.Text = string.Empty;
            if (Gdata.IDarticle == 0 && tabControl1.SelectedIndex > 0)
            {
                lblMessage.Text = "Selecciona un article per mostrar els detalls";
            }

            if (!done[tabControl1.SelectedIndex])
            {
                switch (tabControl1.SelectedIndex)
                {
                    case Tabs.HEADER:
                        FillTabHead();
                        break;

                    case Tabs.SECTIONS:
                        // If tab is empty, show first section
                        if (tbTextDetail.Text == string.Empty)
                        {
                            cbOption op = lbTextSections.SelectedItem as cbOption;
                            if (op != null)
                            {
                                FillTabTexts(Int32.Parse(op.entityValue));
                            }
                        }
                        break;

                    case Tabs.IMAGES:
                        if (lbImageSections.Text == string.Empty)
                        {
                            cbOption op = lbImageSections.SelectedItem as cbOption;
                            if (op != null)
                            {
                                FillTabImages(Int32.Parse(op.entityValue));
                            }
                        }
                        break;

                    case Tabs.LINKS:
                        if (tbLinkName.Text == string.Empty)
                        {
                            cbOption op = lbLinkSections.SelectedItem as cbOption;
                            if (op != null)
                            {
                                FillTabLinks(Int32.Parse(op.entityValue));
                            }
                        }
                        break;

                    case Tabs.REFERENCE:
                        if (lbRefSections.Items.Count > 0)
                        {
                            cbOption op = lbRefSections.SelectedItem as cbOption;
                            if (op != null)
                            {
                                FillTabReferences(op.entityValue);
                            }
                        }
                        break;

                    case Tabs.QUOTES:
                        if (lbQuoteSections.Items.Count > 0)
                        {
                            cbOption op = lbQuoteSections.SelectedItem as cbOption;
                            if (op != null)
                            {
                                FillTabQuotes(Int32.Parse(op.entityValue));
                            }
                        }
                        break;

                    case Tabs.CODE:
                        if (lbCodeSections.Items.Count > 0)
                        {
                            cbOption op = lbCodeSections.SelectedItem as cbOption;
                            if (op != null)
                            {
                                FillTabCode(Int32.Parse(op.entityValue));
                            }
                        }
                        break;

                    case Tabs.METADATA:
                        FillTabMetadata();
                        break;

                    case Tabs.CREDITS:
                        FillTabCredits();
                        if (Gdata.url != string.Empty)
                        {
                            OpenURL(Gdata.url);
                        }
                        break;
                }
                done[tabControl1.SelectedIndex] = true;
            }
        }

        // ---------------------------------------------------------------------------
        // Image download
        // ---------------------------------------------------------------------------

        #region images

        private void DownloadImage(string url)
        {
            if (url == string.Empty) return; 
            if (tabControl1.SelectedIndex != Tabs.IMAGES) return;

            string imageRequested = string.Empty;
            string[] tokens = url.Split('/');
            foreach (string token in tokens)
            {
                imageRequested = tokens.Last();
            }

            if (File.Exists(Paths.DOWNLOAD + imageRequested))
            {
                ShowImage(imageRequested);
                return;
            }

            tokens = imageRequested.Split('.');
            if (tokens.Last() == "webp") 
            {
                // Discard Task
                _ = DownloadWebp(imageRequested);
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(url), Paths.DOWNLOAD + imageRequested);
                }
            }
        }

        // webp
        // https://stackoverflow.com/questions/66072583/download-webp-image-from-url-with-c-sharp

        private static readonly HttpClient client = new HttpClient(new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.Deflate
            // automatically adds HTTP header "Accept-Encoding: gzip, deflate, br"
        });

        private async Task DownloadWebp(string image)
        {
            client.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            try
            {
                string url = Gdata.url + "/" + image;
                UpdateMessage("Baixant...");
                byte[] data = await client.GetByteArrayAsync(url);
                UpdateMessage("Gravant...");
                File.WriteAllBytes(Paths.DOWNLOAD + image, data);
                UpdateMessage("Fet");
                ShowImage(image);
            }
            catch (Exception ex)
            {
                Gdata.ErrorText = ex.Message;
                UpdateMessage(ex.Message);
            }
        }

        public static Image ResizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void ShowImage(string image)
        {
            Image DownloadedImage = null;
            try
            {
                DownloadedImage = Image.FromFile(Paths.DOWNLOAD + image);
            }
            catch (OutOfMemoryException)
            {
                UpdateMessage("Imatge massa gran");
                return;
            }
            if (lblMessage.InvokeRequired)
            {
                lblMessage.BeginInvoke((MethodInvoker)delegate () {

                    pbImage.Image = DownloadedImage;
                });
            }
            else
            {
                pbImage.Image = DownloadedImage;
            }
        }
        #endregion

        /// <summary>
        /// Update message labels depending on current thread
        /// </summary>
        /// <param name="message"></param>
        private void UpdateMessage(string message)
        {
            if (lblMessage.InvokeRequired)
            {
                lblMessage.BeginInvoke((MethodInvoker)delegate () {

                    lblMessage.Text = message;
                });
            }
            else
            {
                lblMessage.Text = message;
            }
        }

        // ---------------------------------------------------------------------------
        // Clear and disable/enable tabs
        // ---------------------------------------------------------------------------

        private void ClearAllBoxes()
        {
            ClearSections();
            ClearTabTexts();
            ClearTabImages();
            ClearTabLinks();
            ClearTabReferences();
            ClearTabQuotes();
            ClearTabCode();
        }

        private void ClearHeaders()
        {
            tbArticle.Text = string.Empty;
            tbTitle.Text = string.Empty;
            tbTitleCA.Text = string.Empty;

            tbHeadExcerpt.Text = string.Empty;
            tbHeadNext.Text = string.Empty;
            tbHeadPrev.Text = string.Empty; 
            tbHeadTime.Text = string.Empty;
            tbHeadWords.Text = string.Empty;

            dgvSelector.Rows.Clear();
            dgvArticles.Rows.Clear();
            dgvMetadata.Rows.Clear();

        }

        private void ClearSections()
        {
            lbTextSections.DataSource = null;
            lbImageSections.DataSource = null;
            lbLinkSections.DataSource = null;
            lbQuoteSections.DataSource = null;
            lbCodeSections.DataSource = null;
            lbRefSections.DataSource = null;

        }

        private void ClearTabTexts()
        {
            tbTextDetail.Text = string.Empty;
            tbTextPos.Text = string.Empty;            
        }

        private void ClearTabImages()
        {
            tbImageSeq.Text = string.Empty;
            tbImageName.Text = string.Empty;
            tbImageCaption.Text = string.Empty;
            tbImageLCaption.Text = string.Empty;
            tbImageAlternate.Text = string.Empty;
            tbImageCredit.Text = string.Empty;
        }

        private void TabImagesFields(bool enable)
        {
            tbImageSeq.Enabled = enable;
            tbImageName.Enabled = enable;
            tbImageCaption.Enabled = enable;
            tbImageLCaption.Enabled = enable;
            tbImageAlternate.Enabled = enable;
            tbImageCredit.Enabled = enable;
            cbImageStatus.Enabled = enable;
            cbImageLang.Enabled = enable;
        }

        private void ClearTabLinks()
        {
            tbLinkName.Text = string.Empty;
            tbLinkURL.Text = string.Empty;
        }

        private void TabLinksFields(bool enable)
        {
            tbLinkName.Enabled = enable;
            tbLinkURL.Enabled = enable;
            cbLinkStatus.Enabled = enable;
            cbLinkLang.Enabled = enable;
        }

        private void ClearTabReferences()
        {
            tbRefSeq.Text = string.Empty;
            tbRefName.Text = string.Empty;
            tbRefURL.Text = string.Empty;
        }

        private void TabReferenceFields(bool enable)
        {
            tbRefSeq.Enabled = enable;
            tbRefName.Enabled = enable;
            tbRefURL.Enabled = enable;
            cbRefStatus.Enabled = enable;
        }

        private void ClearTabQuotes()
        {
            tbQuoteText.Text = string.Empty;
            tbQuoteAuthor.Text = string.Empty;
        }

        private void TabQuoteFields(bool enable)
        {
            tbQuoteText.Enabled = enable;
            tbQuoteAuthor.Enabled = enable;
            cbQuoteStatus.Enabled = enable;
            cbQuoteLang.Enabled = enable;
        }

        private void ClearTabCode()
        {
            tbCode.Text = string.Empty;
            tbCodeSeq.Text = string.Empty;
        }

        private void TabCodeFields(bool enable)
        {
            tbCode.Enabled = enable;
            tbCodeSeq.Enabled = enable;
            cbCodeStatus.Enabled = enable;
            cbCodeLanguage.Enabled = enable;
        }

        // ---------------------------------------------------------------------------
        // Fill tabs
        // ---------------------------------------------------------------------------

        private void FillTabHead()
        {
            List<string> list = new List<string>();
            list = Readers.GetTabHeader();
            if (list != null && list.Count > 0)
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
            if (list != null && list.Count > 0)
            {
                tbTextDetail.Text = list[2];
                tbTextPos.Text = list[0];
                cbTextType.Text = list[1];
                cbTextStatus.Text = list[3];
                cbTextLang.Text = list[4];
            }
        }

        private void FillTabImages(int section)
        {
            // This tab can has sections with no images, so disable empty fields
            // Enable if want to add

            List<string> list = new List<string>();
            list = Readers.GetTabImages(section);
            if (list != null && list.Count > 0)
            {
                TabImagesFields(true);

                tbImageSeq.Text = list[0];
                tbImageName.Text = list[1];
                tbImageCaption.Text = list[2];
                tbImageLCaption.Text = list[3];
                tbImageAlternate.Text = list[4];
                tbImageCredit.Text = list[5];
                cbImageStatus.Text = list[6];
                cbImageLang.Text = list[7];

                DownloadImage(list[1]);
            }
            else
            {
                ClearTabImages();
                TabImagesFields(false);
            }
        }

        private void FillTabLinks(int section)
        {
            // This tab can has sections with no images, so disable empty fields
            // Enable if want to add

            List<string> list = new List<string>();
            list = Readers.GetTabLinks(section);
            if (list != null && list.Count > 0)
            {
                TabLinksFields(true);

                tbLinkName.Text = list[0];
                tbLinkURL.Text = list[1];
                cbLinkStatus.Text = list[2];
                cbLinkLang.Text = list[3];
            }
            else
            {
                ClearTabLinks();
                TabLinksFields(false);
            }
        }

        private void FillTabReferences(string key)
        {
            List<string> list = new List<string>();
            list = Readers.GetTabReferences(key);
            if (list != null && list.Count > 0)
            {
                TabReferenceFields(true);

                tbRefSeq.Text = list[0];
                tbRefName.Text = list[1];
                tbRefURL.Text = list[2];
                cbRefStatus.Text = list[3];
            }
            else
            {
                ClearTabReferences();
                TabReferenceFields(false);
            }
        }

        private void FillTabQuotes(int section)
        {
            // This tab can has sections with no quotes, so disable empty fields
            // Enable if want to add

            List<string> list = new List<string>();
            list = Readers.GetTabQuotes(section);
            if (list != null && list.Count > 0)
            {
                TabQuoteFields(true);

                tbQuoteText.Text = list[0];
                tbQuoteAuthor.Text = list[1];
                cbQuoteStatus.Text = list[3];
                cbQuoteLang.Text = list[3];
            }
            else
            {
                ClearTabQuotes();
                TabQuoteFields(false);
            }
        }

        private void FillTabCode(int section)
        {
            // This tab can has sections with no code, so disable empty fields
            // Enable if want to add

            List<string> list = new List<string>();
            list = Readers.GetTabCode(section);
            if (list != null && list.Count > 0)
            {
                TabCodeFields(true);

                tbCode.Text = list[0];
                tbCodeSeq.Text = list[1];
                cbCodeStatus.Text = list[3];
                cbCodeLanguage.Text = list[3];
            }
            else
            {
                ClearTabCode();
                TabCodeFields(false);
            }
        }

        private void FillTabMetadata()
        {
            dgvMetadata.Rows.Clear();
            List<string[]> list = new List<string[]>();
            list = Readers.GetTabMetadata();
            if (list == null || list.Count == 0) return; 
            foreach (string[] sa in list)
            {
                dgvMetadata.Rows.Add(sa);
            }
        }

        private void FillTabCredits()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = "Versió " + version.Major + "." + version.Minor + " (build " + version.Build + ")";

            lblCreditsDesc.Text = "Manteniment de la base de dades dels blocs publicats a Diari Digital";
            lblCopyright.Text = "© " + DateTime.Today.Year +  " Xavier Peña";
        }

        // ---------------------------------------------------------------------------
        // Browser
        // ---------------------------------------------------------------------------

        private void OpenURL(string urlString)
        {
            // No action unless the user types in some sort of url
            if (string.IsNullOrEmpty(urlString))
            {
                return;
            }
            /*
            Uri url;

            var success = Uri.TryCreate(urlString, UriKind.RelativeOrAbsolute, out url);

            // Basic parsing was a success, now we need to perform additional checks
            if (success)
            {
                // Load absolute urls directly.
                // You may wish to validate the scheme is http/https
                // e.g. url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps
                if (url.IsAbsoluteUri)
                {
                    chromiumWebBrowser1.LoadUrl(urlString);

                    return;
                }

                // Relative Url
                // We'll do some additional checks to see if we can load the Url
                // or if we pass the url off to the search engine
                var hostNameType = Uri.CheckHostName(urlString);

                if (hostNameType == UriHostNameType.IPv4 || hostNameType == UriHostNameType.IPv6)
                {
                    chromiumWebBrowser1.LoadUrl(urlString);

                    return;
                }

                if (hostNameType == UriHostNameType.Dns)
                {
                    try
                    {
                        var hostEntry = Dns.GetHostEntry(urlString);
                        if (hostEntry.AddressList.Length > 0)
                        {
                            chromiumWebBrowser1.LoadUrl(urlString);

                            return;
                        }
                    }
                    catch (Exception)
                    {
                        // Failed to resolve the host
                        lblMessage.Text = "No es troba la pàgina web";
                    }
                }
            }
            */
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

            ClearDoneArray();
            LoadArticleSections();
        }

        private void btnArtDetails_Click(object sender, EventArgs e)
        {
            if (tbArticle.Text == string.Empty) return;
            FillTabHead();
            tabControl1.SelectedIndex = Tabs.HEADER;
        }

        private void btnChangeLang_Click(object sender, EventArgs e)
        {
            if (tbCA.Text == string.Empty) return;

            Singleton Gdata = Singleton.GetInstance();
            Gdata.Lang = Gdata.Lang == Language.CASTELLA ? Language.CATALA : Language.CASTELLA;
            ClearDoneArray();
            LoadArticlesGrid();
        }

        private void cbSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton Gdata = Singleton.GetInstance();
            cbOption op = cbSet.SelectedItem as cbOption;
            Gdata.db = DBConnect(op.entityValue);

            // Load blogs for new set
            LoadBlogs();

            /*
            loading = true;
            ClearHeaders();
            ClearAllBoxes();
            ClearDoneArray();
            LoadCombos();
            LoadArticlesGrid();
            loading = false;
            */
        }

        private void cbBlogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Restart all for a new blog
            Singleton Gdata = Singleton.GetInstance();
            Gdata.IDarticle = 0;
            cbOption op = cbBlogs.SelectedItem as cbOption;
            Gdata.currentBlog = Int32.Parse(op.entityValue);

            loading = true;
            ClearHeaders();
            ClearAllBoxes();
            ClearDoneArray();
            LoadCombos();
            LoadArticlesGrid();
            loading = false;

            lblDesc.Text = Readers.GetBlogDescription();

            // Go back to tab 0
            tabControl1.SelectedIndex = 0;
        }

        private void lbTextSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (lbTextSections.SelectedItem == null) return;

            // Load Text tab
            // get the selected section
            cbOption op = lbTextSections.SelectedItem as cbOption;
            FillTabTexts(Int32.Parse(op.entityValue));
        }

        private void lbImageSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Load Text tab
            // get the selected section
            cbOption op = lbImageSections.SelectedItem as cbOption;
            FillTabImages(Int32.Parse(op.entityValue));
        }

        private void lbLinkSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Load Text tab
            // get the selected section
            cbOption op = lbLinkSections.SelectedItem as cbOption;
            FillTabLinks(Int32.Parse(op.entityValue));
        }

        private void lbRefSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Load Text tab
            // get the selected section
            cbOption op = lbRefSections.SelectedItem as cbOption;
            FillTabReferences(op.entityValue);
        }
    }
}
