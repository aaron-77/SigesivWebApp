using System.Collections.Generic;

namespace SigesivServer.Models.Respuestas
{
    public class RespuestaAsignacion
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public int data { get; set; }
        public List<string> errores { get; set; }
    }
}
