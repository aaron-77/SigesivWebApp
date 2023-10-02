namespace SigesivServer.Models.ViewModels
{
    public class ViewModelAseguradoConUsername
    {
        public int id { get; set; }
        public string nombreCompleto { get; set; }
        public int fkUsuario { get; set; }
        public string username { get; set; }
        public int fkRol { get; set; }
    }
}
