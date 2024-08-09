using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioProveedores : IRepositorioProveedores
    {
        private readonly ApplicationDbContext context;
        public RepositorioProveedores(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Proveedor>> ObtenerTodos()
        {
            return await context.Proveedores.ToListAsync();
        }

        public async Task<Proveedor?> ObtenerPorId(int id)
        {
            return await context.Proveedores.FindAsync(id);
        }

        public async Task<int> CrearProveedor(Proveedor proveedor)
        {
            context.Proveedores.Add(proveedor);
            return await context.SaveChangesAsync();
        }


        public async Task<int> ModificarProveedor(Proveedor proveedor)
        {
            Proveedor proveedorMod = await context.Proveedores.FindAsync(proveedor.Id);
            if (proveedorMod == null)
            {
                throw new KeyNotFoundException("El proveedor con el ID especificado no existe.");
            }
            proveedorMod.Id= proveedor.Id;
            proveedorMod.nombre = proveedor.nombre;
            proveedorMod.origen = proveedor.origen;
            proveedorMod.contacto = proveedor.contacto;
            
            await context.SaveChangesAsync();
            return proveedorMod.Id;
        }

        public async Task EliminarProveedor(int id)
        {
            Proveedor proveedor = await context.Proveedores.FindAsync(id);
            context.Proveedores.Remove(proveedor);
            await context.SaveChangesAsync();
        }
    }
}
