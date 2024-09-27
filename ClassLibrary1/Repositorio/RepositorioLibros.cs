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
    public class RepositorioLibros : IRepositorioLibros
    {
        private readonly ApplicationDbContext context;
        public RepositorioLibros(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<int> Crear(Libro libro)
        {
            context.Libros.Add(libro);
            await context.SaveChangesAsync();
            
            return libro.Id;

        }

        public async Task<Libro?> ObtenerPorId(int id)
        {
            return context.Libros.Where(libro => libro.Id == id)
            .Include(libro => libro.Autor)
            .Include(libro => libro.Genero)
            .ToList()[0];

        }

        /*
        public async Task<Libro?> ObtenerLibrosPorIdAutor(int id)
        {
            return context.Libros.Where(libro => libro.AutorId == id)
            .Include(libro => libro.Autor)
            .Include(libro => libro.Genero)
            .ToList()[0];

        }
        */
        public Task<List<Libro>> ObtenerTodos()
        {
            //return context.Libros.ToListAsync();
            return context.Libros
            .Include(libro => libro.Autor)
            .Include(libro => libro.Genero)
            .ToListAsync();
        }

        public async Task Eliminar(int id)
        {
            Libro libro = await context.Libros.FindAsync(id);
            context.Libros.Remove(libro);
            await context.SaveChangesAsync();
        }

        public async Task<int> Modificar(Libro libroAnt)
        {
            Libro libro = await context.Libros.FindAsync(libroAnt.Id);
            libro.AutorId = libroAnt.AutorId;
            libro.Nombre = libroAnt.Nombre;
            libro.GeneroId = libroAnt.GeneroId;
            await context.SaveChangesAsync();
            return libroAnt.Id;

        }
    }
}
