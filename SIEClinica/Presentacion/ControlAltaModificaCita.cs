using SIEClinica.Datos;
using SIEClinica.Logica;
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
    public partial class ControlAltaModificaCita : UserControl
    {
        int IdCita = 0;
        bool modificandoCita;
        int IdCitaOrigen = 0;
        public ControlAltaModificaCita(int idCita)
        {
            InitializeComponent();
            rbCitaAgentada.Checked = true;
            this.IdCita = Convert.ToInt32(idCita);
            Limpiar();
            modificandoCita = false;
            llenaCombos();
            if (this.IdCita > 0)
            {
                modificandoCita = true;
                llenaDatosCita(IdCita);
                lblTipoCita.Text = "Modificación";
            }
            else
            {
                if(Ambiente.var2 == "desdeCita")
                {
                    IdCitaOrigen = Convert.ToInt32(Ambiente.var1);
                    Ambiente.var2 = "";
                    Ambiente.var1 = "";
                    lblTipoCita.Text = "Cita de seguimiento";
                    TraeDatosCitaSeguimiento();
                    traeFoto(txtPaciente.Text);

                }
                else
                {
                    lblTipoCita.Text = "Cita nueva";
                }
            }
            
        }

        private bool TraeDatosCitaSeguimiento()
        {

            try
            {

                ConexionBD.Abrir();
                string strSQL = "Select * From Citas Where id = " + IdCitaOrigen;

                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.Read())
                {
                    cbMedico.SelectedValue = registro["medico"].ToString();
                    cbConsultorio.SelectedValue = registro["consultorio"].ToString();
                    txtPaciente.Text = registro["paciente"].ToString();
                    txtNombrePaciente.Text = registro["nombrePaciente"].ToString();
                    txtMotivo.Text = registro["motivo"].ToString();
                    cmd.Dispose();
                    registro.Close();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
                return false;
            }
            finally
            {
                
                ConexionBD.Cerrar();
            }

        }
        private void llenaCombos()
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select Medico, Nombre From medicos Where estatus <> 'Eliminado' Order By nombre", ConexionBD.conectar);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                DataRow fila = dt.NewRow();
                fila["Nombre"] = "Selecciona un médico";
                dt.Rows.InsertAt(fila, 0);

                cbMedico.ValueMember = "Medico";
                cbMedico.DisplayMember = "Nombre";
                cbMedico.DataSource = dt;

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
                SqlCommand cmd = new SqlCommand("Select Consultorio, Descripcion From consultorios Where estatus <> 'Eliminado' Order By descripcion", ConexionBD.conectar);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                DataRow fila = dt.NewRow();
                fila["Descripcion"] = "Selecciona un consultorio";
                dt.Rows.InsertAt(fila, 0);

                cbConsultorio.ValueMember = "Consultorio";
                cbConsultorio.DisplayMember = "Descripcion";
                cbConsultorio.DataSource = dt;

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

        private void llenaDatosCita( int idCita)
        {
            string sMedico = "";
            string sConsultorio = "";

            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select * From citas Where id = " + idCita, ConexionBD.conectar);
                SqlDataReader Registros = cmd.ExecuteReader();

                if (Registros.Read())
                {
                    //cbConsultorio.SelectedValue = Registros["Consultorio"].ToString();
                    // cbConsultorio.Text = Registros["Descripcion"].ToString();
                    sMedico = "" + Registros["medico"].ToString();
                    sConsultorio = "" + Registros["consultorio"].ToString();

                    Calendario.SetDate(Convert.ToDateTime(Registros["fecha"].ToString()));

                    dtHoraIni.Value = Convert.ToDateTime(Registros["horaIni"].ToString());
                    dtHoraFin.Value = Convert.ToDateTime(Registros["horaFin"].ToString());;
                    if (Registros["tipoCita"].ToString() == "Cita")
                    {
                        rbCitaAgentada.Checked = true;
                    }
                    else
                    {
                        rbCitaRapida.Checked = true;
                    }
                    txtPaciente.Text = Registros["paciente"].ToString();
                    txtNombrePaciente.Text = Registros["nombrePaciente"].ToString();
                    txtMotivo.Text = Registros["motivo"].ToString();
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
                SqlCommand cmd = new SqlCommand("Select * From Medicos Where medico = '" + sMedico + "'", ConexionBD.conectar);
                SqlDataReader Registros = cmd.ExecuteReader();

                while (Registros.Read())
                {
                    cbMedico.SelectedValue = Registros["Medico"].ToString();
                    cbMedico.Text = Registros["Nombre"].ToString();

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
                    cbConsultorio.SelectedValue = Registros["Consultorio"].ToString();
                    cbConsultorio.Text = Registros["Descripcion"].ToString();
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

            traeFoto(txtPaciente.Text);

            txtMotivo.Focus();
                      

            
        }

        private string traeNombrePaciente(string codigoPaciente)
        {
            string nombrePaciente = "";
            if (String.IsNullOrEmpty(codigoPaciente) == true)
            {
                return "";
            }
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select Nombre From pacientes Where paciente = '" + codigoPaciente + "' And estatus <> 'Eliminado' Order By Nombre", ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    nombrePaciente = registro["nombre"].ToString();
                }
                
                //cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBD.Cerrar();
            }

            return nombrePaciente;
        }

        private void traeFoto(string codigoPaciente)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select foto From pacientes Where paciente = '" + codigoPaciente + "' And estatus <> 'Eliminado' Order By Nombre", ConexionBD.conectar);

                byte[] b = ((Byte[])cmd.ExecuteScalar());
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                pbFoto.Image = Image.FromStream(ms);
                
            }
            catch (Exception ex)
            {
                pbFoto.BackgroundImage = null;
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                ConexionBD.Cerrar();
            }

        }

        private void InsertarCita()
        {
            LCitas parametros = new LCitas();
            DCitas funcion = new DCitas();
            parametros.IdCita = IdCita;
            //parametros.Fecha = Calendario.TodayDate;
            parametros.Fecha = Convert.ToDateTime(Calendario.SelectionEnd.ToString("dd/MM/yyyy"));
            parametros.HoraInicial = dtHoraIni.Value;
            parametros.HoraFinal = dtHoraFin.Value;
            parametros.Paciente = txtPaciente.Text;
            parametros.NombrePaciente = txtNombrePaciente.Text;
            parametros.Medico = cbMedico.SelectedValue.ToString();
            parametros.Consultorio = cbConsultorio.SelectedValue.ToString();
            parametros.Motivo = txtMotivo.Text;
            if (cbEstatus.Text == "Confirmado")
            {
                parametros.Confirmado = "CO";
            }
            else
            {
                parametros.Confirmado = "PE";
            }

            if (rbCitaAgentada.Checked)
            {
                parametros.TipoCita = "Cita";
            }
            else
            {
                parametros.TipoCita = "Revisión";
            }
            parametros.idCitaOrigen = IdCitaOrigen;
            parametros.Estatus = "";
            parametros.Usuario = "SUP";
            parametros.Usufecha = DateTime.Now;
            parametros.Usuhora = "00:00";
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarCita(parametros) == true)
            {
               // ReinciarPaginado();
                //MostrarCita();
                //PanelConsultoriosReg.Visible = false;
                MessageBox.Show("Cita guardada correctamente", "Guarda registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, no se guardó la cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizaCita()
        {
            LCitas parametros = new LCitas();
            DCitas funcion = new DCitas();
            parametros.IdCita = IdCita;
            parametros.Fecha = Convert.ToDateTime(Calendario.SelectionEnd.ToString("dd-MM-yyyy"));
            parametros.HoraInicial = dtHoraIni.Value;
            parametros.HoraFinal = dtHoraFin.Value;
            parametros.Paciente = txtPaciente.Text;
            parametros.NombrePaciente = txtNombrePaciente.Text;
            parametros.Medico = cbMedico.SelectedValue.ToString();
            parametros.Consultorio = cbConsultorio.SelectedValue.ToString();
            parametros.Motivo = txtMotivo.Text;
            if (cbEstatus.Text == "Confirmado")
            {
                parametros.Confirmado = "CO";
            }
            else
            {
                parametros.Confirmado = "PE";
            }
            if (rbCitaAgentada.Checked)
            {
                parametros.TipoCita = "Cita";
            }
            else
            {
                parametros.TipoCita = "Revisión";
            }
            parametros.idCitaOrigen = IdCitaOrigen;
            parametros.Estatus = "";
            parametros.Usuario = "SUP";
            parametros.Usufecha = DateTime.Now;
            parametros.Usuhora = "00:00";
            parametros.Estacion = "ESTACION01";

            if (funcion.ActualizaCita(parametros) == true)
            {
               // ReinciarPaginado();
                //MostrarCita();
                //PanelConsultoriosReg.Visible = false;
                MessageBox.Show("Cita actualizada correctamente", "Guarda registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, no se actualizó la cita", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Limpiar()
        {
            rbCitaAgentada.Checked = true;
            Calendario.TodayDate = DateTime.Now;
            dtHoraIni.Value = Convert.ToDateTime("08:00");
            dtHoraFin.Value = Convert.ToDateTime("08:00");
            txtPaciente.Text = "";
            txtNombrePaciente.Text = "";
            txtMotivo.Text = "";
            cbEstatus.Text = "Pendiente";            
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            //PanelReg.Visible = false;
            //PanelPaginado.Visible = true;
            //PanelBusqueda.Visible = true;
            //dtgRegistros.Visible = true;
            //panelVender.Visible = false;
            //BuscarCitas();
            //IdCita = 0;
            //txtBuscador.Focus();
            regresaAlControlPrincipal();

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            // int hIni = Convert.ToInt32(dtFechaIni.Value.ToString("HHmm"));
            //int hFin = Convert.ToInt32(dtFechaFin.Value.ToString("HHmm"));
            //int result = 
            // MessageBox.Show("" + hIni + hFin);

            DCitas funcion = new DCitas();
            bool laCitaEstadisponible = funcion.citaLibre(cbMedico.SelectedValue.ToString(), cbConsultorio.SelectedValue.ToString(), Calendario.SelectionEnd, dtHoraIni.Value, dtHoraFin.Value, IdCita);
            if (laCitaEstadisponible == false)
            {
                return;
            }
            if (DateTime.Compare(Calendario.SelectionEnd, DateTime.Today) < 0)
            {
                MessageBox.Show("La fecha de la cita debe ser igual o mayor al día actual");
                return;
            }
            if (DateTime.Compare(dtHoraIni.Value, dtHoraFin.Value) == 0)
            {
                MessageBox.Show("La hora final no puede ser igual a la inicial");
                return;
            }
            else if (DateTime.Compare(dtHoraIni.Value, dtHoraFin.Value) > 0)
            {
                MessageBox.Show("La hora final debe ser mayor a la inicial: ");
                return;
            }
            Ambiente ambiente = new Ambiente();
            bool encontrado = ambiente.validaExisteEnCatalogo(cbMedico.SelectedValue.ToString(), "Medicos", "medico");
            if (encontrado == false)
            {
                MessageBox.Show("El médico no existe en el catálogo");
                cbMedico.Focus();
                return;
            }

            encontrado = ambiente.validaExisteEnCatalogo(cbConsultorio.SelectedValue.ToString(), "Consultorios", "consultorio");
            if (encontrado == false)
            {
                MessageBox.Show("El consultorio no existe en el catálogo");
                cbConsultorio.Focus();
                return;
            }

            encontrado = ambiente.validaExisteEnCatalogo(txtPaciente.Text, "Pacientes", "paciente");
            if (encontrado == false)
            {
                MessageBox.Show("El paciente no existe en el catálogo");
                txtPaciente.Focus();
                return;
            }

            if (txtMotivo.TextLength == 0)
            {
                MessageBox.Show("Ingrese un motivo");
                txtMotivo.Focus();
                return;
            }

            if (cbEstatus.Text != "Pendiente" && cbEstatus.Text != "Confirmado")
            {
                MessageBox.Show("Selecciones un estatus");
                return;
            }
            if (IdCita == 0)
            {
                InsertarCita();
                // RegresaDeGuardar();
            }
            else
            {
                ActualizaCita();
                //RegresaDeGuardar();
            }
            regresaAlControlPrincipal();

        }

        private void txtPaciente_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (modificandoCita == true)
                {
                    return;
                }
                try
                {
                    ConexionBD.Abrir();
                    SqlCommand cmd = new SqlCommand("Select Paciente, Nombre From pacientes Where (paciente = '%" + txtPaciente.Text + "%' Or nombre like '%" + txtPaciente.Text + "%') And estatus <> 'Eliminado' Order By Nombre", ConexionBD.conectar);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dtgBusquedaPacientes.Top = panel1.Top;
                    dtgBusquedaPacientes.Left = panel1.Left;
                    dtgBusquedaPacientes.DataSource = dt;
                    dtgBusquedaPacientes.Visible = true;

                    dtgBusquedaPacientes.Columns[0].Width = 100;
                    dtgBusquedaPacientes.Columns[1].Width = 300;

                    dtgBusquedaPacientes.Focus();
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

        private void dtgBusquedaPacientes_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPaciente.Text = "" + dtgBusquedaPacientes[0, dtgBusquedaPacientes.CurrentCell.RowIndex].Value;
                dtgBusquedaPacientes.Visible = false;
                txtNombrePaciente.Text = traeNombrePaciente(txtPaciente.Text);
                traeFoto(txtPaciente.Text);
                txtPaciente.Focus();

            }

            if (e.KeyCode == Keys.Escape)
            {
                dtgBusquedaPacientes.Visible = false;
                txtPaciente.Focus();
            }

        }

        private void regresaAlControlPrincipal()
        {
            this.Controls.Clear();

            ControlCitaAdd control = new ControlCitaAdd();
            this.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void dtgBusquedaPacientes_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("" + e.RowIndex);

            //txtPaciente.Text = "" + dtgBusquedaPacientes[e.RowIndex, 0].Value;
            txtPaciente.Text = "" + dtgBusquedaPacientes[0, dtgBusquedaPacientes.CurrentCell.RowIndex].Value;
            dtgBusquedaPacientes.Visible = false;
            txtNombrePaciente.Text = traeNombrePaciente(txtPaciente.Text);
            traeFoto(txtPaciente.Text);
        }

        private void txtPaciente_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPaciente.Text)==false){
                txtNombrePaciente.Text = traeNombrePaciente(txtPaciente.Text);
            }
            
        }
    }
}
