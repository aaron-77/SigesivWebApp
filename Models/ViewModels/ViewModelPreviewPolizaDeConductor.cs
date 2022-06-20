using System;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelPreviewPolizaDeConductor
    {
        public string numeroDePoliza { get; set; }
        public string modelo { get; set; }
        public DateTime fechaDeInicio { get; set; }
        public DateTime fechaDeExpiracion { get; set; }
        public string estado { get; set; }
        public int fkVehiculoAsegurado { get; set; }

    }
}
