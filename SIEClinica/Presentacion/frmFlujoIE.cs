using Microsoft.VisualBasic;
using SIEClinica.Datos;
using SIEClinica.Logica;
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
    public partial class frmFlujoIE : Form
    {
        public frmFlujoIE()
        {
            InitializeComponent();
            optIngreso.Checked = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validaDatosCobro() == true)
            {
                EjecutaFlujo();
            }            
        }
        private bool validaDatosCobro()
        {
            if (txtImporte.Text.Trim() == "")
            {
                txtImporte.Text = "0";                
            }
            try
            {
                double importe;
                importe = Convert.ToDouble(txtImporte.Text);
                if(importe <= 0)
                {
                    MessageBox.Show("Ingrese un importe mayor a cero");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void EjecutaFlujo()
        {
            LFlujo parametros = new LFlujo();
            DFlujo funcion = new DFlujo();
            parametros.IdVenta = 0;
            parametros.IdCita = 0;
            parametros.IdFlujo = 0;
            parametros.IdCobdet = 0;
            parametros.Fecha = Convert.ToDateTime(String.Format(dtFecha.Value.ToString("yyyy-MM-dd")));
            parametros.Concepto = "Flujo";
            parametros.Concepto2 = txtConcepto.Text.Trim();
            if (optIngreso.Checked == true)
            {
                parametros.IE = "I";
            }
            else
            {
                parametros.IE = "E";
            }
            parametros.Importe = Convert.ToDouble(txtImporte.Text);
            parametros.Estatus = "";
            parametros.Usuario = "SUP";
            parametros.Usufecha = DateTime.Now.ToString("yyyyMMdd");
            parametros.Usuhora = "00:00";
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarFlujo(parametros) == true)
            {
                Dispose();
            }
            else
            {
                MessageBox.Show("Error, no se confirmó el registro de flujo de caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
