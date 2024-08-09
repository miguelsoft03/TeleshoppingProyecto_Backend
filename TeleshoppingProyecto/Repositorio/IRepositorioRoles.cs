using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioRoles
    {
        Task<List<Rol>> ObtenerTodos();
        Task<int> Crear(Rol rol);
        Task<int> ModificarRol(Rol rol);
        Task<int> ActualizarRol(Rol rol);
        Task<bool> ExisteUsuario(string usuario);
        Task EliminarRolPorUsuario(string usuario);
        Task<Rol> VerificarCredencialesRol(string usuario, string password);
        Task<bool> ActualizarRolPorContraseña(string password, Rol rol);


    }
}
