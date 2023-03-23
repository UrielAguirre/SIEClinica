using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIEClinica.Datos;
using SIEClinica.Logica;

namespace SIEClinica.Presentacion
{
    public partial class ControlProductos : UserControl
    {
        public ControlProductos()
        {
            InitializeComponent();
            MostrarProducto();

            hasta = itemsPorPagina;
        }
        int IdCargo = 0;        
        int contador;
        string IdP = "";
        int itemsPorPagina = 10;
        int desde = 1;
        int hasta = 10;
        int totalPaginas;

       
        private void btnPacienteAgregar_Click(object sender, EventArgs e)
        {
            DProductos funcion = new DProductos();
            string ultimoId = funcion.TraeUltimoProducto().ToString();
            if (ultimoId != "-1")
            {
                int largoId = ultimoId.Length;
                int siguienteId = Convert.ToInt32(ultimoId) + 1;

                string siguienteProducto = "";

                if (largoId == 1)
                {
                    siguienteProducto = "00" + siguienteId;
                }
                else if (largoId == 2)
                {
                    siguienteProducto = "0" + siguienteId;
                }
                else
                {
                    siguienteProducto = "" + siguienteId;
                }

                PanelPaginado.Visible = false;
                PanelReg.Visible = true;
                PanelBusqueda.Visible = false;
                dtgRegistros.Visible = false;
                Limpiar();

                txtProducto.Text = siguienteProducto;

                txtDescripcion.Focus();
            }
        }

        private void Limpiar()
        {
            txtProducto.Clear();
            txtDescripcion.Clear();
            txtCosto.Text = "0";
            txtCostoU.Text = "0";
            txtPrecio1.Text = "0";
            txtPrecio2.Text = "0";
            txtPrecio3.Text = "0";
            txtUnidad.Text = "Servicio";
            txtExistencia.Text = "0";
            txtImpuesto.Text = "SYS";
            txtLinea.Text = "SYS";           
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            RegresaDesdeGuaradar();
        }

