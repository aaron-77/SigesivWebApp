using System;
using System.ComponentModel.DataAnnotations;

namespace SigesivServer.Models
{
    public class sp_obtenerPolizaDeConductor
    {
       
        public int idAsegurado { get; set; }
        public DateTime fechaDeNacimiento { get; set; }
        public string nombreCompleto { get; set; }
        public string numeroDeLicencia { get; set; }
        public string celular { get; set; }
        public int idPoliza { get; set; }
        public string numeroDePoliza { get; set; }
        public DateTime fechaDeInicio { get; set; }
        public DateTime fechaDeExpiracion { get; set; }
        public string tipoDeCobertura { get; set; }
        public int lapsoDeCobertura { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string numeroDePlacas { get; set; }
        public int año { get; set; }
        public string color { get; set; }

    }
}
