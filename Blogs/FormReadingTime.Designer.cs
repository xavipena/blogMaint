namespace Blogs
{
    partial class FormReadingTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReadingTime));
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnWordsAll = new System.Windows.Forms.Button();
            this.btnWords = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvArticles
            // 
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvArticles.Location = new System.Drawing.Point(0, 0);
            this.dgvArticles.Margin = new System.Windows.Forms.Padding(2);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.RowHeadersWidth = 51;
            this.dgvArticles.RowTemplate.Height = 24;
            this.dgvArticles.Size = new System.Drawing.Size(711, 440);
            this.dgvArticles.TabIndex = 11;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveChanges.FlatAppearance.BorderSize = 0;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveChanges.Image")));
            this.btnSaveChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanges.Location = new System.Drawing.Point(4, 105);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(150, 37);
            this.btnSaveChanges.TabIndex = 14;
            this.btnSaveChanges.Text = "Desa els canvis";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnWordsAll
            // 
            this.btnWordsAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWordsAll.FlatAppearance.BorderSize = 0;
            this.btnWordsAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWordsAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnWordsAll.ForeColor = System.Drawing.Color.White;
            this.btnWordsAll.Image = ((System.Drawing.Image)(resources.GetObject("btnWordsAll.Image")));
            this.btnWordsAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWordsAll.Location = new System.Drawing.Point(4, 64);
            this.btnWordsAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnWordsAll.Name = "btnWordsAll";
            this.btnWordsAll.Size = new System.Drawing.Size(150, 37);
            this.btnWordsAll.TabIndex = 13;
            this.btnWordsAll.Text = "Actualitza tot";
            this.btnWordsAll.UseVisualStyleBackColor = true;
            this.btnWordsAll.Click += new System.EventHandler(this.btnWordsAll_Click);
            // 
            // btnWords
            // 
            this.btnWords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWords.FlatAppearance.BorderSize = 0;
            this.btnWords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnWords.ForeColor = System.Drawing.Color.White;
            this.btnWords.Image = ((System.Drawing.Image)(resources.GetObject("btnWords.Image")));
            this.btnWords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWords.Location = new System.Drawing.Point(2, 23);
            this.btnWords.Margin = new System.Windows.Forms.Padding(2);
            this.btnWords.Name = "btnWords";
            this.btnWords.Size = new System.Drawing.Size(152, 37);
            this.btnWords.TabIndex = 12;
            this.btnWords.Text = "Actualitza";
            this.btnWords.UseVisualStyleBackColor = true;
            this.btnWords.Click += new System.EventHandler(this.btnWords_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.btnSaveChanges);
            this.panel1.Controls.Add(this.btnWords);
            this.panel1.Controls.Add(this.btnWordsAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(716, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 440);
            this.panel1.TabIndex = 15;
            // 
            // FormReadingTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(872, 440);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvArticles);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormReadingTime";
            this.Text = "ReadingTime";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnWordsAll;
        private System.Windows.Forms.Button btnWords;
        private System.Windows.Forms.Panel panel1;
    }
}