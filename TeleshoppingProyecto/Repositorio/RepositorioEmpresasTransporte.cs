using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioEmpresasTransporte : IRepositorioEmpresasTransporte
    {
        private readonly ApplicationDbContext context;

        public RepositorioEmpresasTransporte(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(EmpresaTransporte empresaTransporte)
        {
            context.EmpresaTransportes.Add(empresaTransporte);
            await context.SaveChangesAsync();
            return empresaTransporte.Id;
        }

        public async Task<EmpresaTransporte> ObtenerPorId(int id)
        {
            return await context.EmpresaTransportes.FindAsync(id);
        }

        public async  Task<List<EmpresaTransporte>> ObtenerTodos()
        {
            return await context.EmpresaTransportes.ToListAsync();
        }

        public async Task<int> ModificarEmpresaTransporte(EmpresaTransporte empresaTransporte)
        {
            EmpresaTransporte objEmpresaTransporte = await context.EmpresaTransportes.FindAsync(empresaTransporte.Id);

            objEmpresaTransporte.nombreEmpresa  = empresaTransporte.nombreEmpresa;
            objEmpresaTransporte.ruc = empresaTransporte.ruc;
            objEmpresaTransporte.correo = empresaTransporte.correo;
            objEmpresaTransporte.fechaRegistro = empresaTransporte.fechaRegistro;
            objEmpresaTransporte.estado = empresaTransporte.estado;
            objEmpresaTransporte.telefono = empresaTransporte.telefono;

            await context.SaveChangesAsync();
            return objEmpresaTransporte.Id;
        }


        public async Task EliminarEmpresaTransporte(int id)
        {
            EmpresaTransporte objEmpTransp = await context.EmpresaTransportes.FindAsync(id);
            context.EmpresaTransportes.Remove(objEmpTransp);
            context.SaveChanges();
        }

        public async Task<EmpresaTransporte?> ObtenerPorIdRelacion(int id)
        {
            
            return await context.EmpresaTransportes
                .Where(x => x.Id == id)
                .Include(x => x.tipoTransportes)
                 .FirstOrDefaultAsync();  // Usamos FirstOrDefaultAsync para obtener un único resultado o null si no existe
        }
    }


}
