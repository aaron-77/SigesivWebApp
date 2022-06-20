namespace SigesivServer.Models.StoredProdecuresTypes
{
    public class VehiculoAsegurado
    {
        public int? id { get; set; }
        public string numeroDeSerie { get; set; }
        public int fkMarca { get; set; }
        public int fkModelo { get; set; }
        public int ano { get; set; }
        public string color { get; set; }
        public string numeroDePlacas { get; set; }
        public int fkEstado { get; set; }
    }
}
