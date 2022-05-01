using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SigesivServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace SigesivServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolizasController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private proyectoaseguradoraequipo5Context context;
        private readonly ILogger<PolizasController> _logger;
        private Usuario user;
        private String connectionString;

        public PolizasController(ILogger<PolizasController> logger)
        {
            _logger = logger;
            user = new Usuario();
            context = new proyectoaseguradoraequipo5Context();



            
         }
        [HttpGet("obtenerPoliza")]
        public async Task<ActionResult< sp_obtenerPolizaDeConductor>> Get(int id)
        {
            try {
                var polizaDeCondutor = context.sp_obtenerPolizaDeConductor.
                FromSqlInterpolated($@"EXEC sp_obtenerPolizaDeConductor @idConductor={id}").AsAsyncEnumerable();
               
                await foreach (var poliza in polizaDeCondutor) {
                    return poliza;
                }
                /*
                await foreach (var poliza in polizaDeCondutor) { 
                    Console.WriteLine(poliza.id);
                }
                */
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
            return NotFound();
        }

    } 
}

