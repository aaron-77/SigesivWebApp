using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Asegurados = new HashSet<Asegurado>();
            Personals = new HashSet<Personal>();
        }

        public int Id { get; set; }
        public int FkRol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Role FkRolNavigation { get; set; }
        public virtual ICollection<Asegurado> Asegurados { get; set; }
        public virtual ICollection<Personal> Personals { get; set; }
    }
}
