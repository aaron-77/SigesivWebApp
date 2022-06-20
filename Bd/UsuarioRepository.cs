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
        public async Task<ActionResult<ViewModelUsuarioRegistrado>> consultarSiUsuarioExiste(string username, string password)
        {
            try
            {              
                var usuarioRegistrado = conexion.usuarioRegistrado.FromSqlInterpolated($@"EXEC sp_iniciarSesion @username={username}, @password={password}").AsAsyncEnumerable();

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
