using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioProductos
    {
        Task<List<Producto>> ObtenerPorNombre(string title);
        Task<Producto?> ObtenerPorId(int id);
        Task<List<Producto>> ObtenerPorOferta(bool isOnSale);
        Task<List<Producto>> ObtenerPorDestacado(bool isFeatured);
        Task<List<Producto>> ObtenerPorCategoria(string category);
        Task<int> AgregarProducto(Producto producto);
        Task<int> ActualizarProducto(Producto producto);
        Task EliminarProducto(int id);
        Task AgregarFavorito(Producto producto);
        Task<List<Producto>> ObtenerPorFavorito(bool isFavorite);
        Task EliminarFavorito(int id);
        Task AgregarOferta(int id);
        Task EliminarOferta(int id);
        Task AgregarDestacado(int id);
        Task EliminarDestacado(int id);
    }
}
