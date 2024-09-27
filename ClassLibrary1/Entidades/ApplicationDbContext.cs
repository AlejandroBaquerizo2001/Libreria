using LibreriaPeliculas.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Entidades
{
    public class ApplicationDbContext : DbContext
    {
     
        /// <summary>
        /// Activar solo este método para que sea implementado desde un Servicio
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        
        /*
        /// <summary>
        /// Activar solo este método para las migraciones de la BD
        /// </summary>
        /// <param name="optionsBuilder"></param>
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Peliculas;Integrated Security=True;TrustServerCertificate=True;");
       
        }
     
       */
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Percha> Perchas { get; set; }

        public DbSet<Ubicacion> Ubicaciones { get; set; }
    }
}
