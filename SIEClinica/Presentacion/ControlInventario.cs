using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIEClinica.Datos;
using SIEClinica.Logica;
using Microsoft.VisualBasic;
using System.Deployment.Internal;

namespace SIEClinica.Presentacion
{
    public partial class ControlInventario : UserControl
    {
        int IdInventario = 0;
        int contador;
        int itemsPorPagina = 10;
        int desde = 1;
        int hasta = 10;
        int totalPaginas;                
        public ControlInventario()
        {
            InitializeComponent();
            //MostrarCita();
            
            hasta = itemsPorPagina;

            txtBuscador.Focus();
            //panelVender.Visible = false;
            dtgRegistros.Dock = DockStyle.Fill;
            dtgRegistros.BringToFront();
            BuscarInventario();
            ReinciarPaginado();
            Paginar();
        }
       
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            IdInventario = 0;
            
            this.Controls.Clear();
            ControlEntradaSalidaInv control = new ControlEntradaSalidaInv(IdInventario);
            this.Controls.Add(control);
            control.Dock = DockStyle.Fill;            
            
            //control.Visible = true;
            //seleccionaBotonMenu(btnCalendario);
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            desde += 10;
            hasta += 10;
            MostrarInventario();
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

        private void btnPagAnterior_Click(object sender, EventArgs e)
        {
            desde -= itemsPorPagina;
            hasta -= itemsPorPagina;
            MostrarInventario();
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
            MostrarInventario();
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
            MostrarInventario();
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarInventario();
        }

        private void dtFechaIni_CloseUp(object sender, EventArgs e)
        {
            BuscarInventario();
        }

        private void dtFechaFin_CloseUp(object sender, EventArgs e)
        {
            BuscarInventario();
        }

        private void dtFechaIni_ValueChanged(object sender, EventArgs e)
        {
            BuscarInventario();
        }

        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {
            BuscarInventario();
        }

        private void cbStatusBusqueda_TextChanged(object sender, EventArgs e)
        {
            BuscarInventario();
        }

        private void dtgRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {            

            if (e.ColumnIndex == dtgRegistros.Columns["Editar"].Index)
            {
                IdInventario = Convert.ToInt32(dtgRegistros[5, dtgRegistros.CurrentCell.RowIndex].Value.ToString());

                this.Controls.Clear();
                ControlEntradaSalidaInv control = new ControlEntradaSalidaInv(IdInventario);
                this.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            }            
        }

        private void MostrarInventario()
        {
            DataTable dt = new DataTable();
            DInventario funcion = new DInventario();
            funcion.MostrarInventario(ref dt, desde, hasta);
            dtgRegistros.DataSource = dt;
            dtgRegistros.Columns[8].Visible = false;
            dtgRegistros.Columns[10].Visible = false;
            dtgRegistros.Columns[16].Visible = false;

            dtgRegistros.Columns[0].Width = 50;
            dtgRegistros.Columns[1].Width = 50;
            dtgRegistros.Columns[2].Width = 50;
            dtgRegistros.Columns[3].Width = 100;
            dtgRegistros.Columns[4].Width = 80;
            dtgRegistros.Columns[5].Width = 80;
            dtgRegistros.Columns[6].Width = 80;
            dtgRegistros.Columns[7].Width = 300;
            dtgRegistros.Columns[8].Width = 80;
            dtgRegistros.Columns[9].Width = 300;
            dtgRegistros.Columns[10].Width = 80;
            dtgRegistros.Columns[11].Width = 300;
            dtgRegistros.Columns[12].Width = 300;
            dtgRegistros.Columns[13].Width = 80;
            dtgRegistros.Columns[14].Width = 80;
            dtgRegistros.Columns[15].Width = 80;
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
            DCitas funcion = new DCitas();
            funcion.ContarCitas(ref contador);
        }

        private void BuscarInventario()
        {
            DataTable dt = new DataTable();
            DInventario funcion = new DInventario();
            funcion.BuscarInventario(ref dt, desde, hasta, txtBuscador.Text, dtFechaIni.Value, dtFechaFin.Value, cbStatusBusqueda.Text);
            dtgRegistros.DataSource = dt;
        }

        private void ReinciarPaginado()
        {
            desde = 1;
            hasta = itemsPorPagina;

            Contar();
            if (contador > hasta)
            {
                btnPagSiguiente.Enabled = true;
                btnPagAnterior.Enabled = false;
                btnUltimaPagina.Enabled = true;
                btnPrimerPagina.Enabled = true;
            }
            else
            {
                btnPagSiguiente.Enabled = false;
                btnPagAnterior.Enabled = false;
                btnUltimaPagina.Enabled = false;
                btnPrimerPagina.Enabled = false;
            }
        }

        private void ModificaInventario()
        {
            string sMedico = dtgRegistros.SelectedCells[9].Value.ToString();
            string sConsultorio = dtgRegistros.SelectedCells[11].Value.ToString();

           
            PanelPaginado.Visible = false;
            //PanelReg.Visible = true;
            PanelBusqueda.Visible = false;
            dtgRegistros.Visible = false;
            //dtgBusquedaPacientes.Visible = false;
            // panelVender.Visible = false;
            // Limpiar();
            // llenaCombos();

            //txtMotivo.Focus();
            IdInventario = Convert.ToInt32(dtgRegistros.SelectedCells[16].Value.ToString());
           // Calendario.SetDate(Convert.ToDateTime(dtgRegistros.SelectedCells[3].Value));
           // dtHoraIni.Value = Convert.ToDateTime(dtgRegistros.SelectedCells[4].Value);
           // dtHoraFin.Value = Convert.ToDateTime(dtgRegistros.SelectedCells[5].Value);

            //Calendario.TodayDate= Convert.ToDateTime(dtgRegistros.SelectedCells[2].Value);
            //Calendario.TodayDate = Convert.ToDateTime(dtgRegistros.SelectedCells[2].Value);
            // dtHoraIni.Value = Convert.ToDateTime(dtgRegistros.SelectedCells[3].Value);
            //dtHoraIni.Value = Convert.ToDateTime(dtgRegistros.SelectedCells[4].Value);
            if (dtgRegistros.SelectedCells[4].Value.ToString() == "Cita")
            {
                //rbCitaAgentada.Checked = true;
            }
            else
            {
                //rbCitaRapida.Checked = true;
            }
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select * From Medicos Where medico = '" + sMedico + "'", ConexionBD.conectar);
                SqlDataReader Registros = cmd.ExecuteReader();

                while (Registros.Read())
                {
                   // cbMedico.SelectedValue = Registros["Medico"].ToString();
                   // cbMedico.Text = Registros["Nombre"].ToString();

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

            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select * From consultorios Where consultorio = '" + sConsultorio + "'", ConexionBD.conectar);
                SqlDataReader Registros = cmd.ExecuteReader();

                while (Registros.Read())
                {
                    //cbConsultorio.SelectedValue = Registros["Consultorio"].ToString();
                   // cbConsultorio.Text = Registros["Descripcion"].ToString();
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
    

