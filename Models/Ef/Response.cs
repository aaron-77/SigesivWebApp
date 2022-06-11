using System.Collections.Generic;

namespace SigesivServer.Models
{
    public class ResponsePolizaDeConductor
    {
        public int estatus { get; set; }
        public string mensaje { get; set; }
        public ViewModel_detalleDePolizaDeConductor data { get; set; }
        public List<string> errores { get; set; }
    }
}
