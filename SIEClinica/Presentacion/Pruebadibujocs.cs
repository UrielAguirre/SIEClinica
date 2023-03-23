using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIEClinica.Presentacion
{
    public partial class Pruebadibujocs : Form
    {
        private Point m_posTrazo;
        private Bitmap m_goma;
        public Pruebadibujocs()
        {
            InitializeComponent();
        }

        private void Pruebadibujocs_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(@"c:\00918L.jpeg");
            checkBox1.Text = "Goma";

            m_goma = new Bitmap(8, 8);
            Graphics g = Graphics.FromImage(m_goma);
            GraphicsUnit gu = GraphicsUnit.Pixel;
            g.FillRectangle(Brushes.White, m_goma.GetBounds(ref gu));
            g.Dispose();
        }

        private void Borra()
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.DrawImage(m_goma, m_posTrazo.X - 4, m_posTrazo.Y - 4);
            g.Dispose();
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (checkBox1.Checked)
                {
                    m_posTrazo = e.Location;
                    Borra();
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            m_posTrazo = e.Location;
            if (checkBox1.Checked) Borra();
        }
    }
}
