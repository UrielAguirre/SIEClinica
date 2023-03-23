using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIEClinica.Logica
{
    public class LInventario
    {
        public int IdInventario { get; set; }

        public string Estado { get; set; }

        public string Ent_Sal { get; set; }

        public string Concepto { get; set; }

        public string ConceptoDescrip { get; set; }

        public DateTime Fecha { get; set; }

        public double Importe { get; set; }

        public double Impuesto { get; set; }

        public string Articulo { get; set; }

        public string Descrip { get; set; }

        public double Cantidad { get; set; }

        public double Costo { get; set; }

        public double Precio1 { get; set; }

        public int Invent { get; set; }

        public string Usuario { get; set; }

        public DateTime UsuFecha { get; set; }

        public DateTime UsuHora { get; set; }

        public string Estacion { get; set; }

    }
}
