using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace SigesivServer.Models
{
    public partial class Estadosvehiculosasegurado
    {
        public Estadosvehiculosasegurado()
        {
            Vehiculosasegurados = new HashSet<Vehiculosasegurado>();
        }

        public int Id { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Vehiculosasegurado> Vehiculosasegurados { get; set; }
    }
}
