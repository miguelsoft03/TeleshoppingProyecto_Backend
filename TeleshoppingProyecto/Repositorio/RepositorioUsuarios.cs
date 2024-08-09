using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public class RepositorioUsuarios: IRepositorioUsuarios
    {

        private readonly ApplicationDbContext context;
        public RepositorioUsuarios(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Usuario>> ObtenerTodos()
        {
            return await context.Usuarios.ToListAsync();
        }

        public async Task<int> CrearUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            return await context.SaveChangesAsync();
        }

        public async Task<int> ModificarUsuario(Usuario usuario)
        {
            var entidadExistente = await context.Usuarios.FindAsync(usuario.Id);
            if (entidadExistente == null)
            {
                throw new InvalidOperationException("El usuario no existe.");
            }

            context.Entry(entidadExistente).CurrentValues.SetValues(usuario);

            return await context.SaveChangesAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorCedula(string cedula)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.cedula == cedula);
        }

        public async Task EliminarUsuarioPorCedula(string cedula)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.cedula == cedula);
            if (usuario != null)
            {
                context.Usuarios.Remove(usuario);
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> ActualizarUsuario(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        // Método para actualizar el usuario por cédula
        public async Task<bool> ActualizarUsuarioPorCedula(string cedula, Usuario usuario)
        {
            var usuarioExistente = await context.Usuarios
                .Where(u => u.cedula == cedula)
                .FirstOrDefaultAsync();

            if (usuarioExistente == null)
            {
                return false; // Usuario no encontrado
            }

            usuarioExistente.nombre = usuario.nombre;
            usuarioExistente.apellido = usuario.apellido;
            usuarioExistente.email = usuario.email;
            // No se actualiza la cédula

            context.Usuarios.Update(usuarioExistente);
            await context.SaveChangesAsync();

            return true; // Actualización exitosa
        }

        public async Task<Usuario> ObtenerDatosBasicosPorCedula(string cedula)
        {
            return await context.Usuarios.Where(u => u.cedula == cedula).Select(u => new Usuario {
                nombre = u.nombre, apellido = u.apellido, cedula = u.cedula, email = u.email }).FirstOrDefaultAsync();
              
        }

        public async Task<Usuario> VerificarCredencialesUsuario(string cedula, string password)
        {
            return await context.Usuarios.FirstOrDefaultAsync(u => u.cedula == cedula && u.password == password);
        }

        // Método para actualizar el usuario por contraseña
        public async Task<bool> ActualizarUsuarioPorContraseña(string password, Usuario usuario)
        {
            var usuarioExistente = await context.Usuarios
                .Where(u => u.password == password)
                .FirstOrDefaultAsync();

            if (usuarioExistente == null)
            {
                return false; // Usuario no encontrado
            }

            usuarioExistente.password = usuario.password;
            usuarioExistente.confirmarPassword = usuario.confirmarPassword;

            context.Usuarios.Update(usuarioExistente);
            await context.SaveChangesAsync();

            return true; // Actualización exitosa
        }


    }
}
