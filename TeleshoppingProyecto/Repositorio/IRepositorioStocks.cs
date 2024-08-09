using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioStocks 
    {
        Task<List<Stock>> ObtenerTodos();
        Task<Stock?> ObtenerPorId(int id);
        Task<int> CrearStock(Stock stock);
        Task<int> ModificarStock(Stock stockAnt);
        Task EliminarStock(int id);

    }
}
