using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioCompras
    {
        Task<List<Compra>> ObtenerTodos();
        Task<int> CrearCompra(Compra compra);
        Task<int> ModificarCompra(Compra compra);
        Task<int> ActualizarCompra(Compra compra);
        Task EliminarCompra(string nombre);
    }
}
