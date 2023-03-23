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
    public partial class ControlCobranza : UserControl
    {
        int IdFlujo = 0;
        int contador;
        int itemsPorPagina = 20;
        int desde = 1;
        int hasta = 20;
        int totalPaginas;
        bool modificandoFlujo;
        string Paciente;
        string NombrePaciente;
        int idCobranza = 0;


        public ControlCobranza()
        {
            InitializeComponent();
            //MostrarCita();
            label8.Visible = false;
            dtFechaIni.Visible = false;
            hasta = itemsPorPagina;

            txtBuscador.Focus();
            //panelVender.Visible = false;
            dtgRegistros.Dock = DockStyle.Fill;
            dtgRegistros.BringToFront();
            MostrarCobranza();
            ReinciarPaginado();
            Paginar();
        }       

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //panelPrincipal.Controls.Clear();  
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            desde += 20;
            hasta += 20;
            MostrarCobranza();
            //Contar();
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
            MostrarCobranza();
            //Contar();
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
            desde = hasta - 19;
            MostrarCobranza();
            //Contar();
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
            BuscarCobranza();
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarCobranza();
        }

        private void dtFechaIni_CloseUp(object sender, EventArgs e)
        {
            BuscarCobranza();
        }

        private void dtFechaFin_CloseUp(object sender, EventArgs e)
        {
            BuscarCobranza();
        }

        private void dtFechaIni_ValueChanged(object sender, EventArgs e)
        {
            BuscarCobranza();
        }

        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {
            BuscarCobranza();
        }

        private void dtgRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dtgRegistros.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el registro?", "Elimina registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.OK)
                {
                   // EliminarFlujo();
                }
            }

            if (e.ColumnIndex == dtgRegistros.Columns["Editar"].Index)
            {                
                
            }

            if (e.ColumnIndex == dtgRegistros.Columns["CargoAbono"].Index)
            {
                Paciente = dtgRegistros[3, dtgRegistros.CurrentCell.RowIndex].Value.ToString();
                NombrePaciente = dtgRegistros[4, dtgRegistros.CurrentCell.RowIndex].Value.ToString();
                idCobranza = Convert.ToInt32(dtgRegistros[12, dtgRegistros.CurrentCell.RowIndex].Value.ToString());
                frmCobranza forma = new frmCobranza(Paciente, NombrePaciente, idCobranza);
                forma.ShowDialog();
                idCobranza = 0;
                BuscarCobranza();
            }
        }

        private void MostrarCobranza()
        {
            DataTable dt = new DataTable();
            DCobranza funcion = new DCobranza();
            funcion.MostrarCobranza(ref dt, desde, hasta);
            dtgRegistros.DataSource = dt;
            dtgRegistros.Columns[0].Visible = false;
            dtgRegistros.Columns[1].Visible = false;
            dtgRegistros.Columns[3].Visible = false;
            dtgRegistros.Columns[9].Visible = false;
            dtgRegistros.Columns[10].Visible = false;
            dtgRegistros.Columns[11].Visible = false;
            dtgRegistros.Columns[12].Visible = false;

            // dtgRegistros.Columns[0].Width = 50;
            // dtgRegistros.Columns[1].Width = 50;
            dtgRegistros.Columns[2].Width = 50;            
            dtgRegistros.Columns[4].Width = 350;
            dtgRegistros.Columns[5].Width = 100;
            dtgRegistros.Columns[6].Width = 100;
            dtgRegistros.Columns[7].Width = 100;
            dtgRegistros.Columns[8].Width = 100;

            //dtgRegistros.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgRegistros.Columns[7].DefaultCellStyle.Format = "N";

            dtgRegistros.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgRegistros.Columns[8].DefaultCellStyle.Format = "N";

            dtgRegistros.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CalculaTotales();
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
        //private void Contar()
        //{
        //    DFlujo funcion = new DFlujo();
        //    funcion.ContarFlujo(ref contador);
        //}

        private void BuscarCobranza()
        {
            DataTable dt = new DataTable();
            DCobranza funcion = new DCobranza();
            funcion.BuscarCobranza(ref dt, desde, hasta, txtBuscador.Text, dtFechaFin.Value);
            dtgRegistros.DataSource = dt;
            CalculaTotales();
        }

        //private void EliminarFlujo()
        //{
        //    IdFlujo = Convert.ToInt32(dtgRegistros.SelectedCells[8].Value.ToString());
        //    LFlujo parametros = new LFlujo();
        //    DFlujo funcion = new DFlujo();
        //    parametros.IdFlujo = IdFlujo;
        //    if (funcion.EliminarFlujo(parametros) == true)
        //    {
        //        BuscarFlujo();
        //    }
        //}

        private void ReinciarPaginado()
        {
            desde = 1;
            hasta = itemsPorPagina;

            //Contar();
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

        private void ModificaFlujo()
        {
            string sMedico = dtgRegistros.SelectedCells[9].Value.ToString();
            string sConsultorio = dtgRegistros.SelectedCells[11].Value.ToString();

            modificandoFlujo = true;
            PanelPaginado.Visible = false;
            //PanelReg.Visible = true;
            PanelBusqueda.Visible = false;
            dtgRegistros.Visible = false;
            //dtgBusquedaPacientes.Visible = false;
           // panelVender.Visible = false;
           // Limpiar();
           // llenaCombos();

            //txtMotivo.Focus();
            IdFlujo = Convert.ToInt32(dtgRegistros.SelectedCells[16].Value.ToString());
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
            //cbMedico.SelectedValue = dtgRegistros.SelectedCells[8].Value.ToString();
            //cbConsultorio.SelectedValue = dtgRegistros.SelectedCells[10].Value.ToString();
            //cbMedico.Text = dtgRegistros.SelectedCells[9].Value.ToString();
            //cbConsultorio.Text = dtgRegistros.SelectedCells[11].Value.ToString();
            //txtPaciente.Text = dtgRegistros.SelectedCells[6].Value.ToString();
            //txtNombrePaciente.Text = dtgRegistros.SelectedCells[7].Value.ToString();
            //txtMotivo.Text = dtgRegistros.SelectedCells[12].Value.ToString();

            //traeFoto(txtPaciente.Text);
        }

        private void CalculaTotales()
        {
            string importe;
            
            try
            {
                importe = "0";
                ConexionBD.Abrir();
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select IsNull(Sum(importe),0)  As i From cobranza Where (paciente + ' ' + nombre) like '%" + txtBuscador.Text + "%' And fecha_venc >= '" + 
                        dtFechaIni.Value.ToString("yyyyMMdd") + "' And fecha_venc <= '" + dtFechaFin.Value.ToString("yyyyMMdd") + "'", ConexionBD.conectar);
                SqlDataReader Registros = cmd.ExecuteReader();

                if (Registros.Read())
                {
                    importe = Registros["i"].ToString();
                    lblImporte.Text = String.Format("{0:c}", Convert.ToDouble(importe));
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
                importe = "0";
                ConexionBD.Abrir();
                SqlCommand cmd1 = new SqlCommand("Select IsNull(Sum(saldo), 0)  As i From cobranza Where(paciente + ' ' + nombre) like '%" + txtBuscador.Text + "%' And fecha_venc >= '" + 
                        dtFechaIni.Value.ToString("yyyyMMdd") + "' And fecha_venc <= '" + dtFechaFin.Value.ToString("yyyyMMdd") + "'", ConexionBD.conectar);
                SqlDataReader Registros1 = cmd1.ExecuteReader();

                if (Registros1.Read())
                {                    
                    importe = Registros1["i"].ToString();
                }
                else
                {
                    importe = "0";
                }                
                
                lblSaldo.Text = String.Format("{0:c}", Convert.ToDouble(importe));
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

        private void PanelBusqueda_Paint(object sender, PaintEventArgs e)
        {

        }
    }      
      
               
 }
    

