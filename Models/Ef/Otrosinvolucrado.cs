using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Otrosinvolucrado
    {
        public Otrosinvolucrado()
        {
            Otrosvehiculosinvolucrados = new HashSet<Otrosvehiculosinvolucrado>();
        }

        public int Id { get; set; }
        public int FkReporte { get; set; }
        public string Nombre { get; set; }

        public virtual Reportesdeincidente FkReporteNavigation { get; set; }
        public virtual ICollection<Otrosvehiculosinvolucrado> Otrosvehiculosinvolucrados { get; set; }
    }
}
