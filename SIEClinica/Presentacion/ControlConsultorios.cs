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
    public partial class ControlConsultorios : UserControl
    {
        public ControlConsultorios()
        {
            InitializeComponent();
            MostrarConsultorio();

            hasta = itemsPorPagina;
        }
        int IdCargo = 0;        
        int contador;
        string IdConsultorio = "";
        int itemsPorPagina = 10;
        int desde = 1;
        int hasta = 10;
        int totalPaginas;

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {            
            DConsultorios funcion = new DConsultorios();
            string ultimoId = funcion.TraeUltimoConsultorio().ToString();
            if (ultimoId != "-1")
            {
                int largoId = ultimoId.Length;
                int siguienteId = Convert.ToInt32(ultimoId) + 1;

                string siguienteConsultorio = "";

                if (largoId == 1)
                {
                    siguienteConsultorio = "00" + siguienteId;
                }
                else if (largoId == 2)
                {
                    siguienteConsultorio = "0" + siguienteId;
                }
                else
                {
                    siguienteConsultorio = "" + siguienteId;
                }

                PanelPaginado.Visible = false;
                PanelReg.Visible = true;
                PanelBusqueda.Visible = false;
                dtgRegistros.Visible = false;
                Limpiar();

                txtConsultorio.Text = siguienteConsultorio;

                txtDescripcion.Focus();
            }
        }

        private void Limpiar()
        {
            txtConsultorio.Clear();
            txtDescripcion.Clear(); 
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            regresaDesdeGuardar();
        }

        private void regresaDesdeGuardar()
        {
            PanelReg.Visible = false;
            PanelPaginado.Visible = true;
            PanelBusqueda.Visible = true;
            dtgRegistros.Visible = true;
            MostrarConsultorio();
            txtBuscador.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtConsultorio.Text)) {
                MessageBox.Show("Ingrese la clave del médico", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(String.IsNullOrEmpty(txtDescripcion.Text)){
                MessageBox.Show("Ingrese el nombre del médico", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }           
            else
            {
                //btnConsultoriosGuardar.Enabled = false;
                InsertarConsultorio();
                regresaDesdeGuardar();
                //btnConsultoriosGuardar.Enabled = true;
            }

        }

        private void InsertarConsultorio()
        {
            LConsultorios parametros = new LConsultorios();
            DConsultorios funcion = new DConsultorios();
            parametros.Consultorio = txtConsultorio.Text;
            parametros.Descripcion = txtDescripcion.Text;            
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
            parametros.Foto = ms.GetBuffer();
            parametros.Estatus = "";
            parametros.Usuario = "SUP";
            parametros.usufecha = "";
            parametros.usuhora = "00:00";
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarConsultorio(parametros) == true)
            {
                ReinciarPaginado();
                MostrarConsultorio();
                //PanelConsultoriosReg.Visible = false;
                MessageBox.Show("Consultorio guardado correctamente", "Guarda registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, no se guardó el consultorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarConsultorio()
        {
            DataTable dt = new DataTable();
            DConsultorios funcion = new DConsultorios();
            funcion.MostrarConsultorios(ref dt, desde, hasta);
            dtgRegistros.DataSource = dt;
            dtgRegistros.Columns[4].Visible = false;
            dtgRegistros.Columns[5].Visible = false;

            dtgRegistros.Columns[0].Width = 80;
            dtgRegistros.Columns[1].Width = 80;
            dtgRegistros.Columns[2].Width = 80;
            dtgRegistros.Columns[3].Width = 300;
            dtgRegistros.Columns[4].Width = 150;            
                        
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
            MostrarConsultorio();
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
            DConsultorios funcion = new DConsultorios();
            funcion.ContarConsultorio(ref contador);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarConsultorios();
        }

        private void BuscarConsultorios()
        {
            DataTable dt = new DataTable();
            DConsultorios funcion = new DConsultorios();
            funcion.BuscarConsultorios(ref dt, desde, hasta, txtBuscador.Text);
            dtgRegistros.DataSource = dt;
        }

        private void dtgRegistros_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {        
            if (e.ColumnIndex == dtgRegistros.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el consultoio?", "Elimina consultorio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,  MessageBoxDefaultButton.Button2);

                if (result== DialogResult.OK)
                {
                    EliminarConsultorio();
                }
                
            }

            if (e.ColumnIndex == dtgRegistros.Columns["Editar"].Index)
            {
                ModificaConsultorio();
            }


        }

        private void ModificaConsultorio()
        {
            PanelPaginado.Visible = false;
            PanelReg.Visible = true;
            PanelBusqueda.Visible = false;
            dtgRegistros.Visible = false;
            Limpiar();
            txtDescripcion.Focus();

            txtConsultorio.Text = dtgRegistros.SelectedCells[2].Value.ToString();
            txtDescripcion.Text = dtgRegistros.SelectedCells[3].Value.ToString();
            

            try
            {
                
                byte[] b = ((Byte[])dtgRegistros.SelectedCells[5].Value);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                pbFoto.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                pbFoto.BackgroundImage = null;
                MessageBox.Show(ex.Message);
            }
           

        }
        
        private void EliminarConsultorio()
        {
            IdConsultorio = dtgRegistros.SelectedCells[2].Value.ToString();
            LConsultorios parametros = new LConsultorios();
            DConsultorios funcion = new DConsultorios();
            parametros.Consultorio = IdConsultorio;
            if (funcion.EliminarConsultorio(parametros) == true)
            {
                MostrarConsultorio();
            }
        }

        private void ControlConsultorios_Load(object sender, EventArgs e)
        {
            txtBuscador.Focus();
            MostrarConsultorio();
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
            MostrarConsultorio();
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
            MostrarConsultorio();
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
            MostrarConsultorio();
        }

        private void ControlConsultorios_Load_1(object sender, EventArgs e)
        {
            txtBuscador.Focus();
            MostrarConsultorio();
            ReinciarPaginado();
            Paginar();
        }
    }
}
