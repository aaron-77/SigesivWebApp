using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Casosdecobertura
    {
        public Casosdecobertura()
        {
            TiposdecoberturaCasosdecoberturas = new HashSet<TiposdecoberturaCasosdecobertura>();
        }

        public int Id { get; set; }
        public string NombreDelCaso { get; set; }
        public string Condiciones { get; set; }

        public virtual ICollection<TiposdecoberturaCasosdecobertura> TiposdecoberturaCasosdecoberturas { get; set; }
    }
}