        private void RegresaDesdeGuaradar()
        {
            PanelReg.Visible = false;
            PanelPaginado.Visible = true;
            PanelBusqueda.Visible = true;
            dtgRegistros.Visible = true;
            MostrarProducto();
            txtBuscador.Focus();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtProducto.Text)) {
                MessageBox.Show("Ingrese la clave del producto/servicio", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(String.IsNullOrEmpty(txtDescripcion.Text)){
                MessageBox.Show("Ingrese la descripción del producto/servicios", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
            else
            {
                //btnPacientesGuardar.Enabled = false;
                InsertarProducto();
                RegresaDesdeGuaradar();
                //btnPacientesGuardar.Enabled = true;
            }
        }

        private void InsertarProducto()
        {
            LProductos parametros = new LProductos();
            DProductos funcion = new DProductos();
            parametros.Producto = txtProducto.Text;
            parametros.Descripcion = txtDescripcion.Text;
            parametros.Costo = Convert.ToDouble(txtCosto.Text);
            parametros.CostoU = Convert.ToDouble(txtCostoU.Text);
            parametros.Precio1 = Convert.ToDouble(txtPrecio1.Text);
            parametros.Precio2 = Convert.ToDouble(txtPrecio2.Text);
            parametros.Precio3 = Convert.ToDouble(txtPrecio3.Text);
            parametros.Unidad = txtUnidad.Text;
            parametros.Impuesto = txtImpuesto.Text;
            parametros.Linea =txtLinea.Text;
            if (chkControlInventario.Checked == true)
            {
                parametros.Invent = 1;
            }
            else
            {
                parametros.Invent = 0;
            }
                      
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
            parametros.Foto = ms.GetBuffer();
            parametros.Estatus = "";
            parametros.Usuario = "SUP";
            parametros.usufecha = "";
            parametros.usuhora = "00:00";
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarProducto(parametros) == true)
            {
                ReinciarPaginado();
                MostrarProducto();
                //PanelPacientesReg.Visible = false;
                MessageBox.Show("Producto guardado correctamente", "Guarda registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, no se guardó el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarProducto()
        {
            DataTable dt = new DataTable();
            DProductos funcion = new DProductos();
            funcion.MostrarProductos(ref dt, desde, hasta);
            dtgRegistros.DataSource = dt;
            dtgRegistros.Columns[12].Visible = false;
            dtgRegistros.Columns[13].Visible = false;
            dtgRegistros.Columns[14].Visible = false;

            dtgRegistros.Columns[0].Width = 80;
            dtgRegistros.Columns[1].Width = 80;
            dtgRegistros.Columns[2].Width = 80;
            dtgRegistros.Columns[3].Width = 300;
            dtgRegistros.Columns[4].Width = 150;
            dtgRegistros.Columns[5].Width = 150;
            dtgRegistros.Columns[6].Width = 150;
            dtgRegistros.Columns[7].Width = 250;
            dtgRegistros.Columns[8].Width = 400;
            dtgRegistros.Columns[9].Width = 200;
            dtgRegistros.Columns[10].Width = 200;
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imágenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imágenes";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbFoto.BackgroundImage = null;
                pbFoto.Image = new Bitmap(dlg.FileName);
            }
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            desde += 10;
            hasta += 10;
            MostrarProducto();
            Contar();
            if(contador > hasta)
            {
                btnPagSiguiente.Enabled = true;
                btnPagAnterior.Enabled = true;
            }
            else
            {
                btnPagSiguiente.Enabled = false;
                btnPagAnterior.Enabled = true;
            }
            Paginar();
        }

        private void Paginar()
        {
            try
            {
                lblPagina.Text = (hasta / itemsPorPagina).ToString();
                lblTotalPaginas.Text = Math.Ceiling(Convert.ToSingle(contador) / itemsPorPagina).ToString();
                totalPaginas = Convert.ToInt32(lblTotalPaginas.Text);
            }
            catch (Exception ex)
            {

                
            }

        }
        private void Contar()
        {
            DProductos funcion = new DProductos();
            funcion.ContarProducto(ref contador);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void BuscarProductos()
        {
            DataTable dt = new DataTable();
            DProductos funcion = new DProductos();
            funcion.BuscarProductos(ref dt, desde, hasta, txtBuscador.Text);
            dtgRegistros.DataSource = dt;
        }

        private void dtgRegistros_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgRegistros.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el producto?", "Elimina producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,  MessageBoxDefaultButton.Button2);

                if (result== DialogResult.OK)
                {
                    EliminarProducto();
                }
                
            }

            if (e.ColumnIndex == dtgRegistros.Columns["Editar"].Index)
            {
                ModificaProducto();
            }


        }

        private void ModificaProducto()
        {
            PanelPaginado.Visible = false;
            PanelReg.Visible = true;
            PanelBusqueda.Visible = false;
            dtgRegistros.Visible = false;
            Limpiar();
            txtDescripcion.Focus();

            txtProducto.Text = dtgRegistros.SelectedCells[2].Value.ToString();
            txtDescripcion.Text = dtgRegistros.SelectedCells[3].Value.ToString();
            txtUnidad.Text = dtgRegistros.SelectedCells[4].Value.ToString();
            txtLinea.Text = dtgRegistros.SelectedCells[5].Value.ToString();
            txtImpuesto.Text = dtgRegistros.SelectedCells[6].Value.ToString();

            txtPrecio1.Text = dtgRegistros.SelectedCells[7].Value.ToString();
            txtPrecio2.Text = dtgRegistros.SelectedCells[8].Value.ToString();
            txtPrecio3.Text = dtgRegistros.SelectedCells[9].Value.ToString();
            txtCosto.Text = dtgRegistros.SelectedCells[10].Value.ToString();
            txtCostoU.Text = dtgRegistros.SelectedCells[11].Value.ToString();
            txtExistencia.Text = dtgRegistros.SelectedCells[14].Value.ToString();
            if (Convert.ToInt32(dtgRegistros.SelectedCells[15].Value.ToString()) == 1)
            {
                chkControlInventario.Checked = true;
            }
            else
            {
                chkControlInventario.Checked = false;
            }


            try
            {                
                byte[] b = ((Byte[])dtgRegistros.SelectedCells[13].Value);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                pbFoto.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                pbFoto.BackgroundImage = null;
                MessageBox.Show(ex.Message);
            }
        }
        
        private void EliminarProducto()
        {

            string IdProducto = dtgRegistros.SelectedCells[2].Value.ToString();
            LProductos parametros = new LProductos();
            DProductos funcion = new DProductos();
            parametros.Producto = IdProducto;
            if (funcion.EliminarProducto(parametros) == true)
            {
                MostrarProducto();
            }
        }

        private void ControlProducto_Load(object sender, EventArgs e)
        {
            txtBuscador.Focus();
            MostrarProducto();
            ReinciarPaginado();
            Paginar();

        }

        private void ReinciarPaginado()
        {
            desde = 1;
            hasta = itemsPorPagina;

            Contar();
            if (contador > hasta)
            {
                btnPagSiguiente.Enabled = true;
                btnPagAnterior.Enabled=false;
                btnUltimaPagina.Enabled = true;
                btnPrimerPagina.Enabled = true;
            }
            else {
                btnPagSiguiente.Enabled = false;
                btnPagAnterior.Enabled = false;
                btnUltimaPagina.Enabled = false;
                btnPrimerPagina.Enabled = false;
            }

        }

        private void btnPagAnterior_Click(object sender, EventArgs e)
        {
            desde -= itemsPorPagina;
            hasta -= itemsPorPagina;
            MostrarProducto();
            Contar();
            if (contador > hasta)
            {
                btnPagSiguiente.Enabled = true;
                btnPagAnterior.Enabled = true;
            }
            else
            {
                btnPagSiguiente.Enabled = false;
                btnPagAnterior.Enabled = false;
            }
            if (desde == 1)
            {
                ReinciarPaginado();
            }
            Paginar();
        }

        private void btnUltimaPagina_Click(object sender, EventArgs e)
        {
            hasta = totalPaginas * itemsPorPagina;
            desde = hasta - 9;
            MostrarProducto();
            Contar();
            if (contador > hasta)
            {
                btnPagSiguiente.Enabled = true;
                btnPagAnterior.Enabled = true;
            }
            else
            {
                btnPagSiguiente.Enabled = false;
                btnPagAnterior.Enabled = true;
            }
            Paginar();
            
        }

        private void btnPrimerPagina_Click(object sender, EventArgs e)
        {
            ReinciarPaginado();
            Paginar();
            MostrarProducto();
        }

        private void ControlProductos_Load(object sender, EventArgs e)
        {
            txtBuscador.Focus();
            MostrarProducto();
            ReinciarPaginado();
            Paginar();
        }
    }
}
