using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Repositorio;
using TeleshoppingProyecto.Entidades;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IRepositorioPagos repositorioPagos;

        public PagoController(IRepositorioPagos repositorioPagos)
        {
            this.repositorioPagos = repositorioPagos;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pagos = await repositorioPagos.ObtenerTodos();
                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Pago pago)
        {
            try
            {
                if (pago == null)
                {
                    return BadRequest("Pago es nulo");
                }

                var resultado = await repositorioPagos.CrearPago(pago);
                if (resultado > 0)
                {
                    return CreatedAtAction(nameof(Get), new { Id = pago.id}, pago);
                }

                return BadRequest("Error al crear el pago");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPago(int id, Pago pago)
        {
            if (id != pago.id)
            {
                return BadRequest("El ID del pago no coincide.");
            }

            try
            {
                await repositorioPagos.ActualizarPago(pago);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al actualizar el pago: {ex.Message}");
                return StatusCode(500, "Error al actualizar el pago.");
            }
        }

        [HttpDelete("{identificacion}")]
        public async Task<ActionResult> EliminarPago(string identificacion)
        {
            try
            {
                await repositorioPagos.EliminarPago(identificacion);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al eliminar el pago: {ex.Message}");
                return StatusCode(500, "Error al eliminar el pago.");
            }
        }

        [HttpGet("productos/{cliente}")]
        public async Task<IActionResult> ObtenerProductosPorCliente(string cliente)
        {
            try
            {
                var productos = await repositorioPagos.ObtenerProductosPorCliente(cliente);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error al obtener productos por cliente: {ex.Message}");
                return StatusCode(500, "Error al obtener productos.");
            }
        }


        [HttpGet("{identificacion}")]
        public async Task<IActionResult> GetByIdentificacion(string identificacion)
        {
            try
            {
                var pago = await repositorioPagos.ObtenerPagoPorIdentificacion(identificacion);
                if (pago == null)
                {
                    return NotFound("Pago no encontrado");
                }
                return Ok(pago);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("actualizar/{identificacion}")]
        public async Task<IActionResult> ActualizarPagoPorIdentificacion(string identificacion, [FromBody] Pago pago)
        {
            try
            {
                var exito = await repositorioPagos.ActualizarPagoPorIdentificacion(identificacion,pago);
                if (exito == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



    }
}
