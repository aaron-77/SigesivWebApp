namespace SigesivServer.Models.ViewModels;
public class ViewModelDetalleReporteDeIncidente
{
    public int? id { get; set; }
    public int fkAsegurado { get; set; }
    public int fkVehiculoAsegurado { get; set; }
    public string latitud { get; set; }
    public string longitud { get; set; }
    public DateTime fechaDelReporte { get; set; }
    public string direccion { get; set; }
    public int? fkPersonal { get; set; }
    public int fkEstado { get; set; }
    public string nombreCompleto { get; set; }
    public string numeroDeLicencia { get; set; }
    public string numeroDePlacas { get; set; }
    public string marca { get; set; }
    public string modelo { get; set; }
    public string color { get; set; }
    public string? nombreAjustador { get; set; }
    public string urlImagen1 { get; set; }
    public string urlImagen2 { get; set; }
    public string urlImagen3 { get; set; }
    public string urlImagen4 { get; set; }
    public string? urlImagen5 { get; set; }
    public string? urlImagen6 { get; set; }
    public string? urlImagen7 { get; set; }
    public string? urlImagen8 { get; set; }
    public string tipoDeCobertura { get; set; }
    public List<ViewModelCasoDeCobertura>? nombreDelCaso { get; set; }
    public List<ViewModelOtroInvolucrado>? otrosInvolucrados { get; set; }
}