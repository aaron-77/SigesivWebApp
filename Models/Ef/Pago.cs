using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Pago
    {
        public Pago()
        {
            Polizasdeseguros = new HashSet<Polizasdeseguro>();
        }

        public int Id { get; set; }
        public int FkAsegurado { get; set; }
        public long NumDeTarjeta { get; set; }

        public virtual Asegurado FkAseguradoNavigation { get; set; }
        public virtual ICollection<Polizasdeseguro> Polizasdeseguros { get; set; }
    }
}
