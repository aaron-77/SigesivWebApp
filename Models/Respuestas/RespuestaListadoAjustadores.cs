using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.ViewModels;

namespace SigesivServer.Models.Respuestas
{
    public class RespuesListadoAjustadores
    {
        public int status { get; set; }
        public string mensaje { get; set; }
        public List<PersonalDTO> data { get; set; }
        public List<string> errores { get; set; }
        
    }
}