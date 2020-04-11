using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppParcial.Models
{
    public class Prestamo
    {
        public int PrestamoID { get; set; }
        public int LibroID { get; set; }
        public Libro Libro { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Devolucion> Devolucions { get; set; }
    }
}
