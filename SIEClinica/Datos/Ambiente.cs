using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIEClinica.Datos
{
    public class Ambiente
    {
        public static string var1;
        public static string var2;
        public static string var3;
        public static string var4;
        public static string var5;
        public static string var6;
        public static string var7;
        public static string var8;
        public static string var9;
        public static string var10;

        public bool validaExisteEnCatalogo(string clave, string tabla, string campo)
        {
            try
            {
                ConexionBD.Abrir();
                string sqlQuery = "Select * From " + tabla + " Where " + campo + " = '" + clave + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.Read())
                {                    
                    return true;
                }
                else
                {
                    return false;
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
        public void validaSoloDigitos(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }



    }
}
