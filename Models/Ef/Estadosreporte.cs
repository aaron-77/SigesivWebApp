using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Estadosreporte
    {
        public Estadosreporte()
        {
            Reportesdeincidentes = new HashSet<Reportesdeincidente>();
        }

        public int Id { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Reportesdeincidente> Reportesdeincidentes { get; set; }
    }
}
