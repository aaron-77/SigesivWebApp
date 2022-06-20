using SigesivServer.Models.ViewModels;
using System.Collections.Generic;

namespace SigesivServer.Models.Respuestas
{
    public class RespuestaListadoPolizas
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public List<ViewModelPreviewPolizaDeConductor> data { get; set; }
        public List<string> errores { get; set; }
    }
}
