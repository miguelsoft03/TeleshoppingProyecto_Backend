using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioPagos
    {
        Task<List<Pago>> ObtenerTodos();
        Task<int> CrearPago(Pago pago);
        Task<int> ActualizarPago(Pago pago);
        Task EliminarPago(string identificacion);
        Task<List<string>> ObtenerProductosPorCliente(string cliente);
        Task<Pago> ObtenerPagoPorIdentificacion(string identificacion);
        Task<bool> ActualizarPagoPorIdentificacion(string identificacion, Pago pago);



    }
}
