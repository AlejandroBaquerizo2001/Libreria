using ClassLibrary1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repositorio
{
    public interface IRepositorioGeneros
    {
        Task<List<Genero>> ObtenerTodos();
        Task<Genero?> ObtenerPorId(int id);
        Task<int> Crear(Genero genero);
        Task<int> Crear2(Genero genero);

        Task<int> CambiarEstadoActivo(int id);
        Task<int> ModificarGenero(Genero genero);
        Task EliminarGenero(int id);

    }
}
