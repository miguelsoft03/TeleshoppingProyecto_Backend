using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransporteController : ControllerBase
    {


        private readonly IRepositorioTiposTransporte _repositorioTiposTransporte;

        public TipoTransporteController(IRepositorioTiposTransporte repositorioTiposTransporte)
        {
            _repositorioTiposTransporte = repositorioTiposTransporte;
        }


        [HttpPost]
        public async Task<IActionResult> Post(TipoTransporte tipoTransporte)
        {
            try
            {
                var id = await _repositorioTiposTransporte.Crear(tipoTransporte);
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
                var lista = await _repositorioTiposTransporte.ObtenerTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                TipoTransporte tipoTransporte = await _repositorioTiposTransporte.ObtenerPorId(id);
                if (tipoTransporte is null)
                {
                    return NotFound();
                }
                await _repositorioTiposTransporte.EliminarTipoTransporte(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TipoTransporte tipoTransporte)
        {
            if (id != tipoTransporte.Id)
            {
                return BadRequest("El ID del Tipo Transporte no coincide con el ID de la URL");
            }
            try
            {
                await _repositorioTiposTransporte.ModificarTipoTransporte(tipoTransporte);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
