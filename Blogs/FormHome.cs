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
    public partial class FormHome : Form
    {
        Form1 startForm;
        public FormHome()
        {
            InitializeComponent();
            // Make it rounded
            RoundBorderForm(this);
        }

        public static void RoundBorderForm(Form frm)
        {

            Rectangle Bounds = new Rectangle(0, 0, frm.Width, frm.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            frm.Region = new Region(path);
            frm.Show();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            this.Opacity = 0.0;
            timer1.Start();
            lblLoading.Text = "Carregant";
            // start loading
            startForm = new Form1();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05; // +5% 
            progressBar1.Value += 1;
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1; // -10%
            if (this.Opacity == 0)
            {
                timer2.Stop();
                this.Hide();
                startForm.Show();
            }
        }
    }
}
