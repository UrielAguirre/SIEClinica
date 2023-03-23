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
    public partial class ControlCalendario : UserControl
    {
        public ControlCalendario()
        {
            InitializeComponent();
        }

        private void btnNavegar_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate("www.google.com.mx");
        }
    }
}
