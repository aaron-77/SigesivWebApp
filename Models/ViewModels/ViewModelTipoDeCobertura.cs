using System.Collections.Generic;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelTipoDeCobertura
    {
        public ViewModelTipoDeCobertura() {
            this.casosDeCobertura = new List<CasoDeCobertura>();
        }
        public int id { get; set; }
        public string tipoDeCobertura { get; set; }
        public int lapsoDeCobertura { get; set; }
        public decimal costo { get; set; }
        public List<CasoDeCobertura> casosDeCobertura { get; set; }
    }
}
