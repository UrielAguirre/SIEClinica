using SIEClinica.Datos;
using SIEClinica.Informes.Reportes;
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
    public partial class ControlReportes : UserControl
    {
        public ControlReportes()
        {
            InitializeComponent();
            btnCxCDet.Visible = false;
        }
        string reporteSeleccionado = "";
        private void ReporteVentastotalizado()
        {
            DataTable dt = new DataTable();
            DReportes.ReporteVentasTotalizadas(ref dt, dtFechaInicial.Value, dtFechaFinal.Value, txtProducto.Text, txtCliente.Text);

            ReporteVentasTotalizada rpt = new ReporteVentasTotalizada();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }

        private void ReporteVentasDetallado()
        {
            DataTable dt = new DataTable();
            DReportes.ReporteVentasDetallado(ref dt, dtFechaInicial.Value, dtFechaFinal.Value, txtProducto.Text, txtCliente.Text);

            ReporteVentasDetallado rpt = new ReporteVentasDetallado();
            //groupHeaderSection1.DataSource = dt;
             rpt.table1.DataSource = dt;
            rpt.table2.DataSource = dt;
            //rpt.crosstab2.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }

        private void ReporteProductos()
        {
            DataTable dt = new DataTable();
            DReportes.ReporteProductos(ref dt);

            ReporteProductos rpt = new ReporteProductos();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }

        private void ReporteMedicos()
        {
            DataTable dt = new DataTable();
            DReportes.ReporteMedicos(ref dt);

            ReporteMedicos rpt = new ReporteMedicos();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }

        private void ReportePacientes()
        {
            DataTable dt = new DataTable();
            DReportes.ReportePacientes(ref dt);

            ReportePacientes rpt = new ReportePacientes();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }
               

        private void ReporteExistencias()
        {
            DataTable dt = new DataTable();
            DReportes.ReporteExistencias(ref dt);

            ReporteExistencias rpt = new ReporteExistencias();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }

        private void ReporteCxC()
        {
            DataTable dt = new DataTable();
            DReportes.ReporteCxC(ref dt, dtFechaInicial.Value, dtFechaFinal.Value, txtCliente.Text);

            ReporteCxC rpt = new ReporteCxC();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }

        private void ReporteEstadoDeCuenta()
        {
            DataTable dt = new DataTable();
            DReportes.ReporteEstadoDeCuenta(ref dt, dtFechaInicial.Value, dtFechaFinal.Value, txtCliente.Text);

            ReporteEstadoDeCuenta rpt = new ReporteEstadoDeCuenta();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }

        private void ReporteKardex()
        {
            DataTable dt = new DataTable();
            DReportes.ReporteKardex(ref dt, dtFechaInicial.Value, dtFechaFinal.Value, txtProducto.Text);

            ReporteKardex rpt = new ReporteKardex();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;

            rptViewVentas.Report = rpt;
            rptViewVentas.RefreshReport();
        }

        private void btnRepVentas_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch(reporteSeleccionado)
            {
                case ("VentasTotalizado"):
                    ReporteVentastotalizado();
                    break;
                case ("VentasDetallado"):
                    ReporteVentasDetallado();
                    break;

                case ("CatalogoProductos"):
                    ReporteProductos();
                    break;

                case ("Existencias"):
                    ReporteExistencias();
                    break;

                case ("CxC"):
                    ReporteCxC();
                    break;

                case ("Kardex"):                    
                    ReporteKardex();
                    break;

                case ("Medicos"):
                    ReporteMedicos();
                    break;
                case ("Pacientes"):
                    ReportePacientes();
                    break;
                case ("CxCDetallado"):
                    //ReporteKardex();
                    break;

                case ("EstadoDeCuenta"):
                    ReporteEstadoDeCuenta();
                    break;

                    
                default:
                    break;



            }
            
        }

        private void btnVentasTotalizado_Click(object sender, EventArgs e)
        {
            reporteSeleccionado = "VentasTotalizado";
            configuraParametros(true, true, true, true);
        }
              
        private void btnCxC_Click(object sender, EventArgs e)
        {
            reporteSeleccionado = "CxC";
            configuraParametros(true, true, false, false);
        }
        private void btnKardex_Click(object sender, EventArgs e)
        {
            reporteSeleccionado = "Kardex";
            configuraParametros(true, false, true, false);
        }
        private void btnReporteExistencias_Click_1(object sender, EventArgs e)
        {
            reporteSeleccionado = "Existencias";
            configuraParametros(false, false, true, false);
        }
             

        private void btnCatalogoProductos_Click_1(object sender, EventArgs e)
        {
            reporteSeleccionado = "CatalogoProductos";
            configuraParametros(false, false, true, false);
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {            
            reporteSeleccionado = "Medicos";
            configuraParametros(false, false, false, true);
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            reporteSeleccionado = "Pacientes";
            configuraParametros(false, true, false, false);
        }

        private void btnRepInventario_Click(object sender, EventArgs e)
        {

        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {

        }

        private void btnVentasDetalle_Click(object sender, EventArgs e)
        {
            reporteSeleccionado = "VentasDetallado";
            configuraParametros(true, true, true, true);
        }

        private void btnRepCobranza_Click(object sender, EventArgs e)
        {

        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            reporteSeleccionado = "EstadoDeCuenta";
            configuraParametros(true, true, false, false);
        }

        private void configuraParametros(bool fechas, bool pacientes, bool productos, bool medicos)
        {
            if(fechas== true)
            {
                label9.Visible = true;
                label1.Visible = true;
                dtFechaInicial.Visible = true;
                dtFechaFinal.Visible = true;
            }
            else
            {
                label9.Visible = false;
                label1.Visible = false;
                dtFechaInicial.Visible = false;
                dtFechaFinal.Visible = false;
            }

            if (pacientes == true)
            {
                label2.Visible = true;
                txtCliente.Visible = true;
                panel4.Visible = true;
            }
            else
            {
                label2.Visible = false;
                txtCliente.Visible = false;
                panel4.Visible = false;
            }

            if (productos == true)
            {
                lblFiltro.Visible = true;
                txtProducto.Visible = true;
                panel3.Visible = true;
            }
            else
            {
                lblFiltro.Visible = false;
                txtProducto.Visible = false;
                panel3.Visible = false;
            }

            if (medicos == true)
            {
                label3.Visible = true;
                txtMedico.Visible = true;
                panel6.Visible = true;
            }
            else
            {
                label3.Visible = false;
                txtMedico.Visible = false;
                panel6.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            configuraParametros(true, true, true, true);
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                string strQuery = "";

                if (txtProducto.Text != "")
                {
                    strQuery = "Select Top 100 Producto, Descrip As 'Descripción', Precio1 From productos Where (producto + ' ' + Descrip) like '%" + txtProducto.Text + "%'";
                }
                else
                {
                    strQuery = "Select Top 100 Producto, Descrip As 'Descripción', Precio1 From productos";
                }
                frmBusqueda busqueda = new frmBusqueda(strQuery, txtProducto.Top, txtProducto.Left);

                busqueda.ShowDialog(this);
                txtProducto.Text = Ambiente.var1;
                Ambiente.var1 = "";
               // consultaDatosProducto(txtProducto.Text);

            }
        }

        private void txtMedico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                string strQuery = "";

                if (txtProducto.Text != "")
                {
                    strQuery = "Select Top 100 Medico, Nombre From medicos Where (medico + ' ' + nombre) like '%" + txtMedico.Text + "%'";
                }
                else
                {
                    strQuery = "Select Top 100 Medico, Nombre From medicos";
                }
                frmBusqueda busqueda = new frmBusqueda(strQuery, txtMedico.Top, txtMedico.Left);

                busqueda.ShowDialog(this);
                txtMedico.Text = Ambiente.var1;
                Ambiente.var1 = "";
                // consultaDatosProducto(txtProducto.Text);

            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                string strQuery = "";

                if (txtProducto.Text != "")
                {
                    strQuery = "Select Top 100 Paciente, Nombre From pacientes Where (paciente + ' ' + nombre) like '%" + txtCliente.Text + "%'";
                }
                else
                {
                    strQuery = "Select Top 100 Paciente, Nombre From pacientes";
                }
                frmBusqueda busqueda = new frmBusqueda(strQuery, txtCliente.Top, txtCliente.Left);

                busqueda.ShowDialog(this);
                txtCliente.Text = Ambiente.var1;
                Ambiente.var1 = "";
                // consultaDatosProducto(txtProducto.Text);

            }

        }
    }
}
