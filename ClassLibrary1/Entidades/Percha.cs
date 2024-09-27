
using ClassLibrary1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaPeliculas.Entidades
{
    public class Percha
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Filas { get; set; }
        public int Columnas { get; set; }

        //public int GeneroId { get; set; }
        //public Genero Genero { get; set; } = null!;

        List<Ubicacion>? Ubicaciones { get; set; }



    }
}
