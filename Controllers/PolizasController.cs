using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SigesivServer.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using SigesivServer.Models.Respuestas;
using SigesivServer.Bd;
using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.Ef;
using SigesivServer.utils;
using SigesivServer.Models.ViewModels;

namespace SigesivServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolizasController : Controller
    {
        //cambio de prueba rama backend
        private static PolizasRepository polizasRepository = new PolizasRepository();
        
        /*
            registra una nueva poliza del conductror,hace  el proceso comleto incluido el pago
         */
        [HttpPost("comprarPoliza")]
        public async Task<ActionResult<RespuestaPolizaDeConductor>> comprarPoliza([FromBody] PolizaCompleta polizaCompleta)
        {

            RespuestaPolizaDeConductor response = new RespuestaPolizaDeConductor();
            polizaCompleta.polizadeseguro.numeroDePoliza="PO-"+Guid.NewGuid().ToString();
            polizaCompleta.vehiculosasegurado.fkEstado = 9;
            polizaCompleta.polizadeseguro.fkEstado = 9;
            var resultado = await polizasRepository.comprarPoliza(polizaCompleta);
            response.data = resultado;
            return View("Index", response);

        }
        [HttpGet("comprarPoliza")]
        public async Task<ActionResult<RespuestaPolizaDeConductor>> crearPoliza(int idUsuario)
        {

            ViewModelCrearPoliza modelCrearPoliza = new ViewModelCrearPoliza();
            modelCrearPoliza.catalogoTiposDeCobertura =  (await polizasRepository.consultarCatalogoTiposDeCobertura()).Value;
            modelCrearPoliza.catalogoMarcasDeAuto = polizasRepository.consultarCatalogoDeMarcasConModelos();
            
            return View("CrearPoliza",modelCrearPoliza);

        }

        /*
         Consulta el detalle de la poliza del conductor
         */
        [HttpGet("obtenerPoliza")]
        public async Task<ActionResult> obtenerDetalleDePoliza(int idConductor)
        {
            
            RespuestaPolizaDeConductor response = new RespuestaPolizaDeConductor();
            var resultado =  await polizasRepository.consultarPoliza(idConductor);
            response.data = resultado.Value;
            return View("Index", response);
          
        }
        [HttpGet("obtenerPolizas")]
        public async Task<ActionResult> obtenerTodasLasPolizasDelConductor(int idConductor)
        {

            RespuestaTodasLasPolizasDelConductor response = new RespuestaTodasLasPolizasDelConductor();
            var resultado = await polizasRepository.consultarPolizasDelConductor(idConductor);
            response.data = resultado.Value;
            return View("Index", response);

        }


        [HttpGet("inicio")]
        public IActionResult inicio(int id) {
            Role rol = new Role() {
                Id = 1,
                Rol = "CONDUCTOREJECUTIVODEASISTENCIAAJUSTADORADMINSTRADOR"
            };
            return View("index");   
        }

        

    } 
}

