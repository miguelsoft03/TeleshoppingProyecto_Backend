using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaTransporteController : ControllerBase
    {

        private readonly IRepositorioEmpresasTransporte _repositorioEmpresasTransporte;

        public EmpresaTransporteController(IRepositorioEmpresasTransporte repositorioEmpresasTransporte)
        {
            _repositorioEmpresasTransporte = repositorioEmpresasTransporte;
        }


        [HttpPost]
        public async Task<IActionResult> Post(EmpresaTransporte empresaTransporte)
        {
            try
            {
                var id = await _repositorioEmpresasTransporte.Crear(empresaTransporte);
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
                var lista = await _repositorioEmpresasTransporte.ObtenerTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, EmpresaTransporte empresaTransporte)
        {
            if (id != empresaTransporte.Id)
            {
                return BadRequest("El ID del género no coincide con el ID de la URL");
            }
            try
            {
                await _repositorioEmpresasTransporte.ModificarEmpresaTransporte(empresaTransporte);
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
                EmpresaTransporte empresaTransporte = await _repositorioEmpresasTransporte.ObtenerPorId(id);
                if (empresaTransporte is null)
                {
                    return NotFound();
                }
                await _repositorioEmpresasTransporte.EliminarEmpresaTransporte(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
