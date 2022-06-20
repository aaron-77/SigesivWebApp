using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SigesivServer.Bd
{
    public class UsuarioRepository : ConexionBD
    {
        public async Task<ActionResult<ViewModelAseguradoConUsername>> consultarSiUsuarioExiste(string username, string password)
        {
            try
            {              
                var usuarioRegistrado = conexion.aseguradoConUsername.FromSqlInterpolated($@"EXEC sp_obtenerInformacionUsuarioAsegurado @username={username}, @password={password}").AsAsyncEnumerable();

                await foreach (var usuario in usuarioRegistrado)
                {
                    return usuario;
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
