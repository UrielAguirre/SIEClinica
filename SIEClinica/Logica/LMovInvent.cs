using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEClinica.Logica
{
    public class LMovInvent
    {
        public int IdInventario { get; set; }

        public string Ent_Sal { get; set; }

        public string Concepto { get; set; }

        public string ConceptoDescrip { get; set; }

        public DateTime Fecha { get; set; }

        public string Usuario { get; set; }

        public DateTime UsuFecha { get; set; }

        public DateTime UsuHora { get; set; }

        public string Estacion { get; set; }

    }
}
