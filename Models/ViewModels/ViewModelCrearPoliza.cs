using System.Collections.Generic;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelCrearPoliza
    {
        public List<ViewModelTipoDeCobertura> catalogoTiposDeCobertura { get; set; }
        public List<ViewModelMarcas> catalogoMarcasDeAuto { get; set; }
    }
}
