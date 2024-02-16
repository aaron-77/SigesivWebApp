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
        public int  otroVehiculo1Id { get; set; }
        public string? otroVehiculo1Color { get; set; }
        public string? otroVehiculo1NumeroDePlaca { get; set; }
        public string? otroInvolucrado1Licencia { get; set; }
        public int otroVehiculo1FkMarca { get; set; }
        public int otroVehiculo1FkModelo { get; set; }

        //otro auto 2
        public int otroVehiculo2Id { get; set; }
        public string? otroVehiculo2Color { get; set; }
        public string? otroVehiculo2NumeroDePlaca { get; set; }
        public string? otroInvolucrado2Licencia { get; set; }
         public int otroVehiculo2Fkmarca { get; set; }
        public int otroVehiculo2FkModelo { get; set; }
        //otro auto 3
        public int otroVehiculo3Id { get; set; }
        public string? otroVehiculo3Color { get; set; }
        public string? otroVehiculo3NumeroDePlaca { get; set; }
        public string? otroInvolucrado3Licencia { get; set; }
         public int otroVehiculo3FkMarca { get; set; }
        public int otroVehiculo3FkModelo { get; set; }
        //otro auto 4
        public int otroVehiculo4Id { get; set; }
        public string? otroVehiculo4Color { get; set; }
        public string? otroVehiculo4NumeroDePlaca { get; set; }
        public string? otroInvolucrado4Licencia { get; set; }
         public int otroVehiculo4FkMarca { get; set; }
        public int otroVehiculo4FkModelo { get; set; }
        // mas datos generales del reporte
        public int fkOtroInvolucrado { get; set; }

    }


}
