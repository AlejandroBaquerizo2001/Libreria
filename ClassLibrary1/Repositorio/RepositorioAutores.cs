using ClassLibrary1.Entidades;
using LibreriaPeliculas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaPeliculas.Repositorio
{
    public class RepositorioAutores : IRepositorioAutores
    {
        private readonly ApplicationDbContext context;
        public RepositorioAutores(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Crear(Autor autor)
        {
            context.Autores.Add(autor);
            await context.SaveChangesAsync();
           
            return autor.Id;
        }

        public async Task EliminarAutor(int id)
        {
            Autor autor = await context.Autores.FindAsync(id);
            context.Autores.Remove(autor);
            await context.SaveChangesAsync();
        }

        public async Task<Autor> ModificarAutor(Autor autor)
        {
           //obtener el objeto de la BD
            Autor autorMod= await context.Autores.FindAsync(autor.Id);
           //cambiar los valores del objeto consultado
           autorMod.nombre= autor.nombre;
           autorMod.FechaNacimiento=autor.FechaNacimiento;
           autorMod.resumen= autor.resumen;
           //Guardar los cambios
           await context.SaveChangesAsync(); 
           return autorMod;
        }

        public async Task<Autor?> ObtenerPorId(int id)
        {
            //return await context.Autores.FindAsync(id);
            return context.Autores.Where(x => x.Id == id)
                .Include(x=> x.Libros)
                .ToList()[0];

        }

        public async Task<List<Autor>> ObtenerPorRangoFecha(DateOnly fechaInicio, DateOnly fechaFin)
        {
            return context.Autores.Where(a => a.FechaNacimiento >= fechaInicio && a.FechaNacimiento <= fechaFin).ToList();
                          

        }

        public async Task<List<Autor>> ObtenerTodos()
        {
            return await context.Autores.ToListAsync();
        }
    }
}
