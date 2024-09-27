using ClassLibrary1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaPeliculas.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public int GeneroId { get; set; }

        public Genero? Genero { get; set; } 
        public int Estado { get; set; }

        public int AutorId { get; set; }
        public Autor? Autor { get; set; } 

    }
}
