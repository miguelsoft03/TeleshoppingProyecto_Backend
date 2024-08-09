using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleshoppingProyecto.Entidades;

namespace TeleshoppingProyecto.Repositorio
{
    public interface IRepositorioUsuarios
    {
        Task<List<Usuario>> ObtenerTodos();
        Task<int> CrearUsuario(Usuario usuario);
        Task<int> ModificarUsuario(Usuario usuario);
        Task EliminarUsuarioPorCedula(string cedula); 
        Task<Usuario> ObtenerUsuarioPorCedula(string cedula);
        Task<int> ActualizarUsuario(Usuario usuario);
        Task<bool> ActualizarUsuarioPorCedula(string cedula, Usuario usuario);
        Task<Usuario> ObtenerDatosBasicosPorCedula(string cedula);
        Task<Usuario> VerificarCredencialesUsuario(string cedula, string password);
        Task<bool> ActualizarUsuarioPorContraseña(string password, Usuario usuario);

    }
}
