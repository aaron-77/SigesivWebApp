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
using System;
using Microsoft.IdentityModel.Tokens;

namespace SigesivServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportesController : Controller
    {
        private static ReportesRepository reportesRepository = new ReportesRepository();
        [HttpPost("crearReporte")]
        public async Task<ActionResult<RespuestaReporteDeIncidente>> registrarReporte([FromForm] ViewModelReporteDeIncidenteCompletoCreate reporte)
        {
            Console.WriteLine("Inicando");
            RespuestaReporteDeIncidente response = new RespuestaReporteDeIncidente();
            //se crea objeto reporte a partir de los datos del fomulario
            ViewModelReporteDeIncidenteCreate reporteConFotos = new ViewModelReporteDeIncidenteCreate();
            Console.WriteLine("Asigando fotos");
            reporteConFotos.id = reporte.id;
            reporteConFotos.fkAsegurado = reporte.fkAsegurado;
            reporteConFotos.fkVehiculoAsegurado = reporte.fkVehiculoAsegurado;
            reporteConFotos.fkEstado = 1;
            reporteConFotos.latitud = reporte.latitud;
            reporteConFotos.longitud = reporte.longitud;
            reporteConFotos.urlImagenes = reporte.urlImagenes;
            ViewModelReporteDeIncidenteCompleto reporteCompletoBd = new ViewModelReporteDeIncidenteCompleto();
            // se crea objeto OtroInvolucrado  a partr de los datos del formulario
            OtroInvolucrado otroInvolucrado = null;
            GestorDeDatosDeOtrosInvolucrados gestor = new GestorDeDatosDeOtrosInvolucrados();
            if (!reporte.otroInvolucrado1Nombre.IsNullOrEmpty() )
            {
                reporteCompletoBd.otrosInvolucrados = gestor.extraerOtrosInvolucradosDeFormulario(reporte);
            }
            // se crea un objeto de tro vehiculo involucradoa partir del formulario
            if (reporte.otroVehiculo1Id > 0)
            {
                reporteCompletoBd.otroVehiculosInvolucrados = gestor.extraerOtrosVehiculosInvolucrados(reporte);
            }
            ConvertidorDeReportes convertidor = new ConvertidorDeReportes();
            EscritorDeImagenes escritor = new EscritorDeImagenes();
            Console.WriteLine("Guardando imagenes en list");
            List<string> urls = escritor.guadarImagenes(reporteConFotos);
            Console.WriteLine("Convirtiendo reporte");
            ReporteDeIncidente reporteConUrls = convertidor.convertirAReporteConUrl(reporteConFotos, urls);
            reporteCompletoBd.reporte = reporteConUrls;
            Console.WriteLine("Llamando a registro de reporte");
            var resultado = await reportesRepository.registrarReporteDeIncidente(reporteCompletoBd);
            response.data = resultado.Value;
            return Created("/algo", response);
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
