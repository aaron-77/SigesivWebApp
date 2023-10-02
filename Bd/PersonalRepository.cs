using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SigesivServer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SigesivServer.Bd
{
    public class PersonalRepository : ConexionBD
    {
        public async Task<ActionResult<List<ViewModelPersonalAjustadores>>> consultarTodosLosAjustadores()
        {

            try
            {
                List<ViewModelPersonalAjustadores> personalesAjustador = new List<ViewModelPersonalAjustadores>();
                var personalAjustador = conexion.personalAjustador.FromSqlInterpolated($@"EXEC sp_obtenerTodosLosAjustadores").AsAsyncEnumerable();

                await foreach (var ajustador in personalAjustador)
                {
                    personalesAjustador.Add(ajustador);
                }
                return personalesAjustador;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return null;

        }
    }
}
