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

namespace Blogs
{
    public partial class FormTranslate : Form
    {
        public FormTranslate()
        {
            InitializeComponent();
            SetUpForm();
            DefineGrids();
            // set up when showing form
            Shown += FormReadingTime_Shown;
        }

        private void FormReadingTime_Shown(object sender, EventArgs e)
        {
            FillTabTranslate();
        }

        private void SetUpForm()
        {

        }

        private void DefineGrids()
        {
            dgvTranslations.Rows.Clear();
            dgvTranslations.ColumnCount = 3;
            dgvTranslations.AllowUserToAddRows = false;
            dgvTranslations.MultiSelect = false;

            dgvTranslations.Columns[0].Name = "ID";
            dgvTranslations.Columns[0].Width = 40;
            dgvTranslations.Columns[1].Name = "Castellà";
            dgvTranslations.Columns[1].Width = 300;
            dgvTranslations.Columns[2].Name = "Català";
            dgvTranslations.Columns[2].Width = 300;
        }

        private void PrintMessage(string msg)
        {
            /*
            To allow a top-level form to share a control with a lower-level form:

            1.) In form designer, open the main form, select the control to be shared, and set its modifier 
                to "Internal".
            2.) When calling the lower-level form, supply "this" as the owner parameter of Show().

                LoginForm login = new LoginForm();
                login.Show(this);

            3.) From the lower-level form, you can now reference the Owner property and cast it back to its 
                class type to access the shared control by name.

                ((MainForm)Owner).PanelContainer.Visible = false;
             */

            if (this.Parent == null || this.Parent.GetType() != typeof(Form1))
                return;

            // Check if calling from a thread that is not main

            if (((Form1)Owner).lblMessage.InvokeRequired)
            {
                ((Form1)Owner).lblMessage.BeginInvoke((MethodInvoker)delegate ()
                {
                    ((Form1)Owner).lblMessage.Text = msg;
                });
            }
            else
            {
                ((Form1)Owner).lblMessage.Text = msg;
            }
        }

        private void FillTabTranslate()
        {
            Cursor.Current = Cursors.WaitCursor;

            List<string[]> tList = Readers.GetTabTranslations();
            dgvTranslations.Rows.Clear();
            foreach (string[] sa in tList)
            {
                dgvTranslations.Rows.Add(sa);
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnes_ES_Click(object sender, EventArgs e)
        {
            if (dgvTranslations.Rows.Count == 0) return;

            HighlightButton(btnes_ES);

            bool noData = true;
            foreach (DataGridViewRow row in dgvTranslations.SelectedRows)
            {
                noData = false;
            }
            if (noData)
            {
                PrintMessage("Res seleccionat");
            }
        }

        private void btnca_ES_Click(object sender, EventArgs e)
        {
            if (dgvTranslations.Rows.Count == 0) return;

            HighlightButton(btnca_ES);

            bool noData = true;
            foreach (DataGridViewRow row in dgvTranslations.SelectedRows)
            {
                noData = false;
            }
            if (noData)
            {
                PrintMessage("Res seleccionat");
            }
        }

        private void HighlightButton(Button btn)
        {
            foreach (Control ctrl in RightMenu.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    ctrl.BackColor = Color.FromArgb(24, 30, 54);
                }
            }
            btn.BackColor = Color.FromArgb(46, 51, 73);
        }
    }
}
