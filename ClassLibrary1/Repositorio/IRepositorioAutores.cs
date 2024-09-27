using ClassLibrary1.Entidades;
using LibreriaPeliculas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaPeliculas.Repositorio
{
    public interface IRepositorioAutores
    {
        Task<List<Autor>> ObtenerTodos();
        Task<Autor?> ObtenerPorId(int id);
        Task<int> Crear(Autor autor);

        Task<List<Autor>> ObtenerPorRangoFecha(DateOnly fechaInicio, DateOnly fechaFin);

        Task<Autor> ModificarAutor(Autor autor);
       
        Task EliminarAutor(int id);
    }
}
