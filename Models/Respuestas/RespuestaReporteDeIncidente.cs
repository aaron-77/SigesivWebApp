using SigesivServer.Models.ViewModels;
using System.Collections.Generic;

namespace SigesivServer.Models.Respuestas
{
    public class RespuestaReporteDeIncidente
    {
        
            public int status { get; set; }
            public string mensaje { get; set; }
            public ViewModelReporteDeIncidentePreview data { get; set; }
            public List<string> errores { get; set; }
        
    }
}
