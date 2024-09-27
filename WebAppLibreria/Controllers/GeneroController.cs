using ClassLibrary1.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IRepositorioGeneros _repositorioGeneros;

        public GeneroController(IRepositorioGeneros repositorioGeneros)
        {
            this._repositorioGeneros = repositorioGeneros;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista= await _repositorioGeneros.ObtenerTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
