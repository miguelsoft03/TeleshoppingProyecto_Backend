using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioTiposTransporte
    {
        Task<List<TipoTransporte>> ObtenerTodos();
        Task<TipoTransporte> ObtenerPorId(int id);
        Task<int> Crear(TipoTransporte tipoTransporte);
        Task<int> ModificarTipoTransporte(TipoTransporte tipoTransporte);
        Task EliminarTipoTransporte(int id);
    }
}
