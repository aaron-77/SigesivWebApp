using Microsoft.AspNetCore.Mvc;
using SigesivServer.Models.Respuestas;
using SigesivServer.Models.ViewModels;
using System.Threading.Tasks;

namespace SigesivServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EjecutivoController : Controller
    {
        [HttpGet("MenuAjustadores")]
        public async Task<ActionResult<ViewModelPersonalAjustadores>> mostarPantalla(RespuestaObtenerTodosLosAjustadores ajustadores)
        {
            return View("MenuAjustadores");

        }

    }
}

//https://localhost:44316/Ajustador/MenuAjustadores