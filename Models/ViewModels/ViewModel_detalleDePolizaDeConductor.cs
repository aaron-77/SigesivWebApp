using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SigesivServer.Models
{
    public class ViewModel_detalleDePolizaDeConductor
    {

        public ViewModel_detalleDePolizaDeConductor() {
            casosDeCobertura = new List<CasoDeCobertura>();
        }
        public int idAsegurado { get; set; }

        public DateTime? fechaDeNacimiento { get; set; }
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
        public List<CasoDeCobertura> casosDeCobertura { get; set; }

        
        public static explicit operator ViewModel_detalleDePolizaDeConductor(ActionResult<ViewModel_detalleDePolizaDeConductor> v)
        {
            return new ViewModel_detalleDePolizaDeConductor
            {
                idPoliza = v.Value.idPoliza,
                numeroDePoliza = v.Value.numeroDePoliza,
                fechaDeInicio = v.Value.fechaDeInicio,
                fechaDeExpiracion = v.Value.fechaDeExpiracion,
                tipoDeCobertura = v.Value.tipoDeCobertura,
                lapsoDeCobertura = v.Value.lapsoDeCobertura,
                idAsegurado = v.Value.idAsegurado,
                nombreCompleto = v.Value.nombreCompleto,
                fechaDeNacimiento = v.Value.fechaDeNacimiento,
                numeroDeLicencia = v.Value.numeroDeLicencia,
                celular = v.Value.celular,
                marca = v.Value.marca,
                modelo = v.Value.modelo,
                numeroDePlacas = v.Value.numeroDePlacas,
                año = v.Value.año,
                color = v.Value.color,
                casosDeCobertura = v.Value.casosDeCobertura
            };

        }
    }
}
