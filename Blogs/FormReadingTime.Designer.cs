﻿namespace Blogs
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
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnWordsAll = new System.Windows.Forms.Button();
            this.btnWords = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticles
            // 
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Location = new System.Drawing.Point(166, 90);
            this.dgvArticles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.RowHeadersWidth = 51;
            this.dgvArticles.RowTemplate.Height = 24;
            this.dgvArticles.Size = new System.Drawing.Size(875, 443);
            this.dgvArticles.TabIndex = 11;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(-6, 249);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(147, 33);
            this.btnSaveChanges.TabIndex = 14;
            this.btnSaveChanges.Text = "Desa els canvis";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnWordsAll
            // 
            this.btnWordsAll.Location = new System.Drawing.Point(-6, 137);
            this.btnWordsAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWordsAll.Name = "btnWordsAll";
            this.btnWordsAll.Size = new System.Drawing.Size(147, 33);
            this.btnWordsAll.TabIndex = 13;
            this.btnWordsAll.Text = "Actualitza tot";
            this.btnWordsAll.UseVisualStyleBackColor = true;
            // 
            // btnWords
            // 
            this.btnWords.Location = new System.Drawing.Point(-6, 98);
            this.btnWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWords.Name = "btnWords";
            this.btnWords.Size = new System.Drawing.Size(147, 33);
            this.btnWords.TabIndex = 12;
            this.btnWords.Text = "Actualitza";
            this.btnWords.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(371, 558);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(44, 16);
            this.lblMessage.TabIndex = 15;
            this.lblMessage.Text = "label1";
            // 
            // FormReadingTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 623);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgvArticles);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnWordsAll);
            this.Controls.Add(this.btnWords);
            this.Name = "FormReadingTime";
            this.Text = "ReadingTime";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnWordsAll;
        private System.Windows.Forms.Button btnWords;
        private System.Windows.Forms.Label lblMessage;
    }
}