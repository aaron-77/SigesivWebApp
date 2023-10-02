using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SigesivServer.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SigesivServer.Bd
{
    public class AseguradoRepository : ConexionBD
    {
        public async Task<ActionResult<ViewModelAseguradoConUsername>> obtenerAseguradoConUsername(ViewModelUserLogin user)
        {

            try
            {
                var aseguradoConUsername = conexion.aseguradoConUsername.FromSqlInterpolated($@"EXEC sp_obtenerInformacionUsuarioAsegurado @username={user.username},@password={user.password}").AsAsyncEnumerable();
                await foreach (var asegurado in aseguradoConUsername)
                {
                    return asegurado;
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
