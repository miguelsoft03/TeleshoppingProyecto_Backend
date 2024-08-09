using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IRepositorioProductos repositorioProductos;

        public ProductoController(IRepositorioProductos repositorioProductos)
        {
            this.repositorioProductos = repositorioProductos;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Producto>>> ObtenerPorNombre([FromQuery] string title)
        {
            return Ok(await repositorioProductos.ObtenerPorNombre(title));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> ObtenerPorId(int id)
        {
            var producto = await repositorioProductos.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpGet("onSale")]
        public async Task<ActionResult<List<Producto>>> ObtenerPorOferta([FromQuery] bool isOnSale = true)
        {
            return Ok(await repositorioProductos.ObtenerPorOferta(isOnSale));
        }

        [HttpGet("featured")]
        public async Task<ActionResult<List<Producto>>> ObtenerPorDestacado([FromQuery] bool isFeatured = true)
        {
            return Ok(await repositorioProductos.ObtenerPorDestacado(isFeatured));
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<Producto>>> ObtenerPorCategoria(string category)
        {
            return Ok(await repositorioProductos.ObtenerPorCategoria(category));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Producto producto)
        {
            try
            {
                var id = await repositorioProductos.AgregarProducto(producto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> ActualizarProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            try
            {
                await repositorioProductos.ActualizarProducto(producto);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            await repositorioProductos.EliminarProducto(id);
            return NoContent();
        }

        [HttpPost("favorites")]
        public async Task<ActionResult> AgregarFavorito(Producto producto)
        {
            await repositorioProductos.AgregarFavorito(producto);
            return NoContent();
        }

        [HttpDelete("favorites/{id}")]
        public async Task<ActionResult> EliminarFavorito(int id)
        {
            await repositorioProductos.EliminarFavorito(id);
            return NoContent();
        }

        [HttpGet("favorites")]
        public async Task<ActionResult<List<Producto>>> ObtenerPorFavorito([FromQuery] bool isFavorite = true)
        {
            return Ok(await repositorioProductos.ObtenerPorFavorito(isFavorite));
        }

        [HttpPost("onSale/{id}")]
        public async Task<ActionResult> AgregarOferta(int id)
        {
            await repositorioProductos.AgregarOferta(id);
            return NoContent();
        }

        [HttpDelete("onSale/{id}")]
        public async Task<ActionResult> EliminarOferta(int id)
        {
            await repositorioProductos.EliminarOferta(id);
            return NoContent();
        }

        [HttpPost("featured/{id}")]
        public async Task<ActionResult> AgregarDestacado(int id)
        {
            await repositorioProductos.AgregarDestacado(id);
            return NoContent();
        }

        [HttpDelete("featured/{id}")]
        public async Task<ActionResult> EliminarDestacado(int id)
        {
            await repositorioProductos.EliminarDestacado(id);
            return NoContent();
        }

    }
}
