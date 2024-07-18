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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnes_ES = new System.Windows.Forms.Button();
            this.btnca_ES = new System.Windows.Forms.Button();
            this.dgvTranslations = new System.Windows.Forms.DataGridView();
            this.RightMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTranslations)).BeginInit();
            this.RightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnes_ES
            // 
            this.btnes_ES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnes_ES.FlatAppearance.BorderSize = 0;
            this.btnes_ES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnes_ES.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnes_ES.ForeColor = System.Drawing.Color.White;
            this.btnes_ES.Image = global::Blogs.Properties.Resources.ph__chat_circle_dots_light;
            this.btnes_ES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnes_ES.Location = new System.Drawing.Point(3, 78);
            this.btnes_ES.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnes_ES.Name = "btnes_ES";
            this.btnes_ES.Size = new System.Drawing.Size(223, 46);
            this.btnes_ES.TabIndex = 5;
            this.btnes_ES.Text = "Castellà";
            this.btnes_ES.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnes_ES.UseVisualStyleBackColor = true;
            this.btnes_ES.Click += new System.EventHandler(this.btnes_ES_Click);
            // 
            // btnca_ES
            // 
            this.btnca_ES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnca_ES.FlatAppearance.BorderSize = 0;
            this.btnca_ES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnca_ES.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnca_ES.ForeColor = System.Drawing.Color.White;
            this.btnca_ES.Image = global::Blogs.Properties.Resources.ph__chat_circle_dots_light;
            this.btnca_ES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnca_ES.Location = new System.Drawing.Point(3, 27);
            this.btnca_ES.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnca_ES.Name = "btnca_ES";
            this.btnca_ES.Size = new System.Drawing.Size(223, 46);
            this.btnca_ES.TabIndex = 4;
            this.btnca_ES.Text = "Català";
            this.btnca_ES.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnca_ES.UseVisualStyleBackColor = true;
            this.btnca_ES.Click += new System.EventHandler(this.btnca_ES_Click);
            // 
            // dgvTranslations
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            this.dgvTranslations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTranslations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTranslations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTranslations.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.dgvTranslations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTranslations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkViolet;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTranslations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTranslations.ColumnHeadersHeight = 35;
            this.dgvTranslations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTranslations.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTranslations.EnableHeadersVisualStyles = false;
            this.dgvTranslations.Location = new System.Drawing.Point(0, 0);
            this.dgvTranslations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTranslations.Name = "dgvTranslations";
            this.dgvTranslations.RowHeadersVisible = false;
            this.dgvTranslations.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTranslations.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTranslations.RowTemplate.Height = 24;
            this.dgvTranslations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTranslations.Size = new System.Drawing.Size(918, 542);
            this.dgvTranslations.TabIndex = 3;
            // 
            // RightMenu
            // 
            this.RightMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(101)))), ((int)(((byte)(180)))));
            this.RightMenu.Controls.Add(this.btnca_ES);
            this.RightMenu.Controls.Add(this.btnes_ES);
            this.RightMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMenu.Location = new System.Drawing.Point(919, 0);
            this.RightMenu.Margin = new System.Windows.Forms.Padding(4);
            this.RightMenu.Name = "RightMenu";
            this.RightMenu.Size = new System.Drawing.Size(244, 542);
            this.RightMenu.TabIndex = 6;
            // 
            // FormTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1163, 542);
            this.Controls.Add(this.RightMenu);
            this.Controls.Add(this.dgvTranslations);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTranslate";
            this.Text = "Translation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTranslations)).EndInit();
            this.RightMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnes_ES;
        private System.Windows.Forms.Button btnca_ES;
        private System.Windows.Forms.DataGridView dgvTranslations;
        private System.Windows.Forms.Panel RightMenu;
    }
}