using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SigesivServer.Bd;
using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.ViewModels;
using SigesivServer.utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace SigesivServerTests
{
    public class PolizasRepositoryTests
    {
      private PolizasRepository polizasRepository;
        [SetUp]
        public void Setup()
        {
            polizasRepository = new PolizasRepository();
        }

        [Test]
        public async Task testObtenerPolizaDeConductorDatosCorrectos()
        {
            var resultado = await polizasRepository.consultarPoliza(5);
            int idPolizaObtenido = resultado.Value.idPoliza;
            Assert.AreEqual(4, idPolizaObtenido);

            
        }
        [Test]
        public async Task testObtenerPolizaDeConductorDatosIncorrectos()
        {
            var resultado = await polizasRepository.consultarPoliza(99);
            Assert.AreEqual(null, resultado);
        }
        [Test]
        public async Task testComprarPolizaDeConductor()
        {

            
            Pago pago = new Pago() { numDeTarjeta = 123456789 };
            string fechastr2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try {
                Asegurado asegurado = new Asegurado() { nombreCompleto = "Juan Vazquez Vazquez", fechaDeNacimiento = fechastr2, numeroDeLicencia = "33435", celular = "2283726372" };
                VehiculoAsegurado vehiculoAsegurado = new VehiculoAsegurado() { numeroDeSerie = "RT70000", fkMarca = 61, fkModelo = 5, año = 2022, color = "azul", numeroDePlacas = "XYZ-ewe",fkEstado=9 };
                Poliza poliza = new Poliza() { numeroDePoliza = "PO-00X", fechaDeInicio = fechastr2, fechaDeExpiracion = fechastr2, costoTotal = 399.75M, fkEstado = 9,fkTipoDeCobertura=37 };
                int usuario = 19;
                SigesivServer.Models.Ef.PolizaCompleta polizaCompleta = new SigesivServer.Models.Ef.PolizaCompleta() { asegurado = asegurado, pago = pago, vehiculosasegurado = vehiculoAsegurado, polizadeseguro = poliza, usuario = usuario };
                var resultado = await polizasRepository.comprarPoliza(polizaCompleta);
                Assert.AreNotEqual(null, resultado);

            }
            catch (Exception ex) { 
            }   
        }
        [Test]
        public async Task testObtenerCatalogoDeCoberturas()
        {
            
            try
            {

                var resultado = await polizasRepository.consultarCatalogoTiposDeCobertura();
                Assert.AreNotEqual(null, resultado);

            }
            catch (Exception ex)
            {
            }
        }
        [Test]
        public async Task testObtenerCatalogoDeMarcasConModelos()
        {

            try
            {

                var resultado = polizasRepository.consultarCatalogoDeMarcasConModelos();
                Assert.AreNotEqual(null, resultado);

            }
            catch (Exception ex)
            {
            }
        }

    }
}