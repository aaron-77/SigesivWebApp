using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Polizasdeseguro
    {
        public int Id { get; set; }
        public string NumeroDePoliza { get; set; }
        public int FkVehiculoAsegurado { get; set; }
        public int FkAsegurado { get; set; }
        public int FkTipoDeCobertura { get; set; }
        public int FkPago { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeExpiracion { get; set; }
        public decimal CostoTotal { get; set; }
        public int FkEstado { get; set; }

        public virtual Asegurado FkAseguradoNavigation { get; set; }
        public virtual Estadospoliza FkEstadoNavigation { get; set; }
        public virtual Pago FkPagoNavigation { get; set; }
        public virtual Tiposdecobertura FkTipoDeCoberturaNavigation { get; set; }
        public virtual Vehiculosasegurado FkVehiculoAseguradoNavigation { get; set; }
    }
}
