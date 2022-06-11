namespace SigesivServer.Models.StoredProdecuresTypes
{
    public class OtroVehiculoInvolucrado
    {
        public int id { get; set; }
        public int? fkOtroInvolucrado { get; set; }
        public int? fkmarca { get; set; }
        public int? fkmodelo { get; set; }
        public string color { get; set; }
        public string numeroDePlaca { get; set; }
        public int fkReporte { get; set; }

    }
}
