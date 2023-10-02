using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
            Vehiculosasegurados = new HashSet<Vehiculosasegurado>();
        }

        public int Id { get; set; }
        public string Marca1 { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
        public virtual ICollection<Vehiculosasegurado> Vehiculosasegurados { get; set; }
    }
}
