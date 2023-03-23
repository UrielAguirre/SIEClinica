using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEClinica.Datos
{
    public class ConexionBD
    {

       //public static string conexion = @"Data Source=.\SQL2014Express; Initial Catalog=SIEClinica; Integrated Security=true;";
       public static string conexion = @"Data Source=.\SQLServer2014; Initial Catalog=SIEClinica; Integrated Security=true;";

        public static SqlConnection conectar = new SqlConnection(conexion);

        public static void Abrir()
        {
            if (conectar.State == System.Data.ConnectionState.Closed)
            {
                conectar.Open();
            }
        }


        public static void Cerrar()
        {

            if (conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }


        }


    }
}