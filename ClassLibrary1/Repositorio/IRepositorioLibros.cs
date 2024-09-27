using LibreriaPeliculas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaPeliculas.Repositorio
{
    public interface IRepositorioLibros
    {
        Task<List<Libro>> ObtenerTodos();
        Task<Libro?> ObtenerPorId(int id);
        Task<int> Crear(Libro autor);

        Task Eliminar(int id);
        Task<int> Modificar(Libro autor);


    }
}
