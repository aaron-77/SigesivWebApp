using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace SigesivServer.Models.Peticiones
{
    public class AsignarReporteModel
    {
        [Required(ErrorMessage = "El ajustador es requerido")]
        [JsonPropertyName("idAjustador")]
        public int idAjustador { get; set; }
        [Required(ErrorMessage = "El reporte es requerido")]
        [JsonPropertyName("idReporte")]
        public int idReporte { get; set; }
    }
}
