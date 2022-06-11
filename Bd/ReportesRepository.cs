﻿using Microsoft.AspNetCore.Mvc;
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
    public class ReportesRepository:ConexionBD
    {
        public async Task<ActionResult<ViewModelReporteDeIncidentePreview>> registrarReporteDeIncidente(ViewModelReporteDeIncidenteCompleto reporte)
        {
            ActionResult<ViewModelReporteDeIncidentePreview> reporteCreado;
            try {
                if (reporte.reporte != null && reporte.otrosInvolucrados != null && reporte.otroVehiculosInvolucrados != null)
                {
                    
                    
                    reporteCreado =  await crearReporteDeIncidenteCompleto(reporte);
                    return reporteCreado;
                }
                if (reporte.reporte != null && reporte.otrosInvolucrados != null && reporte.otroVehiculosInvolucrados == null)
                {
                }
                if (reporte.reporte != null && reporte.otrosInvolucrados == null && reporte.otroVehiculosInvolucrados == null)
                {
                }

            }
            catch (Exception ex) { 
            
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
                            reporteCreado.url5 = reader[9] == DBNull.Value?"":(string)reader[9];
                            reporteCreado.url6 = reader[10] == DBNull.Value ? "" : (string)reader[10];
                            reporteCreado.url7 = reader[11] == DBNull.Value ? "" : (string)reader[11];
                            reporteCreado.url8 = reader[12] == DBNull.Value ? "" : (string)reader[12];
                        }

                        return reporteCreado;

                    }
                }
            }
            catch (Exception ex) { 
            }
            return null;
        }

    }
}
