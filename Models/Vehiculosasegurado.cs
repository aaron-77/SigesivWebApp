using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Vehiculosasegurado
    {
        public Vehiculosasegurado()
        {
            Polizasdeseguros = new HashSet<Polizasdeseguro>();
            Reportesdeincidentes = new HashSet<Reportesdeincidente>();
        }

        public int Id { get; set; }
        public string NumeroDeSerie { get; set; }
        public int FkMarca { get; set; }
        public int FkModelo { get; set; }
        public int Año { get; set; }
        public string Color { get; set; }
        public string NumeroDePlacas { get; set; }
        public int FkEstado { get; set; }

        public virtual Estadosvehiculosasegurado FkEstadoNavigation { get; set; }
        public virtual Marca FkMarcaNavigation { get; set; }
        public virtual Modelo FkModeloNavigation { get; set; }
        public virtual ICollection<Polizasdeseguro> Polizasdeseguros { get; set; }
        public virtual ICollection<Reportesdeincidente> Reportesdeincidentes { get; set; }
    }
}
