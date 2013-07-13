using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaBus.Compra_de_Pasajes
{
    /* Almacena las compras realizadas */
    public class Compra
    {
        public List<Pasaje_Encomienda> Compras { get; set; }

        public Compra() { Compras = new List<Pasaje_Encomienda>(); }
    }
}
