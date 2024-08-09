using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioCompras : IRepositorioCompras
    {
        private readonly ApplicationDbContext context;
        public RepositorioCompras(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Compra>> ObtenerTodos()
        {
            return await context.Compras.ToListAsync();
        }

        public async Task<int> CrearCompra(Compra compra)
        {
            context.Compras.Add(compra);
            await context.SaveChangesAsync();
            return compra.Id;
        }

        public async Task EliminarCompra(string nombre)
        {
            var compra = await context.Compras.FirstOrDefaultAsync(r => r.nombre == nombre);
            if (compra != null)
            {
                context.Compras.Remove(compra);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Rol no encontrado");
            }
        }

        public async Task<int> ModificarCompra(Compra compra)
        {
            context.Entry(compra).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return compra.Id;
        }


        public async Task<int> ActualizarCompra(Compra compra)
        {
            context.Entry(compra).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return compra.Id;
        }
    }
}
