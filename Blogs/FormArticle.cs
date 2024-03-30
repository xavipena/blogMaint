using Blogs.Classes;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Blogs
{
    public partial class FormArticle : Form
    {
        Singleton Gdata = Singleton.GetInstance();

        // buffers to read and check changes
        List<string> listTabHead;
        List<string> listTabText;
        List<string> listTabImage;
        List<string> listTabLink;
        List<string> listTabRefs;
        List<string> listTabQuote;
        List<string> listTabCode;
        List<string> listTabVideo;
        List<string> listTabTip;

        bool[] done = new bool[Constants.NUM_TABS];
        bool[] NeedToSave = new bool[Constants.NUM_TABS];
        bool loading = false;

        public FormArticle()
        {
            InitializeComponent();
            SetUpForm();
            SetDefaultValues();
            DefineGrids();
            LoadCombos();
            SetButtonStatus();

        }

        private void SetUpForm()
        {
            tabControl1.Click += new EventHandler(tabControl_Click);

        }

        private void PrintMessage(string msg)
        {
            /*
            To allow a top-level form to share a control with a lower-level form:

            1.) In form designer, open the main form, select the control to be shared, and set its modifier 
                to "Internal".
            2.) When calling the lower-level form, supply "this" as the owner parameter of Show().

                LoginForm login = new LoginForm();
                login.Show(this);

            3.) From the lower-level form, you can now reference the Owner property and cast it back to its 
                class type to access the shared control by name.

                ((MainForm)Owner).PanelContainer.Visible = false;
             */

            if (this.Parent == null || this.Parent.GetType() != typeof(Form1))
                return;

            // Check if calling from a thread that is not main

            if (((Form1)Owner).lblMessage.InvokeRequired)
            {
                ((Form1)Owner).lblMessage.BeginInvoke((MethodInvoker)delegate ()
                {
                    ((Form1)Owner).lblMessage.Text = msg;
                });
            }
            else
            {
                ((Form1)Owner).lblMessage.Text = msg;
            }
        }

        /// <summary>
        /// Default form values for initialization
        /// </summary>
        private void SetDefaultValues()
        {
            tbES.Text = Language.CASTELLA;
            tbCA.Text = Language.CATALA;
            tbES.BackColor = Color.LightYellow;
            PrintMessage(Messages.READY);
            Gdata.maintMode = Modes.Status.EMPTY;
            loading = false;
        }

        /// <summary>
        /// Grid feinition
        /// </summary>
        private void DefineGrids()
        {
            dgvSelector.Rows.Clear();
            dgvSelector.ColumnCount = 4;
            dgvSelector.AllowUserToAddRows = false;
            dgvSelector.MultiSelect = false;

            dgvSelector.Columns[0].Name = "ID";
            dgvSelector.Columns[0].Width = 40;
            dgvSelector.Columns[1].Name = "Secció";
            dgvSelector.Columns[1].Width = 100;
            dgvSelector.Columns[2].Name = "Data";
            dgvSelector.Columns[2].Width = 100;
            dgvSelector.Columns[3].Name = "Títol";
            dgvSelector.Columns[3].Width = 400;


            dgvMetadata.Rows.Clear();
            dgvMetadata.ColumnCount = 5;
            dgvMetadata.AllowUserToAddRows = false;
            dgvMetadata.MultiSelect = false;

            dgvMetadata.Columns[0].Name = "ID";
            dgvMetadata.Columns[0].Width = 40;
            dgvMetadata.Columns[1].Name = "Pcol.";
            dgvMetadata.Columns[1].Width = 40;
            dgvMetadata.Columns[2].Name = "Propietat";
            dgvMetadata.Columns[2].Width = 80;
            dgvMetadata.Columns[3].Name = "Valor";
            dgvMetadata.Columns[3].Width = 250;
            dgvMetadata.Columns[4].Name = "Descripció";
            dgvMetadata.Columns[4].Width = 360;
        }

        private void LoadCombos()
        {
            if (!Gdata.db.IsConnected) return;

            Loaders.LoadComboBox(cbHeadType, "select distinct type, type from articles");
            PrintMessage(Gdata.ErrorText);
            Loaders.LoadComboBox(cbTipsIcon, "select concat(IDicon, ''), name from article_tip_types");
            PrintMessage(Gdata.ErrorText);

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

            Loaders.LoadCombo(cbTipsStatus, Combos.STATUS);
            Loaders.LoadCombo(cbTipsLang, Combos.LANGUAGE);
        }

        /// <summary>
        /// Load programming language codes
        /// </summary>
        private void LoadCodeLanguages()
        {
            cbCodeLanguage.DataSource = Readers.LoadLangTypes();
            cbCodeLanguage.DisplayMember = "entityName";
            cbCodeLanguage.ValueMember = "entityValue";
            cbCodeLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Load each list of article sections as selector for each tab 
        /// where article content is indexed by section
        /// </summary>
        private void LoadArticleSections()
        {
            Singleton Gdata = Singleton.GetInstance();
            if (Gdata.IDarticle == 0) return;
            loading = true;
            Cursor.Current = Cursors.WaitCursor;

            //Build a list
            var dataSource = new List<cbOption>();

            // load the list
            string sql = "select position, section from article_details " +
                         "where IDarticle = " + Gdata.IDarticle + " and lang = '" + Gdata.Lang + "'";

            dataSource = Readers.LoadList(sql, Gdata.db);
            if (dataSource != null)
            {
                // Setup data binding, same datasource for all

                lbTextSections.DataSource = dataSource;
                lbTextSections.DisplayMember = "entityName";
                lbTextSections.ValueMember = "entityValue";

                lbImageSections.DataSource = dataSource;
                lbImageSections.DisplayMember = "entityName";
                lbImageSections.ValueMember = "entityValue";

                cbOption op = dataSource[0];
                LoadImageSequences(Int32.Parse(op.entityValue.ToString()));

                lbLinkSections.DataSource = dataSource;
                lbLinkSections.DisplayMember = "entityName";
                lbLinkSections.ValueMember = "entityValue";

                lbQuoteSections.DataSource = dataSource;
                lbQuoteSections.DisplayMember = "entityName";
                lbQuoteSections.ValueMember = "entityValue";

                lbCodeSections.DataSource = dataSource;
                lbCodeSections.DisplayMember = "entityName";
                lbCodeSections.ValueMember = "entityValue";

                LoadCodeSequences(Int32.Parse(op.entityValue.ToString()));

                lbTipsSections.DataSource = dataSource;
                lbTipsSections.DisplayMember = "entityName";
                lbTipsSections.ValueMember = "entityValue";

            }
            // References, get list
            dataSource = Readers.LoadRefList();
            lbRefSections.DataSource = dataSource;
            lbRefSections.DisplayMember = "entityName";
            lbRefSections.ValueMember = "entityValue";

            loading = false;
            Cursor.Current = Cursors.Default;
        }

        private void LoadImageSequences(int section)
        {
            string sql = "select sequence, concat(section,'-',sequence) from article_images " +
                         "where IDarticle = " + Gdata.IDarticle + " and section = '" + section + "' and lang = '" + Gdata.Lang + "'";
            var dataSource = Readers.LoadList(sql, Gdata.db);
            lbImageSeqs.DataSource = dataSource;
            lbImageSeqs.DisplayMember = "entityName";
            lbImageSeqs.ValueMember = "entityValue";
        }

        private void LoadCodeSequences(int section)
        {
            string sql = "select sequence, concat(section,'-',sequence) from article_code " +
                         "where IDarticle = " + Gdata.IDarticle + " and section = '" + section + "'";
            var dataSource = Readers.LoadList(sql, Gdata.db);
            lbCodeSeqs.DataSource = dataSource;
            lbCodeSeqs.DisplayMember = "entityName";
            lbCodeSeqs.ValueMember = "entityValue";
        }

        // ---------------------------------------------------------------------------
        // Load data
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Load articles list
        /// </summary>
        private void LoadArticles()
        {
            Gdata.db.DBOpen();

            string sql = "select IDarticle, title, readTime, wordCount, type, date " +
                         "from articles where IDblog = " + Gdata.currentBlog + " and lang = '" + Gdata.Lang + "' " +
                         "order by date desc";
            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] selRow = new string[]
                {
                    reader.GetInt32(0).ToString(),
                    reader.GetString(4),
                    reader.GetDateTime(5).ToString().Substring(0,10),
                    reader.GetString(1)
                };
                dgvSelector.Rows.Add(selRow);
            }

            Gdata.db.DBClose();
        }

        /// <summary>
        /// Load article list into grid
        /// </summary>
        private void LoadArticlesGrid()
        {
            dgvSelector.Rows.Clear();
            dgvSelector.Sort(dgvSelector.Columns[0], ListSortDirection.Descending);

            LoadArticles();
            lblRowCount.Text = dgvSelector.Rows.Count + " files";
            SetButtonStatus();
        }

        // ---------------------------------------------------------------------------
        // Update butons status
        // ---------------------------------------------------------------------------

        private void SetButtonStatus()
        {
            if (Gdata.IDarticle == 0)
            {
                // No article loaded
                AllButtonsDisabled(true);
            }
            else
            {
                AllButtonsDisabled(false);
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
            bool NeedSave = false;
            for (int i = 0; i < Constants.NUM_TABS; i++) NeedSave = NeedSave || NeedToSave[i];
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

        private void ClearDoneArray()
        {
            for (int i = 0; i < tabControl1.Controls.Count; i++)
            {
                done[i] = false;
            }
        }

        private void AllButtonsDisabled(bool status)
        {
            DisableButtonsInTab(tabControl1.TabPages[Tabs.HEADER], status);
            DisableButtonsInTab(tabControl1.TabPages[Tabs.SECTIONS], status);
            DisableButtonsInTab(tabControl1.TabPages[Tabs.IMAGES], status);
            DisableButtonsInTab(tabControl1.TabPages[Tabs.LINKS], status);
            DisableButtonsInTab(tabControl1.TabPages[Tabs.REFERENCE], status);
            DisableButtonsInTab(tabControl1.TabPages[Tabs.QUOTES], status);
            DisableButtonsInTab(tabControl1.TabPages[Tabs.CODE], status);
        }

        // ---------------------------------------------------------------------------
        // Change tab
        // ---------------------------------------------------------------------------

        private void tabControl_Click(object sender, EventArgs e)
        {
            PrintMessage(string.Empty);
            if (Gdata.IDarticle == 0 && tabControl1.SelectedIndex < 9)
            {
                PrintMessage("Selecciona un article per mostrar els detalls");
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
                        if (tbImageName.Text == string.Empty)
                        {
                            cbOption op = lbImageSections.SelectedItem as cbOption;
                            if (op != null)
                            {
                                FillTabImages(Int32.Parse(op.entityValue), 0);
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
                                FillTabCode(Int32.Parse(op.entityValue), 0);
                            }
                        }
                        break;

                    case Tabs.VIDEO:

                        FillTabVideo(0);
                        break;

                    case Tabs.TIPS:
                        if (lbTipsSections.Items.Count > 0)
                        {
                            cbOption op = lbTipsSections.SelectedItem as cbOption;
                            if (op != null)
                            {
                                FillTabTips(Int32.Parse(op.entityValue));
                            }
                        }
                        break;
                }
                done[tabControl1.SelectedIndex] = true;
            }
        }

        // ---------------------------------------------------------------------------
        // Fill tabs
        // ---------------------------------------------------------------------------

        #region fillTabls

        private void FillTabHead()
        {
            if (NeedToSave[Tabs.HEADER])
            {
                MessageBox.Show("Hi ha canvis sense desar.");
                return;
            }
            listTabHead = Readers.GetTabHeader();
            if (listTabHead != null && listTabHead.Count > 0)
            {
                cbHeadType.Text = listTabHead[0];
                dtpHeadDate.Text = listTabHead[1];
                dtpHeadPub.Text = listTabHead[2];
                dtpHeadUpdate.Text = listTabHead[3];
                tbHeadExcerpt.Text = listTabHead[5];
                cbHeadStatus.Text = listTabHead[6];
                cbHeadAuthor.Text = listTabHead[7];
                cbHeadLang.Text = listTabHead[8];
                tbHeadNext.Text = listTabHead[9];
                tbHeadPrev.Text = listTabHead[10];
                tbHeadTime.Text = listTabHead[11];
                tbHeadWords.Text = listTabHead[12];

                tbHeadTitle.Text = Gdata.Lang == Language.CASTELLA ? tbTitle.Text : tbTitleCA.Text;
            }
        }

        private void FillTabTexts(int section)
        {
            if (NeedToSave[Tabs.SECTIONS])
            {
                MessageBox.Show("Hi ha canvis sense desar.");
                return;
            }
            listTabText = Readers.GetTabTexts(section);
            if (listTabText != null && listTabText.Count > 0)
            {
                tbTextSection.Text = listTabText[0];
                tbTextPos.Text = listTabText[1];
                cbTextType.Text = listTabText[2];
                tbTextDetail.Text = listTabText[3];
                cbTextStatus.Text = listTabText[4];
                cbTextLang.Text = listTabText[5];
            }
        }

        private void FillTabImages(int section, int sequence)
        {
            // This tab can has sections with no images, so disable empty fields
            // Enable if want to add

            // The very firt time, disable the layout
            if (sequence == 0)
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.IMAGES], Actions.CLEAR);
                ListControlsInTab(tabControl1.TabPages[Tabs.IMAGES], Actions.DISABLE);
                pbImage.Image = null;
            }

            List<string> list = new List<string>();
            list = Readers.GetTabImages(section, sequence);
            if (list != null && list.Count > 0)
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.IMAGES], Actions.ENABLE);

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
                if (sequence > 0)
                {
                    // Do not clear again if aready done
                    ListControlsInTab(tabControl1.TabPages[Tabs.IMAGES], Actions.CLEAR);
                    ListControlsInTab(tabControl1.TabPages[Tabs.IMAGES], Actions.DISABLE);
                    pbImage.Image = null;
                }
            }
        }

        private void FillTabLinks(int section)
        {
            // This tab can has sections with no images, so disable empty fields
            // Enable if want to add

            listTabLink = Readers.GetTabLinks(section);
            if (listTabLink != null && listTabLink.Count > 0)
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.LINKS], Actions.ENABLE);

                tbLinkName.Text = listTabLink[0];
                tbLinkURL.Text = listTabLink[1];
                cbLinkStatus.Text = listTabLink[2];
                cbLinkLang.Text = listTabLink[3];
            }
            else
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.LINKS], Actions.CLEAR);
                ListControlsInTab(tabControl1.TabPages[Tabs.LINKS], Actions.DISABLE);
            }
        }

        private void FillTabReferences(string key)
        {
            listTabRefs = Readers.GetTabReferences(key);
            if (listTabRefs != null && listTabRefs.Count > 0)
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.REFERENCE], Actions.ENABLE);

                tbRefSeq.Text = listTabRefs[0];
                tbRefName.Text = listTabRefs[1];
                tbRefURL.Text = listTabRefs[2];
                cbRefStatus.Text = listTabRefs[3];
            }
            else
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.REFERENCE], Actions.CLEAR);
                ListControlsInTab(tabControl1.TabPages[Tabs.REFERENCE], Actions.DISABLE);
            }
        }

        private void FillTabQuotes(int section)
        {
            // This tab can has sections with no quotes, so disable empty fields
            // Enable if want to add

            listTabQuote = Readers.GetTabQuotes(section);
            if (listTabQuote != null && listTabQuote.Count > 0)
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.QUOTES], Actions.ENABLE);

                tbQuoteText.Text = listTabQuote[1];
                cbQuoteStatus.Text = listTabQuote[2];
                cbQuoteLang.Text = listTabQuote[3];
                tbQuoteAuthor.Text = listTabQuote[4];
            }
            else
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.QUOTES], Actions.CLEAR);
                ListControlsInTab(tabControl1.TabPages[Tabs.QUOTES], Actions.DISABLE);
            }
        }

        private void FillTabCode(int section, int sequence)
        {
            // This tab can has sections with no code, so disable empty fields
            // Enable if want to add

            // The very firt time, disable the layout
            if (sequence == 0) ListControlsInTab(tabControl1.TabPages[Tabs.CODE], Actions.CLEAR);

            listTabCode = Readers.GetTabCode(section, sequence);
            if (listTabCode != null && listTabCode.Count > 0)
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.CODE], Actions.ENABLE);

                tbCodeSeq.Text = listTabCode[0];
                cbCodeLanguage.Text = listTabCode[1];
                tbCode.Text = listTabCode[2];
                cbCodeStatus.Text = listTabCode[3];
            }
            else
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.CODE], Actions.CLEAR);
                ListControlsInTab(tabControl1.TabPages[Tabs.CODE], Actions.DISABLE);
            }
        }

        private void FillTabVideo(int section)
        {
            listTabVideo = Readers.GetTabVideo(section);
            if (listTabVideo != null && listTabVideo.Count > 0)
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.VIDEO], Actions.ENABLE);

                //  url, embed, caption, alternate, credit, status, lang

                tbVideoName.Text = listTabVideo[0];
                tbVideoEmbed.Text = listTabVideo[1];
                tbVideoCaption.Text = listTabVideo[2];
                tbVideoAlt.Text = listTabVideo[3];
                tbVideoCredit.Text = listTabVideo[4];
                cbVideoStatus.Text = listTabVideo[5];
                cbVideoLang.Text = listTabVideo[6];
            }
            else
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.VIDEO], Actions.CLEAR);
                ListControlsInTab(tabControl1.TabPages[Tabs.VIDEO], Actions.DISABLE);
            }
        }

        private void FillTabTips(int section)
        {
            listTabTip = Readers.GetTabTip(section);
            if (listTabTip != null && listTabTip.Count > 0)
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.TIPS], Actions.ENABLE);
                EnableDisableButtons(Tabs.TIPS, true);

                tbTipsText.Text = listTabTip[0];
                cbTipsIcon.Text = listTabTip[1];
                cbTipsStatus.Text = listTabTip[2];
                cbTipsLang.Text = listTabTip[3];
            }
            else
            {
                ListControlsInTab(tabControl1.TabPages[Tabs.TIPS], Actions.CLEAR);
                ListControlsInTab(tabControl1.TabPages[Tabs.TIPS], Actions.DISABLE);
                EnableDisableButtons(Tabs.TIPS, false);
            }
        }

        #endregion

        private void EnableDisableButtons(int tab, bool enable)
        {
            switch (tab)
            {
                case Tabs.TIPS:
                    btnTipsSave.Enabled = enable;
                    break;
            }
        }

        // ---------------------------------------------------------------------------
        // Clear and disable/enable tabs
        // ---------------------------------------------------------------------------

        private void ClearAllBoxes()
        {
            ClearSections();
            ListControlsInTab(tabControl1.TabPages[Tabs.SECTIONS], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.IMAGES], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.LINKS], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.REFERENCE], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.QUOTES], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.CODE], Actions.CLEAR);
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
        }

        private void ClearGrids()
        {
            dgvSelector.Rows.Clear();
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
            imageRequested = tokens.Last();

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
                    url = Gdata.url + "/images/" + imageRequested;
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
                string url = Gdata.url + "/images/" + image;
                PrintMessage("Baixant...");
                byte[] data = await client.GetByteArrayAsync(url);
                PrintMessage("Gravant...");
                File.WriteAllBytes(Paths.DOWNLOAD + image, data);
                PrintMessage("Fet");
                ShowImage(image);
            }
            catch (Exception ex)
            {
                Gdata.ErrorText = ex.Message;
                PrinteMessage(ex.Message);
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
                PrintMessage("Imatge massa gran");
                //throw; throw newOutOfMemoryException("Imatge massa gran: " + image, e);
            }
            // Access main thread
            if (pbImage.InvokeRequired)
            {
                pbImage.BeginInvoke((MethodInvoker)delegate ()
                {

                    pbImage.Image = DownloadedImage;
                });
            }
            else
            {
                pbImage.Image = DownloadedImage;
            }
        }
        #endregion

        private void FillTabMetadata()
        {
            Cursor.Current = Cursors.WaitCursor;

            dgvMetadata.Rows.Clear();
            List<string[]> list = new List<string[]>();
            list = Readers.GetTabMetadata();
            if (list == null || list.Count == 0)
            {
                list = Readers.GetCleanMetadata();
                if (list == null || list.Count == 0) return;
            };
            foreach (string[] sa in list)
            {
                dgvMetadata.Rows.Add(sa);
            }
            Cursor.Current = Cursors.Default;
        }

        // ---------------------------------------------------------------------------
        // list the controls in a Control (tab) and apply action
        // ---------------------------------------------------------------------------

        private void ListControlsInTab(Control f, int action)
        {
            List<string> cList = new List<string>();
            foreach (Control c in f.Controls)
            {
                if (c.HasChildren)
                {
                    ListControlsInTab(c, action);
                }
                else
                {
                    if (c is TextBox)
                    {
                        TextBox tb = (TextBox)c;
                        switch (action)
                        {
                            case Actions.LIST:
                                cList.Add(tb.Name);
                                break;
                            case Actions.CLEAR:
                                tb.Text = string.Empty;
                                break;
                            case Actions.ENABLE:
                                tb.Enabled = true;
                                break;
                            case Actions.DISABLE:
                                tb.Enabled = false;
                                break;
                        }
                    }
                    if (c is ComboBox)
                    {
                        ComboBox cb = (ComboBox)c;
                        switch (action)
                        {
                            case Actions.LIST:
                                cList.Add(cb.Name);
                                break;
                            case Actions.ENABLE:
                                cb.Enabled = true;
                                break;
                            case Actions.DISABLE:
                                cb.Enabled = false;
                                break;
                        }
                    }
                    if (c is DateTimePicker)
                    {
                        DateTimePicker dt = (DateTimePicker)c;
                        switch (action)
                        {
                            case Actions.LIST:
                                cList.Add(dt.Name);
                                break;
                            case Actions.CLEAR:
                                dt.Value = DateTime.Today;
                                break;
                            case Actions.ENABLE:
                                dt.Enabled = true;
                                break;
                            case Actions.DISABLE:
                                dt.Enabled = false;
                                break;
                        }
                    }
                }
            }
        }

        private void DisableButtonsInTab(Control f, bool status)
        {
            bool enable = !status;
            foreach (Control c in f.Controls)
            {
                if (c.HasChildren)
                {
                    DisableButtonsInTab(c, status);
                }
                else
                {
                    if (c is Button)
                    {
                        c.Enabled = enable;
                    }
                }
            }
        }

        // ---------------------------------------------------------------------------
        // Selected indexes for sections
        // ---------------------------------------------------------------------------

        private void lbTextSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (lbTextSections.SelectedItem == null) return;

            // Load Text tab
            // get the selected section
            cbOption op = lbTextSections.SelectedItem as cbOption;
            if (op != null)
            {
                FillTabTexts(Int32.Parse(op.entityValue));
            }
        }

        private void lbImageSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (lbImageSections.SelectedItem == null) return;

            // Load Text tab
            // get the selected section

            cbOption op = lbImageSections.SelectedItem as cbOption;
            if (op != null)
            {
                LoadImageSequences(Int32.Parse(op.entityValue));
                FillTabImages(Int32.Parse(op.entityValue), 0);
            }
        }

        private void lbLinkSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Load Text tab
            // get the selected section
            cbOption op = lbLinkSections.SelectedItem as cbOption;
            if (op != null)
            {
                FillTabLinks(Int32.Parse(op.entityValue));
            }
        }

        private void lbRefSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Load Text tab
            // get the selected section
            cbOption op = lbRefSections.SelectedItem as cbOption;
            if (op != null)
            {
                FillTabReferences(op.entityValue);
            }
        }

        private void lbCodeSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOption op = lbCodeSections.SelectedItem as cbOption;
            if (op != null)
            {
                LoadCodeSequences(Int32.Parse(op.entityValue));
                FillTabCode(Int32.Parse(op.entityValue), 0);
            }
        }

        private void lbTipsSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOption op = lbTipsSections.SelectedItem as cbOption;
            if (op != null)
            {
                FillTabTips(Int32.Parse(op.entityValue));
            }
        }

        // ---------------------------------------------------------------------------
        // Selected indexes for sequences
        // ---------------------------------------------------------------------------

        private void lbImageSeqs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Load Text tab
            // get the selected section and sequence
            cbOption op = lbImageSections.SelectedItem as cbOption;
            int section = Int32.Parse(op.entityValue);
            op = lbImageSeqs.SelectedItem as cbOption;
            int sequence = Int32.Parse(op.entityValue);
            FillTabImages(section, sequence);
        }

        private void lbCodeSeqs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            // Load Text tab
            // get the selected section and sequence
            cbOption op = lbCodeSections.SelectedItem as cbOption;
            int section = Int32.Parse(op.entityValue);
            op = lbCodeSeqs.SelectedItem as cbOption;
            int sequence = Int32.Parse(op.entityValue);
            FillTabCode(section, sequence);
        }

        // ---------------------------------------------------------------------------
        // Save tabs
        // ---------------------------------------------------------------------------

        private void btnHeadSave_Click(object sender, EventArgs e)
        {
            if (AnyMissingFieldIn(Tabs.HEADER))
            {
                return;
            }
            if (Gdata.maintMode != Modes.Status.INSERT)
            {
                UpdateTheTab(Tabs.HEADER);
            }
            else
            {
                SaveHeadChanges();
            }
        }
        private void btnTextSave_Click(object sender, EventArgs e)
        {
            if (AnyMissingFieldIn(Tabs.SECTIONS))
            {
                return;
            }
            if (Gdata.maintMode != Modes.Status.INSERT)
            {
                UpdateTheTab(Tabs.SECTIONS);
            }
            else
            {
                SaveTextChanges();
            }
        }

        private void btnImageSave_Click(object sender, EventArgs e)
        {
            UpdateTheTab(Tabs.IMAGES);
        }

        private void btnLinkSave_Click(object sender, EventArgs e)
        {
            UpdateTheTab(Tabs.LINKS);
        }

        private void btnRefSave_Click(object sender, EventArgs e)
        {
            UpdateTheTab(Tabs.REFERENCE);
        }

        private void btnQuoteSave_Click(object sender, EventArgs e)
        {
            UpdateTheTab(Tabs.QUOTES);
        }

        private void btnCodeSave_Click(object sender, EventArgs e)
        {
            UpdateTheTab(Tabs.CODE);
        }

        private void btnVideoSave_Click(object sender, EventArgs e)
        {
            UpdateTheTab(Tabs.VIDEO);
        }

        private void btnTipsSave_Click(object sender, EventArgs e)
        {
            UpdateTheTab(Tabs.TIPS);
        }

        // ---------------------------------------------------------------------------
        // Deal with changes
        // ---------------------------------------------------------------------------

        private bool AnyChangeInHead()
        {
            if (listTabHead == null || listTabHead.Count == 0) return false;
            bool changes = false;

            changes = changes || cbHeadType.Text != listTabHead[0];

            changes = changes || dtpHeadDate.Value.ToString("dd/MM/yyyy") != listTabHead[1].Substring(0, 10);
            changes = changes || dtpHeadPub.Value.ToString("dd/MM/yyyy") != listTabHead[2].Substring(0, 10);
            changes = changes || dtpHeadUpdate.Value.ToString("dd/MM/yyyy") != listTabHead[3].Substring(0, 10);

            changes = changes || tbHeadTitle.Text != listTabHead[4];
            changes = changes || tbHeadExcerpt.Text != listTabHead[5];

            changes = changes || cbHeadStatus.SelectedValue.ToString() != listTabHead[6];
            changes = changes || cbHeadAuthor.SelectedValue.ToString() != listTabHead[7];
            changes = changes || cbHeadLang.SelectedValue.ToString() != listTabHead[8];

            changes = changes || tbHeadNext.Text != listTabHead[9];
            changes = changes || tbHeadPrev.Text != listTabHead[10];
            changes = changes || tbHeadTime.Text != listTabHead[11];
            changes = changes || tbHeadWords.Text != listTabHead[12];

            return changes;
        }

        private void SaveHeadChanges()
        {
            string[] val = { "", "", "", "" };
            cbOption op = cbHeadType.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbHeadStatus.SelectedItem as cbOption;
            val[1] = op.entityValue;
            op = cbHeadAuthor.SelectedItem as cbOption;
            val[2] = op.entityValue;
            op = cbHeadLang.SelectedItem as cbOption;
            val[3] = op.entityValue;

            List<string> list = new List<string>();

            list.Add(val[0]);
            list.Add(dtpHeadDate.Value.ToString("yyyy/MM/dd"));
            list.Add(dtpHeadPub.Value.ToString("yyyy/MM/dd"));
            list.Add(dtpHeadUpdate.Value.ToString("yyyy/MM/dd"));
            list.Add(tbHeadTitle.Text);
            list.Add(tbHeadExcerpt.Text);
            list.Add(val[1]);
            list.Add(val[2]);
            list.Add(val[3]);
            list.Add(tbHeadNext.Text);
            list.Add(tbHeadPrev.Text);
            list.Add(tbHeadTime.Text.Replace(',', '.'));
            list.Add(tbHeadWords.Text);

            if (Writers.UpdateHeader(list))
            {
                NeedToSave[Tabs.HEADER] = false;
                FillTabHead();
            }
        }

        private bool AnyChangeInText()
        {
            if (listTabText == null || listTabText.Count == 0) return false;
            bool changes = false;

            // section, position, type, text, status, lang

            changes = changes || tbTextSection.Text != listTabText[0];
            changes = changes || tbTextPos.Text != listTabText[1];
            changes = changes || tbTextDetail.Text != listTabText[3];

            changes = changes || cbTextLang.SelectedValue.ToString() != listTabText[5];
            changes = changes || cbTextStatus.SelectedValue.ToString() != listTabText[4];
            changes = changes || cbTextType.SelectedValue.ToString() != listTabText[2];

            return changes;
        }

        private void SaveTextChanges()
        {
            string[] val = { "", "", "" };
            cbOption op = cbTextType.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbTextStatus.SelectedItem as cbOption;
            val[1] = op.entityValue;
            op = cbTextLang.SelectedItem as cbOption;
            val[2] = op.entityValue;

            List<string> list = new List<string>();

            list.Add(tbTextPos.Text);
            list.Add(tbTextSection.Text);
            list.Add(val[0]);
            list.Add(tbTextDetail.Text);
            list.Add(val[1]);
            list.Add(val[2]);

            if (Writers.UpdateText(list))
            {
                NeedToSave[Tabs.SECTIONS] = false;
                FillTabTexts(Int32.Parse(tbTextPos.Text));
            }
        }

        private bool AnyChangeInImage()
        {
            if (listTabImage == null || listTabImage.Count == 0) return false;
            bool changes = false;

            // sequence, image, caption, captionLong, alternate, credit, status, lang

            changes = changes || tbImageSeq.Text != listTabImage[0];
            changes = changes || tbImageName.Text != listTabImage[1];
            changes = changes || tbImageCaption.Text != listTabImage[2];
            changes = changes || tbImageLCaption.Text != listTabImage[3];
            changes = changes || tbImageAlternate.Text != listTabImage[4];
            changes = changes || tbImageCredit.Text != listTabImage[5];

            changes = changes || cbImageStatus.SelectedValue.ToString() != listTabImage[6];
            changes = changes || cbImageLang.SelectedValue.ToString() != listTabImage[7];

            return changes;
        }

        private void SaveImageChanges()
        {
            string[] val = { "", "" };
            cbOption op = cbImageStatus.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbImageLang.SelectedItem as cbOption;
            val[1] = op.entityValue;

            string sql = "update article_images set " +
                         " image        = '" + tbImageName.Text + "'" +
                         ",caption      = '" + tbImageCaption.Text + "'" +
                         ",captionLong  = '" + tbImageLCaption.Text + "'" +
                         ",alternate    = '" + tbImageAlternate.Text + "'" +
                         ",credit       = '" + tbImageCredit.Text + "'" +
                         ",status       = '" + val[0] + "'" +
                         ",lang         = '" + val[1] + "'" +
                         " where IDarticle = @par1 and section = @par2 and sequence = @par3";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            op = lbImageSections.SelectedItem as cbOption;
            cmd.Parameters.AddWithValue("@par2", op.entityValue);
            cmd.Parameters.AddWithValue("@par2", tbImageSeq.Text);

            if (Writers.RunUpdate(cmd))
            {
                NeedToSave[Tabs.IMAGES] = false;
                FillTabImages(Int32.Parse(op.entityValue), Int32.Parse(tbImageSeq.Text));
            }
        }

        private bool AnyChangeInLink()
        {
            if (listTabLink == null || listTabLink.Count == 0) return false;
            bool changes = false;

            // name, url, status, lang

            changes = changes || tbLinkName.Text != listTabLink[0];
            changes = changes || tbLinkURL.Text != listTabLink[1];

            changes = changes || cbLinkStatus.SelectedValue.ToString() != listTabLink[2];
            changes = changes || cbLinkLang.SelectedValue.ToString() != listTabLink[3];

            return changes;
        }

        private void SaveLinkChanges()
        {
            string[] val = { "", "" };
            cbOption op = cbLinkStatus.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbLinkLang.SelectedItem as cbOption;
            val[1] = op.entityValue;

            string sql = "update article_links set " +
                         " name         = '" + tbLinkName.Text + "'" +
                         ",url          = '" + tbLinkURL.Text + "'" +
                         ",status       = '" + val[0] + "'" +
                         ",lang         = '" + val[1] + "'" +
                         " where IDarticle = @par1 and section = @par2";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            op = lbLinkSections.SelectedItem as cbOption;
            cmd.Parameters.AddWithValue("@par2", op.entityValue);

            if (Writers.RunUpdate(cmd))
            {
                NeedToSave[Tabs.LINKS] = false;
                FillTabLinks(Int32.Parse(op.entityValue));
            }
        }

        private bool AnyChangeInRefs()
        {
            if (listTabRefs == null || listTabRefs.Count == 0) return false;
            bool changes = false;

            // sequence, name, url, status

            changes = changes || tbRefSeq.Text != listTabRefs[0];
            changes = changes || tbRefName.Text != listTabRefs[1];
            changes = changes || tbRefURL.Text != listTabRefs[2];

            changes = changes || cbRefStatus.SelectedValue.ToString() != listTabRefs[3];

            return changes;
        }

        private void SaveRefsChanges()
        {
            string[] val = { "" };
            cbOption op = cbLinkStatus.SelectedItem as cbOption;
            val[0] = op.entityValue;

            string sql = "update article_related set " +
                         " name         = '" + tbRefName.Text + "'" +
                         ",url          = '" + tbRefURL.Text + "'" +
                         ",status       = '" + val[0] + "'" +
                         " where IDarticle = @par1 and section = @par2 and sequence = @par3";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            op = lbRefSections.SelectedItem as cbOption;
            string[] tokens = op.entityValue.Split('-');
            cmd.Parameters.AddWithValue("@par2", tokens[0]);
            cmd.Parameters.AddWithValue("@par3", tokens[1]);

            if (Writers.RunUpdate(cmd))
            {
                NeedToSave[Tabs.REFERENCE] = false;
                string key = tokens[0] + "-" + tokens[1];
                FillTabReferences(key);
            }
        }

        private bool AnyChangeInQuote()
        {
            if (listTabQuote == null || listTabQuote.Count == 0) return false;
            bool changes = false;

            // embed, status, lang, author

            changes = changes || tbQuoteText.Text != listTabQuote[0];
            changes = changes || tbQuoteAuthor.Text != listTabQuote[4];

            changes = changes || cbQuoteStatus.SelectedValue.ToString() != listTabQuote[2];
            changes = changes || cbQuoteLang.SelectedValue.ToString() != listTabQuote[3];

            return changes;
        }

        private void SaveQuoteChanges()
        {
            string[] val = { "", "" };
            cbOption op = cbQuoteStatus.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbQuoteLang.SelectedItem as cbOption;
            val[1] = op.entityValue;

            string sql = "update article_quotes set " +
                         " embed      = '" + tbQuoteText.Text + "'" +
                         ",author     = '" + tbQuoteAuthor.Text + "'" +
                         ",status     = '" + val[0] + "'" +
                         ",lang       = '" + val[1] + "'" +
                         " where IDarticle = @par1 and section = @par2";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            op = lbQuoteSections.SelectedItem as cbOption;
            cmd.Parameters.AddWithValue("@par2", op.entityValue);

            if (Writers.RunUpdate(cmd))
            {
                NeedToSave[Tabs.QUOTES] = false;
                FillTabQuotes(Int32.Parse(op.entityValue));
            }
        }

        private bool AnyChangeInCode()
        {
            if (listTabCode == null) return false;
            bool changes = false;

            // sequence, os, code, status

            changes = changes || tbCode.Text != listTabCode[2];

            changes = changes || cbCodeLanguage.SelectedValue.ToString() != listTabCode[1];
            changes = changes || cbCodeStatus.SelectedValue.ToString() != listTabCode[3];

            return changes;
        }

        private bool AnyChangeInVideo()
        {
            if (listTabVideo == null) return false;
            bool changes = false;

            // url, embed, caption, alternate, credit, status, lang

            changes = changes || tbVideoName.Text != listTabVideo[0];
            changes = changes || tbVideoEmbed.Text != listTabVideo[1];
            changes = changes || tbVideoCaption.Text != listTabVideo[2];
            changes = changes || tbVideoAlt.Text != listTabVideo[3];
            changes = changes || tbVideoCredit.Text != listTabVideo[4];

            changes = changes || cbVideoStatus.SelectedValue.ToString() != listTabVideo[5];
            changes = changes || cbVideoLang.SelectedValue.ToString() != listTabVideo[6];

            return changes;
        }

        private bool AnyChangeInTip()
        {
            if (listTabTip == null) return false;
            bool changes = false;

            // tipText, IDicon, status, lang

            changes = changes || tbTipsText.Text != listTabTip[0];

            changes = changes || cbTipsIcon.SelectedValue.ToString() != listTabTip[1];
            changes = changes || cbTipsStatus.SelectedValue.ToString() != listTabTip[3];
            changes = changes || cbTipsLang.SelectedValue.ToString() != listTabTip[3];

            return changes;
        }

        private void SaveCodeChanges()
        {
            string[] val = { "", "" };
            cbOption op = cbCodeLanguage.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbCodeStatus.SelectedItem as cbOption;
            val[1] = op.entityValue;

            string sql = "update article_code set " +
                         " os       = '" + val[0] + "'" +
                         ",code     = '" + tbCode.Text + "'" +
                         ",status   = '" + val[1] + "'" +
                         " where IDarticle = @par1 and section = @par2 and sequence = @par3";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            op = lbCodeSections.SelectedItem as cbOption;
            cmd.Parameters.AddWithValue("@par2", op.entityValue);
            op = lbCodeSeqs.SelectedItem as cbOption;
            cmd.Parameters.AddWithValue("@par3", op.entityValue);

            if (Writers.RunUpdate(cmd))
            {
                NeedToSave[Tabs.CODE] = false;
                op = lbCodeSections.SelectedItem as cbOption;
                int section = Int32.Parse(op.entityValue);
                op = lbCodeSeqs.SelectedItem as cbOption;
                int sequence = Int32.Parse(op.entityValue);
                FillTabCode(section, sequence);
            }
        }

        private void SaveVideoChanges()
        {
            string[] val = { "", "" };
            cbOption op = cbCodeLanguage.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbCodeStatus.SelectedItem as cbOption;
            val[1] = op.entityValue;

            string sql = "update article_video set " +
                         " url        = '" + tbVideoName.Text + "'" +
                         ",embed      = '" + tbVideoEmbed.Text + "'" +
                         ",caption    = '" + tbVideoCaption.Text + "'" +
                         ",alternate  = '" + tbVideoAlt.Text + "'" +
                         ",credit     = '" + tbVideoCredit.Text + "'" +
                         ",lang       = '" + val[0] + "'" +
                         ",status     = '" + val[1] + "'" +
                         " where IDarticle = @par1 and section = @par2 and sequence = @par3";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            cmd.Parameters.AddWithValue("@par2", tbVideoSection.Text);
            cmd.Parameters.AddWithValue("@par3", tbVideoSeq.Text);

            if (Writers.RunUpdate(cmd))
            {
                NeedToSave[Tabs.VIDEO] = false;
                int section = Int32.Parse(tbVideoSection.Text);
                int sequence = Int32.Parse(tbVideoSeq.Text);
                FillTabVideo(section);
            }
        }

        private void SaveTipChanges()
        {
            string[] val = { "", "", "" };
            cbOption op = cbTipsIcon.SelectedItem as cbOption;
            val[0] = op.entityValue;
            op = cbCodeLanguage.SelectedItem as cbOption;
            val[1] = op.entityValue;
            op = cbCodeStatus.SelectedItem as cbOption;
            val[2] = op.entityValue;

            string sql = "update article_tips set " +
                         " tipText    = '" + tbVideoName.Text + "'" +
                         ",IDicon     =  " + val[0] +
                         ",lang       = '" + val[1] + "'" +
                         ",status     = '" + val[2] + "'" +
                         " where IDarticle = @par1 and section = @par2";

            var cmd = new MySqlCommand(sql, Gdata.db.Connection);
            cmd.Parameters.AddWithValue("@par1", Gdata.IDarticle);
            op = lbTipsSections.SelectedItem as cbOption;
            int section = Int32.Parse(op.entityValue.ToString());
            cmd.Parameters.AddWithValue("@par2", op.entityValue.ToString());

            if (Writers.RunUpdate(cmd))
            {
                NeedToSave[Tabs.TIPS] = false;
                FillTabTips(section);
            }
        }

        // ---------------------------------------------------------------------------
        // Add new records from tabs
        // ---------------------------------------------------------------------------

        private void btnNewArticle_Click(object sender, EventArgs e)
        {
            if (ForgotToSave()) return;

            if (Gdata.maintMode != Modes.Status.QUERY)
            {
                PrintMessage("Hi ha canvis pendents");
                return;
            }

            if (GetNewNumber())
            {
                SetMode(Modes.Status.INSERT);
                // Clear all tabls
                loading = true;
                Cursor.Current = Cursors.WaitCursor;
                ClearHeaders();
                ClearDoneArray();
                loading = false;
                tabControl1.SelectedIndex = Tabs.HEADER;
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnNewText_Click(object sender, EventArgs e)
        {
            PrintMessage("En procès");
            if (Gdata.maintMode != Modes.Status.QUERY)
            {
                PrintMessage("Hi ha canvis pendents");
                return;
            }

            ListControlsInTab(tabControl1.TabPages[Tabs.SECTIONS], Actions.CLEAR);
            tbTextPos.Text = Readers.GetNextTextSection().ToString();
            lbTextSections.Enabled = false;
            SetMode(Modes.Status.INSERT);
        }

        private void btnNewImage_Click(object sender, EventArgs e)
        {
            PrintMessage("Encara no");
            if (Gdata.maintMode != Modes.Status.QUERY)
            {
                PrintMessage("Hi ha canvis pendents");
                return;
            }

            ListControlsInTab(tabControl1.TabPages[Tabs.IMAGES], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.IMAGES], Actions.ENABLE);
            SetMode(Modes.Status.INSERT);
        }

        private void btnNewLink_Click(object sender, EventArgs e)
        {
            PrintMessage("Encara no");
            if (Gdata.maintMode != Modes.Status.QUERY)
            {
                PrintMessage("Hi ha canvis pendents");
                return;
            }

            ListControlsInTab(tabControl1.TabPages[Tabs.LINKS], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.LINKS], Actions.ENABLE);
            SetMode(Modes.Status.INSERT);
        }

        private void btnNewRef_Click(object sender, EventArgs e)
        {
            PrintMessage("Encara no");
            if (Gdata.maintMode != Modes.Status.QUERY)
            {
                PrintMessage("Hi ha canvis pendents");
                return;
            }

            ListControlsInTab(tabControl1.TabPages[Tabs.REFERENCE], Actions.CLEAR);
            //get sequence number
            SetMode(Modes.Status.INSERT);
        }

        private void btnNewQuote_Click(object sender, EventArgs e)
        {
            PrintMessage("Encara no");
            if (Gdata.maintMode != Modes.Status.QUERY)
            {
                PrintMessage("Hi ha canvis pendents");
                return;
            }

            ListControlsInTab(tabControl1.TabPages[Tabs.QUOTES], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.QUOTES], Actions.ENABLE);
            SetMode(Modes.Status.INSERT);
        }

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            PrintMessage("Encara no");
            if (Gdata.maintMode != Modes.Status.QUERY)
            {
                PrintMessage("Hi ha canvis pendents");
                return;
            }

            ListControlsInTab(tabControl1.TabPages[Tabs.CODE], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.CODE], Actions.ENABLE);
            SetMode(Modes.Status.INSERT);
        }

        private void btnNewTips_Click(object sender, EventArgs e)
        {
            PrintMessage("Encara no");
            if (Gdata.maintMode != Modes.Status.QUERY)
            {
                PrintMessage("Hi ha canvis pendents");
                return;
            }

            ListControlsInTab(tabControl1.TabPages[Tabs.TIPS], Actions.CLEAR);
            ListControlsInTab(tabControl1.TabPages[Tabs.TIPS], Actions.ENABLE);
            SetMode(Modes.Status.INSERT);
        }

        private void btnSaveMeta_Click(object sender, EventArgs e)
        {
            if (dgvMetadata.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (Writers.UpdateMetadata(dgvMetadata))
                {
                    PrintMessage("Actualització correcta");
                }
                Cursor.Current = Cursors.Default;
            }
        }

        // ---------------------------------------------------------------------------
        // Insertions
        // ---------------------------------------------------------------------------

        private bool GetNewNumber()
        {
            int num = Readers.GetNextArticle();
            if (num > 0)
            {
                Gdata.IDarticle = num;
            }
            else
            {
                PrintMessage("Error recuperant número");
            }
            return num > 0;
        }

        private bool AnyMissingFieldIn(int tab)
        {
            bool missingData = false;

            switch (tab)
            {
                case Tabs.HEADER:
                    missingData = CheckRequiredTextFields(tabControl1.TabPages[Tabs.HEADER]);
                    break;
            }
            if (missingData)
            {
                PrintMessage("Falta omplir camps obigatoris");
            }
            return missingData;
        }

        private bool CheckRequiredTextFields(Control ctab)
        {
            bool emptyField = false;

            foreach (Control c in ctab.Controls)
            {
                if (c.HasChildren)
                {
                    CheckRequiredTextFields(c);
                }
                else
                {
                    if (c is TextBox)
                    {
                        if (c.Text == string.Empty)
                        {
                            c.BackColor = Color.LightPink;
                            emptyField = true;
                        }
                    }
                }
            }
            return emptyField;
        }

        // ---------------------------------------------------------------------------
        // Helpers
        // ---------------------------------------------------------------------------

        private void UpdateTheTab(int tab)
        {
            if (Gdata.IDarticle == 0)
            {
                PrintMessage("Res seleccionat");
                return;
            }

            if (!NeedToSave[tab])
            {
                switch (tab)
                {
                    case Tabs.HEADER:
                        NeedToSave[tab] = AnyChangeInHead();
                        break;
                    case Tabs.SECTIONS:
                        NeedToSave[tab] = AnyChangeInText();
                        break;
                    case Tabs.IMAGES:
                        NeedToSave[tab] = AnyChangeInImage();
                        break;
                    case Tabs.LINKS:
                        NeedToSave[tab] = AnyChangeInLink();
                        break;
                    case Tabs.REFERENCE:
                        NeedToSave[tab] = AnyChangeInRefs();
                        break;
                    case Tabs.QUOTES:
                        NeedToSave[tab] = AnyChangeInQuote();
                        break;
                    case Tabs.CODE:
                        NeedToSave[tab] = AnyChangeInCode();
                        break;
                    case Tabs.VIDEO:
                        NeedToSave[tab] = AnyChangeInVideo();
                        break;
                    case Tabs.TIPS:
                        NeedToSave[tab] = AnyChangeInTip();
                        break;
                }
            }
            if (NeedToSave[tab])
            {
                PrintMessage("Gravar canvis");
                switch (tab)
                {
                    case Tabs.HEADER:
                        SaveHeadChanges();
                        break;
                    case Tabs.SECTIONS:
                        SaveTextChanges();
                        break;
                    case Tabs.IMAGES:
                        SaveImageChanges();
                        break;
                    case Tabs.LINKS:
                        SaveLinkChanges();
                        break;
                    case Tabs.REFERENCE:
                        SaveRefsChanges();
                        break;
                    case Tabs.QUOTES:
                        SaveQuoteChanges();
                        break;
                    case Tabs.CODE:
                        SaveCodeChanges();
                        break;
                    case Tabs.VIDEO:
                        SaveVideoChanges();
                        break;
                    case Tabs.TIPS:
                        SaveTipChanges();
                        break;
                }
            }
            else PrintMessage("No hi ha canvis");
        }

        private void SetMode(int mode)
        {
            /* ??????
             * How to access lblMode from this form
             * 
            switch (mode)
            {
                case Modes.Status.INSERT:
                    Gdata.maintMode = mode;
                    lblMode.Text = Modes.Text.INSERT;
                    break;

                case Modes.Status.QUERY:
                    Gdata.maintMode = mode;
                    lblMode.Text = Modes.Text.QUERY;
                    break;
            }
            */
        }



        // ---------------------------------------------------------------------------
        // Events
        // on grid cell click
        // ---------------------------------------------------------------------------

        private void dgvSelector_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ???
            if (e.RowIndex < 0) return;

            // Get the article selected and fill the header
            int IDarticle = Int32.Parse(dgvSelector.Rows[e.RowIndex].Cells[0].Value.ToString());
            Singleton Gdata = Singleton.GetInstance();
            Gdata.IDarticle = IDarticle;
            SetMode(Modes.Status.QUERY);

            tbArticle.Text = IDarticle.ToString();
            tbTitle.Text = Readers.GetTitle(Language.CASTELLA);
            tbTitleCA.Text = Readers.GetTitle(Language.CATALA);

            // Restar tabs and load
            ClearAllBoxes();
            ClearDoneArray();
            LoadArticleSections();
            SetButtonStatus();
        }
    }
}
