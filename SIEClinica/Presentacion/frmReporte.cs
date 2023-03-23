using SIEClinica.Datos;
using SIEClinica.Reporte.Formatos;
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
    public partial class frmReporte : Form
    {
        public frmReporte(string cPaciente)
        {
            InitializeComponent();
            ReporteEstadoDeCuenta(cPaciente);
            //this.
        }


        private void ReporteEstadoDeCuenta(string cPaciente)
        {
            panelReporte.Visible = true;
            panelReporte.Dock = DockStyle.Fill;
            DataTable dt = new DataTable();
            DReportes.ReporteEstadoDeCuenta(ref dt, Convert.ToDateTime("01-01-2000"), Convert.ToDateTime("01-01-2024"), cPaciente);

            ReporteEstadoDeCuenta rpt = new ReporteEstadoDeCuenta();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            reportViewer1.Report = rpt;
            reportViewer1.RefreshReport();
        }
    }
}
