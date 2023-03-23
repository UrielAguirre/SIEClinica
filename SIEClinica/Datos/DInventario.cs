using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SIEClinica.Logica;

namespace SIEClinica.Datos
{
    public class DInventario
    {
        public bool InsertarMovInventario(LMovInvent parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarMovInventario", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdInventario", parametros.IdInventario);                
                cmd.Parameters.AddWithValue("@Ent_Sal", parametros.Ent_Sal);
                cmd.Parameters.AddWithValue("@Concepto", parametros.Concepto);
                cmd.Parameters.AddWithValue("@ConceptoDescrip", parametros.ConceptoDescrip);
                cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);                
                cmd.Parameters.AddWithValue("@Usuario", parametros.Usuario);
                cmd.Parameters.AddWithValue("@Usufecha", parametros.UsuFecha);
                cmd.Parameters.AddWithValue("@Usuhora", parametros.UsuHora);
                cmd.Parameters.AddWithValue("@Estacion", parametros.Estacion);                
                cmd.ExecuteNonQuery();

                cmd.ResetCommandTimeout();
                
                return true;
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();
            }
        }

        public bool InsertarPartidaInventario(LInventario parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("InsertarPartidaInventario", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdInventario", parametros.IdInventario);
                cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                cmd.Parameters.AddWithValue("@Ent_Sal", parametros.Ent_Sal);
                cmd.Parameters.AddWithValue("@Concepto", parametros.Concepto);
                cmd.Parameters.AddWithValue("@ConceptoDescrip", parametros.ConceptoDescrip);
                cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                cmd.Parameters.AddWithValue("@Importe", parametros.Importe);
                cmd.Parameters.AddWithValue("@Impuesto", parametros.Impuesto);
                cmd.Parameters.AddWithValue("@Articulo", parametros.Articulo);
                cmd.Parameters.AddWithValue("@Descrip", parametros.Descrip);
                cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);
                cmd.Parameters.AddWithValue("@Costo", parametros.Costo);
                cmd.Parameters.AddWithValue("@Precio1", parametros.Precio1);
                cmd.Parameters.AddWithValue("@Invent", parametros.Invent);
                cmd.Parameters.AddWithValue("@Usuario", parametros.Usuario);
                cmd.Parameters.AddWithValue("@Usufecha", parametros.UsuFecha);
                cmd.Parameters.AddWithValue("@Usuhora", parametros.UsuHora);
                cmd.Parameters.AddWithValue("@Estacion", parametros.Estacion);

                SqlParameter IdInvNvo = new SqlParameter("@IdInvNvo", SqlDbType.Int);
                IdInvNvo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(IdInvNvo);

                cmd.ExecuteNonQuery();

                cmd.ResetCommandTimeout();
                int IdInvNvo1 = (int)IdInvNvo.Value;
                //MessageBox.Show(idVenta.ToString());
                Ambiente.var1 = IdInvNvo1.ToString();
                
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                //MessageBox.Show(ex.Source);
                //MessageBox.Show(ex.InnerException.ToString());
                //MessageBox.Show(ex.TargetSite.ToString());
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();                
            }
        }

        public bool EliminarMovInventario(LInventario parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("EliminarMovInventario", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idInventario", parametros.IdInventario);               
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

        public void MostrarInventario(ref DataTable dt, int desde, int hasta)
        {
            try
            {                
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarInventario", ConexionBD.conectar);
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

        public void BuscarInventario(ref DataTable dt, int desde, int hasta, string buscador, DateTime fechaIni, DateTime fechaFin, string Confirmado)
        {
            try
            {                
                ConexionBD.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarInventario", ConexionBD.conectar);
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

                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                ConexionBD.Cerrar();
            }

        }
                
        public void ContarInventario(ref int Contador)
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

        public double CalculaUnidades(int IdInventario)
        {
            double iUnidades = 0;
           
            string strSQL = "Select IsNull(Sum(cantidad),0) As i From EntSalPart Where idMovimiento = " + IdInventario;
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                iUnidades = Convert.ToDouble(cmd.ExecuteScalar());                
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBD.Cerrar();
            }
            return iUnidades;


        }

        public double CalculaImporte(int IdInventario)
        {            
            double iImporte = 0;
            string strSQL = "Select IsNull(Sum(costo * cantidad * (1 + (impuesto/100))),0) As i From EntSalPart Where idMovimiento = " + IdInventario;
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                iImporte = Convert.ToDouble(cmd.ExecuteScalar());
                cmd.Dispose();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBD.Cerrar();                
            }
            return iImporte;

        }
    }

}


