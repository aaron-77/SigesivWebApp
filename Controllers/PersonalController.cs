using Microsoft.AspNetCore.Mvc;
using SigesivServer.Bd;
using SigesivServer.Models.Respuestas;
using System.Threading.Tasks;

namespace SigesivServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalController : Controller
    {
        private static PersonalRepository personalRepository = new PersonalRepository();


        [HttpGet("obtenerPersonalAjustador")]
        public async Task<ActionResult<RespuestaObtenerTodosLosAjustadores>> consultarTodosLosAjustadores()
        {

            RespuestaObtenerTodosLosAjustadores response = new RespuestaObtenerTodosLosAjustadores();
            var resultado = await personalRepository.consultarTodosLosAjustadores();
            response.data = resultado.Value;
            return response;

        }
    }
}
