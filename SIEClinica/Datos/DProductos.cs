using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SIEClinica.Logica;

namespace SIEClinica.Datos
{
    public class DProductos
    {

        public bool InsertarProducto(LProductos parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarProducto", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Producto", parametros.Producto);
                cmd.Parameters.AddWithValue("@Descrip", parametros.Descripcion);
                cmd.Parameters.AddWithValue("@Costo", parametros.Costo);
                cmd.Parameters.AddWithValue("@CostoU", parametros.CostoU);
                cmd.Parameters.AddWithValue("@Precio1", parametros.Precio1);
                cmd.Parameters.AddWithValue("@Precio2", parametros.Precio2);
                cmd.Parameters.AddWithValue("@Precio3", parametros.Precio3);
                cmd.Parameters.AddWithValue("@Invent", parametros.Invent);
                cmd.Parameters.AddWithValue("@Impuesto", parametros.Impuesto);
                cmd.Parameters.AddWithValue("@Unidad", parametros.Unidad);
                cmd.Parameters.AddWithValue("@Linea", parametros.Linea);
                cmd.Parameters.AddWithValue("@Foto", parametros.Foto);
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

        public bool EliminarProducto(LProductos parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("EliminarProducto", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Producto", parametros.Producto);
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

        public void MostrarProductos(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarProductos", ConexionBD.conectar);
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

        public void BuscarProductos(ref DataTable dt, int desde, int hasta, string buscador)
        {
            try
            {
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarProducto", ConexionBD.conectar);
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

        public int TraeUltimoProducto()
        {
            try
            {
                int ultimoProductoId;
                String sqlQuery = "Select isNull(Max(Cast(producto As integer)),0) As id From productos";               
              
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(sqlQuery, ConexionBD.conectar);
                //if(cmd.ExecuteScalar().)
                ultimoProductoId = Convert.ToInt32(cmd.ExecuteScalar());
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
                return ultimoProductoId;

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

        public void ContarProducto(ref int Contador)
        {
            try
            {
                ConexionBD.Abrir();
                string sqlQuery = "Select Count(descrip) As i From Productos Where estatus <> 'Eliminado'";
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


