using System.Collections.Generic;

namespace SigesivServer.Models.Respuestas
{
    public class RespuestaPolizaDeConductor
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public ViewModel_detalleDePolizaDeConductor data { get; set; }
        public List<string> errores { get; set; }
    }
}
