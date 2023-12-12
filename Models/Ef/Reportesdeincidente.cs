using System;
using System.Collections.Generic;

#nullable disable

namespace SigesivServer.Models
{
    public partial class Reportesdeincidente
    {
        public Reportesdeincidente()
        {
            Otrosinvolucrados = new HashSet<Otrosinvolucrado>();
            Otrosvehiculosinvolucrados = new HashSet<Otrosvehiculosinvolucrado>();
        }

        public int Id { get; set; }
        public int FkAsegurado { get; set; }
        public int FkVehiculoAsegurado { get; set; }
        public int FkPersonal { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string UrlImagen1 { get; set; }
        public string UrlImagen2 { get; set; }
        public string UrlImagen3 { get; set; }
        public string UrlImagen4 { get; set; }
        public string UrlImagen5 { get; set; }
        public string UrlImagen6 { get; set; }
        public string UrlImagen7 { get; set; }
        public string UrlImagen8 { get; set; }
        public int FkEstado { get; set; }
        public DateTime FechaDelReporte { get; set; }

        public virtual Asegurado FkAseguradoNavigation { get; set; }
        public virtual Estadosreporte FkEstadoNavigation { get; set; }
        public virtual Personal FkPersonalNavigation { get; set; }
        public virtual Vehiculosasegurado FkVehiculoAseguradoNavigation { get; set; }
        public virtual ICollection<Otrosinvolucrado> Otrosinvolucrados { get; set; }
        public virtual ICollection<Otrosvehiculosinvolucrado> Otrosvehiculosinvolucrados { get; set; }
    }
}
