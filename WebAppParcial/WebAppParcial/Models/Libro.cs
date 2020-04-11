using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppParcial.Models
{
    public class Libro
    {
        public int LibroID { get; set; }
        public int AreaID { get; set; }
        public Area Area { get; set; } 
        public string Nombre { get; set; }
        public string NumeroPaginas { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; }
    }
}
