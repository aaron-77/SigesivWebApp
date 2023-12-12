using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class TiposdecoberturaCasosdecobertura
    {
        public int Id { get; set; }
        public int FkTipoDeCobertura { get; set; }
        public int FkCasoDeCobertura { get; set; }

        public virtual Casosdecobertura FkCasoDeCoberturaNavigation { get; set; }
        public virtual Tiposdecobertura FkTipoDeCoberturaNavigation { get; set; }
    }
}
