using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
 
        public interface IRepositorioOrdenes
        {
            Task<List<Orden>> ObtenerTodos();
            Task<Orden> ObtenerPorId(int id); 
            Task<int> CrearOrden(Orden orden);
            Task<int> ModificarOrden(Orden orden);
            Task<int> ActualizarOrden(Orden orden);
           Task EliminarOrden(int id);
        }


}
