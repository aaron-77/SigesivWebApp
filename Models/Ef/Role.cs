using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Role
    {
        public Role()
        {
            Personals = new HashSet<Personal>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<Personal> Personals { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
