using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SIEClinica.Logica;

namespace SIEClinica.Datos
{
    public class DCitas
    {

        public bool InsertarCita(LCitas parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarCita", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                cmd.Parameters.AddWithValue("@HoraIni", parametros.HoraInicial);                
                cmd.Parameters.AddWithValue("@HoraFin", parametros.HoraFinal);
                cmd.Parameters.AddWithValue("@Paciente", parametros.Paciente);
                cmd.Parameters.AddWithValue("@nombrePaciente", parametros.NombrePaciente);
                cmd.Parameters.AddWithValue("@Medico", parametros.Medico);
                cmd.Parameters.AddWithValue("@Consultorio", parametros.Consultorio);
                cmd.Parameters.AddWithValue("@Motivo", parametros.Motivo);
                cmd.Parameters.AddWithValue("@Confirmado", parametros.Confirmado);
                cmd.Parameters.AddWithValue("@TipoCita", parametros.TipoCita);
                cmd.Parameters.AddWithValue("@IdCitaOrigen", parametros.idCitaOrigen);
                cmd.Parameters.AddWithValue("@Estatus", parametros.Estatus);
                cmd.Parameters.AddWithValue("@Usuario", parametros.Usuario);
                cmd.Parameters.AddWithValue("@Usufecha", parametros.Usufecha);
                cmd.Parameters.AddWithValue("@Usuhora", parametros.Usuhora);
                cmd.Parameters.AddWithValue("@Estacion", parametros.Estacion);
                cmd.ExecuteNonQuery();
                //cmd.ResetCommandTimeout();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();                
            }

        }

        public bool ActualizaCita(LCitas parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("ActualizaCita", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCita", parametros.IdCita);
                cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                cmd.Parameters.AddWithValue("@HoraIni", parametros.HoraInicial);
                cmd.Parameters.AddWithValue("@HoraFin", parametros.HoraFinal);
                cmd.Parameters.AddWithValue("@Paciente", parametros.Paciente);
                cmd.Parameters.AddWithValue("@nombrePaciente", parametros.NombrePaciente);
                cmd.Parameters.AddWithValue("@Medico", parametros.Medico);
                cmd.Parameters.AddWithValue("@Consultorio", parametros.Consultorio);
                cmd.Parameters.AddWithValue("@Motivo", parametros.Motivo);
                cmd.Parameters.AddWithValue("@Confirmado", parametros.Confirmado);
                cmd.Parameters.AddWithValue("@TipoCita", parametros.TipoCita);
                cmd.Parameters.AddWithValue("@IdCitaOrigen", parametros.idCitaOrigen);
                cmd.Parameters.AddWithValue("@Estatus", parametros.Estatus);
                cmd.Parameters.AddWithValue("@Usuario", parametros.Usuario);
                cmd.Parameters.AddWithValue("@Usufecha", parametros.Usufecha);
                cmd.Parameters.AddWithValue("@Usuhora", parametros.Usuhora);
                cmd.Parameters.AddWithValue("@Estacion", parametros.Estacion);
                cmd.ExecuteNonQuery();
                //cmd.ResetCommandTimeout();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();
            }
        }

