using Microsoft.VisualBasic;
using Microsoft.Win32;
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
    public partial class ControlEntradaSalidaInv : UserControl
    {
        int IdInventario = 0;
        bool bloqueado;
        int esInventariable = 0;
        public ControlEntradaSalidaInv(int IdInventario)
        {
            InitializeComponent();

            this.IdInventario = IdInventario;
            
            llenaCombos();
            
            optEntrada.Checked = true;
            bloqueado = true;
            
           if (llenaDatosInventario() == true)
           {                
                LlenaGrid();
           }
        }
        private void llenaCombos()
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select Concepto, Descrip From conceptosMovsInv Order By descrip", ConexionBD.conectar);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                DataRow fila = dt.NewRow();
                fila["Descrip"] = "Selecciona un concepto";
                dt.Rows.InsertAt(fila, 0);

                cmbConcepto.ValueMember = "Concepto";
                cmbConcepto.DisplayMember = "Descrip";
                cmbConcepto.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
            finally
            {                
                ConexionBD.Cerrar();
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
            //MessageBox.Show("" + IdInventario);
            InsertarPartida();
            
        }

        private void InsertarPartida()
        {
            LInventario parametros = new LInventario();
            DInventario funcion = new DInventario();
            //MessageBox.Show(IdInventario.ToString());
            parametros.IdInventario = IdInventario;
            parametros.Estado = "PE";
            if (optEntrada.Checked == true)
            {
                parametros.Ent_Sal = "EN";
            }
            else
            {
                parametros.Ent_Sal = "SA";
            }

            parametros.Concepto = cmbConcepto.SelectedValue.ToString();
            parametros.ConceptoDescrip = cmbConcepto.SelectedText;
            parametros.Fecha = dtFecha.Value;
            parametros.Importe = Convert.ToDouble(lblImporte.Text) + Convert.ToDouble(txtPrecio.Text);
            parametros.Impuesto = 0;

            parametros.Articulo = txtArticulo.Text;
            parametros.Descrip = txtDescrip.Text;
            parametros.Cantidad = Convert.ToDouble(txtCantidad.Text);
            parametros.Precio1 = Convert.ToDouble(txtPrecio.Text);
            parametros.Invent = esInventariable;

            parametros.Usuario = "SUP";
            parametros.UsuFecha = DateTime.Now;
            parametros.UsuHora = Convert.ToDateTime("00:00");
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarPartidaInventario(parametros) == true)
            {
                LimpiarPanelMovInv();
                IdInventario = Convert.ToInt32(Ambiente.var1);
                Ambiente.var1 = "";
                LlenaGrid();
                lblUnidades.Text = funcion.CalculaUnidades(IdInventario).ToString();
                lblImporte.Text = funcion.CalculaImporte(IdInventario).ToString();
            }
            else
            {
                MessageBox.Show("Error, no se guardó el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LlenaGrid()
        {
            try
            {
                //MessageBox.Show(nVenta.ToString());
                string strSQL = "";
                strSQL = strSQL + "Select Descrip As 'Descripción', Cantidad, Costo, (costo * cantidad) As Importe, Articulo, id From EntSalPart Where idMovimiento = " + IdInventario;
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

                dtgProductos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgProductos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgProductos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select Sum(cantidad * costo) As i From EntSalPart Where idMovimiento = " + IdInventario, ConexionBD.conectar);

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
                SqlCommand cmd1 = new SqlCommand("Select estado From EntradasSalidas Where Id = " + IdInventario, ConexionBD.conectar);
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.Read())
                {
                    lblEstado.Text = "" + reader["Estado"].ToString();
                }
                else
                {
                    lblEstado.Text = "PE";
                }

                if (lblEstado.Text == "CO")
                {
                    btnAdd.Enabled = false;
                    btnConfirmar.Enabled = false;
                    dtgProductos.Enabled = false;
                    txtArticulo.Enabled = false;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnConfirmar.Enabled = true;
                    dtgProductos.Enabled = true;
                    txtArticulo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ' ' + ex.StackTrace);
            }
            finally
            {
                ConexionBD.Cerrar();
            }
        }              
               
        private void regresaAlControlPrincipal()
        {
            this.Controls.Clear();

            ControlInventario control = new ControlInventario();
            this.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void consultaDatosProducto(string cProducto)
        {
            string strSQL = "";
            strSQL = strSQL + "Select ";
            strSQL = strSQL + "producto, descrip, precio1, unidad, foto, invent ";
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
                    esInventariable = Convert.ToInt32(registro["invent"].ToString());
                    txtCantidad.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);

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
                    eliminaRegistro(Convert.ToInt32(dtgProductos.SelectedCells[5].Value));
                }
            }
        }

        private void eliminaRegistro(int id)
        {
            try
            {
                string strSQL = "";
                strSQL = strSQL + "Delete From EntSalPart Where id = " + id;

                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                cmd.ExecuteNonQuery();
                DInventario funcion = new DInventario();
                lblUnidades.Text = funcion.CalculaUnidades(IdInventario).ToString();
                lblImporte.Text = funcion.CalculaImporte(IdInventario).ToString();
                LlenaGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                ConexionBD.Cerrar();
            }
        }

        private void LimpiarPanelMovInv()
        {
            txtArticulo.Clear();
            txtPrecio.Clear();
            txtCantidad.Text = "1";
            txtDescrip.Text = "";
            txtUnidad.Clear();
            txtArticulo.Focus();
        }

        private bool llenaDatosInventario()
        {
            bool sinError;
            sinError = true;
            SqlCommand cmd;
            SqlDataReader Registros;
            try
            {
                ConexionBD.Abrir();
                cmd = new SqlCommand("Select * From EntradasSalidas Where id = " + IdInventario, ConexionBD.conectar);
                Registros = cmd.ExecuteReader();

                if (Registros.Read())
                {
                    lblEstado.Text= Registros["Estado"].ToString();
                    cmbConcepto.SelectedValue = Registros["concepto"].ToString();
                    cmbConcepto.SelectedText = Registros["conceptoDescrip"].ToString();
                    if (Registros["Ent_Sal"].ToString() == "EN")
                    {
                        optEntrada.Checked = true;
                    }
                    else
                    {
                        optSalida.Checked = true;
                    }
                    
                    if(lblEstado.Text == "CO")
                    {
                        Bloquea();
                    }
                    cmd.Dispose();
                    Registros.Close();
                    DInventario funcion = new DInventario();
                    lblUnidades.Text = funcion.CalculaUnidades(IdInventario).ToString();
                    lblImporte.Text = funcion.CalculaImporte(IdInventario).ToString();

                }
                

            }
            catch (Exception ex)
            {
                sinError = false;
                MessageBox.Show(ex.Message + " " + ex.StackTrace);                
            }
            finally
            {               
                ConexionBD.Cerrar();                
            }
            return sinError;
        }

        private void Bloquea()
        {
            btnAdd.Enabled = false;
            btnConfirmar.Enabled = false;
            txtArticulo.Enabled= false;
            //dtgProductos.Enabled= false;
            bloqueado = true;
        }

        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {

                string strQuery = "";

                if (txtArticulo.Text != "")
                {
                    strQuery = "Select Top 100 Producto, Descrip As 'Descripción', Precio1 From productos Where producto = '" + txtArticulo.Text + "'";
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
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea confirmar el movimiento de inventario?", "Inventario", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ConfirmaMovimiento();
            }
        }

        private void ConfirmaMovimiento()
        {
            LMovInvent parametros = new LMovInvent();
            DInventario funcion = new DInventario();
            //MessageBox.Show(IdInventario.ToString());
            parametros.IdInventario = IdInventario;           
            if (optEntrada.Checked == true)
            {
                parametros.Ent_Sal = "EN";
            }
            else
            {
                parametros.Ent_Sal = "SA";
            }

            parametros.Concepto = cmbConcepto.SelectedValue.ToString();
            parametros.ConceptoDescrip = cmbConcepto.SelectedText;
            parametros.Fecha = dtFecha.Value;

            parametros.Usuario = "SUP";
            parametros.UsuFecha = DateTime.Now;
            parametros.UsuHora = Convert.ToDateTime("00:00");
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarMovInventario(parametros) == true)
            {
                LimpiarPanelMovInv();
                //IdInventario = Convert.ToInt32(Ambiente.var1);
                //Ambiente.var1 = "";
                LlenaGrid();
                bloqueado = true;
            }
            else
            {
                MessageBox.Show("Error, no se guardó el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAtrasInventario_Click(object sender, EventArgs e)
        {
            IdInventario = 0;
            regresaAlControlPrincipal();
        }
    }

}
