using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

namespace WebTeleshopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        private readonly IRepositorioRoles repositorioRoles;

        public RolController(IRepositorioRoles repositorioRoles)
        {
            this.repositorioRoles = repositorioRoles;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await repositorioRoles.ObtenerTodos();
                return Ok(roles);
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
                var rol = await repositorioRoles.ObtenerTodos();
                var role = rol.FirstOrDefault(r => r.Id == id);

                if (role == null)
                {
                    return NotFound();
                }

                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rol rol)
        {
            if (rol == null)
            {
                return BadRequest();
            }

            try
            {
                var id = await repositorioRoles.Crear(rol);
                return CreatedAtAction(nameof(Get), new { id = id }, rol);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpGet("verificarUsuario/{usuario}")]
        public async Task<IActionResult> VerificarUsuario(string usuario)
        {
            var existe = await repositorioRoles.ExisteUsuario(usuario);
            return Ok(existe);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Rol rol)
        {
            if (rol == null || rol.Id != id)
            {
                return BadRequest("Rol inválido.");
            }

            try
            {
                var existingRol = await repositorioRoles.ObtenerTodos();
                var role = existingRol.FirstOrDefault(r => r.Id == id);

                if (role == null)
                {
                    return NotFound("Rol no encontrado.");
                }

                role.password = rol.password;

                await repositorioRoles.ModificarRol(role);

                return Ok(role.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete("eliminar/{usuario}")]
        public async Task<IActionResult> EliminarRol(string usuario)
        {
            try
            {
                await repositorioRoles.EliminarRolPorUsuario(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost("verificar-credenciales-rol")]
        public async Task<IActionResult> VerificarCredencialesRol([FromBody] Rol rolRequest)
        {
            try
            {
                var rol = await repositorioRoles.VerificarCredencialesRol(rolRequest.usuario, rolRequest.password);

                if (rol == null)
                {
                    return Unauthorized("Credenciales incorrectas");
                }

                return Ok(rol);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        // Método para actualizar rol por contraseña
        [HttpPut("actualizarContraseña/{password}")]
        public async Task<IActionResult> ActualizarRolPorContraseña(string password, [FromBody] Rol rol)
        {
            try
            {
                var exito = await repositorioRoles.ActualizarRolPorContraseña(password, rol);
                if (exito == null)
                {
                    return NotFound("Administrador no encontrado");
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