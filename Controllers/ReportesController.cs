using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigesivServer.Bd;
using SigesivServer.Models;
using SigesivServer.Models.Respuestas;
using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.ViewModels;
using SigesivServer.utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigesivServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportesController : Controller
    {
        private static ReportesRepository reportesRepository = new ReportesRepository();
        [HttpPost("crearReporte")]
        public async Task<ActionResult<RespuestaReporteDeIncidente>> registrarReporte([FromForm]ViewModelReporteDeIncidenteCompletoCreate reporte)
        {
        
            RespuestaReporteDeIncidente response = new RespuestaReporteDeIncidente();
            //se crea objeto reporte a paertir de los datos del fomulario
            ViewModelReporteDeIncidenteCreate reporteConFotos = new ViewModelReporteDeIncidenteCreate();
            reporteConFotos.id = reporte.id;
            reporteConFotos.fkAsegurado = reporte.fkAsegurado;
            reporteConFotos.fkVehiculoAsegurado = reporte.fkVehiculoAsegurado;
            reporteConFotos.fkEstado = 13;
            reporteConFotos.latitud = reporte.latitud;
            reporteConFotos.longitud = reporte.longitud;
            reporteConFotos.urlImagen1 = reporte.urlImagen1;
            reporteConFotos.urlImagen2 = reporte.urlImagen2;
            reporteConFotos.urlImagen3 = reporte.urlImagen3;
            reporteConFotos.urlImagen4 = reporte.urlImagen4;
            reporteConFotos.urlImagen5 = reporte.urlImagen5;
            reporteConFotos.urlImagen6 = reporte.urlImagen6;
            reporteConFotos.urlImagen7 = reporte.urlImagen7;
            reporteConFotos.urlImagen8 = reporte.urlImagen8;
            ViewModelReporteDeIncidenteCompleto reporteCompletoBd = new ViewModelReporteDeIncidenteCompleto();
            // se crea objeto OtroInvolucrado  a partr de los datos del formulario
            OtroInvolucrado otroInvolucrado = null;
            if (reporte.idOtroInvolucrado > 0) {
                otroInvolucrado = new OtroInvolucrado();
                otroInvolucrado.id = reporte.idOtroInvolucrado;
                otroInvolucrado.nombre = reporte.nombre;
                reporteCompletoBd.otrosInvolucrados = new List<OtroInvolucrado> { otroInvolucrado };
            }
            // se crea un objeto de tro vehiculo involucradoa partir del formulario
            OtroVehiculoInvolucrado otroVehiculo = null;
            if (reporte.idOtroVehiculo > 0) {
                otroVehiculo = new OtroVehiculoInvolucrado();
                otroVehiculo.id = reporte.idOtroVehiculo;
                otroVehiculo.fkOtroInvolucrado = (reporte.idOtroInvolucrado == 0)?null:otroInvolucrado.id;
                otroVehiculo.fkmarca = reporte.fkmarca;
                otroVehiculo.fkmodelo = reporte.fkmodelo;
                otroVehiculo.color = reporte.color;
                otroVehiculo.numeroDePlaca = reporte.numeroDePlaca;
                reporteCompletoBd.otroVehiculosInvolucrados = new List<OtroVehiculoInvolucrado>() { otroVehiculo };
            }
            
            ConvertidorDeReportes convertidor = new ConvertidorDeReportes();
            EscritorDeImagenes escritor = new EscritorDeImagenes();
            List<string> urls = escritor.guadarImagenes(reporteConFotos);
            ReporteDeIncidente reporteConUrls = convertidor.convertirAReporteConUrl(reporteConFotos,urls);
            
            reporteCompletoBd.reporte = reporteConUrls;
            
            var resultado = await reportesRepository.registrarReporteDeIncidente(reporteCompletoBd);
            response.data = resultado.Value;
            return response;

        }
        
        [HttpGet("CrearReporte")]
        public async Task<ActionResult<RespuestaReporteDeIncidente>> RegistrarReporte([FromForm] ViewModelReporteDeIncidenteCompletoCreate reporte)
        {

            return View("MenuConductor");

        }
        [HttpGet("MapeoUbicacion")]
        public async Task<ActionResult<RespuestaReporteDeIncidente>> ubicacionReporte([FromForm] ViewModelReporteDeIncidenteCompletoCreate reporte)
        {
            return View("MapeoUbicacion");

        }
        [HttpGet("ReporteDetalle")]
        public async Task<ActionResult<RespuestaReporteDeIncidente>> detalleReporte([FromForm] ViewModelReporteDeIncidenteCompletoCreate reporte)
        {
            return View("ReporteDetalle");

        }
  
        [HttpPut("asignarReporte")]
        public async Task<ActionResult<RespuestaAsignacion>> asignarReporteDeIncidente([FromBody] int idreporte, int idajustador)
        {
            RespuestaAsignacion respuestaAsignacion = new RespuestaAsignacion();
            var resultados = await reportesRepository.asignarReporteDeIncidente(idreporte, idajustador);
            respuestaAsignacion.data = resultados.Value;

            return respuestaAsignacion;
        }

        [HttpGet("obtenerReportesSinAsignar")]
        public async Task<ActionResult<RespuestaTodosLosReportesSinAsignar>> consultarReportesSinAjustador()
        {

            RespuestaTodosLosReportesSinAsignar response = new RespuestaTodosLosReportesSinAsignar();
            var resultado = await reportesRepository.consultarReportesSinAjustador();
            response.data = resultado.Value;
            return response;

        }

    }
}
