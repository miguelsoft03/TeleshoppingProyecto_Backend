using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {

        private readonly IRepositorioOrdenes repositorioOrdenes;

        public OrdenController(IRepositorioOrdenes repositorioOrdenes)
        {
            this.repositorioOrdenes = repositorioOrdenes;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ordenes = await repositorioOrdenes.ObtenerTodos();
                return Ok(ordenes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var orden = await repositorioOrdenes.ObtenerPorId(id);

                if (orden == null)
                {
                    return NotFound();
                }

                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Orden orden)
        {
            try
            {
                if (orden== null)
                {
                    return BadRequest("Pago es nulo");
                }

                var resultado = await repositorioOrdenes.CrearOrden(orden);
                if (resultado > 0)
                {
                    return CreatedAtAction(nameof(Get), new { id = orden.Id }, orden);
                }

                return BadRequest("Error al crear el pago");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Orden orden)
        {
            if (id != orden.Id)
            {
                return BadRequest("El ID de la orden no coincide.");
            }

            try
            {
                var existente = await repositorioOrdenes.ObtenerPorId(id);
                if (existente == null)
                {
                    return NotFound();
                }

                await repositorioOrdenes.ModificarOrden(orden);
                return NoContent();
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
                var existente = await repositorioOrdenes.ObtenerPorId(id);
                if (existente == null)
                {
                    return NotFound();
                }

                await repositorioOrdenes.EliminarOrden(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }
}
