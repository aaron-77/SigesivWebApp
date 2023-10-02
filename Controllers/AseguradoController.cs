using Microsoft.AspNetCore.Mvc;
using SigesivServer.Bd;
using SigesivServer.Models.Respuestas;
using SigesivServer.Models.ViewModels;
using System.Threading.Tasks;

namespace SigesivServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AseguradoController : Controller
    {
        private static AseguradoRepository aseguradoRepository = new AseguradoRepository();

        [HttpPost("obtenerAseguradoConUsername")]
        public async Task<ActionResult<RespuestaAseguradoConUsername>> obtenerAseguradoConUsername([FromBody] ViewModelUserLogin user)
        {
            RespuestaAseguradoConUsername response = new RespuestaAseguradoConUsername();
            var resultado = await aseguradoRepository.obtenerAseguradoConUsername(user);
            response.data = resultado.Value;
            return response;

        }
    }
}
