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
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbBlogs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWords = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1006, 653);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 29);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Surt";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(168, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Títol";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 653);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(59, 16);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Preparat";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Blogs.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // cbBlogs
            // 
            this.cbBlogs.FormattingEnabled = true;
            this.cbBlogs.Location = new System.Drawing.Point(67, 25);
            this.cbBlogs.Name = "cbBlogs";
            this.cbBlogs.Size = new System.Drawing.Size(335, 24);
            this.cbBlogs.TabIndex = 4;
            this.cbBlogs.SelectedIndexChanged += new System.EventHandler(this.cbBlogs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bloc";
            // 
            // dgvArticles
            // 
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Location = new System.Drawing.Point(171, 136);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.RowHeadersWidth = 51;
            this.dgvArticles.RowTemplate.Height = 24;
            this.dgvArticles.Size = new System.Drawing.Size(918, 505);
            this.dgvArticles.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbBlogs);
            this.groupBox1.Location = new System.Drawing.Point(171, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecció";
            // 
            // btnWords
            // 
            this.btnWords.Location = new System.Drawing.Point(15, 192);
            this.btnWords.Name = "btnWords";
            this.btnWords.Size = new System.Drawing.Size(147, 33);
            this.btnWords.TabIndex = 8;
            this.btnWords.Text = "Actualitza";
            this.btnWords.UseVisualStyleBackColor = true;
            this.btnWords.Click += new System.EventHandler(this.btnWords_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1095, 688);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnWords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvArticles);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExit);
            this.Name = "Form1";
            this.Text = "Blocs";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbBlogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnWords;
        private System.Windows.Forms.Label label2;
    }
}

