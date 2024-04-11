using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SigesivServer.Models;
using SigesivServer.Models.Ef;
using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebGrease.Css.Ast.Selectors;
using SigesivServer.Models.Respuestas;

namespace SigesivServer.Bd
{
    public class EjecutivoAsistenciaRepository 
    {
        private proyectoaseguradoraequipo5Context conexion;
        
        public EjecutivoAsistenciaRepository(){
            conexion = new proyectoaseguradoraequipo5Context();
        }
        public async Task<ActionResult<int>> asignarReporteDeIncidente(int idAjustador, int idReporte)
        {
            try
            {
                var resultado = await conexion.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_asignarReporte @idReporte={idReporte},@idAjustador={idAjustador}");
                return resultado;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public async Task<ActionResult<RespuesListadoAjustadores>> ConsultarAjustadores()
        {
            int fkRol = 1;
            List<PersonalDTO> ajustadores ;
            RespuesListadoAjustadores respuestaListadoAjustadores = new RespuesListadoAjustadores();
            try
            {
                var result = await conexion.catalogoPersonal.FromSqlInterpolated($@"EXEC sp_obtenerPersonalPorRol @idRol={fkRol}").ToListAsync();
                ajustadores = result;          
            }
            catch (Exception ex)
            {
                respuestaListadoAjustadores.errores.Add(ex.Message+ "\n" + ex.StackTrace);
                respuestaListadoAjustadores.mensaje = "Error al cargar los ajustadores";
                ajustadores = null;
                
            }
            respuestaListadoAjustadores.mensaje = "Consulta exitosa";
            respuestaListadoAjustadores.data = ajustadores;
            return respuestaListadoAjustadores;
        }
    }
}

