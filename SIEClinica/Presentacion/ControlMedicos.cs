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
    public partial class ControlMedicos : UserControl
    {
        public ControlMedicos()
        {
            InitializeComponent();
            MostrarMedico();

            hasta = itemsPorPagina;
        }
        int IdCargo = 0;        
        int contador;
        string IdMedico = "";
        int itemsPorPagina = 10;
        int desde = 1;
        int hasta = 10;
        int totalPaginas;

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            DMedicos funcion = new DMedicos();
            string ultimoId = funcion.TraeUltimoMedico().ToString();
            if (ultimoId != "-1")
            {
                int largoId = ultimoId.Length;
                int siguienteId = Convert.ToInt32(ultimoId) + 1;

                string siguienteMedico = "";

                if (largoId == 1)
                {
                    siguienteMedico = "00" + siguienteId;
                }
                else if (largoId == 2)
                {
                    siguienteMedico = "0" + siguienteId;
                }
                else
                {
                    siguienteMedico = "" + siguienteId;
                }

                PanelPaginado.Visible = false;
                PanelReg.Visible = true;
                PanelBusqueda.Visible = false;
                dtgRegistros.Visible = false;
                Limpiar();

                txtMedico.Text = siguienteMedico;

                txtNombre.Focus();
            }
        }

        private void Limpiar()
        {
            txtMedico.Clear();
            txtNombre.Clear();
            dtFechaNac.Value = DateTime.Now;
            txtDomicilio.Clear();
            txtCiudad.Clear();
            cmbEstados.Text = "Jalisco";
            txtTelefono.Clear();
            txtCelular.Clear();
            txtEMail.Clear();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresarDesdeGuardar();
        }

        private void regresarDesdeGuardar()
        {
            PanelReg.Visible = false;
            PanelPaginado.Visible = true;
            PanelBusqueda.Visible = true;
            dtgRegistros.Visible = true;
            MostrarMedico();
            txtBuscador.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMedico.Text)) {
                MessageBox.Show("Ingrese la clave del médico", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(String.IsNullOrEmpty(txtNombre.Text)){
                MessageBox.Show("Ingrese el nombre del médico", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (String.IsNullOrEmpty(txtCelular.Text))
            {
                MessageBox.Show("Ingrese el número de celular del médico", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else
            {
                //btnMedicosGuardar.Enabled = false;
                InsertarMedico();
                regresarDesdeGuardar();
                //btnMedicosGuardar.Enabled = true;
            }

        }

        private void InsertarMedico()
        {
            LMedicos parametros = new LMedicos();
            DMedicos funcion = new DMedicos();
            parametros.Medico = txtMedico.Text;
            parametros.Nombre = txtNombre.Text;
            parametros.FNacimiento = dtFechaNac.Value;
            parametros.Domicilio = txtDomicilio.Text;
            parametros.Ciudad = txtCiudad.Text;
            parametros.Estado =cmbEstados.Text;
            parametros.Telefono = txtTelefono.Text;
            parametros.Celular = txtCelular.Text;
            parametros.eMail = txtEMail.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
            parametros.Foto = ms.GetBuffer();
            parametros.Estatus = "";
            parametros.Usuario = "SUP";
            parametros.usufecha = "";
            parametros.usuhora = "00:00";
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarMedico(parametros) == true)
            {
                ReinciarPaginado();
                MostrarMedico();
                //PanelMedicosReg.Visible = false;
                MessageBox.Show("Médico guardado correctamente", "Guarda registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, no se guardó el médico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarMedico()
        {
            DataTable dt = new DataTable();
            DMedicos funcion = new DMedicos();
            funcion.MostrarMedicos(ref dt, desde, hasta);
            dtgRegistros.DataSource = dt;
            dtgRegistros.Columns[12].Visible = false;

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
            MostrarMedico();
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
                MessageBox.Show(ex.Message);
            }

        }
        private void Contar()
        {
            DMedicos funcion = new DMedicos();
            funcion.ContarMedico(ref contador);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarMedicos();
        }

        private void BuscarMedicos()
        {
            DataTable dt = new DataTable();
            DMedicos funcion = new DMedicos();
            funcion.BuscarMedicos(ref dt, desde, hasta, txtBuscador.Text);
            dtgRegistros.DataSource = dt;
        }

        private void dtgRegistros_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {        
            if (e.ColumnIndex == dtgRegistros.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el médico?", "Elimina médico", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,  MessageBoxDefaultButton.Button2);

                if (result== DialogResult.OK)
                {
                    EliminarMedico();
                }
                
            }

            if (e.ColumnIndex == dtgRegistros.Columns["Editar"].Index)
            {
                ModificaMedico();
            }


        }

        private void ModificaMedico()
        {
            PanelPaginado.Visible = false;
            PanelReg.Visible = true;
            PanelBusqueda.Visible = false;
            dtgRegistros.Visible = false;
            Limpiar();
            txtNombre.Focus();

            txtMedico.Text = dtgRegistros.SelectedCells[2].Value.ToString();
            txtNombre.Text = dtgRegistros.SelectedCells[3].Value.ToString();
            dtFechaNac.Value = Convert.ToDateTime(dtgRegistros.SelectedCells[4].Value.ToString());
            txtTelefono.Text = dtgRegistros.SelectedCells[5].Value.ToString();
            txtCelular.Text = dtgRegistros.SelectedCells[6].Value.ToString();
            txtEMail.Text = dtgRegistros.SelectedCells[7].Value.ToString();
            txtDomicilio.Text = dtgRegistros.SelectedCells[8].Value.ToString();
            txtCiudad.Text = dtgRegistros.SelectedCells[9].Value.ToString();
            cmbEstados.Text = dtgRegistros.SelectedCells[10].Value.ToString();

            try
            {
                
                byte[] b = ((Byte[])dtgRegistros.SelectedCells[12].Value);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                pbFoto.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                pbFoto.BackgroundImage = null;
                MessageBox.Show(ex.Message);
            }
           

        }
        
        private void EliminarMedico()
        {
            IdMedico = dtgRegistros.SelectedCells[2].Value.ToString();
            LMedicos parametros = new LMedicos();
            DMedicos funcion = new DMedicos();
            parametros.Medico = IdMedico;
            if (funcion.EliminarMedico(parametros) == true)
            {
                MostrarMedico();
            }
        }

        private void ControlMedicos_Load(object sender, EventArgs e)
        {
            txtBuscador.Focus();
            MostrarMedico();
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
            MostrarMedico();
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
            MostrarMedico();
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
            MostrarMedico();
        }

        private void ControlMedicos_Load_1(object sender, EventArgs e)
        {
            txtBuscador.Focus();
            MostrarMedico();
            ReinciarPaginado();
            Paginar();
        }
    }
}
