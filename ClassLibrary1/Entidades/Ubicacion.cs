using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaPeliculas.Entidades
{
    public class Ubicacion
    {
        public int Id { get; set; }
        public int NumeroFila { get; set; }
        public int NumeroColumna { get; set; }

        public int PerchaId { get; set; }
        public Percha Percha { get; set; } = null!;

        public int LibroId { get; set; }
        public Libro Libro { get; set; } = null!;

    }
}
