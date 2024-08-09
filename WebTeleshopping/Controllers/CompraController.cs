using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Repositorio;
using TeleshoppingProyecto.Entidades;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IRepositorioCompras repositorioCompras;

        public CompraController(IRepositorioCompras repositorioCompras)
        {
            this.repositorioCompras = repositorioCompras;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var productos = await repositorioCompras.ObtenerTodos();
                return Ok(productos);
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
                var compra= await repositorioCompras.ObtenerTodos();
                var product = compra.FirstOrDefault(r => r.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Compra compra)
        {
            if (compra == null)
            {
                return BadRequest();
            }

            try
            {
                var id = await repositorioCompras.CrearCompra(compra);
                return CreatedAtAction(nameof(Get), new { id = id }, compra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete("eliminar/{nombre}")]
        public async Task<IActionResult> EliminarCompra(string nombre)
        {
            try
            {
                await repositorioCompras.EliminarCompra(nombre);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
