using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIEClinica.Datos;
using SIEClinica.Logica;
using SIEClinica.Reporte.Formatos;

namespace SIEClinica.Presentacion
{
    public partial class ControlPacientes : UserControl
    {
        public ControlPacientes()
        {
            InitializeComponent();
            MostrarPaciente();
            //panelReporte.Visible = false;
            hasta = itemsPorPagina;

            ToolTip tp =new ToolTip();

            tp.SetToolTip(btnOdontograma, "Odontograma");
            tp.SetToolTip(btnExpediente, "Expediente");
            tp.SetToolTip(btnPacientesGuardar, "Guardar paciente");
            tp.SetToolTip(btnPacientesRegresar, "Regresar");
        }
        //int IdCargo = 0;        
        int contador;
        string IdPaciente = "";
        int itemsPorPagina = 20;
        int desde = 1;
        int hasta = 20;
        int totalPaginas;

       
        private void btnPacienteAgregar_Click(object sender, EventArgs e)
        {
            
            DPacientes funcion = new DPacientes();
            string ultimoId = funcion.TraeUltimoPaciente().ToString();
            if (ultimoId != "-1")
            {
                int largoId = ultimoId.Length;
                int siguienteId = Convert.ToInt32(ultimoId) + 1;

                string siguientePaciente = "";

                if (largoId == 1)
                {
                    siguientePaciente = "00" + siguienteId;
                }
                else if (largoId == 2)
                {
                    siguientePaciente = "0" + siguienteId;
                }
                else
                {
                    siguientePaciente = "" + siguienteId;
                }

                PanelPaginado.Visible = false;
                PanelPacientesReg.Visible = true;
                PanelBusqueda.Visible = false;
                dtgPacientes.Visible = false;
                Limpiar();

                txtPaciente.Text = siguientePaciente;
                llenaCombos();

                txtPacienteNombre.Focus();
            }
        }

        private void Limpiar()
        {
            txtPaciente.Clear();
            txtPacienteNombre.Clear();
            dtPacienteFechaNac.Value = DateTime.Now;
            txtPacienteDomicilio.Clear();
            txtPacienteCiudad.Text = "Zapotlanejo";
            cmbPacientesEstados.Text = "Jalisco";
            txtPacienteTelefono.Clear();
            txtPacienteCelular.Clear();
            txtPacienteEMail.Clear();
            txtOcupacion.Clear();
            cmbEstadoCivil.SelectedValue = "";
            cmbEstadoCivil.Text = "";

            chkTratamiento.Checked = false;
            chkPenicilina.Checked = false;
            chkCorazon.Checked = false;
            txtEnfCorazon.Clear();
            chkEpilepsia.Checked = false;
            chkDesmayo.Checked = false;
            chkDiabetes.Checked = false;
            chkAnesteciaLocal.Checked = false;
            txtAnesteciaLocal.Clear();
            chkEmbarazada.Checked = false;
            chkNerviosa.Checked = false;
            chkCicatrizacion.Checked = false;
            chkAnestesiaBoca.Checked = false;
            chkRechinan.Checked = false;
            chkTuberculosis.Checked = false;
            chkHepatitis.Checked = false;
            chkSifilis.Checked = false;
            chkOsteoporosis.Checked = false;
            chkVIH.Checked = false;

            txtTratamiento.Clear();
            txtAlergico.Clear();
            txtDiabetes.Clear();
            txtMeses.Clear();
        }

        private void btnPacientesRegresar_Click(object sender, EventArgs e)
        {
            regresaDesdeguardar();
        }

        private void regresaDesdeguardar()
        {
            PanelPacientesReg.Visible = false;
            PanelPaginado.Visible = true;
            PanelBusqueda.Visible = true;
            dtgPacientes.Visible = true;
            MostrarPaciente();
            txtBuscador.Focus();
        }

