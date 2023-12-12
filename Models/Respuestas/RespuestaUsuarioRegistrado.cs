using SigesivServer.Models.ViewModels;
using System.Collections.Generic;

namespace SigesivServer.Models.Respuestas
{
    public class RespuestaUsuarioRegistrado
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public ViewModelUsuarioRegistrado data { get; set; }
        public List<string> errores { get; set; }

    }
}
