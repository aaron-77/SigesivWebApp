using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Otrosvehiculosinvolucrado
    {
        public int Id { get; set; }
        public int? FkOtroInvolucrado { get; set; }
        public int? Fkmarca { get; set; }
        public int? Fkmodelo { get; set; }
        public string Color { get; set; }
        public string NumeroDePlaca { get; set; }
        public int FkReporte { get; set; }

        public virtual Otrosinvolucrado FkOtroInvolucradoNavigation { get; set; }
        public virtual Reportesdeincidente FkReporteNavigation { get; set; }
    }
}
