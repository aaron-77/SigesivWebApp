using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Vehiculosasegurados = new HashSet<Vehiculosasegurado>();
        }

        public int Id { get; set; }
        public int FkMarca { get; set; }
        public string Modelo1 { get; set; }

        public virtual Marca FkMarcaNavigation { get; set; }
        public virtual ICollection<Vehiculosasegurado> Vehiculosasegurados { get; set; }
    }
}
