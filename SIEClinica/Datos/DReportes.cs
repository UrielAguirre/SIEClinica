using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIEClinica.Datos
{
    public class DReportes
    {
        public static void ReporteVentasTotalizadas(ref DataTable dt, DateTime FechaIni, DateTime FechaFin, string Producto, string Cliente)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteVentasTotalizadoPorProducto", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaIni", FechaIni);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", FechaFin);
                da.SelectCommand.Parameters.AddWithValue("@Producto", Producto);
                da.SelectCommand.Parameters.AddWithValue ("@Cliente", Cliente);
                da.Fill(dt);
                
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

        public static void ReporteVentasDetallado(ref DataTable dt, DateTime FechaIni, DateTime FechaFin, string Producto, string Cliente)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteVentasDetallado", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaIni", FechaIni);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", FechaFin);
                da.SelectCommand.Parameters.AddWithValue("@Producto", Producto);
                da.SelectCommand.Parameters.AddWithValue("@Cliente", Cliente);
                da.Fill(dt);

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

        

        public static void ReporteProductos(ref DataTable dt)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteProductos", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;             
                da.Fill(dt);

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

        public static void ReporteMedicos(ref DataTable dt)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteMedicos", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);

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

        public static void ReportePacientes(ref DataTable dt)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReportePacientes", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);

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

        

        public static void ReporteExistencias(ref DataTable dt)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteExistencias", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
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

        public static void ReporteCxC(ref DataTable dt, DateTime FechaIni, DateTime FechaFin, string Cliente)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReportecXc", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaIni", FechaIni);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", FechaFin);                
                da.SelectCommand.Parameters.AddWithValue("@Cliente", Cliente);
                da.Fill(dt);
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

        public static void ReporteEstadoDeCuenta(ref DataTable dt, DateTime FechaIni, DateTime FechaFin, string Cliente)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteEstadoDeCuenta", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaIni", FechaIni);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", FechaFin);
                da.SelectCommand.Parameters.AddWithValue("@Cliente", Cliente);
                da.Fill(dt);
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

        public static void ReporteKardex(ref DataTable dt, DateTime FechaIni, DateTime FechaFin, string Producto)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteKardex", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaIni", FechaIni);
                da.SelectCommand.Parameters.AddWithValue("@FechaFin", FechaFin);
                da.SelectCommand.Parameters.AddWithValue("@Producto", Producto);
                da.Fill(dt);
                
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

        



    }
}
