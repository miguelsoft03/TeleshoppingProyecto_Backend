using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioEntrega : IRepositorioEntrega
    {

        private readonly ApplicationDbContext context;


        public RepositorioEntrega(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<Entrega>> ObtenerTodos()
        {
            return  context.Entregas
                .Include(e => e.usuario)
                 .Include(e => e.tipoTransporte) // Incluye la entidad TipoTransporte relacionada
                 .ThenInclude(t => t.empresaTransporte) // Incluye la entidad EmpresaTransporte relacionada
                 // Incluye la entidad Usuario relacionada
                .ToListAsync();
        }

        public async Task<Entrega> ObtenerPorId(int id)
        {
            return context.Entregas.Where(entrega => entrega.Id == id)
             .Include(entrega => entrega.tipoTransporte)
                .ThenInclude(tipoTransporte => tipoTransporte.empresaTransporte)
             .Include(entrega => entrega.usuario)
             .ToList()[0];


        }

        public async Task<int> Crear(Entrega entrega)
        {
            context.Entregas.Add(entrega);
            await context.SaveChangesAsync();
            return entrega.Id;
        }

        public async Task<int> ModificarEntrega(Entrega entrega)
        {
              Entrega objEntrega =  await context.Entregas.FindAsync(entrega.Id);
               
               objEntrega.usuarioId = entrega.usuarioId;
               objEntrega.ordenCompra = entrega.ordenCompra;
               objEntrega.estado = entrega.estado;
               objEntrega.descripcion = entrega.descripcion;
               objEntrega.nombreEmpresaTransporte = entrega.nombreEmpresaTransporte;
               objEntrega.fechaEnvio = entrega.fechaEnvio;
               objEntrega.numSeguimiento = entrega.numSeguimiento;
               objEntrega.tipoTransporteId = entrega.tipoTransporteId;
               objEntrega.direccionEntrega = entrega.direccionEntrega;
            
               await context.SaveChangesAsync();
               return objEntrega.Id;
        }
        public async Task EliminarEntrega(int id)
        {
            Entrega objEntrega = await context.Entregas.FindAsync(id);
            context.Entregas.Remove(objEntrega);
            context.SaveChanges();

        }


        public async Task<List<Entrega>> ObtenerPorUsuario(int usuarioId)
        {
            return await context.Entregas
                .Where(entrega => entrega.usuarioId == usuarioId)
                .Include(entrega => entrega.tipoTransporte)
                .ThenInclude(tipoTransporte => tipoTransporte.empresaTransporte)
                .Include(entrega => entrega.usuario)
                .ToListAsync();
        }



    }
}
