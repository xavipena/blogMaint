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
            this.lbTabs = new System.Windows.Forms.ListBox();
            this.lbControls = new System.Windows.Forms.ListBox();
            this.chkTestMode = new System.Windows.Forms.CheckBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCreditsDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(29, 168);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 16);
            this.lblDescription.TabIndex = 25;
            this.lblDescription.Text = "Description";
            // 
            // lbTabs
            // 
            this.lbTabs.FormattingEnabled = true;
            this.lbTabs.ItemHeight = 16;
            this.lbTabs.Location = new System.Drawing.Point(740, 115);
            this.lbTabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbTabs.Name = "lbTabs";
            this.lbTabs.Size = new System.Drawing.Size(164, 180);
            this.lbTabs.TabIndex = 24;
            // 
            // lbControls
            // 
            this.lbControls.FormattingEnabled = true;
            this.lbControls.ItemHeight = 16;
            this.lbControls.Location = new System.Drawing.Point(910, 115);
            this.lbControls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbControls.Name = "lbControls";
            this.lbControls.Size = new System.Drawing.Size(164, 180);
            this.lbControls.TabIndex = 23;
            // 
            // chkTestMode
            // 
            this.chkTestMode.AutoSize = true;
            this.chkTestMode.Checked = true;
            this.chkTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTestMode.Location = new System.Drawing.Point(32, 115);
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
            this.lblDatabase.Location = new System.Drawing.Point(30, 479);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(26, 16);
            this.lblDatabase.TabIndex = 21;
            this.lblDatabase.Text = "DB";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(29, 500);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(24, 16);
            this.lblCopyright.TabIndex = 20;
            this.lblCopyright.Text = "(C)";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(30, 438);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(53, 16);
            this.lblVersion.TabIndex = 19;
            this.lblVersion.Text = "Version";
            // 
            // lblCreditsDesc
            // 
            this.lblCreditsDesc.AutoSize = true;
            this.lblCreditsDesc.Location = new System.Drawing.Point(30, 458);
            this.lblCreditsDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreditsDesc.Name = "lblCreditsDesc";
            this.lblCreditsDesc.Size = new System.Drawing.Size(75, 16);
            this.lblCreditsDesc.TabIndex = 18;
            this.lblCreditsDesc.Text = "Description";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 631);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lbTabs);
            this.Controls.Add(this.lbControls);
            this.Controls.Add(this.chkTestMode);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCreditsDesc);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ListBox lbTabs;
        private System.Windows.Forms.ListBox lbControls;
        private System.Windows.Forms.CheckBox chkTestMode;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCreditsDesc;
    }
}