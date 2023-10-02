using SigesivServer.Models.ViewModels;
using System.Collections.Generic;

namespace SigesivServer.Models.Respuestas
{
    public class RespuestaReportesSinAsignar_Ajustadores
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public ViewModelReportesSinAsignar_Ajustadores data { get; set; }
        public List<string> errores { get; set; }
    }
}
