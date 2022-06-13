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
    public class ReportesRepositoryTest
    {
        private ReportesRepository reportesRepository;
        [SetUp]
        public void Setup()
        {
            reportesRepository = new ReportesRepository();
        }

        [Test]
        public async Task testCrearReporteDeIncidenteCompletoCompletoValido()
        {
            ReporteDeIncidente reporte = new ReporteDeIncidente() { fkAsegurado = 5, fkVehiculoAsegurado = 4, fechaDelReporte = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), latitud = 19.453900M, longitud = -99.099800M, urlImagen1 = "url1x", urlImagen2 = "url2x", urlImagen3 = "url3x", urlImagen4 = "url4x", fkEstado = 13 };
            OtroInvolucrado otroInvolucrado = new OtroInvolucrado() { id = 1, nombre = "Karina gonzalez" };
            OtroInvolucrado otroInvolucrado2 = new OtroInvolucrado() { id = 2, nombre = "Jorge Perez" };
            OtroVehiculoInvolucrado otroVehiculoInvolucrado = new OtroVehiculoInvolucrado() { id = 1, fkOtroInvolucrado = 1, fkmarca = 61, fkmodelo = 5, color = "negro", numeroDePlaca = "MNB-7765" };
            OtroVehiculoInvolucrado otroVehiculoInvolucrado2 = new OtroVehiculoInvolucrado() { id = 2, fkOtroInvolucrado = 1, fkmarca = 61, fkmodelo = 5, color = "amarillo", numeroDePlaca = "ZCV-777" };
            List<OtroInvolucrado> otrosInvolurados = new List<OtroInvolucrado>();
            List<OtroVehiculoInvolucrado> otrosVehiculosInvolucrados = new List<OtroVehiculoInvolucrado>();
            otrosInvolurados.Add(otroInvolucrado);
            otrosInvolurados.Add(otroInvolucrado2);
            otrosVehiculosInvolucrados.Add(otroVehiculoInvolucrado);
            otrosVehiculosInvolucrados.Add(otroVehiculoInvolucrado2);
            ViewModelReporteDeIncidenteCompleto reporteCompleto = new ViewModelReporteDeIncidenteCompleto()
            {
                reporte = reporte,
                otrosInvolucrados = otrosInvolurados,
                otroVehiculosInvolucrados = otrosVehiculosInvolucrados
            };

            var resultado = await reportesRepository.registrarReporteDeIncidente(reporteCompleto);
            Assert.AreNotEqual(null,resultado);
        }
        [Test]
        public async Task testCrearReporteDeIncidenteSinOtrosVehiculosValido()
        {
            ReporteDeIncidente reporte = new ReporteDeIncidente() { fkAsegurado = 5, fkVehiculoAsegurado = 4, fechaDelReporte = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), latitud = 19.453900M, longitud = -99.099800M, urlImagen1 = "url1x", urlImagen2 = "url2x", urlImagen3 = "url3x", urlImagen4 = "url4x", fkEstado = 13 };
            OtroInvolucrado otroInvolucrado = new OtroInvolucrado() { id = 1, nombre = "Karina gonzalez" };
            OtroInvolucrado otroInvolucrado2 = new OtroInvolucrado() { id = 2, nombre = "Jorge Perez" };
            List<OtroInvolucrado> otrosInvolurados = new List<OtroInvolucrado>();
            
            otrosInvolurados.Add(otroInvolucrado);
            otrosInvolurados.Add(otroInvolucrado2);
            
            ViewModelReporteDeIncidenteCompleto reporteCompleto = new ViewModelReporteDeIncidenteCompleto()
            {
                reporte = reporte,
                otrosInvolucrados = otrosInvolurados
            };

            var resultado = await reportesRepository.registrarReporteDeIncidente(reporteCompleto);
            Assert.AreNotEqual(null, resultado);
        }
        [Test]
        public async Task testCrearReporteDeIncidenteSinOtrosInvolucradosValido()
        {
            ReporteDeIncidente reporte = new ReporteDeIncidente() { fkAsegurado = 5, fkVehiculoAsegurado = 4, fechaDelReporte = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), latitud = 19.453900M, longitud = -99.099800M, urlImagen1 = "url1x", urlImagen2 = "url2x", urlImagen3 = "url3x", urlImagen4 = "url4x", fkEstado = 13 };
            OtroVehiculoInvolucrado otroVehiculoInvolucrado = new OtroVehiculoInvolucrado() { id = 1, fkOtroInvolucrado = 1, fkmarca = 61, fkmodelo = 5, color = "negro", numeroDePlaca = "MNB-7765" };
            OtroVehiculoInvolucrado otroVehiculoInvolucrado2 = new OtroVehiculoInvolucrado() { id = 2, fkOtroInvolucrado = 1, fkmarca = 61, fkmodelo = 5, color = "amarillo", numeroDePlaca = "ZCV-777" };
            List<OtroVehiculoInvolucrado> otrosVehiculosInvolucrados = new List<OtroVehiculoInvolucrado>();
            otrosVehiculosInvolucrados.Add(otroVehiculoInvolucrado);
            otrosVehiculosInvolucrados.Add(otroVehiculoInvolucrado2);
            ViewModelReporteDeIncidenteCompleto reporteCompleto = new ViewModelReporteDeIncidenteCompleto()
            {
                reporte = reporte,
                otroVehiculosInvolucrados = otrosVehiculosInvolucrados
            };

            var resultado = await reportesRepository.registrarReporteDeIncidente(reporteCompleto);
            Assert.AreNotEqual(null, resultado);
        }
        [Test]
        public async Task testCrearReporteDeIncidenteSolo()
        {
            ReporteDeIncidente reporte = new ReporteDeIncidente() { fkAsegurado = 5, fkVehiculoAsegurado = 4, fechaDelReporte = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), latitud = 19.453900M, longitud = -99.099800M, urlImagen1 = "url1x", urlImagen2 = "url2x", urlImagen3 = "url3x", urlImagen4 = "url4x", fkEstado = 13 };
            ViewModelReporteDeIncidenteCompleto reporteCompleto = new ViewModelReporteDeIncidenteCompleto()
            {
                reporte = reporte,
            };
            var resultado = await reportesRepository.registrarReporteDeIncidente(reporteCompleto);
            Assert.AreNotEqual(null, resultado);
        }
    }
}
