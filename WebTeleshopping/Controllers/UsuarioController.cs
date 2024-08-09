using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IRepositorioUsuarios repositorioUsuarios;

        public UsuarioController(IRepositorioUsuarios repositorioUsuarios)
        {
            this.repositorioUsuarios = repositorioUsuarios;
        }

       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await repositorioUsuarios.ObtenerTodos();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = await repositorioUsuarios.ObtenerTodos();
                var usuarioEncontrado = usuario.FirstOrDefault(r => r.Id == id);

                if (usuarioEncontrado == null)
                {
                    return NotFound();
                }

                return Ok(usuarioEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest("Usuario es nulo");
                }

                var resultado = await repositorioUsuarios.CrearUsuario(usuario);
                if (resultado > 0)
                {
                    return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
                }

                return BadRequest("Error al crear el usuario");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return BadRequest("El ID del usuario no coincide");
                }

                var usuarioExistente = await repositorioUsuarios.ObtenerTodos();
                if (!usuarioExistente.Any(r => r.Id == id))
                {
                    return NotFound();
                }

                var resultado = await repositorioUsuarios.ModificarUsuario(usuario);
                if (resultado > 0)
                {
                    return NoContent();
                }

                return BadRequest("Error al modificar el usuario");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("verificar/{cedula}")]
        public async Task<IActionResult> VerificarCedula(string cedula)
        {
            try
            {
                var usuarios = await repositorioUsuarios.ObtenerTodos();
                var cedulaExistente = usuarios.Any(r => r.cedula == cedula);
                return Ok(cedulaExistente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet("recuperar/{cedula}")]
        public async Task<IActionResult> RecuperarContrasenaPorCedula(string cedula)
        {
            try
            {
                var usuario = await repositorioUsuarios.ObtenerUsuarioPorCedula(cedula);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }
                return Ok(new { contrasena = usuario.password });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete("eliminar/{cedula}")]
        public async Task<IActionResult> EliminarUsuarioPorCedula(string cedula)
        {
            try
            {
                var usuario = await repositorioUsuarios.ObtenerUsuarioPorCedula(cedula);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                await repositorioUsuarios.EliminarUsuarioPorCedula(cedula);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        // Método para actualizar usuario por cédula
        [HttpPut("actualizar/{cedula}")]
        public async Task<IActionResult> ActualizarUsuarioPorCedula(string cedula, [FromBody] Usuario usuario)
        {
            try
            {
                var exito = await repositorioUsuarios.ActualizarUsuarioPorCedula(cedula, usuario);
                if (exito == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpGet("datos-basicos/{cedula}")]
        public async Task<IActionResult> ObtenerDatosBasicosPorCedula(string cedula)
        {
            try
            {
                var usuario = await repositorioUsuarios.ObtenerDatosBasicosPorCedula(cedula);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("verificar-credenciales-usuario")]
        public async Task<IActionResult> VerificarCredencialesUsuario([FromBody] Usuario usuarioRequest)
        {
            var usuario = await repositorioUsuarios.VerificarCredencialesUsuario(usuarioRequest.cedula, usuarioRequest.password);

            if (usuario == null)
            {
                return Unauthorized("Credenciales incorrectas");
            }

            return Ok(usuario);
        }


        // Método para actualizar usuario por contraseña
        [HttpPut("actualizarContraseña/{password}")]
        public async Task<IActionResult> ActualizarUsuarioPorContraseña(string password, [FromBody] Usuario usuario)
        {
            try
            {
                var exito = await repositorioUsuarios.ActualizarUsuarioPorContraseña(password, usuario);
                if (exito == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }







    }


}
