// See https://aka.ms/new-console-template for more information

using ClassLibrary1.Entidades;
using ClassLibrary1.Repositorio;
using LibreriaPeliculas.Entidades;
using LibreriaPeliculas.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


public class Program
{
    static ServiceCollection? service;
    static ServiceProvider? serviceProvider;
    static IRepositorioGeneros? repositorioGeneros;
    static IRepositorioAutores? repositorioAutores;
    static IRepositorioLibros? repositorioLibros;
    public static void agregarServicios()
    {
        // Configurar los servicios de inyección de dependencias
        // ServiceCollection es una colección de servicios que se utilizará para construir el proveedor de servicios.
        service = new ServiceCollection();
        // Registrar el repositorio de géneros
        // Registra RepositorioGeneros como la implementación de IRepositorioGeneros con un ciclo de vida Scoped
        // (una instancia por cada solicitud).
        service.AddScoped<IRepositorioGeneros, RepositorioGeneros>();
        service.AddScoped<IRepositorioAutores, RepositorioAutores>();
        service.AddScoped<IRepositorioLibros, RepositorioLibros>();

        // Registrar el contexto de la base de datos con la cadena de conexión a SQL Server
        // registra ApplicationDbContext y configura su cadena de conexión para conectarse a una base de datos SQL Server.
        service.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Peliculas;Integrated Security=True;TrustServerCertificate=True;"));

        // BuildServiceProvider construye el contenedor de dependencias, permitiendo la resolución de servicios.
        serviceProvider = service.BuildServiceProvider();

        // Obtener el servicio de repositorio de géneros
        // GetService<IRepositorioGeneros> obtiene una instancia del servicio registrado IRepositorioGeneros.
        repositorioGeneros = serviceProvider.GetService<IRepositorioGeneros>();

        repositorioAutores = serviceProvider.GetService<IRepositorioAutores>();

        repositorioLibros = serviceProvider.GetService<IRepositorioLibros>();

    }
    public static async Task  Main()
    {
        agregarServicios();

        //await agregarGenero("Prueba", 1);
        //await consultarGeneros();
        //await consultarGeneroPorId(2);

        //DateOnly fecha = new DateOnly(1960, 11,10);
        //await agregarAutor("Neil Gaiman", fecha);

        //await modificarAutor(5, "Neil Richard Gaiman", new DateOnly(1960, 11, 11),"Esritor de nacionalidad Britanica, uno de los primeros en ");
        //await consultarAutorPorId(1);

        //await consultarAutores();

        //await consultarAutoresPorRangoFecha(new DateOnly(1942, 01, 01), new DateOnly(1960, 01, 01));

        await EliminarAutor(3);
        //await agregarLibro("El Alquimista",5,1,1);

        //await consultarLibroPorId(1);

        //await modificarEstadoGenero(2);
        //await eliminarGenero(7);

        //await modificarGenero(9,"Ciencia Ficción",1);

    }

    public static async Task agregarGenero(string nombre, int estado)
    {

         var genero = new Genero
         {
             Nombre = nombre,
             estado = estado
         };


         // Crear un nuevo género en la base de datos
         int codigo = await repositorioGeneros.Crear(genero);
       
    }

    public static async Task consultarGeneros()
    {
        // Obtener todos los géneros de la base de datos
        List<Genero> generos = await repositorioGeneros.ObtenerTodos();


        foreach (var elem in generos)
        {
            Console.WriteLine($"{elem.Id} - {elem.Nombre}");
        }
    }

    public static async Task consultarGeneroPorId(int id)
    {
        Genero genero = await repositorioGeneros.ObtenerPorId(id);
        Console.WriteLine($"{genero.Id} - {genero.Nombre}");
    }

    public static async Task agregarAutor(string nombre, DateOnly fecha)
    {

        var autor = new Autor
        {
            nombre = nombre,
            FechaNacimiento = fecha
        };


        // Crear un nuevo género en la base de datos
        int codigo = await repositorioAutores.Crear(autor);

    }

    public static async Task modificarAutor(int id,string nombre, DateOnly fecha, string resumen)
    {

        var autor = new Autor
        {   Id = id,
            nombre = nombre,
            FechaNacimiento = fecha,
            resumen= resumen
        };


        // Crear un nuevo género en la base de datos
        autor = await repositorioAutores.ModificarAutor(autor);

        Console.WriteLine($"{autor.resumen}");

    }

    public static async Task EliminarAutor(int id)
    {
                
       await repositorioAutores.EliminarAutor(id);

    }


    public static async Task consultarAutorPorId(int id)
    {
        Autor autor = await repositorioAutores.ObtenerPorId(id);
        Console.WriteLine($"{autor.Id} - {autor.nombre} - {autor.FechaNacimiento}");
        foreach (var item in autor.Libros)
        {
            Console.WriteLine($"{item.Nombre}");
        }
    }

    public static async Task consultarAutores()
    {
        List<Autor> listaAutores = await repositorioAutores.ObtenerTodos();
        foreach (var autor in listaAutores)
        {
            Console.WriteLine($"{autor.Id} - {autor.nombre} - {autor.FechaNacimiento}");
        }
    }

    public static async Task consultarAutoresPorRangoFecha(DateOnly fechaInicio, DateOnly fechaFin)
    {
        List<Autor> listaAutores = await repositorioAutores.ObtenerPorRangoFecha(fechaInicio, fechaFin);
        foreach (var autor in listaAutores)
        {
            Console.WriteLine($"{autor.Id} - {autor.nombre} - {autor.FechaNacimiento}");
        }
    }

    public static async Task agregarLibro(string nombre, int generoId,int autorId ,int estado)
    {
        var libro = new Libro
        {
             Nombre= nombre,
             GeneroId= generoId,
             Estado= estado,
             AutorId= autorId,
                 
        };

        int codigo = await repositorioLibros.Crear(libro);
    }

    public static async Task consultarLibroPorId(int id)
    {
        Libro libro = await repositorioLibros.ObtenerPorId(id);
        Console.WriteLine($"{libro.Id} - {libro.Nombre} - {libro.Genero.Nombre} - {libro.Autor.nombre} ");
    }

    public static async Task modificarEstadoGenero(int id)
    {
        int genero = await repositorioGeneros.CambiarEstadoActivo(id);
        
    }

    public static async Task eliminarGenero(int id)
    {
         await repositorioGeneros.EliminarGenero(id);

    }


    public static async Task modificarGenero(int id, string nombre, int estado)
    {

        var genero = new Genero
        {
            Id= id,
            Nombre = nombre,
            estado = estado
        };


        // Crear un nuevo género en la base de datos
        int codigo = await repositorioGeneros.ModificarGenero(genero);

    }
}
