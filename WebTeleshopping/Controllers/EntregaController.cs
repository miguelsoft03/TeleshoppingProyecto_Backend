using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaController : ControllerBase
    {

        private readonly IRepositorioEntrega _repositorioEntrega;

        public EntregaController(IRepositorioEntrega repositorioEntrega)
        {
            _repositorioEntrega = repositorioEntrega;
        }



        [HttpPost]
        public async Task<IActionResult> Post(Entrega entrega)
        {
            try
            {
                var id = await _repositorioEntrega.Crear(entrega);
                return Ok(id);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioEntrega.ObtenerTodos();
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
                var entrega = await _repositorioEntrega.ObtenerPorId(id);
                return Ok(entrega);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Entrega entrega)
        {
            if (id != entrega.Id)
            {
                return BadRequest("El ID de la Entrega no coincide con el ID de la URL");
            }
            try
            {
                await _repositorioEntrega.ModificarEntrega(entrega);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Entrega entrega = await _repositorioEntrega.ObtenerPorId(id);
                if (entrega is null)
                {
                    return NotFound();
                }
                await _repositorioEntrega.EliminarEntrega(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetEntregasPorUsuario(int usuarioId)
        {
            try
            {
                var entregas = await _repositorioEntrega.ObtenerPorUsuario(usuarioId);
                return Ok(entregas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }
}
