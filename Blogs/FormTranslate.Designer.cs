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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTranslate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnes_ES.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnes_ES.ForeColor = System.Drawing.Color.White;
            this.btnes_ES.Image = ((System.Drawing.Image)(resources.GetObject("btnes_ES.Image")));
            this.btnes_ES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnes_ES.Location = new System.Drawing.Point(2, 77);
            this.btnes_ES.Margin = new System.Windows.Forms.Padding(2);
            this.btnes_ES.Name = "btnes_ES";
            this.btnes_ES.Size = new System.Drawing.Size(152, 37);
            this.btnes_ES.TabIndex = 5;
            this.btnes_ES.Text = "Castellà";
            this.btnes_ES.UseVisualStyleBackColor = true;
            this.btnes_ES.Click += new System.EventHandler(this.btnes_ES_Click);
            // 
            // btnca_ES
            // 
            this.btnca_ES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnca_ES.FlatAppearance.BorderSize = 0;
            this.btnca_ES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnca_ES.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnca_ES.ForeColor = System.Drawing.Color.White;
            this.btnca_ES.Image = ((System.Drawing.Image)(resources.GetObject("btnca_ES.Image")));
            this.btnca_ES.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnca_ES.Location = new System.Drawing.Point(2, 36);
            this.btnca_ES.Margin = new System.Windows.Forms.Padding(2);
            this.btnca_ES.Name = "btnca_ES";
            this.btnca_ES.Size = new System.Drawing.Size(152, 37);
            this.btnca_ES.TabIndex = 4;
            this.btnca_ES.Text = "Català";
            this.btnca_ES.UseVisualStyleBackColor = true;
            this.btnca_ES.Click += new System.EventHandler(this.btnca_ES_Click);
            // 
            // dgvTranslations
            // 
            this.dgvTranslations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTranslations.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.dgvTranslations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTranslations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Violet;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkViolet;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTranslations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTranslations.ColumnHeadersHeight = 25;
            this.dgvTranslations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumOrchid;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTranslations.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTranslations.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvTranslations.EnableHeadersVisualStyles = false;
            this.dgvTranslations.Location = new System.Drawing.Point(0, 0);
            this.dgvTranslations.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTranslations.Name = "dgvTranslations";
            this.dgvTranslations.RowHeadersVisible = false;
            this.dgvTranslations.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTranslations.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTranslations.RowTemplate.Height = 24;
            this.dgvTranslations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTranslations.Size = new System.Drawing.Size(711, 440);
            this.dgvTranslations.TabIndex = 3;
            // 
            // RightMenu
            // 
            this.RightMenu.BackColor = System.Drawing.Color.SlateGray;
            this.RightMenu.Controls.Add(this.btnca_ES);
            this.RightMenu.Controls.Add(this.btnes_ES);
            this.RightMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightMenu.Location = new System.Drawing.Point(716, 0);
            this.RightMenu.Name = "RightMenu";
            this.RightMenu.Size = new System.Drawing.Size(156, 440);
            this.RightMenu.TabIndex = 6;
            // 
            // FormTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(872, 440);
            this.Controls.Add(this.RightMenu);
            this.Controls.Add(this.dgvTranslations);
            this.Margin = new System.Windows.Forms.Padding(2);
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