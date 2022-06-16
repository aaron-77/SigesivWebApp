using SigesivServer.Models.ViewModels;
using System.Collections.Generic;

namespace SigesivServer.Models.Respuestas
{
    public class RespuestaTodosLosReportesSinAsignar
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public List<ViewModelReporteDeIncidenteSinAjustador> data { get; set; }
        public List<string> errores { get; set; }
    }
}
