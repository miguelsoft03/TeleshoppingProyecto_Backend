using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioOrdenes : IRepositorioOrdenes
    {
          private readonly ApplicationDbContext context;

          public RepositorioOrdenes(ApplicationDbContext context)
          {
              this.context = context;
          }

        public async Task<List<Orden>> ObtenerTodos()
        {
            return await context.Ordenes.ToListAsync();
        }

        public async Task<Orden> ObtenerPorId(int id)
        {
            return await context.Ordenes.FindAsync(id);
        }

        public async Task<int> CrearOrden(Orden orden)
        {
            context.Ordenes.Add(orden);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModificarOrden(Orden orden)
        {
            context.Entry(orden).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public async Task<int> ActualizarOrden(Orden orden)
        {
            return await ModificarOrden(orden);
        }

        public async Task EliminarOrden(int id)
        {
            var orden = await context.Ordenes.FindAsync(id);
            if (orden != null)
            {
                context.Ordenes.Remove(orden);
                await context.SaveChangesAsync();
            }
        }

    }
}
