using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioEntrega
    {
        Task<List<Entrega>> ObtenerTodos();
        Task<Entrega> ObtenerPorId(int id);
        Task<int> Crear(Entrega entrega);
        Task<int> ModificarEntrega(Entrega entrega);
        Task EliminarEntrega(int id);


        // Cambiado para devolver una lista de entregas
        Task<List<Entrega>> ObtenerPorUsuario(int usuarioId);
    }
}
