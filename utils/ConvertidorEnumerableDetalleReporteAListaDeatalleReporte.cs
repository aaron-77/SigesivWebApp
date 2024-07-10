using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.ViewModels;

namespace SigesivServer.utils{
    public class ConvertidorEnumerableDetalleReporteAListaDeatalleReporte{
        public List<ViewModelDetalleReporteDeIncidente> enumarableToList (IEnumerable<ViewModelDetalleReporteDeIncidente> reportesDeIncidente){
            List<ViewModelDetalleReporteDeIncidente> listaReportes = new List<ViewModelDetalleReporteDeIncidente>();
            
            foreach(var item in reportesDeIncidente){
                listaReportes.Add(item);
            }

            return listaReportes;
        }

    }
}