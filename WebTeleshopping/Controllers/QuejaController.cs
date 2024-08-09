using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuejasController : ControllerBase
    {
        private readonly IRepositorioQuejas repositorioQuejas;

        public QuejasController(IRepositorioQuejas repositorioQuejas)
        {
            this.repositorioQuejas = repositorioQuejas;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Queja>>> ObtenerQuejas()
        {
            var quejas = await repositorioQuejas.ObtenerQuejas();
            return Ok(quejas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Queja>> ObtenerQuejaPorId(int id)
        {
            var queja = await repositorioQuejas.ObtenerQuejaPorId(id);
            if (queja == null)
                return NotFound();
            return Ok(queja);
        }

        [HttpPost]
        public async Task<ActionResult> AgregarQueja([FromBody] Queja queja)
        {
            await repositorioQuejas.AgregarQueja(queja);
            return CreatedAtAction(nameof(ObtenerQuejaPorId), new { id = queja.Id }, queja);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarQueja(int id, [FromBody] Queja queja)
        {
            if (id != queja.Id)
                return BadRequest();

            await repositorioQuejas.ActualizarQueja(queja);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarQueja(int id)
        {
            await repositorioQuejas.EliminarQueja(id);
            return NoContent();
        }
    }
}
