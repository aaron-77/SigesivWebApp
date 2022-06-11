using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Asegurado
    {
        public Asegurado()
        {
            Pagos = new HashSet<Pago>();
            Polizasdeseguros = new HashSet<Polizasdeseguro>();
            Reportesdeincidentes = new HashSet<Reportesdeincidente>();
        }

        public int Id { get; set; }
        public int FkUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string NumeroDeLicencia { get; set; }
        public string Celular { get; set; }

        public virtual Usuario FkUsuarioNavigation { get; set; }
        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Polizasdeseguro> Polizasdeseguros { get; set; }
        public virtual ICollection<Reportesdeincidente> Reportesdeincidentes { get; set; }
    }
}
