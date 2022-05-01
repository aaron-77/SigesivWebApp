using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Reportesdeincidentes = new HashSet<Reportesdeincidente>();
        }

        public int Id { get; set; }
        public int FkUsuario { get; set; }
        public int FkRol { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaDeIngreso { get; set; }

        public virtual Role FkRolNavigation { get; set; }
        public virtual Usuario FkUsuarioNavigation { get; set; }
        public virtual ICollection<Reportesdeincidente> Reportesdeincidentes { get; set; }
    }
}
