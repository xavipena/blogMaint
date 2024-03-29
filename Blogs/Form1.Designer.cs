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
            this.btnNewArticle = new System.Windows.Forms.Button();
            this.btnTabSelector = new System.Windows.Forms.Button();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnTabTime = new System.Windows.Forms.Button();
            this.btnTabChain = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            this.LeftMenu = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChangeLang = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblLang = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.LeftMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTopBar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(190, 585);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(54, 15);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Preparat";
            // 
            // cbBlogs
            // 
            this.cbBlogs.FormattingEnabled = true;
            this.cbBlogs.Location = new System.Drawing.Point(50, 20);
            this.cbBlogs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBlogs.Name = "cbBlogs";
            this.cbBlogs.Size = new System.Drawing.Size(252, 23);
            this.cbBlogs.TabIndex = 4;
            this.cbBlogs.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bloc";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.cbSet);
            this.groupBox1.Controls.Add(this.lblDesc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbBlogs);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(191, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(688, 87);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecció";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(315, 23);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(43, 15);
            this.label52.TabIndex = 13;
            this.label52.Text = "del set";
            // 
            // cbSet
            // 
            this.cbSet.FormattingEnabled = true;
            this.cbSet.Location = new System.Drawing.Point(361, 20);
            this.cbSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSet.Name = "cbSet";
            this.cbSet.Size = new System.Drawing.Size(252, 23);
            this.cbSet.TabIndex = 12;
            this.cbSet.SelectedIndexChanged += new System.EventHandler(this.cbSet_SelectedIndexChanged);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(48, 45);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(65, 15);
            this.lblDesc.TabIndex = 11;
            this.lblDesc.Text = "Descripció";
            // 
            // btnNewArticle
            // 
            this.btnNewArticle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewArticle.FlatAppearance.BorderSize = 0;
            this.btnNewArticle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnNewArticle.ForeColor = System.Drawing.Color.White;
            this.btnNewArticle.Location = new System.Drawing.Point(9, 221);
            this.btnNewArticle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewArticle.Name = "btnNewArticle";
            this.btnNewArticle.Size = new System.Drawing.Size(153, 27);
            this.btnNewArticle.TabIndex = 40;
            this.btnNewArticle.Text = "Nou article";
            this.btnNewArticle.UseVisualStyleBackColor = true;
            // 
            // btnTabSelector
            // 
            this.btnTabSelector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabSelector.FlatAppearance.BorderSize = 0;
            this.btnTabSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnTabSelector.ForeColor = System.Drawing.Color.White;
            this.btnTabSelector.Location = new System.Drawing.Point(9, 191);
            this.btnTabSelector.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTabSelector.Name = "btnTabSelector";
            this.btnTabSelector.Size = new System.Drawing.Size(153, 27);
            this.btnTabSelector.TabIndex = 44;
            this.btnTabSelector.Text = "Seleccionar article";
            this.btnTabSelector.UseVisualStyleBackColor = true;
            this.btnTabSelector.Click += new System.EventHandler(this.btnTabSelector_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTranslate.FlatAppearance.BorderSize = 0;
            this.btnTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnTranslate.ForeColor = System.Drawing.Color.White;
            this.btnTranslate.Location = new System.Drawing.Point(9, 311);
            this.btnTranslate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(153, 27);
            this.btnTranslate.TabIndex = 43;
            this.btnTranslate.Text = "Traduccions";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // btnTabTime
            // 
            this.btnTabTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabTime.FlatAppearance.BorderSize = 0;
            this.btnTabTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnTabTime.ForeColor = System.Drawing.Color.White;
            this.btnTabTime.Location = new System.Drawing.Point(9, 251);
            this.btnTabTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTabTime.Name = "btnTabTime";
            this.btnTabTime.Size = new System.Drawing.Size(153, 27);
            this.btnTabTime.TabIndex = 42;
            this.btnTabTime.Text = "Temps de lectura";
            this.btnTabTime.UseVisualStyleBackColor = true;
            this.btnTabTime.Click += new System.EventHandler(this.btnTabTime_Click);
            // 
            // btnTabChain
            // 
            this.btnTabChain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabChain.FlatAppearance.BorderSize = 0;
            this.btnTabChain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnTabChain.ForeColor = System.Drawing.Color.White;
            this.btnTabChain.Location = new System.Drawing.Point(9, 281);
            this.btnTabChain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTabChain.Name = "btnTabChain";
            this.btnTabChain.Size = new System.Drawing.Size(153, 27);
            this.btnTabChain.TabIndex = 41;
            this.btnTabChain.Text = "Encadenament";
            this.btnTabChain.UseVisualStyleBackColor = true;
            this.btnTabChain.Click += new System.EventHandler(this.btnTagChain_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblMode.ForeColor = System.Drawing.Color.White;
            this.lblMode.Location = new System.Drawing.Point(5, 60);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(53, 20);
            this.lblMode.TabIndex = 14;
            this.lblMode.Text = "Mode";
            // 
            // LeftMenu
            // 
            this.LeftMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
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
            this.LeftMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LeftMenu.Name = "LeftMenu";
            this.LeftMenu.Size = new System.Drawing.Size(178, 609);
            this.LeftMenu.TabIndex = 15;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(9, 479);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(153, 27);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Surt";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChangeLang
            // 
            this.btnChangeLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeLang.FlatAppearance.BorderSize = 0;
            this.btnChangeLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeLang.ForeColor = System.Drawing.Color.White;
            this.btnChangeLang.Image = global::Blogs.Properties.Resources.idioma;
            this.btnChangeLang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeLang.Location = new System.Drawing.Point(9, 152);
            this.btnChangeLang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChangeLang.Name = "btnChangeLang";
            this.btnChangeLang.Size = new System.Drawing.Size(153, 36);
            this.btnChangeLang.TabIndex = 10;
            this.btnChangeLang.Text = "Canvia l\'idioma";
            this.btnChangeLang.UseVisualStyleBackColor = true;
            this.btnChangeLang.Click += new System.EventHandler(this.btnChangeLang_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Blogs.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(38, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelected.ForeColor = System.Drawing.Color.White;
            this.lblSelected.Location = new System.Drawing.Point(5, 14);
            this.lblSelected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(53, 20);
            this.lblSelected.TabIndex = 16;
            this.lblSelected.Text = "Mode";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Location = new System.Drawing.Point(191, 116);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(900, 462);
            this.pnlContainer.TabIndex = 17;
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblLang.ForeColor = System.Drawing.Color.White;
            this.lblLang.Location = new System.Drawing.Point(5, 36);
            this.lblLang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(49, 20);
            this.lblLang.TabIndex = 18;
            this.lblLang.Text = "Lang";
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.pnlTopBar.Controls.Add(this.lblTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(178, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(930, 24);
            this.pnlTopBar.TabIndex = 19;
            this.pnlTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblTitle.Location = new System.Drawing.Point(12, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(28, 13);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "Bloc";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMode);
            this.groupBox2.Controls.Add(this.lblSelected);
            this.groupBox2.Controls.Add(this.lblLang);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(884, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 87);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estat";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1108, 609);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.LeftMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blocs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.LeftMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbBlogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnChangeLang;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.ComboBox cbSet;
        private System.Windows.Forms.Button btnNewArticle;
        private System.Windows.Forms.Label lblMode;
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
    }
}

