using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Tiposdecobertura
    {
        public Tiposdecobertura()
        {
            Polizasdeseguros = new HashSet<Polizasdeseguro>();
            TiposdecoberturaCasosdecoberturas = new HashSet<TiposdecoberturaCasosdecobertura>();
        }

        public int Id { get; set; }
        public string TipoDeCobertura { get; set; }
        public int LapsoDeCobertura { get; set; }
        public decimal Costo { get; set; }

        public virtual ICollection<Polizasdeseguro> Polizasdeseguros { get; set; }
        public virtual ICollection<TiposdecoberturaCasosdecobertura> TiposdecoberturaCasosdecoberturas { get; set; }
    }
}
