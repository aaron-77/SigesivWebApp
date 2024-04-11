using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SigesivServer.Bd;
using SigesivServer.Models.Peticiones;
using SigesivServer.Models.Respuestas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;


namespace SigesivServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EjecutivoAsistenciaController : Controller
    {

         private  EjecutivoAsistenciaRepository ejecutivoRepository;
        
        public EjecutivoAsistenciaController()
        {
            ejecutivoRepository = new EjecutivoAsistenciaRepository();
        }
        
        [HttpGet("obtenerAjustadores")]
        public async Task<ActionResult<RespuesListadoAjustadores>> ObtenerAjustadores(){
            var result = await ejecutivoRepository.ConsultarAjustadores();
            if(result.Value.data == null){
                result.Value.mensaje = "Error al cargar los ajustadores";
                result.Value.status = 0;
                return StatusCode(500,result.Value);
            }
            return Ok(result.Value);
        } 
         [HttpPut("asignar")]
        public async Task<ActionResult<RespuestaAsignacion>> AsignarReporte ([FromBody] AsignarReporteModel datosAsignacion ){
            
            RespuestaAsignacion respuestaAsignacion = new RespuestaAsignacion();
            var resultados = await ejecutivoRepository.asignarReporteDeIncidente(datosAsignacion.idAjustador, datosAsignacion.idReporte);
            respuestaAsignacion.data = resultados.Value;
            return respuestaAsignacion;

         }
    }
}
