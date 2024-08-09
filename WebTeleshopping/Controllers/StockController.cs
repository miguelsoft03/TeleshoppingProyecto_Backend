using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly IRepositorioStocks repositorioStocks;
        public StockController(IRepositorioStocks repositorioStocks)
        {
            this.repositorioStocks = repositorioStocks;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await repositorioStocks.ObtenerTodos();
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
                var stock = await repositorioStocks.ObtenerPorId(id);
                return Ok(stock);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Stock stock)
        {
            try
            {
                var id = await repositorioStocks.CrearStock (stock);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Stock stock)
        {
            try
            {
                if (id != stock.Id)
                {
                    return BadRequest("El ID no coincide");
                }
                await repositorioStocks.ModificarStock(stock);
                return Ok(stock.Id);
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
                await repositorioStocks.EliminarStock(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
