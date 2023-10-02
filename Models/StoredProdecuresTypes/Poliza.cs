using System;

namespace SigesivServer.Models.StoredProdecuresTypes
{
    public class Poliza
    {
        public int id { get; set; }
        public string numeroDePoliza { get; set; }
        public int fkVehiculoAsegurado { get; set; }
        public int fkAsegurado { get; set; }
        public int fkTipoDeCobertura { get; set; }
        public int fkPago { get; set; }
        public string fechaDeInicio { get; set; }
        public string fechaDeExpiracion { get; set; }
        public decimal costoTotal { get; set; }
        public int fkEstado { get; set; } 
    }
}
