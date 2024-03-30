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
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkTestMode = new System.Windows.Forms.CheckBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCreditsDesc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(17, 27);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 25;
            this.lblDescription.Text = "Description";
            // 
            // chkTestMode
            // 
            this.chkTestMode.AutoSize = true;
            this.chkTestMode.Checked = true;
            this.chkTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestMode.Location = new System.Drawing.Point(21, 31);
            this.chkTestMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkTestMode.Name = "chkTestMode";
            this.chkTestMode.Size = new System.Drawing.Size(93, 17);
            this.chkTestMode.TabIndex = 22;
            this.chkTestMode.Text = "Modus de test";
            this.chkTestMode.UseVisualStyleBackColor = true;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(17, 77);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(22, 13);
            this.lblDatabase.TabIndex = 21;
            this.lblDatabase.Text = "DB";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(17, 94);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(20, 13);
            this.lblCopyright.TabIndex = 20;
            this.lblCopyright.Text = "(C)";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(17, 44);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 19;
            this.lblVersion.Text = "Version";
            // 
            // lblCreditsDesc
            // 
            this.lblCreditsDesc.AutoSize = true;
            this.lblCreditsDesc.Location = new System.Drawing.Point(17, 60);
            this.lblCreditsDesc.Name = "lblCreditsDesc";
            this.lblCreditsDesc.Size = new System.Drawing.Size(60, 13);
            this.lblCreditsDesc.TabIndex = 18;
            this.lblCreditsDesc.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTestMode);
            this.groupBox1.Location = new System.Drawing.Point(441, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 123);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ajusts";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDescription);
            this.groupBox2.Controls.Add(this.lblVersion);
            this.groupBox2.Controls.Add(this.lblDatabase);
            this.groupBox2.Controls.Add(this.lblCreditsDesc);
            this.groupBox2.Controls.Add(this.lblCopyright);
            this.groupBox2.Location = new System.Drawing.Point(45, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 123);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crèdits";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(872, 440);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkTestMode;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCreditsDesc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}