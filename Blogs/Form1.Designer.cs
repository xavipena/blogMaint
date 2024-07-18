namespace Blogs
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.cbBlogs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.cbSet = new System.Windows.Forms.ComboBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.LeftMenu = new System.Windows.Forms.Panel();
            this.lblSelected = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblLang = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnTabSelector = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnNewArticle = new System.Windows.Forms.Button();
            this.btnTabTime = new System.Windows.Forms.Button();
            this.btnChangeLang = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTabChain = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.LeftMenu.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(253, 740);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(64, 18);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Preparat";
            // 
            // cbBlogs
            // 
            this.cbBlogs.FormattingEnabled = true;
            this.cbBlogs.Location = new System.Drawing.Point(67, 34);
            this.cbBlogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBlogs.Name = "cbBlogs";
            this.cbBlogs.Size = new System.Drawing.Size(335, 26);
            this.cbBlogs.TabIndex = 4;
            this.cbBlogs.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bloc";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(98)))), ((int)(((byte)(156)))));
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.cbSet);
            this.groupBox1.Controls.Add(this.lblDesc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbBlogs);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(255, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(917, 101);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecció";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(420, 38);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(51, 18);
            this.label52.TabIndex = 13;
            this.label52.Text = "del set";
            // 
            // cbSet
            // 
            this.cbSet.FormattingEnabled = true;
            this.cbSet.Location = new System.Drawing.Point(481, 34);
            this.cbSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSet.Name = "cbSet";
            this.cbSet.Size = new System.Drawing.Size(335, 26);
            this.cbSet.TabIndex = 12;
            this.cbSet.SelectedIndexChanged += new System.EventHandler(this.cbSet_SelectedIndexChanged);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(64, 65);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(79, 18);
            this.lblDesc.TabIndex = 11;
            this.lblDesc.Text = "Descripció";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblMode.ForeColor = System.Drawing.Color.White;
            this.lblMode.Location = new System.Drawing.Point(7, 72);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(63, 24);
            this.lblMode.TabIndex = 14;
            this.lblMode.Text = "Mode";
            // 
            // LeftMenu
            // 
            this.LeftMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(101)))), ((int)(((byte)(180)))));
            this.LeftMenu.Controls.Add(this.btnSettings);
            this.LeftMenu.Controls.Add(this.btnTabSelector);
            this.LeftMenu.Controls.Add(this.btnExit);
            this.LeftMenu.Controls.Add(this.btnTranslate);
            this.LeftMenu.Controls.Add(this.btnNewArticle);
            this.LeftMenu.Controls.Add(this.btnTabTime);
            this.LeftMenu.Controls.Add(this.btnChangeLang);
            this.LeftMenu.Controls.Add(this.pictureBox1);
            this.LeftMenu.Controls.Add(this.btnTabChain);
            this.LeftMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftMenu.Location = new System.Drawing.Point(0, 0);
            this.LeftMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LeftMenu.Name = "LeftMenu";
            this.LeftMenu.Size = new System.Drawing.Size(237, 770);
            this.LeftMenu.TabIndex = 15;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblSelected.ForeColor = System.Drawing.Color.White;
            this.lblSelected.Location = new System.Drawing.Point(7, 17);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(79, 30);
            this.lblSelected.TabIndex = 16;
            this.lblSelected.Text = "Mode";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(126)))), ((int)(((byte)(149)))));
            this.pnlContainer.Location = new System.Drawing.Point(255, 143);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1200, 590);
            this.pnlContainer.TabIndex = 17;
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblLang.ForeColor = System.Drawing.Color.White;
            this.lblLang.Location = new System.Drawing.Point(7, 43);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(56, 24);
            this.lblLang.TabIndex = 18;
            this.lblLang.Text = "Lang";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(101)))), ((int)(((byte)(180)))));
            this.pnlTopBar.Controls.Add(this.lblTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(237, 0);
            this.pnlTopBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1232, 30);
            this.pnlTopBar.TabIndex = 19;
            this.pnlTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(34, 16);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Bloc";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(98)))), ((int)(((byte)(156)))));
            this.groupBox2.Controls.Add(this.lblMode);
            this.groupBox2.Controls.Add(this.lblSelected);
            this.groupBox2.Controls.Add(this.lblLang);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(1179, 36);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(276, 101);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estat";
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::Blogs.Properties.Resources.ph__equalizer_light;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(12, 581);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(222, 79);
            this.btnSettings.TabIndex = 45;
            this.btnSettings.Text = "Ajusts";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnTabSelector
            // 
            this.btnTabSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabSelector.FlatAppearance.BorderSize = 0;
            this.btnTabSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnTabSelector.ForeColor = System.Drawing.Color.White;
            this.btnTabSelector.Image = global::Blogs.Properties.Resources.ph__stack_light;
            this.btnTabSelector.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTabSelector.Location = new System.Drawing.Point(9, 239);
            this.btnTabSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTabSelector.Name = "btnTabSelector";
            this.btnTabSelector.Size = new System.Drawing.Size(225, 79);
            this.btnTabSelector.TabIndex = 44;
            this.btnTabSelector.Text = "Articles";
            this.btnTabSelector.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTabSelector.UseVisualStyleBackColor = true;
            this.btnTabSelector.Click += new System.EventHandler(this.btnTabSelector_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::Blogs.Properties.Resources.ph__radio_button_light;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(6, 654);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(225, 79);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Surt";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTranslate.FlatAppearance.BorderSize = 0;
            this.btnTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnTranslate.ForeColor = System.Drawing.Color.White;
            this.btnTranslate.Image = global::Blogs.Properties.Resources.ph__translate_light;
            this.btnTranslate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTranslate.Location = new System.Drawing.Point(6, 512);
            this.btnTranslate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(225, 79);
            this.btnTranslate.TabIndex = 43;
            this.btnTranslate.Text = "Traduccions";
            this.btnTranslate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // btnNewArticle
            // 
            this.btnNewArticle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewArticle.FlatAppearance.BorderSize = 0;
            this.btnNewArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnNewArticle.ForeColor = System.Drawing.Color.White;
            this.btnNewArticle.Image = global::Blogs.Properties.Resources.ph__note_pencil_light;
            this.btnNewArticle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewArticle.Location = new System.Drawing.Point(15, 307);
            this.btnNewArticle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNewArticle.Name = "btnNewArticle";
            this.btnNewArticle.Size = new System.Drawing.Size(219, 79);
            this.btnNewArticle.TabIndex = 40;
            this.btnNewArticle.Text = "Nou article";
            this.btnNewArticle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewArticle.UseVisualStyleBackColor = true;
            this.btnNewArticle.Click += new System.EventHandler(this.btnNewArticle_Click);
            // 
            // btnTabTime
            // 
            this.btnTabTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabTime.FlatAppearance.BorderSize = 0;
            this.btnTabTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnTabTime.ForeColor = System.Drawing.Color.White;
            this.btnTabTime.Image = global::Blogs.Properties.Resources.ph__clock_user_light;
            this.btnTabTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTabTime.Location = new System.Drawing.Point(9, 373);
            this.btnTabTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTabTime.Name = "btnTabTime";
            this.btnTabTime.Size = new System.Drawing.Size(225, 79);
            this.btnTabTime.TabIndex = 42;
            this.btnTabTime.Text = "Temps lectura";
            this.btnTabTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTabTime.UseVisualStyleBackColor = true;
            this.btnTabTime.Click += new System.EventHandler(this.btnTabTime_Click);
            // 
            // btnChangeLang
            // 
            this.btnChangeLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeLang.FlatAppearance.BorderSize = 0;
            this.btnChangeLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnChangeLang.ForeColor = System.Drawing.Color.White;
            this.btnChangeLang.Image = global::Blogs.Properties.Resources.ph__chat_circle_dots_light;
            this.btnChangeLang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeLang.Location = new System.Drawing.Point(9, 182);
            this.btnChangeLang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangeLang.Name = "btnChangeLang";
            this.btnChangeLang.Size = new System.Drawing.Size(225, 63);
            this.btnChangeLang.TabIndex = 10;
            this.btnChangeLang.Text = "Canvia l\'idioma";
            this.btnChangeLang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeLang.UseVisualStyleBackColor = true;
            this.btnChangeLang.Click += new System.EventHandler(this.btnChangeLang_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Blogs.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(51, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnTabChain
            // 
            this.btnTabChain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabChain.FlatAppearance.BorderSize = 0;
            this.btnTabChain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnTabChain.ForeColor = System.Drawing.Color.White;
            this.btnTabChain.Image = global::Blogs.Properties.Resources.ph__link_light;
            this.btnTabChain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTabChain.Location = new System.Drawing.Point(6, 445);
            this.btnTabChain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTabChain.Name = "btnTabChain";
            this.btnTabChain.Size = new System.Drawing.Size(228, 79);
            this.btnTabChain.TabIndex = 41;
            this.btnTabChain.Text = "Encadenament";
            this.btnTabChain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTabChain.UseVisualStyleBackColor = true;
            this.btnTabChain.Click += new System.EventHandler(this.btnTagChain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(1469, 770);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.LeftMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blocs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.LeftMenu.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbBlogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnChangeLang;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.ComboBox cbSet;
        private System.Windows.Forms.Button btnNewArticle;
        internal System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnTabTime;
        private System.Windows.Forms.Button btnTabChain;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnTabSelector;
        private System.Windows.Forms.Panel LeftMenu;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblLang;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSettings;
        internal System.Windows.Forms.Label lblMessage;
    }
}

