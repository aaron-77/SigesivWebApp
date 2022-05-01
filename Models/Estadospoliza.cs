using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Estadospoliza
    {
        public Estadospoliza()
        {
            Polizasdeseguros = new HashSet<Polizasdeseguro>();
        }

        public int Id { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Polizasdeseguro> Polizasdeseguros { get; set; }
    }
}
