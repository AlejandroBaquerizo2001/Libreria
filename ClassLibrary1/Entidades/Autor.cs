using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace LibreriaPeliculas.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        public string nombre { get; set; } = null!;

        public string resumen { get; set; } = null!;

        public DateOnly FechaNacimiento { get; set; }
        [JsonIgnore]
        public List<Libro>? Libros { get; set; }

    }
}
