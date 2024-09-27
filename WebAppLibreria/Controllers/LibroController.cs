using LibreriaPeliculas.Entidades;
using LibreriaPeliculas.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IRepositorioLibros _repositorioLibros;

        public LibroController(IRepositorioLibros repositorioLibros)
        {
            _repositorioLibros = repositorioLibros;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var lista= await _repositorioLibros.ObtenerTodos();
               return Ok(lista);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.ToString());
            }

        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var libro = await _repositorioLibros.ObtenerPorId(id);
                return Ok(libro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Libro libro)
        {
            try
            {
                var id = await _repositorioLibros.Crear(libro);
                return Ok(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repositorioLibros.Eliminar(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Libro libro)
        {
            try
            {
                await _repositorioLibros.Modificar(libro);
                return Ok(libro.Id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }

    }
}
