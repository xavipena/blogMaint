namespace Blogs
{
    partial class FormLinking
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
            this.btnChainSave = new System.Windows.Forms.Button();
            this.dgvChains = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChains)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChainSave
            // 
            this.btnChainSave.Enabled = false;
            this.btnChainSave.Location = new System.Drawing.Point(15, 26);
            this.btnChainSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChainSave.Name = "btnChainSave";
            this.btnChainSave.Size = new System.Drawing.Size(97, 27);
            this.btnChainSave.TabIndex = 47;
            this.btnChainSave.Text = "Desa els canvis";
            this.btnChainSave.UseVisualStyleBackColor = true;
            // 
            // dgvChains
            // 
            this.dgvChains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChains.Location = new System.Drawing.Point(121, 9);
            this.dgvChains.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvChains.Name = "dgvChains";
            this.dgvChains.RowHeadersWidth = 51;
            this.dgvChains.RowTemplate.Height = 24;
            this.dgvChains.Size = new System.Drawing.Size(682, 420);
            this.dgvChains.TabIndex = 46;
            // 
            // FormLinking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(872, 440);
            this.Controls.Add(this.btnChainSave);
            this.Controls.Add(this.dgvChains);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormLinking";
            this.Text = "Linking";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChains)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChainSave;
        private System.Windows.Forms.DataGridView dgvChains;
    }
}