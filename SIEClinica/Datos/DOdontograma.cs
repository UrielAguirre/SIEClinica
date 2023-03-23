using SIEClinica.Logica;
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
    class DOdontograma
    {

        public bool InsertarCoordenas(LOdontograma parametros)
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd = new SqlCommand("PuntosOdontograma", ConexionBD.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Paciente", parametros.Paciente);
                cmd.Parameters.AddWithValue("@PuntoIniX", parametros.PuntoIniX);
                cmd.Parameters.AddWithValue("@PuntoIniY", parametros.PuntoIniX);
                cmd.Parameters.AddWithValue("@PuntoFinX", parametros.PuntoFinX);
                cmd.Parameters.AddWithValue("@PuntoFinY", parametros.PuntoFinY);
                cmd.Parameters.AddWithValue("@PuntoIni", parametros.PuntoIni);
                cmd.Parameters.AddWithValue("@PuntoFin", parametros.PuntoFin);
                cmd.Parameters.AddWithValue("@Color", parametros.Color);
                cmd.Parameters.AddWithValue("@Inicia", parametros.Inicia);
                cmd.Parameters.AddWithValue("@Finaliza", parametros.Finaliza);
                cmd.Parameters.AddWithValue("@Borrado", parametros.borrado);
                cmd.Parameters.AddWithValue("@Usuario", parametros.Usuario);                
                cmd.Parameters.AddWithValue("@Estacion", parametros.Estacion);
                cmd.ExecuteNonQuery();
                //cmd.ResetCommandTimeout();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();
            }

        }

        public SqlDataReader MuestraOdontograma(string Paciente)
        {
            try
            {
                ConexionBD.Abrir();
                string strSQL = "Select SubSTring(PuntoIni, 4, CharIndex(',',PuntoIni,0) - 4) As PIniA, SubSTring(PuntoIni, CharIndex('Y',PuntoIni,0) + 2, Len(PuntoIni) - (CharIndex('Y',PuntoIni,0) + 2) ) As PIniB, " +
                        "SubSTring(PuntoFin, 4, CharIndex(',',PuntoIni,0) - 4) As PFinA, SubSTring(PuntoFin, CharIndex('Y',PuntoFin,0) + 2, Len(PuntoFin) - (CharIndex('Y',PuntoFin,0) + 2) ) As PFinB" +
                        "From Odontograma Where paciente = '" + Paciente + "'";
                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                cmd.CommandType = CommandType.Text;
                SqlDataReader registros = cmd.ExecuteReader();

                
                //cmd.ResetCommandTimeout();
                return registros;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
                return null;
            }
            finally
            {
                ConexionBD.Cerrar();
            }
            

        }
    }
}
