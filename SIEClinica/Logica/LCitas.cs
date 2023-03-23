using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEClinica.Logica
{
    public class LCitas
    {

        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicial { get; set; }

        public DateTime HoraFinal { get; set; }

        public string Paciente { get; set; }

        public string NombrePaciente { get; set; }

        public string Medico { get; set; }

        public string Consultorio { get; set; }

        public string Motivo { get; set; }

        public string Confirmado { get; set; }

        public string Estatus { get; set; }

        public string TipoCita { get; set; }

        public int idCitaOrigen { get; set; }

        public string Usuario { get; set; }

        public DateTime Usufecha { get; set; }

        public string Usuhora { get; set; }

        public string Estacion { get; set; }

    }
}
