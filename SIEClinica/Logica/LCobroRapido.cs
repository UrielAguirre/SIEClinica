using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEClinica.Logica
{
    public class LCobroRapido
    {
        public int nVenta { get; set; }

        public int idCita { get; set; }
        public string sPaciente { get; set; }
        public string nombrePaciente { get; set; }
        public string sFPago1 { get; set; } 
        public double iImporte1 { get; set; }
        public string sFPago2 { get; set; }
        public double iImporte2 { get; set; }
        public string sFPago3 { get; set; }
        public double iImporte3 { get; set; }
        public double iCambio { get; set; }
        public double iImporteCxC { get; set; }
        public string Usuario { get; set; }
        public string Usufecha { get; set; }
        public string Usuhora { get; set; }
        public string Estacion { get; set; }

    }
}
