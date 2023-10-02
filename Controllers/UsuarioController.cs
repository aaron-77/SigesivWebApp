using Microsoft.AspNetCore.Mvc;
using SigesivServer.Bd;
using SigesivServer.Models.Peticiones;
using SigesivServer.Models.Respuestas;
using System;
using System.Threading.Tasks;

namespace SigesivServer.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private static UsuarioRepository usuarioRepository = new UsuarioRepository();

        [HttpPost("obtenerUsuario")]

        public async Task<ActionResult<RespuestaUsuarioRegistrado>> consultarSiUsuarioExiste([FromBody] UsuarioModelForLogin user)
        {

            RespuestaUsuarioRegistrado response = new RespuestaUsuarioRegistrado();
            try
            {

                var resultado = await usuarioRepository.consultarSiUsuarioExiste(user.username, user.password);
                if (resultado == null)
                {
                    response.status = 0;
                    response.data = null;
                    response.mensaje = "usuario o contraseña incorrectos";
                    response.errores = null;
                }
                else
                {
                    response.data = resultado.Value;
                    response.status = 1;
                    response.mensaje = "Operacion exitosa";
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.status = 0;
                response.data = null;
                response.mensaje = "Error interno del servidor";
                response.errores = null;
                Console.WriteLine(ex);

            }
            return StatusCode(500, response);
        }

    }


}
