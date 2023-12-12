using System.Collections.Generic;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelReportesSinAsignar_Ajustadores
    {
        public ViewModelReportesSinAsignar_Ajustadores()
        {
            this.listaAjustadores = null;
            this.listaReportesSinAjustador = null;
        }
        public List<ViewModelPersonalAjustadores> listaAjustadores { get; set; }

        public List<ViewModelReporteDeIncidenteSinAjustador> listaReportesSinAjustador { get; set; }
    }
}
