using Blogs.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Blogs
{
    public partial class FormSettings : Form
    {
        Singleton Gdata = Singleton.GetInstance();

        public FormSettings()
        {
            InitializeComponent();
            chkTestMode.Checked = Gdata.testMode;
            FillTabSettings();
            lblDatabase.Text = Gdata.currentSet == BlogSet.TECHNICAL ? dBServers.TECHNICAL : dBServers.PERSONAL;

        }

        private void FillTabSettings()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = "Versió " + version.Major + "." + version.Minor + " (build " + version.Build + ")";

            lblCreditsDesc.Text = "Manteniment de la base de dades dels blocs publicats a Diari Digital";
            lblCopyright.Text = "© " + DateTime.Today.Year + " Xavier Peña";
        }


        private void chkTestMode_CheckedChanged(object sender, EventArgs e)
        {
            // Save status into singleton
            Gdata.testMode = chkTestMode.Checked;
        }
    }
}
