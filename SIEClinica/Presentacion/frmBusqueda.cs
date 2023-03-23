using SIEClinica.Datos;

using System;
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
    public partial class frmBusqueda : Form
    {
        public frmBusqueda(string strQuery, int iTop, int iLeft)
        {
            InitializeComponent();            
            LlenaGrid(strQuery, iTop, iLeft);
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
                this.Top = iTop;
                this.Left = iLeft;
                dtgBusqueda.Top = iTop;
                dtgBusqueda.Left = iLeft;
                dtgBusqueda.DataSource = dt;
                dtgBusqueda.Visible = true;

                dtgBusqueda.Columns[0].Width = 100;
                dtgBusqueda.Columns[1].Width = 300;

                dtgBusqueda.Focus();
                
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

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Ambiente.var1 = claveSeleccionada();
            Dispose();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Dispose();            
        }

        private string claveSeleccionada()
        {
            string strClave = "";

            strClave = "" + dtgBusqueda[0, dtgBusqueda.CurrentCell.RowIndex].Value.ToString();

            return strClave;
        }

        private void dtgBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ambiente.var1 = claveSeleccionada();
            Dispose();
        }

        private void dtgBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Ambiente.var1 = claveSeleccionada();
                Dispose();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }



    }
}
