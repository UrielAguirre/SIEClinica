using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SIEClinica.Logica;

namespace SIEClinica.Datos
{
    public class DFlujo
    {

        public bool InsertarFlujo(LFlujo parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarFlujo", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdFlujo", 0);
                cmd.Parameters.AddWithValue("@IdVenta", 0);
                cmd.Parameters.AddWithValue("@IdCita", 0);
                cmd.Parameters.AddWithValue("@IdCobdet", 0);
                cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                cmd.Parameters.AddWithValue("@Concepto", parametros.Concepto);
                cmd.Parameters.AddWithValue("@Concepto2", parametros.Concepto2);
                cmd.Parameters.AddWithValue("@IE", parametros.IE);
                cmd.Parameters.AddWithValue("@Importe", parametros.Importe);
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

        public bool EliminarFlujo(LFlujo parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("EliminarFlujo", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idFlujo", parametros.IdFlujo);               
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

        public void MostrarFlujo(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarFlujo", ConexionBD.conectar);
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

        public void BuscarFlujo(ref DataTable dt, int desde, int hasta, string buscador, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarFlujo", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                da.SelectCommand.Parameters.AddWithValue("@FechaIni", fechaIni);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", fechaFin);                        
                
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
        

    }

}