        public bool EliminarCita(LCitas parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("EliminarCita", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCita", parametros.IdCita);               
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

        public void MostrarCitas(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarCitas", ConexionBD.conectar);
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

        public void BuscarCitas(ref DataTable dt, int desde, int hasta, string buscador, DateTime fechaIni, DateTime fechaFin, string Confirmado)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarCita", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                da.SelectCommand.Parameters.AddWithValue("@FechaIni", fechaIni);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);
                if (Confirmado == "Confirmado")                {
                    da.SelectCommand.Parameters.AddWithValue("@Confirmado", "CO");

                }else if (Confirmado == "Pendiente") 
                {
                    da.SelectCommand.Parameters.AddWithValue("@Confirmado", "PE");
                }
                else
                {
                    da.SelectCommand.Parameters.AddWithValue("@Confirmado", "");
                }                
                
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
                
        public void ContarCitas(ref int Contador)
        {
            try
            {
                ConexionBD.Abrir();
                string sqlQuery = "Select Count(fecha) As i From citas Where estatus <> 'Eliminado'";
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

        public bool citaLibre( string medico, string consultorio, DateTime fecha, DateTime horaIni, DateTime horaFin, int IdCita )
        {
            try
            {
                ConexionBD.Abrir();
                string sqlQuery = "";
                string strMensaje = "";
                DateTime fechaCita;
                DateTime horaIniCita;
                DateTime horaFinCita;

                sqlQuery = sqlQuery + "Select p.Nombre As NombrePac, m.Nombre, c.fecha, c.HoraIni, c.HoraFin From citas As c Left Join pacientes As p On p.paciente = c.paciente Left Join medicos As m On m.medico = c.medico ";
                sqlQuery = sqlQuery + "Where id != " + IdCita + " And Format(c.fecha, 'yyyyMMdd') = '" + fecha.ToString("yyyyMMdd") + "' And c.medico = '" + medico + "' ";
                sqlQuery = sqlQuery + "And ( ";
                    sqlQuery = sqlQuery + "('" + horaIni.ToString("HH:mm") + "' >= c.horaIni And '" + horaIni.ToString("HH:mm") + "' < c.horaFin) ";
                sqlQuery = sqlQuery + "Or ('" + horaFin.ToString("HH:mm") + "' > c.horaIni And '" + horaFin.ToString("HH:mm") + "' <= c.horaFin) ";
                sqlQuery = sqlQuery + "Or  (('" + horaIni.ToString("HH:mm") + "' < c.horaIni) And ('" + horaFin.ToString("HH:mm") + "' > c.horaFin)) ";                
                sqlQuery = sqlQuery + ") ";
                                
                SqlCommand cmd = new SqlCommand(sqlQuery, ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    fechaCita = Convert.ToDateTime(registro["fecha"]);
                    horaIniCita = Convert.ToDateTime(registro["HoraIni"].ToString());
                    horaFinCita = Convert.ToDateTime(registro["HoraFin"].ToString());

                    strMensaje = strMensaje + "Existe una cita en la misma fecha\n\nPaciente: " + registro["NombrePac"].ToString() + "\nMédico: " + registro["Nombre"].ToString();
                    strMensaje = strMensaje + "\nFecha: " + fechaCita.ToString("dd/MM/yyyy");
                    strMensaje = strMensaje + "\n" + horaIniCita.ToString("hh:mm tt") + " - " + horaFinCita.ToString("hh:mm tt");
                    MessageBox.Show(strMensaje);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
            finally
            {
                ConexionBD.Cerrar();
            }
            
        }

        public bool consultorioLibre( string consultorio, DateTime fecha, DateTime horaIni, DateTime horaFin)
        {
            try
            {
                ConexionBD.Abrir();
                string sqlQuery = "";
                sqlQuery = sqlQuery + "Select * From citas ";
                sqlQuery = sqlQuery + "Where Format(fecha, 'yyyyMMdd') = '" + fecha.ToString("yyyyMMdd") + "' ";
                //sqlQuery = sqlQuery + "And " + horaIni.ToString("HHmm")  + " >= Format(horaIni, 'HH:mm') And " + horaIni.ToString("HHmm") + " <= Format(horaFin, 'HH:mm')";
                //sqlQuery = sqlQuery + "And " + horaFin.ToString("HHmm") + " >= Format(horaIni, 'HH:mm') And " + horaFin.ToString("HHmm") + " <= Format(horaFin, 'HH:mm')";
                sqlQuery = sqlQuery + "And '" + horaIni.ToString("HH:mm") + "' >= horaIni And '" + horaIni.ToString("HH:mm") + "' <= horaFin ";
                sqlQuery = sqlQuery + "And '" + horaFin.ToString("HH:mm") + "' >= horaIni And '" + horaFin.ToString("HH:mm") + "' <= horaFin And consultorio = '" + consultorio + "'";

                MessageBox.Show(sqlQuery);

                SqlCommand cmd = new SqlCommand(sqlQuery, ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.Read())
                {
                    MessageBox.Show("El consultorio está ocupado en esa fecha y hora");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
            finally
            {
                ConexionBD.Cerrar();
            }
        }

    }

}


