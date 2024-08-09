using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioProveedores
    {
        Task<List<Proveedor>> ObtenerTodos();
        Task<Proveedor?> ObtenerPorId(int id);
        Task<int> CrearProveedor(Proveedor proveedor);
        Task<int> ModificarProveedor(Proveedor proveedor);
        Task EliminarProveedor(int id);
    }
}
