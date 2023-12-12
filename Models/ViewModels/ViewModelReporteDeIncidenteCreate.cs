using Microsoft.AspNetCore.Http;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelReporteDeIncidenteCreate
    {
        public int id { get; set; }
        public int fkAsegurado { get; set; }
        public int? fkVehiculoAsegurado { get; set; }
        public int? fkPersonal { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public List<IFormFile> urlImagenes { get; set; }
        public int fkEstado { get; set; }
        public string fechaDelReporte { get; set; }
    }
}
