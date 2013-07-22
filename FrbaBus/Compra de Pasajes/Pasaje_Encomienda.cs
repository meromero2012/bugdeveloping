using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Compra_de_Pasajes
{
    /* En esta clase equivale a todos los datos de un pasaje o encomienda comprados */
    public class Pasaje_Encomienda
    {
        public String tipo { get; set; }
        public String dni_viajero { get; set; }
        public String precio { get; set; }
        public String codigo_viaje { get; set; }
        public String micro_patente { get; set; }
        public String nro_butaca { get; set; }
        public String piso_butaca { get; set; }
        public String kgs_utilizados { get; set; }
    }
}