        private void btnPacientesGuardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPaciente.Text)) {
                MessageBox.Show("Ingrese la clave del paciente", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(String.IsNullOrEmpty(txtPacienteNombre.Text)){
                MessageBox.Show("Ingrese el nombre del paciente", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (String.IsNullOrEmpty(txtPacienteCelular.Text))
            {
                MessageBox.Show("Ingrese el número de celular del paciente", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (String.IsNullOrEmpty(cmbEstadoCivil.Text))
            {
                MessageBox.Show("Ingrese el estado civil", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (String.IsNullOrEmpty(txtOcupacion.Text))
            {
                MessageBox.Show("Ingrese la ocupación", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (chkTratamiento.Checked == true && String.IsNullOrEmpty(txtTratamiento.Text))
            {
                MessageBox.Show("Ingrese el tipo de tratamiento");
                txtTratamiento.Focus();
                return;
            }

            if (chkPenicilina.Checked == true && String.IsNullOrEmpty(txtAlergico.Text))
            {
                MessageBox.Show("Ingrese a que es alérgico");
                txtAlergico.Focus();
                return;
            }

            if (chkCorazon.Checked == true && String.IsNullOrEmpty(txtEnfCorazon.Text))
            {
                MessageBox.Show("Especifique la enfermedad del corazón");
                txtEnfCorazon.Focus();
                return;
            }

            if (chkDiabetes.Checked == true && String.IsNullOrEmpty(txtDiabetes.Text))
            {
                MessageBox.Show("Especifique el familiar con diabetes");
                txtDiabetes.Focus();
                return;
            }

            if (chkAnesteciaLocal.Checked == true && String.IsNullOrEmpty(txtAnesteciaLocal.Text))
            {
                MessageBox.Show("Especifique el tipo de complicación por anestecia local");
                txtAnesteciaLocal.Focus();
                return;
            }

            if (chkEmbarazada.Checked == true && String.IsNullOrEmpty(txtMeses.Text))
            {
                MessageBox.Show("Ingrese los meses de embarazo");
                txtMeses.Focus();
                return;
            }

            //btnPacientesGuardar.Enabled = false;
            InsertarPaciente();
            regresaDesdeguardar();
            //btnPacientesGuardar.Enabled = true;
        }

        private void InsertarPaciente()
        {
            LPacientes parametros = new LPacientes();
            DPacientes funcion = new DPacientes();
            parametros.Paciente = txtPaciente.Text;
            parametros.Nombre = txtPacienteNombre.Text;
            parametros.FNacimiento = dtPacienteFechaNac.Value;
            parametros.Domicilio = txtPacienteDomicilio.Text;
            parametros.Ciudad = txtPacienteCiudad.Text;
            parametros.Estado =cmbPacientesEstados.Text;
            parametros.Telefono = txtPacienteTelefono.Text;
            parametros.Celular = txtPacienteCelular.Text;
            parametros.eMail = txtPacienteEMail.Text;
            parametros.EstadoCivil = cmbEstadoCivil.SelectedValue.ToString();
            parametros.Ocupacion = txtOcupacion.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if(pbFoto.Image == null)
            {
                pbFoto.Image = Properties.Resources.camara;  
            }
            
            pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                       
            parametros.Foto = ms.GetBuffer();
            parametros.Estatus = "";
            if (chkTratamiento.Checked == true)
            {
                parametros.Tratamiento = 1;
                parametros.TratamientoMedico = txtTratamiento.Text;
            }
            else
            {
                parametros.Tratamiento = 0;
                parametros.TratamientoMedico = "";
            }

            if (chkPenicilina.Checked == true)
            {
                parametros.Penicilina = 1;
                parametros.AlergicoD = txtAlergico.Text;
            }
            else
            {
                parametros.Penicilina = 0;
                parametros.AlergicoD = "";
            }

            if (chkCorazon.Checked == true)
            {
                parametros.EnfCorazon = 1;
                parametros.EnfCorazonDesc = txtEnfCorazon.Text;
            }
            else
            {
                parametros.EnfCorazon = 0;
                parametros.EnfCorazonDesc = "";
            }

            if (chkEpilepsia.Checked == true)
            {
                parametros.Epilepsia = 1;
            }
            else
            {
                parametros.Epilepsia = 0;
            }

            if (chkDesmayo.Checked == true)
            {
                parametros.Desmayo = 1;
            }
            else
            {
                parametros.Desmayo = 0;
            }

            if (chkDiabetes.Checked == true)
            {
                parametros.Diabetes = 1;
                parametros.DiabetesFam = txtDiabetes.Text;
            }
            else
            {
                parametros.Diabetes = 0;
                parametros.DiabetesFam = "";
            }

            if (chkAnesteciaLocal.Checked == true)
            {
                parametros.AnesteciaLocal = 1;
                parametros.AnesteciaLocalDesc = txtAnesteciaLocal.Text;
            }
            else
            {
                parametros.AnesteciaLocal = 0;
                parametros.AnesteciaLocalDesc = "";
            }

            if (chkEmbarazada.Checked == true)
            {
                parametros.Embarazada = 1;
                parametros.MesesEmbarazo = Convert.ToInt32(txtMeses.Text);
            }
            else
            {
                parametros.Embarazada = 0;

                parametros.MesesEmbarazo = 0;
            }

            if (chkNerviosa.Checked == true)
            {
                parametros.PersonaNerviosa = 1;
            }
            else
            {
                parametros.PersonaNerviosa = 0;
            }

            if (chkCicatrizacion.Checked == true)
            {
                parametros.CicatrizacionRapida = 1;
            }
            else
            {
                parametros.CicatrizacionRapida = 0;
            }

            if (chkAnestesiaBoca.Checked == true)
            {
                parametros.AnestesiaBoca = 1;
            }
            else
            {
                parametros.AnestesiaBoca = 0;
            }

            if (chkRechinan.Checked == true)
            {
                parametros.RechinanDientes = 1;
            }
            else
            {
                parametros.RechinanDientes = 0;
            }

            if (chkTuberculosis.Checked == true)
            {
                parametros.Tuberculosis = 1;
            }
            else
            {
                parametros.Tuberculosis = 0;
            }

            if (chkHepatitis.Checked == true)
            {
                parametros.Hepatitis = 1;
            }
            else
            {
                parametros.Hepatitis = 0;
            }

            if (chkSifilis.Checked == true)
            {
                parametros.Sifilis = 1;
            }
            else
            {
                parametros.Sifilis = 0;
            }

            if (chkOsteoporosis.Checked == true)
            {
                parametros.Osteoporosis = 1;
            }
            else
            {
                parametros.Osteoporosis = 0;
            }

            if (chkVIH.Checked == true)
            {
                parametros.Sida = 1;
            }
            else
            {
                parametros.Sida = 0;
            }

            parametros.Usuario = "SUP";
            parametros.usufecha = "";
            parametros.usuhora = "00:00";
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarPaciente(parametros) == true)
            {
                ReinciarPaginado();
                MostrarPaciente();
                //PanelPacientesReg.Visible = false;
                MessageBox.Show("Paciente guardado correctamente", "Guarda registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, no se guardó el paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MostrarPaciente()
        {
            DataTable dt = new DataTable();
            DPacientes funcion = new DPacientes();
            funcion.MostrarPacientes(ref dt, desde, hasta);
            dtgPacientes.DataSource = dt;
            dtgPacientes.Columns[12].Visible = false;

            dtgPacientes.Columns[0].Width = 80;
            dtgPacientes.Columns[1].Width = 80;
            dtgPacientes.Columns[2].Width = 80;
            dtgPacientes.Columns[3].Width = 300;
            dtgPacientes.Columns[4].Width = 150;
            dtgPacientes.Columns[5].Width = 150;
            dtgPacientes.Columns[6].Width = 150;
            dtgPacientes.Columns[7].Width = 250;
            dtgPacientes.Columns[8].Width = 400;
            dtgPacientes.Columns[9].Width = 200;
            dtgPacientes.Columns[10].Width = 200;
            dtgPacientes.Columns[13].Width = 200;
            dtgPacientes.Columns[14].Width = 200;

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
            MostrarPaciente();
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
            DPacientes funcion = new DPacientes();
            funcion.ContarPaciente(ref contador);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarPacientes();
        }

        private void BuscarPacientes()
        {
            DataTable dt = new DataTable();
            DPacientes funcion = new DPacientes();
            funcion.BuscarPacientes(ref dt, desde, hasta, txtBuscador.Text);
            dtgPacientes.DataSource = dt;
        }

        private void dtgPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgPacientes.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar el paciente?", "Elimina paciente", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,  MessageBoxDefaultButton.Button2);

                if (result== DialogResult.OK)
                {
                    EliminarPaciente();
                }
                
            }

            if (e.ColumnIndex == dtgPacientes.Columns["Editar"].Index)
            {
                ModificaPaciente();
            }


        }

        private void ModificaPaciente()
        {
            PanelPaginado.Visible = false;
            PanelPacientesReg.Visible = true;
            PanelBusqueda.Visible = false;
            dtgPacientes.Visible = false;
            Limpiar();
            txtPacienteNombre.Focus();

            llenaCombos();
            txtPaciente.Text = dtgPacientes.SelectedCells[2].Value.ToString();
            txtPacienteNombre.Text = dtgPacientes.SelectedCells[3].Value.ToString();
            dtPacienteFechaNac.Value = Convert.ToDateTime(dtgPacientes.SelectedCells[4].Value.ToString());
            txtPacienteTelefono.Text = dtgPacientes.SelectedCells[5].Value.ToString();
            txtPacienteCelular.Text = dtgPacientes.SelectedCells[6].Value.ToString();
            txtPacienteEMail.Text = dtgPacientes.SelectedCells[7].Value.ToString();
            txtPacienteDomicilio.Text = dtgPacientes.SelectedCells[8].Value.ToString();
            txtPacienteCiudad.Text = dtgPacientes.SelectedCells[9].Value.ToString();
            cmbPacientesEstados.Text = dtgPacientes.SelectedCells[10].Value.ToString();
            cmbEstadoCivil.Text = dtgPacientes.SelectedCells[13].Value.ToString();
            txtOcupacion.Text = dtgPacientes.SelectedCells[14].Value.ToString();

            
            try
            {                
                byte[] b = ((Byte[])dtgPacientes.SelectedCells[12].Value);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                pbFoto.Image = Image.FromStream(ms);

                ConexionBD.Abrir();
                string strSQL = "Select * From pacientes Where paciente = '" + txtPaciente.Text  + "'";
                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.Read())
                {
                    if (registro["Tratamiento"].ToString() == "1")
                    {
                        chkTratamiento.Checked = true;
                        txtTratamiento.Text = registro["TratamientoDescrip"].ToString();
                    }
                    else
                    {
                        chkTratamiento.Checked = false;
                        txtTratamiento.Text = "";
                    }

                    if (registro["Alergico"].ToString() == "1")
                    {
                        chkPenicilina.Checked = true;
                        txtAlergico.Text = registro["AlergicoDescrip"].ToString();
                    }
                    else
                    {
                        chkPenicilina.Checked = false;
                        txtAlergico.Text = "";
                    }

                    if (registro["EnfermedadCorazon"].ToString() == "1")
                    {
                        chkCorazon.Checked = true;
                        txtEnfCorazon.Text = registro["EnfermedadCorazonDesc"].ToString();
                    }
                    else
                    {
                        chkCorazon.Checked = false;
                        txtEnfCorazon.Text = "";
                    }

                    if (registro["Epilepsia"].ToString() == "1")
                    {
                        chkEpilepsia.Checked = true;
                    }
                    else
                    {
                        chkEpilepsia.Checked = false;
                    }

                    if (registro["Desmayo"].ToString() == "1")
                    {
                        chkDesmayo.Checked = true;
                    }
                    else
                    {
                        chkDesmayo.Checked = false;
                    }

                    if (registro["Diabetes"].ToString() == "1")
                    {
                        chkDiabetes.Checked = true;
                        txtDiabetes.Text = registro["DiabetesDescrip"].ToString();
                    }
                    else
                    {
                        chkDiabetes.Checked = false;
                        txtDiabetes.Text = "";
                    }

                    if (registro["AnestesiaLocal"].ToString() == "1")
                    {
                        chkAnesteciaLocal.Checked = true;
                        txtAnesteciaLocal.Text = registro["AnestesiaLocalDesc"].ToString();
                    }
                    else
                    {
                        chkAnesteciaLocal.Checked = false;
                        txtAnesteciaLocal.Text = "";
                    }

                    if (registro["Embarazada"].ToString() == "1")
                    {
                        chkEmbarazada.Checked = true;
                        txtMeses.Text = registro["EmbarazadaMeses"].ToString();
                    }
                    else
                    {
                        chkEmbarazada.Checked = false;
                        txtMeses.Text = "";
                    }

                    if (registro["Nerviosa"].ToString() == "1")
                    {
                        chkNerviosa.Checked = true;
                    }
                    else
                    {
                        chkNerviosa.Checked = false;
                    }

                    if (registro["CicatrizaPronto"].ToString() == "1")
                    {
                        chkCicatrizacion.Checked = true;
                    }
                    else
                    {
                        chkCicatrizacion.Checked = false;
                    }

                    if (registro["AnestesiaBoca"].ToString() == "1")
                    {
                        chkAnestesiaBoca.Checked = true;
                    }
                    else
                    {
                        chkAnestesiaBoca.Checked = false;
                    }

                    if (registro["RechinaDientes"].ToString() == "1")
                    {
                        chkRechinan.Checked = true;
                    }
                    else
                    {
                        chkRechinan.Checked = false;
                    }

                    if (registro["Tuberculosis"].ToString() == "1")
                    {
                        chkTuberculosis.Checked = true;
                    }
                    else
                    {
                        chkTuberculosis.Checked = false;
                    }

                    if (registro["Hepatitis"].ToString() == "1")
                    {
                        chkHepatitis.Checked = true;
                    }
                    else
                    {
                        chkHepatitis.Checked = false;
                    }

                    if (registro["Sifilis"].ToString() == "1")
                    {
                        chkSifilis.Checked = true;
                    }
                    else
                    {
                        chkSifilis.Checked = false;
                    }

                    if (registro["Osteoporosis"].ToString() == "1")
                    {
                        chkOsteoporosis.Checked = true;
                    }
                    else
                    {
                        chkOsteoporosis.Checked = false;
                    }

                    if (registro["Sida"].ToString() == "1")
                    {
                        chkVIH.Checked = true;
                    }
                    else
                    {
                        chkVIH.Checked = false;
                    }
                }

            }
            catch (Exception)
            {
                pbFoto.BackgroundImage = null;
                pbFoto.Image = null;
            }
            finally
            {
                ConexionBD.Cerrar();
            }
           

        }
        
        private void EliminarPaciente()
        {
            IdPaciente = dtgPacientes.SelectedCells[2].Value.ToString();
            LPacientes parametros = new LPacientes();
            DPacientes funcion = new DPacientes();
            parametros.Paciente = IdPaciente;
            if (funcion.EliminarPaciente(parametros) == true)
            {
                MostrarPaciente();
            }
        }

        private void ControlPacientes_Load(object sender, EventArgs e)
        {
            txtBuscador.Focus();
            MostrarPaciente();
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
            MostrarPaciente();
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
            desde = hasta - 19;
            MostrarPaciente();
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
            MostrarPaciente();
        }

        private void llenaCombos()
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("Select estadocivil From estadoCivil Order By estadoCivil", ConexionBD.conectar);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                DataRow fila = dt.NewRow();
                fila["estadoCivil"] = "";
                dt.Rows.InsertAt(fila, 0);

                cmbEstadoCivil.ValueMember = "estadocivil";
                cmbEstadoCivil.DisplayMember = "estadocivil";
                cmbEstadoCivil.DataSource = dt;

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

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            frmReporte frm = new frmReporte(txtPaciente.Text);
            frm.ShowDialog();
            //frm.Visible = true;
        }

        private void txtMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOdontograma_Click(object sender, EventArgs e)
        {
            frmOdontograma forma = new frmOdontograma(txtPaciente.Text);
            forma.ShowDialog();

            //Pruebadibujocs forma = new Pruebadibujocs();
            //forma.ShowDialog();
        }
    }
}
