using SigesivServer.Models.StoredProdecuresTypes;
using System.Collections.Generic;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelReporteDeIncidenteCompleto
    {
        public ViewModelReporteDeIncidenteCompleto() {
            this.otrosInvolucrados = null;
            this.otroVehiculosInvolucrados = null;
        }
        public ReporteDeIncidente reporte { get; set; }
        public List<OtroInvolucrado> otrosInvolucrados { get; set; } 
        public List<OtroVehiculoInvolucrado> otroVehiculosInvolucrados { get; set; }

    }
}
