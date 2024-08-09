using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioTiposTransporte : IRepositorioTiposTransporte
    {
        private readonly ApplicationDbContext context;

        public RepositorioTiposTransporte(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(TipoTransporte tipoTransporte)
        {
            context.TipoTransportes.Add(tipoTransporte);
            await context.SaveChangesAsync();
            return tipoTransporte.Id;
        }

        public async Task<TipoTransporte> ObtenerPorId(int id)
        {
            return await context.TipoTransportes.FindAsync(id);
        }

        public async Task<List<TipoTransporte>> ObtenerTodos()
        {
            return await  context.TipoTransportes
                .Include(TipoTransporte => TipoTransporte.empresaTransporte)
                .ToListAsync();
                
                
        }

        public async Task<int> ModificarTipoTransporte(TipoTransporte tipoTransporte)
        {
            TipoTransporte objTipoTransporte = await context.TipoTransportes.FindAsync(tipoTransporte.Id);
            objTipoTransporte.empresaTransporteId = tipoTransporte.empresaTransporteId;
            objTipoTransporte.tipoTransporte = tipoTransporte.tipoTransporte;
            objTipoTransporte.estado = tipoTransporte.estado;         
            await context.SaveChangesAsync();
            return objTipoTransporte.Id;
        }

        public async Task EliminarTipoTransporte(int id)
        {
            TipoTransporte objTipoTransp = await context.TipoTransportes.FindAsync(id);
            context.TipoTransportes.Remove(objTipoTransp);
            context.SaveChanges();
        }

    }
}
