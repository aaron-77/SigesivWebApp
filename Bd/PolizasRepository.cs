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
using Pago = SigesivServer.Models.StoredProdecuresTypes.Pago;
 

namespace SigesivServer.Bd
{
    public class PolizasRepository : ConexionBD
    {


        public async Task<ViewModel_detalleDePolizaDeConductor> comprarPoliza(PolizaCompleta polizaCompleta)
        {
            
            try
            {
                ViewModel_detalleDePolizaDeConductor polizaCreada = new ViewModel_detalleDePolizaDeConductor();
                
                using (SqlConnection conn = new SqlConnection(conexion.Database.GetDbConnection().ConnectionString))
                {
                    await conn.OpenAsync();
                   
                    using (SqlCommand comando = new SqlCommand("sp_registrarPoliza", conn))
                    {
                        comando.CommandText = "sp_registrarPoliza";
                        comando.CommandType = CommandType.StoredProcedure;              
                        List<Pago> pagos2 = new List<Pago>();
                        List<Models.StoredProdecuresTypes.Asegurado> asegurados = new List<Models.StoredProdecuresTypes.Asegurado>();
                        List<Models.StoredProdecuresTypes.Poliza> polizas = new List<Models.StoredProdecuresTypes.Poliza>();
                        List<Models.StoredProdecuresTypes.VehiculoAsegurado> vehiculosasegurados = new List<Models.StoredProdecuresTypes.VehiculoAsegurado>();
                        List<Models.StoredProdecuresTypes.Usuario> usuarios = new List<Models.StoredProdecuresTypes.Usuario>();
                        pagos2.Add(polizaCompleta.pago);
                        asegurados.Add(polizaCompleta.asegurado);
                        polizas.Add(polizaCompleta.polizadeseguro);
                        vehiculosasegurados.Add(polizaCompleta.vehiculosasegurado);
                        usuarios.Add(polizaCompleta.usuario);
                        DataTable pago2 = pagos2.ConvertToDataTable<Pago>();
                        DataTable asegurado = asegurados.ConvertToDataTable<Models.StoredProdecuresTypes.Asegurado>();
                        DataTable vehiculoasegurado = vehiculosasegurados.ConvertToDataTable<Models.StoredProdecuresTypes.VehiculoAsegurado>();
                        DataTable poliza = polizas.ConvertToDataTable<Models.StoredProdecuresTypes.Poliza>();
                        DataTable usuario = usuarios.ConvertToDataTable<Models.StoredProdecuresTypes.Usuario>();
                        DbHelper helper2 = new DbHelper();
                        SqlParameter parametro1 = helper2.CreateParameter("@pago", pago2, SqlDbType.Structured);
                        SqlParameter parametro2 = helper2.CreateParameter("@asegurado", asegurado, SqlDbType.Structured);
                        SqlParameter parametro3 = helper2.CreateParameter("@vehiculoAsegurado", vehiculoasegurado, SqlDbType.Structured);
                        SqlParameter parametro4 = helper2.CreateParameter("@usuario", usuario, SqlDbType.Structured);
                        SqlParameter parametro5 = helper2.CreateParameter("@poliza", poliza, SqlDbType.Structured);
                        comando.Parameters.Add(parametro1);
                        comando.Parameters.Add(parametro2);
                        comando.Parameters.Add(parametro3);
                        comando.Parameters.Add(parametro4);
                        comando.Parameters.Add(parametro5);
                        var reader = await comando.ExecuteReaderAsync();
                        while (reader.Read())
                        {
                            polizaCreada.idAsegurado = (int)reader[0];
                            polizaCreada.fechaDeNacimiento = (DateTime)reader[1];
                            polizaCreada.nombreCompleto = (string)reader[2];
                            polizaCreada.numeroDeLicencia = (string)reader[3];
                            polizaCreada.celular = (string)reader[4];
                            polizaCreada.idPoliza = (int)reader[5];
                            polizaCreada.numeroDePoliza = (string)reader[6];
                            polizaCreada.fechaDeInicio = (DateTime)reader[7];
                            polizaCreada.fechaDeExpiracion = (DateTime)reader[8];
                            polizaCreada.tipoDeCobertura = (string)reader[9];
                            polizaCreada.lapsoDeCobertura = (int)reader[10];
                            polizaCreada.marca = (string)reader[11];
                            polizaCreada.modelo = (string)reader[12];
                            polizaCreada.numeroDePlacas = (string)reader[13];
                            polizaCreada.año = (int)reader[14];
                            polizaCreada.color = (string)reader[15];

                        }

                        return polizaCreada;

                    }
                }   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<ActionResult<ViewModel_detalleDePolizaDeConductor>> consultarPoliza(int id) {

            try
            {

                
                    var polizaDeCondutor = conexion.poliza.
                    FromSqlInterpolated($@"EXEC sp_obtenerPolizaDeConductor @idConductor={id}").AsAsyncEnumerable();
                    await foreach (var poliza in polizaDeCondutor)
                    {
                        var polizaObtenida = poliza;
                        var casosDeCobertura = conexion.sp_obtenerCoberturaDePoliza.FromSqlInterpolated($@"EXEC sp_obtenerCoberturaDePoliza @idPoliza={polizaObtenida.idPoliza}").AsAsyncEnumerable();
                        await foreach (var caso in casosDeCobertura)
                        {
                            polizaObtenida.casosDeCobertura.Add(caso);
                        }
                        return poliza;
                    }
                               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<ActionResult<ViewModel_detalleDePolizaDeConductor>> obtenerCoberturaDePoliza(int id)
        {

            try
            {
                var polizaDeCondutor = conexion.poliza.
                FromSqlInterpolated($@"EXEC sp_obtenerPolizaDeConductor @idConductor={id}").AsAsyncEnumerable();


                await foreach (var poliza in polizaDeCondutor)
                {
                    return poliza;
                }

                await foreach (var poliza in polizaDeCondutor)
                {
                    Console.WriteLine(poliza.idPoliza);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        
    }
}
