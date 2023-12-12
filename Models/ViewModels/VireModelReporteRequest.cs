using Microsoft.AspNetCore.Http;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelReporteRequest
    {
        public int id { get; set; }
        public int fkAsegurado { get; set; }
        public int? fkVehiculoAsegurado { get; set; }
        public int? fkPersonal { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public IFormFile urlImagen1 { get; set; }
        public IFormFile urlImagen2 { get; set; }
        public IFormFile urlImagen3 { get; set; }
        public IFormFile urlImagen4 { get; set; }
        public IFormFile? urlImagen5 { get; set; }
        public IFormFile? urlImagen6 { get; set; }
        public IFormFile? urlImagen7 { get; set; }
        public IFormFile? urlImagen8 { get; set; }
        public int fkEstado { get; set; }
        public string fechaDelReporte { get; set; }
    }
}
