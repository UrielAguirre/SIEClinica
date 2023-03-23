using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SIEClinica.Logica;

namespace SIEClinica.Datos
{
    public class DPacientes
    {

        public bool InsertarPaciente(LPacientes parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarPaciente", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Paciente", parametros.Paciente);
                cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                cmd.Parameters.AddWithValue("@FNacimiento", parametros.FNacimiento);
                cmd.Parameters.AddWithValue("@Domicilio", parametros.Domicilio);
                cmd.Parameters.AddWithValue("@Ciudad", parametros.Ciudad);
                cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);
                cmd.Parameters.AddWithValue("@Celular", parametros.Celular);
                cmd.Parameters.AddWithValue("@eMail", parametros.eMail);
                cmd.Parameters.AddWithValue("@EstadoCivil", parametros.EstadoCivil);
                cmd.Parameters.AddWithValue("@Ocupacion", parametros.Ocupacion);
                cmd.Parameters.AddWithValue("@foto", parametros.Foto);
                cmd.Parameters.AddWithValue("@Estatus", parametros.Estatus);
                cmd.Parameters.AddWithValue("@Tratamiento", parametros.Tratamiento);
                cmd.Parameters.AddWithValue("@Penicilina", parametros.Penicilina);
                cmd.Parameters.AddWithValue("@EnfCorazon", parametros.EnfCorazon);
                cmd.Parameters.AddWithValue("@EnfCorazonDesc", parametros.EnfCorazonDesc);
                cmd.Parameters.AddWithValue("@Epilepsia", parametros.Epilepsia);
                cmd.Parameters.AddWithValue("@Desmayo", parametros.Desmayo);
                cmd.Parameters.AddWithValue("@Diabetes", parametros.Diabetes);
                cmd.Parameters.AddWithValue("@AnesteciaLocal", parametros.AnesteciaLocal);
                cmd.Parameters.AddWithValue("@AnesteciaLocalDesc", parametros.AnesteciaLocalDesc);
                cmd.Parameters.AddWithValue("@Embarazada", parametros.Embarazada);
                cmd.Parameters.AddWithValue("@PersonaNerviosa", parametros.PersonaNerviosa);
                cmd.Parameters.AddWithValue("@CicatrizacionRapida", parametros.CicatrizacionRapida);
                cmd.Parameters.AddWithValue("@AnestesiaBoca", parametros.AnestesiaBoca);
                cmd.Parameters.AddWithValue("@RechinanDientes", parametros.RechinanDientes);
                cmd.Parameters.AddWithValue("@Tuberculosis", parametros.Tuberculosis);
                cmd.Parameters.AddWithValue("@Hepatitis", parametros.Hepatitis);
                cmd.Parameters.AddWithValue("@Sifilis", parametros.Sifilis);
                cmd.Parameters.AddWithValue("@Osteoporosis", parametros.Osteoporosis);
                cmd.Parameters.AddWithValue("@Sida", parametros.Sida);
                cmd.Parameters.AddWithValue("@MesesEmbarazo", parametros.MesesEmbarazo);
                cmd.Parameters.AddWithValue("@TratamientoMedico", parametros.TratamientoMedico);
                cmd.Parameters.AddWithValue("@AlergicoD", parametros.AlergicoD);
                cmd.Parameters.AddWithValue("@DiabetesFam", parametros.DiabetesFam);
                cmd.Parameters.AddWithValue("@Usuario", parametros.Usuario);
                cmd.Parameters.AddWithValue("@Usufecha", parametros.usufecha);
                cmd.Parameters.AddWithValue("@Usuhora", parametros.usuhora);
                cmd.Parameters.AddWithValue("@Estacion", parametros.Estacion);
                cmd.ExecuteNonQuery();
                //cmd.ResetCommandTimeout();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();                
            }

        }

        public bool EliminarPaciente(LPacientes parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("EliminarPaciente", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Paciente", parametros.Paciente);               
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();
            }

        }

        public void MostrarPacientes(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarPacientes", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde",desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.Fill(dt);

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

        public void BuscarPacientes(ref DataTable dt, int desde, int hasta, string buscador)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarPaciente", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                da.Fill(dt);

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

        public int TraeUltimoPaciente()
        {
            try
            {
                int ultimoPacienteId;
                String sqlQuery = "Select isNull(Max(Cast(paciente As integer)),0) As id From pacientes";               
              
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(sqlQuery, ConexionBD.conectar);
                //if(cmd.ExecuteScalar().)
                ultimoPacienteId = Convert.ToInt32(cmd.ExecuteScalar());
                //MessageBox.Show("" + ultimoPacienteId);

                //cmd.Dispose();

                //SqlDataReader registro = cmd.ExecuteReader();
                //if (registro.Read())
                //{
                //    ultimoPacienteId = Convert.ToInt32(registro["id"].ToString());
                //}
                //else
                //{
                //    ultimoPacienteId = 0;
                //}
                return ultimoPacienteId;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            finally
            {
                ConexionBD.Cerrar();                
            }
            
        }

        public void ContarPaciente(ref int Contador)
        {
            try
            {
                ConexionBD.Abrir();
                string sqlQuery = "Select Count(nombre) As i From pacientes Where estatus <> 'Eliminado'";
                SqlCommand cmd = new SqlCommand(sqlQuery, ConexionBD.conectar);
                Contador = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Contador = 0;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBD.Cerrar();
            }

        }
    }

}


