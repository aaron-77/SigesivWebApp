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
        public string latitud { get; set; }
        public string longitud { get; set; }
        public List<IFormFile> urlImagenes { get; set; }

        public int fkEstado { get; set; }
        //datos del otro involucrado 1
        public int otroInvolucrado1Id { get; set; }
        public string? otroInvolucrado1Nombre { get; set; }
        //datos del otro involucrado 2
        public int otroInvolucrado2Id { get; set; }
        public string? otroInvolucrado2Nombre { get; set; }
        //datos del otro involucrado 3
        public int otroInvolucrado3Id { get; set; }
        public string? otroInvolucrado3Nombre { get; set; }
        //datos del otro involucrado 4
        public int otroInvolucrado4Id { get; set; }
        public string? otroInvolucrado4Nombre { get; set; }

        // datos de los otros vehiculos involucrado
        public int idOtroVehiculo1 { get; set; }
        public string? otroVehiculo1Color { get; set; }
        public string? otroVehiculo1NumeroDePlaca { get; set; }
        public string? otroVehiculo1Licencia { get; set; }
        public int fkmarca1 { get; set; }
        public int fkmodelo1 { get; set; }

        //otro auto 2
        public int idOtroVehiculo2 { get; set; }
        public string? otroVehiculo2Color { get; set; }
        public string? otroVehiculo2NumeroDePlaca { get; set; }
        public string? otroVehiculo2Licencia { get; set; }
         public int fkmarca2 { get; set; }
        public int fkmodelo2 { get; set; }
        //otro auto 3
        public int idOtroVehiculo3 { get; set; }
        public string? otroVehiculo3Color { get; set; }
        public string? otroVehiculo3NumeroDePlaca { get; set; }
        public string? otroVehiculo3Licencia { get; set; }
         public int fkmarca3 { get; set; }
        public int fkmodelo3 { get; set; }
        //otro auto 4
        public int idOtroVehiculo4 { get; set; }
        public string? otroVehiculo4Color { get; set; }
        public string? otroVehiculo4NumeroDePlaca { get; set; }
        public string? otroVehiculo4Licencia { get; set; }
         public int fkmarca4 { get; set; }
        public int fkmodelo4 { get; set; }
        // mas datos generales del reporte
        public int fkOtroInvolucrado { get; set; }

    }


}
