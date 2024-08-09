using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioRoles: IRepositorioRoles
    {

        private readonly ApplicationDbContext context;
        public RepositorioRoles(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Rol>> ObtenerTodos()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<int> Crear(Rol rol)
        {
            context.Roles.Add(rol);
            await context.SaveChangesAsync();
            return rol.Id;
        }

        public async Task EliminarRolPorUsuario(string usuario)
        {
            var rol = await context.Roles.FirstOrDefaultAsync(r => r.usuario == usuario);
            if (rol != null)
            {
                context.Roles.Remove(rol);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Rol no encontrado");
            }
        }

        public async Task<int> ModificarRol(Rol rol)
        {
            context.Entry(rol).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return rol.Id;
        }


        public async Task<int> ActualizarRol(Rol rol)
        {
            context.Entry(rol).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return rol.Id;
        }

        public async Task<bool> ExisteUsuario(string usuario)
        {
            return await context.Roles.AnyAsync(r => r.usuario == usuario);
        }

        public async Task<Rol> VerificarCredencialesRol(string usuario, string password)
        {
            return await context.Roles.FirstOrDefaultAsync(u => u.usuario == usuario && u.password == password);
        }


        // Método para actualizar el rol por contraseña
        public async Task<bool> ActualizarRolPorContraseña(string password, Rol rol)
        {
            var rolExistente = await context.Roles
                .Where(u => u.password == password)
                .FirstOrDefaultAsync();

            if (rolExistente == null)
            {
                return false; // rol no encontrado
            }

            rolExistente.password = rol.password;
            rolExistente.confirmarPassword = rol.confirmarPassword;

            context.Roles.Update(rolExistente);
            await context.SaveChangesAsync();

            return true; // Actualización exitosa
        }



    }
}
