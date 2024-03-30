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
    public partial class FormLinking : Form
    {
        bool NeedToSave = false;

        public FormLinking()
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
            dgvChains.Rows.Clear();
            dgvChains.ColumnCount = 7;
            dgvChains.AllowUserToAddRows = false;
            dgvChains.MultiSelect = false;

            // IDarticle, date, prev, title, next

            dgvChains.Columns[0].Name = "ID";
            dgvChains.Columns[0].Width = 40;
            dgvChains.Columns[1].Name = "Data.";
            dgvChains.Columns[1].Width = 100;
            dgvChains.Columns[2].Name = "Previ";
            dgvChains.Columns[2].Width = 40;
            dgvChains.Columns[3].Name = "Títol";
            dgvChains.Columns[3].Width = 300;
            dgvChains.Columns[4].Name = "Següent";
            dgvChains.Columns[4].Width = 40;
            dgvChains.Columns[5].Name = "Mod";
            dgvChains.Columns[5].Width = 30;
            dgvChains.Columns[6].Name = "Section";
            dgvChains.Columns[6].Width = 60;
        }

        private void FillTabChained()
        {
            dgvChains.Rows.Clear();
            List<string[]> list = Readers.GetChained();
            if (list == null || list.Count == 0) return;

            int i = 0;
            foreach (string[] sa in list)
            {
                dgvChains.Rows.Add(sa);
                if (dgvChains.Rows[i].Cells[2].Value.ToString() == "0")
                {
                    dgvChains.Rows[i].Cells[2].Style.BackColor = Color.LightPink;
                }
                if (dgvChains.Rows[i].Cells[4].Value.ToString() == "0")
                {
                    dgvChains.Rows[i].Cells[4].Style.BackColor = Color.LightPink;
                }
                i += 1;
            }
        }

        private void btnChainSave_Click(object sender, EventArgs e)
        {
            if (dgvChains.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (Writers.UpdateChains(dgvChains))
                {
                    PrintMessage("Actualització correcta");
                    FillTabChained();
                    btnChainSave.Enabled = false;
                }
                Cursor.Current = Cursors.Default;
            }
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

        // ---------------------------------------------------------------------------
        // Events
        // on grid cell click
        // ---------------------------------------------------------------------------

        private void SetMode(int mode)
        {
            /* ??????
             * How to access lblMode from this form
             * 
            switch (mode)
            {
                case Modes.Status.INSERT:
                    Gdata.maintMode = mode;
                    lblMode.Text = Modes.Text.INSERT;
                    break;

                case Modes.Status.QUERY:
                    Gdata.maintMode = mode;
                    lblMode.Text = Modes.Text.QUERY;
                    break;
            }
            */
        }

        private void dgvChain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ???
            if (e.RowIndex < 0) return;

            // Get the article selected and fill the header
            int IDarticle = Int32.Parse(dgvChains.Rows[e.RowIndex].Cells[0].Value.ToString());
            dgvChains.Rows[e.RowIndex].Cells[5].Value = Marks.MODIFIED;
            // local context changes
            btnChainSave.Enabled = true;
            SetMode(Modes.Status.MODIFY);
            NeedToSave = true;
        }
    }
}
