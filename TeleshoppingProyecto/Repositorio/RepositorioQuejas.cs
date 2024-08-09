using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;


namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioQuejas : IRepositorioQuejas
    {
        private readonly ApplicationDbContext context;

        public RepositorioQuejas(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Queja?> ObtenerPorId(int id)
        {
            //return await context.Quejas.FindAsync(id);
            return context.Quejas.Where(queja => queja.Id == id)

                .ToList()[0];
        }

        public async Task AgregarQueja(Queja queja)
        {
            await context.Quejas.AddAsync(queja);
            await context.SaveChangesAsync();
        }

        public async Task ActualizarQueja(Queja queja)
        {
            context.Quejas.Update(queja);
            await context.SaveChangesAsync();
        }

        public async Task EliminarQueja(int id)
        {
            var queja = await context.Quejas.FindAsync(id);
            if (queja != null)
            {
                context.Quejas.Remove(queja);
                await context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Queja>> ObtenerQuejas()
        {
            throw new NotImplementedException();
        }

        public Task<Queja> ObtenerQuejaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
