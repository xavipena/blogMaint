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
            dgvTranslations.Columns[1].Width = 360;
            dgvTranslations.Columns[2].Name = "Català";
            dgvTranslations.Columns[2].Width = 360;
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

            bool noData = true;
            foreach (DataGridViewRow row in dgvTranslations.SelectedRows)
            {
                noData = false;
            }
            if (noData)
            {
                lblMessage.Text = "Res seleccionat";
            }

        }

        private void btnca_ES_Click(object sender, EventArgs e)
        {
            if (dgvTranslations.Rows.Count == 0) return;

            bool noData = true;
            foreach (DataGridViewRow row in dgvTranslations.SelectedRows)
            {
                noData = false;
            }
            if (noData)
            {
                lblMessage.Text = "Res seleccionat";
            }

        }
    }
}
