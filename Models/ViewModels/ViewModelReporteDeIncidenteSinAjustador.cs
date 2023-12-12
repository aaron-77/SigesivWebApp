using Microsoft.AspNetCore.Http;
using System;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelReporteDeIncidenteSinAjustador
    {
        public int id { get; set; }
        public int fkAsegurado { get; set; }
        public int? fkVehiculoAsegurado { get; set; }
        public int? fkPersonal { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string urlImagen1 { get; set; }
        public string urlImagen2 { get; set; }
        public string urlImagen3 { get; set; }
        public string urlImagen4 { get; set; }
        public string? urlImagen5 { get; set; }
        public string? urlImagen6 { get; set; }
        public string? urlImagen7 { get; set; }
        public string? urlImagen8 { get; set; }
        public int fkEstado { get; set; }       
        public DateTime fechaDelReporte { get; set; }
    }
}
