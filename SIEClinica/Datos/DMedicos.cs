using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SIEClinica.Logica;

namespace SIEClinica.Datos
{
    public class DMedicos
    {

        public bool InsertarMedico(LMedicos parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarMedico", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Medico", parametros.Medico);
                cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                cmd.Parameters.AddWithValue("@FNacimiento", parametros.FNacimiento);
                cmd.Parameters.AddWithValue("@Domicilio", parametros.Domicilio);
                cmd.Parameters.AddWithValue("@Ciudad", parametros.Ciudad);
                cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);
                cmd.Parameters.AddWithValue("@Celular", parametros.Celular);
                cmd.Parameters.AddWithValue("@eMail", parametros.eMail);
                cmd.Parameters.AddWithValue("@foto", parametros.Foto);
                cmd.Parameters.AddWithValue("@Estatus", parametros.Estatus);
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
                MessageBox.Show(ex.StackTrace + " " + ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();                
            }

        }

        public bool EliminarMedico(LMedicos parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("EliminarMedico", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Medico", parametros.Medico);               
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

        public void MostrarMedicos(ref DataTable dt, int desde, int hasta)
        {
            
            try
            {                
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarMedicos", ConexionBD.conectar);
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

        public void BuscarMedicos(ref DataTable dt, int desde, int hasta, string buscador)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarMedico", ConexionBD.conectar);
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

        public int TraeUltimoMedico()
        {
            try
            {
                int ultimoMedicoId;
                String sqlQuery = "Select isNull(Max(Cast(medico As integer)),0) As id From medicos";               
              
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(sqlQuery, ConexionBD.conectar);
                //if(cmd.ExecuteScalar().)
                ultimoMedicoId = Convert.ToInt32(cmd.ExecuteScalar());
                //MessageBox.Show("" + ultimoMedicoId);

                //cmd.Dispose();

                //SqlDataReader registro = cmd.ExecuteReader();
                //if (registro.Read())
                //{
                //    ultimoMedicoId = Convert.ToInt32(registro["id"].ToString());
                //}
                //else
                //{
                //    ultimoMedicoId = 0;
                //}
                return ultimoMedicoId;

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

        public void ContarMedico(ref int Contador)
        {
            try
            {
                ConexionBD.Abrir();
                string sqlQuery = "Select Count(nombre) As i From Medicos Where estatus <> 'Eliminado'";
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


