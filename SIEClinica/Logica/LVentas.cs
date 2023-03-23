using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEClinica.Logica
{
    public class LVentas 
    { 
           public int Venta { get; set; }
           public string Paciente { get; set; }
           public string nombrePaciente { get; set; }
           public DateTime Fecha { get; set; }
           public DateTime Fecha_venc { get; set; }
           public int No_Referen { get; set; }
           public double Importe { get; set; }
           public double Impuesto { get; set; }
           public string Estado { get; set; }
           public int Cobranza { get; set; }
           public int idCita { get; set; }
           public string Usuario { get; set; }
           public DateTime UsuFecha { get; set; }
           public DateTime UsuHora { get; set; }
           public string Estacion { get; set; }
           public string Producto { get; set; }
           public string Descrip { get; set; }
           public double Cantidad { get; set; }
           public double Precio { get; set; }
           public double ImpuestoU { get; set; }
           public double DescuentoU { get; set; }
           public int Invent { get; set; }
           public string Observ { get; set; }

    }

    
}
