using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEClinica.Logica
{
    public class LCobranza
    {
        public int IdCobdet { get; set; }
        public int IdCobranza { get; set; }
        public int IdCita { get; set; }        
        public string Paciente { get; set; }
        public string Nombre { get; set; }
        public string CargoAb { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }     
        public double Importe { get; set; }
        public string Estatus { get; set; }
        public string Usuario { get; set; }
        public string Usufecha { get; set; }
        public string Usuhora { get; set; }
        public string Estacion { get; set; }


    }
}
