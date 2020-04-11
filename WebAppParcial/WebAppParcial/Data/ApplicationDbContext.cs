using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppParcial.Models;

namespace WebAppParcial.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebAppParcial.Models.Usuario> Usuario { get; set; }
        public DbSet<WebAppParcial.Models.Area> Area { get; set; }
        public DbSet<WebAppParcial.Models.Libro> Libro { get; set; }
        public DbSet<WebAppParcial.Models.Prestamo> Prestamo { get; set; }
        public DbSet<WebAppParcial.Models.Devolucion> Devolucion { get; set; }
    }
}
