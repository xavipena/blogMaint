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
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChains)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChainSave
            // 
            this.btnChainSave.Enabled = false;
            this.btnChainSave.Location = new System.Drawing.Point(24, 98);
            this.btnChainSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChainSave.Name = "btnChainSave";
            this.btnChainSave.Size = new System.Drawing.Size(129, 33);
            this.btnChainSave.TabIndex = 47;
            this.btnChainSave.Text = "Desa els canvis";
            this.btnChainSave.UseVisualStyleBackColor = true;
            // 
            // dgvChains
            // 
            this.dgvChains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChains.Location = new System.Drawing.Point(166, 78);
            this.dgvChains.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChains.Name = "dgvChains";
            this.dgvChains.RowHeadersWidth = 51;
            this.dgvChains.RowTemplate.Height = 24;
            this.dgvChains.Size = new System.Drawing.Size(909, 443);
            this.dgvChains.TabIndex = 46;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(399, 544);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(59, 16);
            this.lblMessage.TabIndex = 48;
            this.lblMessage.Text = "Preparat";
            // 
            // FormLinking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 598);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnChainSave);
            this.Controls.Add(this.dgvChains);
            this.Name = "FormLinking";
            this.Text = "Linking";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChains)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChainSave;
        private System.Windows.Forms.DataGridView dgvChains;
        private System.Windows.Forms.Label lblMessage;
    }
}