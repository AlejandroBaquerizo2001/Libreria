using ClassLibrary1.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repositorio
{
    public class RepositorioGeneros : IRepositorioGeneros
    {
        private readonly ApplicationDbContext context;
        public RepositorioGeneros(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return genero.Id;
        }

        public async Task<int> Crear2(Genero genero)
        {
            context.Generos.Add(genero);
            await context.SaveChangesAsync();
            return genero.Id;
        }

        public async Task<int> CambiarEstadoActivo(int id)
        {
            Genero genero= await context.Generos.FindAsync(id); //await ObtenerPorId(genero.Id);
            genero.estado = 1;
            await context.SaveChangesAsync();
            return genero.Id;
        }

        public async Task<Genero?> ObtenerPorId(int id)
        {
            //return await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            return await context.Generos.FindAsync(id);
        }

        public async Task<List<Genero>> ObtenerTodos()
        {
            //return await context.Generos.ToListAsync();
            return context.Generos.Where(g=>g.estado==1).ToList();
        }

        public async Task EliminarGenero(int id)
        {
            Genero genero = await context.Generos.FindAsync(id);
            context.Generos.Remove(genero);
            context.SaveChanges();
        }

        public async Task<int> ModificarGenero(Genero genero)
        {
            Genero objGenero = await context.Generos.FindAsync(genero.Id);
            objGenero.Nombre = genero.Nombre;
            objGenero.estado= genero.estado;
            await context.SaveChangesAsync();
            return objGenero.Id;
        }
    }
}
