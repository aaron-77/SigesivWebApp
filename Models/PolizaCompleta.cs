using SigesivServer.Models.StoredProdecuresTypes;
namespace SigesivServer.Models.Ef
{
    public class PolizaCompleta
    {
        public Models.StoredProdecuresTypes.Pago pago { get; set; }
        public Models.StoredProdecuresTypes.Asegurado asegurado { get; set; }
        public VehiculoAsegurado vehiculosasegurado { get; set; }
        public Poliza polizadeseguro { get; set; }
        public int usuario { get; set; }

    }
}
