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
            this.btnChainSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnChainSave.ForeColor = System.Drawing.Color.White;
            this.btnChainSave.Image = global::Blogs.Properties.Resources.ph__note_pencil_light;
            this.btnChainSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChainSave.Location = new System.Drawing.Point(5, 30);
            this.btnChainSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChainSave.Name = "btnChainSave";
            this.btnChainSave.Size = new System.Drawing.Size(223, 46);
            this.btnChainSave.TabIndex = 47;
            this.btnChainSave.Text = "Desa canvis";
            this.btnChainSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChainSave.UseVisualStyleBackColor = true;
            this.btnChainSave.Click += new System.EventHandler(this.btnChainSave_Click);
            // 
            // dgvChains
            // 
            this.dgvChains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChains.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.dgvChains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChains.Location = new System.Drawing.Point(0, 0);
            this.dgvChains.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChains.Name = "dgvChains";
            this.dgvChains.RowHeadersWidth = 51;
            this.dgvChains.RowTemplate.Height = 24;
            this.dgvChains.Size = new System.Drawing.Size(918, 542);
            this.dgvChains.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(101)))), ((int)(((byte)(180)))));
            this.panel1.Controls.Add(this.btnChainSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(918, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 542);
            this.panel1.TabIndex = 48;
            // 
            // FormLinking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1163, 542);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvChains);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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