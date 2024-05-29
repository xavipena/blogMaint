namespace Blogs
{
    partial class FormSettings
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
            this.chkTestMode = new System.Windows.Forms.CheckBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCreditsDesc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblBlogs = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkTestMode
            // 
            this.chkTestMode.AutoSize = true;
            this.chkTestMode.Checked = true;
            this.chkTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestMode.Location = new System.Drawing.Point(28, 38);
            this.chkTestMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkTestMode.Name = "chkTestMode";
            this.chkTestMode.Size = new System.Drawing.Size(113, 20);
            this.chkTestMode.TabIndex = 22;
            this.chkTestMode.Text = "Modus de test";
            this.chkTestMode.UseVisualStyleBackColor = true;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(196, 47);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(26, 16);
            this.lblDatabase.TabIndex = 21;
            this.lblDatabase.Text = "DB";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(196, 70);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(24, 16);
            this.lblCopyright.TabIndex = 20;
            this.lblCopyright.Text = "(C)";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(196, 23);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(53, 16);
            this.lblVersion.TabIndex = 19;
            this.lblVersion.Text = "Version";
            // 
            // lblCreditsDesc
            // 
            this.lblCreditsDesc.AutoSize = true;
            this.lblCreditsDesc.Location = new System.Drawing.Point(23, 167);
            this.lblCreditsDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreditsDesc.Name = "lblCreditsDesc";
            this.lblCreditsDesc.Size = new System.Drawing.Size(75, 16);
            this.lblCreditsDesc.TabIndex = 18;
            this.lblCreditsDesc.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Khaki;
            this.groupBox1.Controls.Add(this.chkTestMode);
            this.groupBox1.Location = new System.Drawing.Point(583, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(516, 512);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajusts";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Khaki;
            this.groupBox2.Controls.Add(this.lblBlogs);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.lblVersion);
            this.groupBox2.Controls.Add(this.lblDatabase);
            this.groupBox2.Controls.Add(this.lblCreditsDesc);
            this.groupBox2.Controls.Add(this.lblCopyright);
            this.groupBox2.Location = new System.Drawing.Point(55, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(516, 512);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crèdits";
            // 
            // lblBlogs
            // 
            this.lblBlogs.AutoSize = true;
            this.lblBlogs.Location = new System.Drawing.Point(23, 204);
            this.lblBlogs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlogs.Name = "lblBlogs";
            this.lblBlogs.Size = new System.Drawing.Size(42, 16);
            this.lblBlogs.TabIndex = 23;
            this.lblBlogs.Text = "Blogs";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Blogs.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(27, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(1163, 542);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkTestMode;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCreditsDesc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBlogs;
    }
}