using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppParcial.Models
{
    public class Devolucion
    {
        public int DevolucionID { get; set; }
        public int PrestamoID { get; set; }
        public Prestamo Prestamo { get; set; }
        public DateTime Fecha { get; set; }

    }
}
