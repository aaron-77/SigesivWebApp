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
        public async Task<ActionResult<RespuestaAseguradoConUsername>> consultarSiUsuarioExiste([FromBody] string username, string password)
        {

            RespuestaAseguradoConUsername response = new RespuestaAseguradoConUsername();
            var resultado = await usuarioRepository.consultarSiUsuarioExiste(username, password);
            response.data = resultado.Value;
            return response;
        }


    }


}
