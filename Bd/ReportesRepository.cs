using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SigesivServer.Models;
using SigesivServer.Models.Ef;
using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.ViewModels;
using SigesivServer.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SigesivServer.Bd
{
    public class ReportesRepository : ConexionBD
    {
        public async Task<ActionResult<ViewModelReporteDeIncidentePreview>> registrarReporteDeIncidente(ViewModelReporteDeIncidenteCompleto reporte)
        {
            ActionResult<ViewModelReporteDeIncidentePreview> reporteCreado;
            try
            {
                if (reporte.reporte != null && reporte.otrosInvolucrados != null && reporte.otroVehiculosInvolucrados != null)
                {
                    reporteCreado = await crearReporteDeIncidenteCompleto(reporte);
                    return reporteCreado;
                }
                if (reporte.reporte != null && reporte.otrosInvolucrados != null && reporte.otroVehiculosInvolucrados == null)
                {
                    return reporteCreado = await crearReporteDeIncidenteSinOtrosVehiculos(reporte);
                }
                if (reporte.reporte != null && reporte.otrosInvolucrados == null && reporte.otroVehiculosInvolucrados != null)
                {
                    return reporteCreado = await crearReporteDeIncidenteSinOtrosInvolucrados(reporte);
                }
                if (reporte.reporte != null && reporte.otrosInvolucrados == null && reporte.otroVehiculosInvolucrados == null)
                {
                    return reporteCreado = await crearReporteDeIncidenteBase(reporte);
                }

            }
            catch (Exception ex)
            {

            }


            return null;
        }
        private async Task<ActionResult<ViewModelReporteDeIncidentePreview>> crearReporteDeIncidenteCompleto(ViewModelReporteDeIncidenteCompleto reporte)
        {
            ViewModelReporteDeIncidentePreview reporteCreado = new ViewModelReporteDeIncidentePreview();
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand comando = new SqlCommand("sp_registrarReporteDeIncidenteCompleto", conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        List<ReporteDeIncidente> reporteDeIncidente = new List<ReporteDeIncidente>();
                        List<Models.StoredProdecuresTypes.OtroInvolucrado> otrosInvolucrados = reporte.otrosInvolucrados;
                        List<Models.StoredProdecuresTypes.OtroVehiculoInvolucrado> vehiculosasegurados = reporte.otroVehiculosInvolucrados;
                        reporteDeIncidente.Add(reporte.reporte);
                        DataTable reportedt = reporteDeIncidente.ConvertToDataTable<ReporteDeIncidente>();
                        DataTable otrosInvolucradosdt = otrosInvolucrados.ConvertToDataTable<Models.StoredProdecuresTypes.OtroInvolucrado>();
                        DataTable otrosVehiculosInvolucradosdt = vehiculosasegurados.ConvertToDataTable<Models.StoredProdecuresTypes.OtroVehiculoInvolucrado>();
                        DbHelper helper2 = new DbHelper();
                        SqlParameter parametro1 = helper2.CreateParameter("@reporte", reportedt, SqlDbType.Structured);
                        SqlParameter parametro2 = helper2.CreateParameter("@otrosInvolucrados", otrosInvolucradosdt, SqlDbType.Structured);
                        SqlParameter parametro3 = helper2.CreateParameter("@otrosVehiculosInvolucrados", otrosVehiculosInvolucradosdt, SqlDbType.Structured);
                        comando.Parameters.Add(parametro1);
                        comando.Parameters.Add(parametro2);
                        comando.Parameters.Add(parametro3);

                        var reader = await comando.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            reporteCreado.id = (int)reader[0];
                            reporteCreado.nombreCompleto = (string)reader[1];
                            reporteCreado.modelo = (string)reader[2];
                            reporteCreado.marca = (string)reader[3];
                            reporteCreado.color = (string)reader[4];
                            reporteCreado.url1 = (string)reader[5];
                            reporteCreado.url2 = (string)reader[6];
                            reporteCreado.url3 = (string)reader[7];
                            reporteCreado.url4 = (string)reader[8];
                            reporteCreado.url5 = reader[9] == DBNull.Value ? "" : (string)reader[9];
                            reporteCreado.url6 = reader[10] == DBNull.Value ? "" : (string)reader[10];
                            reporteCreado.url7 = reader[11] == DBNull.Value ? "" : (string)reader[11];
                            reporteCreado.url8 = reader[12] == DBNull.Value ? "" : (string)reader[12];
                        }

                        return reporteCreado;

                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        private async Task<ActionResult<ViewModelReporteDeIncidentePreview>> crearReporteDeIncidenteSinOtrosVehiculos(ViewModelReporteDeIncidenteCompleto reporte)
        {
            ViewModelReporteDeIncidentePreview reporteCreado = new ViewModelReporteDeIncidentePreview();
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand comando = new SqlCommand("sp_registrarReporteDeIncidenteSinOtrosVehiculos", conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        List<ReporteDeIncidente> reporteDeIncidente = new List<ReporteDeIncidente>();
                        List<Models.StoredProdecuresTypes.OtroInvolucrado> otrosInvolucrados = reporte.otrosInvolucrados;
                        reporteDeIncidente.Add(reporte.reporte);
                        DataTable reportedt = reporteDeIncidente.ConvertToDataTable<ReporteDeIncidente>();
                        DataTable otrosInvolucradosdt = otrosInvolucrados.ConvertToDataTable<Models.StoredProdecuresTypes.OtroInvolucrado>();
                        DbHelper helper2 = new DbHelper();
                        SqlParameter parametro1 = helper2.CreateParameter("@reporte", reportedt, SqlDbType.Structured);
                        SqlParameter parametro2 = helper2.CreateParameter("@otrosInvolucrados", otrosInvolucradosdt, SqlDbType.Structured);
                        comando.Parameters.Add(parametro1);
                        comando.Parameters.Add(parametro2);
                        var reader = await comando.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            reporteCreado.id = (int)reader[0];
                            reporteCreado.nombreCompleto = (string)reader[1];
                            reporteCreado.modelo = (string)reader[2];
                            reporteCreado.marca = (string)reader[3];
                            reporteCreado.color = (string)reader[4];
                            reporteCreado.url1 = (string)reader[5];
                            reporteCreado.url2 = (string)reader[6];
                            reporteCreado.url3 = (string)reader[7];
                            reporteCreado.url4 = (string)reader[8];
                            reporteCreado.url5 = reader[9] == DBNull.Value ? "" : (string)reader[9];
                            reporteCreado.url6 = reader[10] == DBNull.Value ? "" : (string)reader[10];
                            reporteCreado.url7 = reader[11] == DBNull.Value ? "" : (string)reader[11];
                            reporteCreado.url8 = reader[12] == DBNull.Value ? "" : (string)reader[12];
                        }

                        return reporteCreado;

                    }

                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        private async Task<ActionResult<ViewModelReporteDeIncidentePreview>> crearReporteDeIncidenteSinOtrosInvolucrados(ViewModelReporteDeIncidenteCompleto reporte)
        {
            ViewModelReporteDeIncidentePreview reporteCreado = new ViewModelReporteDeIncidentePreview();
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand comando = new SqlCommand("sp_registrarReporteDeIncidenteSinOtrosInvolucrados", conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        List<ReporteDeIncidente> reporteDeIncidente = new List<ReporteDeIncidente>();
                        List<Models.StoredProdecuresTypes.OtroVehiculoInvolucrado> vehiculosasegurados = reporte.otroVehiculosInvolucrados;
                        reporteDeIncidente.Add(reporte.reporte);
                        DataTable reportedt = reporteDeIncidente.ConvertToDataTable<ReporteDeIncidente>();
                        DataTable otrosVehiculosInvolucradosdt = vehiculosasegurados.ConvertToDataTable<Models.StoredProdecuresTypes.OtroVehiculoInvolucrado>();
                        DbHelper helper2 = new DbHelper();
                        SqlParameter parametro1 = helper2.CreateParameter("@reporte", reportedt, SqlDbType.Structured);
                        SqlParameter parametro3 = helper2.CreateParameter("@otrosVehiculosInvolucrados", otrosVehiculosInvolucradosdt, SqlDbType.Structured);
                        comando.Parameters.Add(parametro1);
                        comando.Parameters.Add(parametro3);
                        var reader = await comando.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            reporteCreado.id = (int)reader[0];
                            reporteCreado.nombreCompleto = (string)reader[1];
                            reporteCreado.modelo = (string)reader[2];
                            reporteCreado.marca = (string)reader[3];
                            reporteCreado.color = (string)reader[4];
                            reporteCreado.url1 = (string)reader[5];
                            reporteCreado.url2 = (string)reader[6];
                            reporteCreado.url3 = (string)reader[7];
                            reporteCreado.url4 = (string)reader[8];
                            reporteCreado.url5 = reader[9] == DBNull.Value ? "" : (string)reader[9];
                            reporteCreado.url6 = reader[10] == DBNull.Value ? "" : (string)reader[10];
                            reporteCreado.url7 = reader[11] == DBNull.Value ? "" : (string)reader[11];
                            reporteCreado.url8 = reader[12] == DBNull.Value ? "" : (string)reader[12];
                        }
                        return reporteCreado;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        private async Task<ActionResult<ViewModelReporteDeIncidentePreview>> crearReporteDeIncidenteBase(ViewModelReporteDeIncidenteCompleto reporte)
        {
            ViewModelReporteDeIncidentePreview reporteCreado = new ViewModelReporteDeIncidentePreview();
            try
            {
                using (SqlConnection conn = new SqlConnection(conexion.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand comando = new SqlCommand("sp_registrarReporteDeIncidenteSolo", conn))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        List<ReporteDeIncidente> reporteDeIncidente = new List<ReporteDeIncidente>();
                        reporteDeIncidente.Add(reporte.reporte);
                        DataTable reportedt = reporteDeIncidente.ConvertToDataTable<ReporteDeIncidente>();
                        DbHelper helper2 = new DbHelper();
                        SqlParameter parametro1 = helper2.CreateParameter("@reporte", reportedt, SqlDbType.Structured);
                        comando.Parameters.Add(parametro1);
                        var reader = await comando.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            reporteCreado.id = (int)reader[0];
                            reporteCreado.nombreCompleto = (string)reader[1];
                            reporteCreado.modelo = (string)reader[2];
                            reporteCreado.marca = (string)reader[3];
                            reporteCreado.color = (string)reader[4];
                            reporteCreado.url1 = (string)reader[5];
                            reporteCreado.url2 = (string)reader[6];
                            reporteCreado.url3 = (string)reader[7];
                            reporteCreado.url4 = (string)reader[8];
                            reporteCreado.url5 = reader[9] == DBNull.Value ? "" : (string)reader[9];
                            reporteCreado.url6 = reader[10] == DBNull.Value ? "" : (string)reader[10];
                            reporteCreado.url7 = reader[11] == DBNull.Value ? "" : (string)reader[11];
                            reporteCreado.url8 = reader[12] == DBNull.Value ? "" : (string)reader[12];
                        }
                        return reporteCreado;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<ActionResult<int>> asignarReporteDeIncidente(int idreporte, int idajustador)
        {
            
            try
            {
                var resultado = await conexion.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_asignarReporteDeIncidente @reporte={idreporte},@personal={idajustador}");
                return resultado;
            }
            catch (Exception ex)
            {

            }

            return null;

        }

        public async Task<ActionResult<List<ViewModelReporteDeIncidenteSinAjustador>>> consultarReportesSinAjustador()
        {

            try
            {
                List<ViewModelReporteDeIncidenteSinAjustador> reportesSinAjustador = new List<ViewModelReporteDeIncidenteSinAjustador>();
                var reporteSinAjustador = conexion.reporteSinAjustador.FromSqlInterpolated($@"EXEC sp_obtenerTodosLosReportesSinAjustador").AsAsyncEnumerable();

                await foreach (var reporte in reporteSinAjustador)
                {
                    reportesSinAjustador.Add(reporte);
                }
                return reportesSinAjustador;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return null;

        }


    }
}

