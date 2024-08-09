using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IRepositorioProveedores _repositorioProveedores;
        public ProveedorController (IRepositorioProveedores repositorioProveedores)
        {
            _repositorioProveedores = repositorioProveedores;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListProveedores = await _repositorioProveedores.ObtenerTodos();
                return Ok(ListProveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var proveedor = await _repositorioProveedores.ObtenerPorId(id);
                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Proveedor proveedor)
        {
            try
            {
                var id = await _repositorioProveedores.CrearProveedor(proveedor);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Proveedor proveedor)
        {
            try
            {
                if (id != proveedor.Id)
                {
                    return BadRequest("El ID del proveedor no coincide");
                }

                var prove = await _repositorioProveedores.ObtenerTodos();
                if (!prove.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                var resultado = await _repositorioProveedores.ModificarProveedor(proveedor);
                if (resultado > 0)
                {
                    return NoContent();
                }
                return BadRequest("Error al modificar el Proveedor");
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
                await _repositorioProveedores.EliminarProveedor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
