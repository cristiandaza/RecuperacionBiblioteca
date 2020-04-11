using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppParcial.Models
{
    public class Area
    {
     public int AreaID { get; set; }
     public string Nombre { get; set; }
     public string TiempoPrestamo { get; set; }
     public ICollection<Libro> Libros { get; set; } 
    }
}
