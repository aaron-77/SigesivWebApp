using Microsoft.AspNetCore.Mvc;
using SigesivServer.Bd;
using SigesivServer.Models.Respuestas;
using System.Threading.Tasks;

namespace SigesivServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AseguradoController : Controller
    {
        private static AseguradoRepository aseguradoRepository = new AseguradoRepository();

        [HttpGet("obtenerAseguradoConUsername")]
        public async Task<ActionResult<RespuestaAseguradoConUsername>> obtenerAseguradoConUsername([FromBody] int id)
        {
            RespuestaAseguradoConUsername response = new RespuestaAseguradoConUsername();
            var resultado = await aseguradoRepository.obtenerAseguradoConUsername(id);
            response.data = resultado.Value;
            return response;

        }
    }
}
