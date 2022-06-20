namespace SigesivServer.Models.ViewModels
{
    public class ViewModelUsuarioRegistrado
    {
        public int id { get; set; }
        public int fkRol { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
