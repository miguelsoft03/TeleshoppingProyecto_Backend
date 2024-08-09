using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Migrations;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioProductos: IRepositorioProductos
    {
        private readonly ApplicationDbContext context;

        public RepositorioProductos(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<Producto?> ObtenerPorId(int id)
        {
            // return await context.Productos.FindAsync(id);
            return context.Productos.Where(producto => producto.Id == id)

                 .ToList()[0];
        }


        public async Task<List<Producto>> ObtenerPorNombre(string title)
        {
            return await context.Productos.Where(p => p.Title.Contains(title)).ToListAsync();
            /*
            return await context.Productos
                .Where(p => p.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();*/
        }

        public async Task<List<Producto>> ObtenerPorOferta(bool isOnSale)
        {
            return await context.Productos.Where(p => p.IsOnSale == isOnSale).ToListAsync();
        }

        public async Task<List<Producto>> ObtenerPorDestacado(bool isFeatured)
        {
            return await context.Productos.Where(p => p.IsFeatured == isFeatured).ToListAsync();
        }

        public async Task<List<Producto>> ObtenerPorCategoria(string category)
        {
            return await context.Productos.Where(p => p.Category == category).ToListAsync();
        }

        public async Task<int> AgregarProducto(Producto producto)
        {
            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return producto.Id;
        }

        public async Task<int> ActualizarProducto(Producto producto)
        {
            context.Productos.Update(producto);
            await context.SaveChangesAsync();
            return producto.Id;
        }

        public async Task EliminarProducto(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto != null)
            {
                context.Productos.Remove(producto);
                await context.SaveChangesAsync();
            }
        }

        public async Task AgregarFavorito(Producto producto)
        {
            producto.IsFavorite = true;
            await ActualizarProducto(producto);
        }

        public async Task<List<Producto>> ObtenerPorFavorito(bool isFavorite)
        {
            return await context.Productos.Where(p => p.IsFavorite == isFavorite).ToListAsync();
        }

        public async Task EliminarFavorito(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto != null)
            {
                producto.IsFavorite = false;
                await ActualizarProducto(producto);
            }
        }


        public async Task AgregarOferta(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto != null)
            {
                producto.IsOnSale = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task EliminarOferta(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto != null)
            {
                producto.IsOnSale = false;
                await context.SaveChangesAsync();
            }
        }

        public async Task AgregarDestacado(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto != null)
            {
                producto.IsFeatured = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task EliminarDestacado(int id)
        {
            var producto = await context.Productos.FindAsync(id);
            if (producto != null)
            {
                producto.IsFeatured = false;
                await context.SaveChangesAsync();
            }
        }
    }
}
