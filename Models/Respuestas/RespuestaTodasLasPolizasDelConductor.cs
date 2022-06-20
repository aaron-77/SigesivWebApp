using SigesivServer.Models.ViewModels;
using System.Collections.Generic;

namespace SigesivServer.Models.Respuestas
{
    public class RespuestaTodasLasPolizasDelConductor
    {
        public RespuestaTodasLasPolizasDelConductor() {
            this.status = 1;
            this.mensaje = "consulta realizada con exito";
            this.data = null;
            this.errores = null;
        }
        public int status { get; set; }
        public string mensaje { get; set; }
        public List<ViewModelPreviewPolizaDeConductor> data { get; set; }
        public List<string> errores { get; set; }
    }
}
