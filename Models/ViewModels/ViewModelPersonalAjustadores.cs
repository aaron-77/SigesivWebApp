using System;

namespace SigesivServer.Models.ViewModels
{
    public class ViewModelPersonalAjustadores
    {
        public int id { get; set; }
        public int? fkUsuario { get; set; }
        public int fkRol { get; set; }
        public string nombreCompleto { get; set; }
        public DateTime fechaDeIngreso { get; set; }

    }
}
