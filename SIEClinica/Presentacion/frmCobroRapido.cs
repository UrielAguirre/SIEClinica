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
    public partial class frmCobroRapido : Form
    {
        int nVenta = Convert.ToInt32(Ambiente.var2);
        int idCita = Convert.ToInt32(Ambiente.var5);
        double cambio, iImporte, iPago1, iPago2, iPago3;
        string sPaciente = "";
        string sNombrePaciente = "";
        public frmCobroRapido()
        {
            InitializeComponent();
            iImporte = Convert.ToDouble(Ambiente.var1);
            iPago1 = Convert.ToDouble(Ambiente.var1);
            iPago2 = 0;
            iPago3 = 0;

            txtImporte.Text = Convert.ToDouble(Ambiente.var1).ToString("N");
            txtIPago1.Text = Convert.ToDouble(Ambiente.var1).ToString("N");
            Ambiente.var1 = "";
            Ambiente.var2 = "";

            sPaciente = ""+ Ambiente.var3;
            Ambiente.var3 = "";
            sNombrePaciente = "" + Ambiente.var4;
            Ambiente.var4 = "";
            Ambiente.var5 = "";
        }              
        private string DaFormato(double valor)
        {
            string valorResultante="0.00";
            try
            {
                valorResultante = Convert.ToDouble(valor).ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return valorResultante;
        }
        private void txtIPago1_Leave(object sender, EventArgs e)
        {
            if (txtIPago1.Text.Trim() == "")
            {                
                iPago1 = 0;
            }
            else
            {
                iPago1 = Convert.ToDouble(txtIPago1.Text);
            }
            
            txtIPago1.Text = DaFormato(iPago1);
        }
        private void txtIPago2_Leave(object sender, EventArgs e)
        {
            if (txtIPago2.Text.Trim() == "")
            {
                iPago2 = 0;
            }
            else
            {
                iPago2 = Convert.ToDouble(txtIPago2.Text);
            }
            txtIPago2.Text = DaFormato(iPago2);
        }
        private void txtIPago3_Leave(object sender, EventArgs e)
        {
            if (txtIPago3.Text.Trim() == "")
            {
                iPago3 = 0;
            }
            else
            {
                iPago3 = Convert.ToDouble(txtIPago3.Text);
            }
            txtIPago3.Text = DaFormato(iPago3);
        }
        private void txtIPago1_TextChanged(object sender, EventArgs e)
        {
            calculaCambio();
        }
        private void txtIPago2_TextChanged(object sender, EventArgs e)
        {
            calculaCambio();
        }       
        private void txtIPago3_TextChanged(object sender, EventArgs e)
        {
            calculaCambio();
        }
        private void btnAtrasVentas_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            validaDatosCobro();
            EjecutaCobro();
        }
        private void validaDatosCobro()
        {

            if (txtIPago1.Text.Trim() == "")
            {
                txtIPago1.Text = "0";
            }
            if (txtIPago2.Text.Trim() == "")
            {
                txtIPago2.Text = "0";
            }
            if (txtIPago3.Text.Trim() == "")
            {
                txtIPago3.Text = "0";
            }
            if (txtCambio.Text.Trim() == "")
            {
                txtCambio.Text = "0";
            }
        }
        private void EjecutaCobro()
        {           
            LCobroRapido parametros = new LCobroRapido();
            DCobroRapido funcion = new DCobroRapido();
            parametros.nVenta = nVenta;
            parametros.idCita = idCita;
            parametros.sPaciente = sPaciente;
            parametros.nombrePaciente = sNombrePaciente;            
            parametros.sFPago1 = txtPago1.Text.Trim();
            parametros.sFPago2 = txtPago2.Text.Trim();
            parametros.sFPago3 = txtPago3.Text.Trim();
            parametros.iImporte1 = Convert.ToDouble(txtIPago1.Text);
            parametros.iImporte2 = Convert.ToDouble(txtIPago2.Text);
            parametros.iImporte3 = Convert.ToDouble(txtIPago3.Text);            
            if (Convert.ToDouble(txtCambio.Text) > 0)
            {
                parametros.iCambio = Convert.ToDouble(txtCambio.Text);
                parametros.iImporteCxC = 0;
            }
            else
            {
                parametros.iCambio = 0;
                parametros.iImporteCxC = Convert.ToDouble(txtCambio.Text)*-1;
            }
            //MessageBox.Show("" + Convert.ToDouble(txtCambio.Text) * -1);

            parametros.Usuario = "SUP";
            parametros.Usufecha = DateTime.Now.ToString("yyyyMMdd");
            parametros.Usuhora = "00:00";
            parametros.Estacion = "ESTACION01";

            if (funcion.CobraVenta(parametros) == true)
            {
                Dispose();                
            }
            else
            {
                MessageBox.Show("Error, no se confirmó la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }               
        private void calculaCambio()
        {            
            try
            {   
                cambio = (iPago1 + iPago2 + iPago3) - iImporte;
                txtCambio.Text = cambio.ToString("N");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }            
        }              
        private void txtIPago1_KeyPress_1(object sender, KeyPressEventArgs e)
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
        private void txtIPago2_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtIPago3_KeyPress(object sender, KeyPressEventArgs e)
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
