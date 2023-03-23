using Microsoft.VisualBasic;
using SIEClinica.Datos;
using SIEClinica.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIEClinica.Presentacion
{
    public partial class ControlVender : UserControl
    {
        int nVenta = 0;
        int IdCita = 0;
        int esInventariable = 0;
        public ControlVender( int IdCita, int nVenta, bool esDirecta)
        {
            InitializeComponent();
            this.nVenta = nVenta;
            this.IdCita = IdCita;

            if (esDirecta == true)
            {
                txtPaciente.ReadOnly = false;
                txtPaciente.Text = "SYS";
                txtNombrePaciente.Text = "Venta al Público en General";
            }
            if (llenaDatosCita() == true)
            {
                LlenaGrid();
            }
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(txtPrecio.Text))
            {
                MessageBox.Show("Ingrese un valor numérico en el precio");
                return;

            }
            if (Convert.ToDouble(txtPrecio.Text) <= 0)
            {
                MessageBox.Show("Ingrese un precio mayor a cero");
                return;
            }

            if (Convert.ToDouble(txtCantidad.Text) <= 0)
            {
                MessageBox.Show("Ingrese un precio mayor a cero");
                return;
            }

            if (txtDescrip.Text.Length == 0)
            {
                MessageBox.Show("Ingrese un producto o servicio válido");
                txtArticulo.Focus();
                return;
            }

            InsertarVenta();
        }
        private void InsertarVenta()
        {
            LVentas parametros = new LVentas();
            DVentas funcion = new DVentas();
            parametros.Venta = nVenta;
            parametros.Paciente = txtPaciente.Text;
            parametros.nombrePaciente = txtNombrePaciente.Text;
            parametros.Fecha = DateTime.Now;
            parametros.Fecha_venc = DateTime.Now;
            parametros.No_Referen = 0;
            parametros.Importe = Convert.ToDouble(lblImporte.Text) + Convert.ToDouble(txtPrecio.Text);
            parametros.Impuesto = 0;
            parametros.Estado = "PE";
            parametros.Cobranza = 0;
            parametros.idCita = IdCita;
            parametros.Usuario = "SUP";
            parametros.UsuFecha = DateTime.Now;
            parametros.UsuHora = Convert.ToDateTime("00:00");
            parametros.Estacion = "ESTACION01";

            parametros.Producto = txtArticulo.Text;
            parametros.Descrip = txtDescrip.Text;
            parametros.Precio = Convert.ToDouble(txtPrecio.Text);
            parametros.Cantidad = Convert.ToDouble(txtCantidad.Text);
            parametros.ImpuestoU = 0;
            parametros.DescuentoU = 0;
            parametros.Invent = esInventariable;
            parametros.Observ = txtObserv.Text;

            if (funcion.InsertarVenta(parametros) == true)
            {
                nVenta = Convert.ToInt32(Ambiente.var1);
                LimpiarPanelVender();
                LlenaGrid();
                Ambiente.var1 = "";

                //MostrarMedico();
                //PanelMedicosReg.Visible = false;
                //MessageBox.Show("Médico guardado correctamente", "Guarda registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, no se guardó la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LlenaGrid()
        {
            try
            {
                //MessageBox.Show(nVenta.ToString());
                string strSQL = "";
                strSQL = strSQL + "Select Descrip As 'Descripción', Cantidad, Precio, (precio * cantidad) As Importe, id From partvta Where venta = " + nVenta;
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgProductos.DataSource = dt;

                dtgProductos.Columns[0].Width = 450;
                dtgProductos.Columns[1].Width = 100;
                dtgProductos.Columns[2].Width = 100;
                dtgProductos.Columns[3].Width = 100;
                dtgProductos.Columns[4].Visible = false;

                dtgProductos.Columns[2].DefaultCellStyle.Format = "N";
                dtgProductos.Columns[3].DefaultCellStyle.Format = "N";

                dtgProductos.Columns[1].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
                dtgProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select Sum(cantidad * precio) As i From partvta Where venta = " + nVenta, ConexionBD.conectar);

                lblImporte.Text = cmd.ExecuteScalar().ToString();
                if (lblImporte.Text.Trim() == "")
                {
                    lblImporte.Text = "0.00";
                }
                else
                {
                    lblImporte.Text = DaFormato(Convert.ToDouble(lblImporte.Text));
                }

                ConexionBD.Abrir();
                SqlCommand cmd1 = new SqlCommand("Select estado From ventas Where venta = " + nVenta, ConexionBD.conectar);
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.Read())
                {
                    lblEstado.Text = "" + reader["Estado"].ToString();
                }
                else
                {
                    lblEstado.Text = "PE";
                }
                
                if(lblEstado.Text =="CO")
                {
                    btnAdd.Enabled = false;
                    btnCobrar.Enabled = false;
                    dtgProductos.Enabled = false;
                    txtArticulo.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnCobrar.Enabled = true;
                    dtgProductos.Enabled = true;
                    txtArticulo.Enabled = true;
                }
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
        private void btnCredito_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opción en desarrollo");
        }
        private void RegresaDeGuardar()
        {
            //PanelReg.Visible = false;
           // PanelPaginado.Visible = true;
            //PanelBusqueda.Visible = true;
            //dtgRegistros.Visible = true;
            //panelVender.Visible = false;
            //BuscarCitas();
            IdCita = 0;
           // txtBuscador.Focus();
        }
        private void btnAtrasVentas_Click_1(object sender, EventArgs e)
        {
            nVenta = 0;           
            IdCita = 0;
            regresaAlControlPrincipal();
        }
        private void regresaAlControlPrincipal()
        {
            this.Controls.Clear();

            ControlCitaAdd control = new ControlCitaAdd();
            this.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }       
        private void consultaDatosProducto(string cProducto)
        {
            string strSQL = "";
            strSQL = strSQL + "Select ";
            strSQL = strSQL + "producto, descrip, precio1, unidad, foto, Invent ";
            strSQL = strSQL + "From productos Where producto = '" + cProducto + "'";
            try
            {
                ConexionBD.Abrir();

                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.Read())
                {
                    txtPrecio.Text = Convert.ToDouble(registro["precio1"].ToString()).ToString("##,##0.00");
                    txtDescrip.Text = registro["descrip"].ToString();
                    txtUnidad.Text = registro["unidad"].ToString();
                    txtCantidad.Text = "1";
                    txtCantidad.Focus();
                    esInventariable = Convert.ToInt32(registro["invent"].ToString());
                }

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
        private void dtgProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el artículo seleccionado?", "Elimina registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta.Equals(DialogResult.Yes))
                {
                    eliminaRegistro(Convert.ToInt32(dtgProductos.SelectedCells[4].Value));
                }
            }
        }       
        private void eliminaRegistro(int id)
        {
            try
            {
                string strSQL = "";
                strSQL = strSQL + "Delete From partvta Where id = " + id;

                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                cmd.ExecuteNonQuery();
                DVentas funcion = new DVentas();
                funcion.CalculaImportesVenta(nVenta);
                LlenaGrid();

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
        private void LimpiarPanelVender()
        {
            txtArticulo.Clear();
            txtPrecio.Clear();
            txtCantidad.Text = "1";
            txtDescrip.Text = "";
            txtUnidad.Clear();
            txtObserv.Clear();
            txtArticulo.Focus();
        }
        private bool llenaDatosCita()
        {
            bool sinError;
            sinError = true;
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select * From citas Where id = " + IdCita, ConexionBD.conectar);
                SqlDataReader Registros = cmd.ExecuteReader();

                if (Registros.Read())
                {                                      
                    txtPaciente.Text = Registros["paciente"].ToString();
                    txtNombrePaciente.Text = Registros["nombrePaciente"].ToString();                    
                }
            }
            catch (Exception ex)
            {
                sinError = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBD.Cerrar();                
            }
            return sinError;
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            //panelPrincipal.Controls.Clear();
            Ambiente.var1 = lblImporte.Text;
            Ambiente.var2 = nVenta.ToString();
            Ambiente.var3 = txtPaciente.Text;
            Ambiente.var4 = txtNombrePaciente.Text;
            Ambiente.var5 = IdCita.ToString();
            frmCobroRapido cobro = new frmCobroRapido();
            cobro.ShowDialog();
            regresaAlControlPrincipal();

        }
        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                string strQuery = "";

                if (txtArticulo.Text != "")
                {
                    strQuery = "Select Top 100 Producto, Descrip As 'Descripción', Precio1 From productos Where (producto + ' ' + Descrip) like '%" + txtArticulo.Text + "%'";
                }
                else
                {
                    strQuery = "Select Top 100 Producto, Descrip As 'Descripción', Precio1 From productos";
                }
                frmBusqueda busqueda = new frmBusqueda(strQuery, txtArticulo.Top, txtArticulo.Left);

                busqueda.ShowDialog(this);
                txtArticulo.Text = Ambiente.var1;
                Ambiente.var1 = "";
                consultaDatosProducto(txtArticulo.Text);
                
            }

        }
        private string DaFormato(double valor)
        {
            string valorResultante = "0.00";
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
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCitaLigada_Click(object sender, EventArgs e)
        {
            Ambiente.var1 = IdCita.ToString();
            Ambiente.var2 = "desdeCita";
            

            this.Controls.Clear();
            ControlAltaModificaCita control = new ControlAltaModificaCita(0);
            this.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void txtPaciente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                string strQuery = "";

                if (txtPaciente.Text != "")
                {
                    strQuery = "Select Top 100 Paciente, Nombre From pacientes Where (paciente + ' ' + nombre) like '%" + txtPaciente.Text + "%'";
                }
                else
                {
                    strQuery = "Select Top 100 Paciente, Nombre From pacientes";
                }
                frmBusqueda busqueda = new frmBusqueda(strQuery, txtPaciente.Top, txtPaciente.Left);

                busqueda.ShowDialog(this);
                txtPaciente.Text = Ambiente.var1;
                Ambiente.var1 = "";
                consultaDatosPaciente(txtPaciente.Text);

            }

        }

        private void consultaDatosPaciente(string cPaciente)
        {
            string strSQL = "";
            strSQL = strSQL + "Select ";
            strSQL = strSQL + "nombre ";
            strSQL = strSQL + "From pacientes Where paciente = '" + cPaciente + "'";
            try
            {
                ConexionBD.Abrir();

                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.Read())
                {
                    txtNombrePaciente.Text = (registro["nombre"].ToString());
                    
                }

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
    
    }
}
