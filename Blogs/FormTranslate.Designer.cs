namespace Blogs
{
    partial class FormTranslate
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
            this.btnes_ES = new System.Windows.Forms.Button();
            this.btnca_ES = new System.Windows.Forms.Button();
            this.dgvTranslations = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTranslations)).BeginInit();
            this.SuspendLayout();
            // 
            // btnes_ES
            // 
            this.btnes_ES.Location = new System.Drawing.Point(306, 404);
            this.btnes_ES.Margin = new System.Windows.Forms.Padding(2);
            this.btnes_ES.Name = "btnes_ES";
            this.btnes_ES.Size = new System.Drawing.Size(75, 25);
            this.btnes_ES.TabIndex = 5;
            this.btnes_ES.Text = "Castellà";
            this.btnes_ES.UseVisualStyleBackColor = true;
            // 
            // btnca_ES
            // 
            this.btnca_ES.Location = new System.Drawing.Point(487, 404);
            this.btnca_ES.Margin = new System.Windows.Forms.Padding(2);
            this.btnca_ES.Name = "btnca_ES";
            this.btnca_ES.Size = new System.Drawing.Size(72, 25);
            this.btnca_ES.TabIndex = 4;
            this.btnca_ES.Text = "Català";
            this.btnca_ES.UseVisualStyleBackColor = true;
            // 
            // dgvTranslations
            // 
            this.dgvTranslations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTranslations.Location = new System.Drawing.Point(11, 11);
            this.dgvTranslations.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTranslations.Name = "dgvTranslations";
            this.dgvTranslations.RowHeadersWidth = 51;
            this.dgvTranslations.RowTemplate.Height = 24;
            this.dgvTranslations.Size = new System.Drawing.Size(850, 389);
            this.dgvTranslations.TabIndex = 3;
            // 
            // FormTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(872, 440);
            this.Controls.Add(this.btnes_ES);
            this.Controls.Add(this.btnca_ES);
            this.Controls.Add(this.dgvTranslations);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTranslate";
            this.Text = "Translation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTranslations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnes_ES;
        private System.Windows.Forms.Button btnca_ES;
        private System.Windows.Forms.DataGridView dgvTranslations;
    }
}