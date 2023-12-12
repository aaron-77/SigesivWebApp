namespace SigesivServer.Models.StoredProdecuresTypes
{
    [Serializable]
    public class Pago
    {
        public int id { get; set; }
        public int fkAsegurado { get; set; }
        public long numDeTarjeta { get; set; }
    }
}
