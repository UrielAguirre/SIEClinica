using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SIEClinica.Logica;

namespace SIEClinica.Datos
{
    public class DConsultorios
    {

        public bool InsertarConsultorio(LConsultorios parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarConsultorio", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Consultorio", parametros.Consultorio);
                cmd.Parameters.AddWithValue("@Descripcion", parametros.Descripcion);                
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
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();
                
            }

        }

        public bool EliminarConsultorio(LConsultorios parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("EliminarConsultorio", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Consultorio", parametros.Consultorio);               
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

        public void MostrarConsultorios(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarConsultorios", ConexionBD.conectar);
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

        public void BuscarConsultorios(ref DataTable dt, int desde, int hasta, string buscador)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarConsultorio", ConexionBD.conectar);
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

        public int TraeUltimoConsultorio()
        {
            try
            {
                int ultimoConsultorioId;
                String sqlQuery = "Select isNull(Max(Cast(consultorio As integer)),0) As id From consultorios";               
              
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(sqlQuery, ConexionBD.conectar);
                //if(cmd.ExecuteScalar().)
                ultimoConsultorioId = Convert.ToInt32(cmd.ExecuteScalar());
                //MessageBox.Show("" + ultimoMedicoId);

                //cmd.Dispose();

                //SqlDataReader registro = cmd.ExecuteReader();
                //if (registro.Read())
                //{
                //    ultimoConsultorioId = Convert.ToInt32(registro["id"].ToString());
                //}
                //else
                //{
                //    ultimoConsultorioId = 0;
                //}
                return ultimoConsultorioId;

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

        public void ContarConsultorio(ref int Contador)
        {
            try
            {
                ConexionBD.Abrir();
                string sqlQuery = "Select Count(descripcion) As i From consultorios Where estatus <> 'Eliminado'";
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


