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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChains)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChainSave
            // 
            this.btnChainSave.Enabled = false;
            this.btnChainSave.FlatAppearance.BorderSize = 0;
            this.btnChainSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChainSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnChainSave.ForeColor = System.Drawing.Color.White;
            this.btnChainSave.Image = global::Blogs.Properties.Resources.link;
            this.btnChainSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChainSave.Location = new System.Drawing.Point(2, 24);
            this.btnChainSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnChainSave.Name = "btnChainSave";
            this.btnChainSave.Size = new System.Drawing.Size(152, 37);
            this.btnChainSave.TabIndex = 47;
            this.btnChainSave.Text = "Desa els canvis";
            this.btnChainSave.UseVisualStyleBackColor = true;
            this.btnChainSave.Click += new System.EventHandler(this.btnChainSave_Click);
            // 
            // dgvChains
            // 
            this.dgvChains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChains.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvChains.Location = new System.Drawing.Point(0, 0);
            this.dgvChains.Margin = new System.Windows.Forms.Padding(2);
            this.dgvChains.Name = "dgvChains";
            this.dgvChains.RowHeadersWidth = 51;
            this.dgvChains.RowTemplate.Height = 24;
            this.dgvChains.Size = new System.Drawing.Size(711, 440);
            this.dgvChains.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.btnChainSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(716, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 440);
            this.panel1.TabIndex = 48;
            // 
            // FormLinking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(872, 440);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvChains);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLinking";
            this.Text = "Linking";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChains)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChainSave;
        private System.Windows.Forms.DataGridView dgvChains;
        private System.Windows.Forms.Panel panel1;
    }
}