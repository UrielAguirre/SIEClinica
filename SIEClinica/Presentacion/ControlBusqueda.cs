using SIEClinica.Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SIEClinica.Presentacion
{
    public partial class ControlBusqueda : UserControl
    {
        public ControlBusqueda()
        {
            InitializeComponent();
            
        }

        public void LlenaGrid(string strQuery, int iTop, int iLeft)
        {
            string valor = "";

            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(strQuery, ConexionBD.conectar);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dtgBusqueda.Top = iTop;
                dtgBusqueda.Left = iLeft;
                dtgBusqueda.DataSource = dt;
                dtgBusqueda.Visible = true;

                dtgBusqueda.Columns[0].Width = 100;
                dtgBusqueda.Columns[1].Width = 300;

                dtgBusqueda.Focus();
                MessageBox.Show("p");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                ConexionBD.Cerrar();
            }                        
        }      

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Visible = false;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            claveBusqueda();
        }

        private string claveBusqueda()
        {
            string strClave = "";

            strClave = "" + dtgBusqueda[0, dtgBusqueda.CurrentCell.RowIndex].Value;

            return strClave;

        }
    }
}
