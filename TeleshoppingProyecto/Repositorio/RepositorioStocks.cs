using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioStocks : IRepositorioStocks
    {
        private readonly ApplicationDbContext context;
        public RepositorioStocks(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<Stock>> ObtenerTodos()
        {
            return context.Stocks
            .Include(stock => stock.Proveedor)
            .ToListAsync();
        }

        public async Task<Stock?> ObtenerPorId(int id)
        {
            return context.Stocks.Where(stock => stock.Id == id)
            .Include(stock => stock.Proveedor)
            .ToList()[0];
        }

        public async Task<int> CrearStock(Stock stock)
        {
            context.Stocks.Add(stock);
            await context.SaveChangesAsync();
            return stock.Id;
        }

        public async Task<int> ModificarStock(Stock stockAnt)
        {
            Stock stock = await context.Stocks.FindAsync(stockAnt.Id);
            if (stock == null)
            {
                throw new KeyNotFoundException("El proveedor con el ID especificado no existe.");
            }

            stock.Id = stockAnt.Id;
            stock.proveedorId = stockAnt.proveedorId;
            stock.stockcant = stockAnt.stockcant;
            stock.producto = stockAnt.producto;
            stock.descripcion = stockAnt.descripcion;
            stock.marca = stockAnt.marca;
            stock.precio = stockAnt.precio;

            await context.SaveChangesAsync();
            return stockAnt.Id;
        }

        public async Task EliminarStock(int id)
        {
            Stock stock= await context.Stocks.FindAsync(id);
            context.Stocks.Remove(stock);
            await context.SaveChangesAsync();
        }

    }
}
