using Microsoft.AspNetCore.Mvc;
using SigesivServer.Bd;
using SigesivServer.Models.Respuestas;
using System.Threading.Tasks;

namespace SigesivServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private static UsuarioRepository usuarioRepository = new UsuarioRepository();

        [HttpGet("obtenerUsuario")]
        public async Task<ActionResult<RespuestaUsuarioRegistrado>> consultarSiUsuarioExiste([FromBody] string username, string password)
        {

            RespuestaUsuarioRegistrado response = new RespuestaUsuarioRegistrado();
            var resultado = await usuarioRepository.consultarSiUsuarioExiste(username, password);
            response.data = resultado.Value;
            if (response.data.fkRol == 27)
                return View("MenuAjustadores", response);
            if (response.data.fkRol == 25)
            {

                return View("MenuConductor", response);
            }
            return response;
        }

    }


}
