using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.ViewModels;
using System.Collections.Generic;

namespace SigesivServer.utils
{
    public class ConvertidorDeReportes
    {
        public ReporteDeIncidente convertirAReporteConUrl(ViewModelReporteDeIncidenteCreate reporteConFotos,List<string> urls) {
            ReporteDeIncidente reporteConUrl = new ReporteDeIncidente();
            reporteConUrl.fkVehiculoAsegurado = reporteConFotos.fkVehiculoAsegurado;
            reporteConUrl.fkAsegurado = reporteConFotos.fkAsegurado;
            reporteConUrl.fkEstado = reporteConFotos.fkEstado;
            reporteConUrl.latitud = reporteConFotos.latitud;
            reporteConUrl.longitud = reporteConFotos.longitud;
            reporteConUrl.urlImagen1 = urls[0];
            reporteConUrl.urlImagen2 = urls[1];
            reporteConUrl.urlImagen3 = urls[2];
            reporteConUrl.urlImagen4 = urls[3];
            reporteConUrl.urlImagen5 = urls[4];
            reporteConUrl.urlImagen6 = urls[5];
            reporteConUrl.urlImagen7 = urls[6];
            reporteConUrl.urlImagen8 = urls[7];
            return reporteConUrl;
        }
    }
}
