using LibreriaPeliculas.Entidades;
using LibreriaPeliculas.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IRepositorioAutores _repositorioAutores;

        // Constructor con inyección de dependencias, principio de inversión de control 
        public AutorController(IRepositorioAutores repositorioAutores)
        {
            _repositorioAutores = repositorioAutores;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListAutores = await _repositorioAutores.ObtenerTodos();
                return Ok(ListAutores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

/*
        [HttpGet]
        public async Task<Results<Ok<List<Autor>>, BadRequest>> Get()
        {
            try
            {
                var ListAutores = await _repositorioAutores.ObtenerTodos();
                return TypedResults.Ok(ListAutores);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest();
            }
        }
*/
    }
}
