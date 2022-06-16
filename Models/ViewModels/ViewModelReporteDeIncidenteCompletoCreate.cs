using Microsoft.AspNetCore.Http;
using SigesivServer.Models.StoredProdecuresTypes;
using System.Collections.Generic;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelReporteDeIncidenteCompletoCreate
    {
        public int id { get; set; }
        public int fkAsegurado { get; set; }
        public int? fkVehiculoAsegurado { get; set; }
        public int? fkPersonal { get; set; }
        public decimal latitud { get; set; }
        public decimal longitud { get; set; }
        public IFormFile urlImagen1 { get; set; }
        public IFormFile urlImagen2 { get; set; }
        public IFormFile urlImagen3 { get; set; }
        public IFormFile urlImagen4 { get; set; }
        public IFormFile? urlImagen5 { get; set; }
        public IFormFile? urlImagen6 { get; set; }
        public IFormFile? urlImagen7 { get; set; }
        public IFormFile? urlImagen8 { get; set; }
        public int fkEstado { get; set; }
        //datos del otro involucrado
        public int idOtroInvolucrado { get; set; }
        public string nombre { get; set; }
        // datos del otro vehiculo involucrado
        public int idOtroVehiculo { get; set; }
        public int? fkOtroInvolucrado { get; set; }
        public int? fkmarca { get; set; }
        public int? fkmodelo { get; set; }
        public string color { get; set; }
        public string numeroDePlaca { get; set; }
       
    }
}
