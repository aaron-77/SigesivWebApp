using System.Collections.Generic;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelMarcas
    {
        public ViewModelMarcas() {
            this.modelos = new List<ViewModelModelo>();
        }
        public int id { get; set; }
        public string marca { get; set; }

        public List<ViewModelModelo> modelos;
    }
}
