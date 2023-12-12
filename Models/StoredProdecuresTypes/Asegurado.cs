using System;

namespace SigesivServer.Models.StoredProdecuresTypes
{
    public class Asegurado
    {
        public int? id { get; set; }
        public int? fkUsuario { get; set; }
        public string nombreCompleto { get; set; }
        public string fechaDeNacimiento { get; set; }
        public string numeroDeLicencia { get; set; }
        public string celular { get; set; }

    }
}
