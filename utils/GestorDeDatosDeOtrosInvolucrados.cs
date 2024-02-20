using System.Reflection;
using SigesivServer.Models.ViewModels;
using SigesivServer.Models.StoredProdecuresTypes;


class GestorDeDatosDeOtrosInvolucrados
{


    public List<OtroInvolucrado> extraerOtrosInvolucradosDeFormulario(ViewModelReporteDeIncidenteCompletoCreate reporte)
    {
        List<OtroInvolucrado> otrosInvolucrados = new List<OtroInvolucrado>();

        /*
        * se obtienen todas propiedades que contienen los datos de los otros involucrados considerando 2 condiciones
        *1.- Que la propiedad id tenga valor mayor a 0
        * 2.- que la propiead nombre no sea null ni este vacia    
        */
        var properties = reporte.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.Name.StartsWith("otroInvolucrado") &&
                (
                    (
                        //que el valor de la propidad sea un numero(id) mayor a 0
                        (p.GetValue(reporte) != null && int.TryParse(p.GetValue(reporte).ToString(), out int numero) && (int)p.GetValue(reporte) > 0)
                        ||
                        //o bien que el valor no sea un numero y tenga un valor definido distinto de null o vacio(osea que si no es un id sea un nombre con valor definido)
                        (p.GetValue(reporte) != null && int.TryParse(p.GetValue(reporte).ToString(), out int numero2) == false)
                    )
                )
            );
        OtroInvolucrado otroInvlucradoNew = new OtroInvolucrado();
        for (int index = 1; index <= (properties.Count() / 3); index++)
        {
            var propId = properties.FirstOrDefault(pM => pM.Name.Contains(index.ToString()) && pM.Name.ToLower().Contains("id"));
            var propName = properties.FirstOrDefault(pM => pM.Name.Contains(index.ToString()) && pM.Name.ToLower().Contains("nombre"));
            var propLiencia = properties.FirstOrDefault(pM => pM.Name.Contains(index.ToString()) && pM.Name.ToLower().Contains("licencia"));
            otroInvlucradoNew.id = (int)propId.GetValue(reporte);
            otroInvlucradoNew.nombre = (string)propName.GetValue(reporte);
            otroInvlucradoNew.licencia = (string)propLiencia.GetValue(reporte);
            otrosInvolucrados.Add(otroInvlucradoNew);
            otroInvlucradoNew = new OtroInvolucrado();
        }

        return otrosInvolucrados;
    }
    public List<OtroVehiculoInvolucrado> extraerOtrosVehiculosInvolucrados(ViewModelReporteDeIncidenteCompletoCreate reporte)
    {
        //int[] cantidadOtrosInvolucradosYVehiculos = determinarNumDeOtrosInvolucrados(reporte);
        List<OtroVehiculoInvolucrado> otrosVehiculosInvolucrados = new List<OtroVehiculoInvolucrado>();
        /*
        * se obtienen todas propiedades que contienen los datos de los otros involucrados considerando 2 condiciones
        *1.- Que la propiedad id tenga valor mayor a 0
        * 2.- que la propiead nombre no sea null ni este vacia    
        */
        var properties = reporte.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(p => (p.Name.ToLower().Contains("otrovehiculo") || p.Name.ToLower().Contains("fkmarca") || p.Name.ToLower().Contains("fkmodelo")) &&
        (
            (
                //que el valor de la propidad sea un numero(id) mayor a 0
                (p.GetValue(reporte) != null && int.TryParse(p.GetValue(reporte).ToString(), out int numero) && (int)p.GetValue(reporte) > 0)
                ||
                //o bien que el valor no sea un numero y tenga un valor definido distinto de null o vacio(osea que si no es un id sea un nombre con valor definido)
                (p.GetValue(reporte) != null && int.TryParse(p.GetValue(reporte).ToString(), out int numero2) == false)
            )
        )
    );
        OtroVehiculoInvolucrado otroVehiculoInvlucradoNew = new OtroVehiculoInvolucrado();
        for (int index = 1; index <= (properties.Count() / 5); index++)
        {
            var propId = properties.FirstOrDefault(pM => pM.Name.Contains(index.ToString()) && pM.Name.ToLower().Contains("id"));
            var propPlaca = properties.FirstOrDefault(pM => pM.Name.Contains(index.ToString()) && pM.Name.ToLower().Contains("numerodeplaca"));
            var propFkMarca = properties.FirstOrDefault(pM => pM.Name.Contains(index.ToString()) && pM.Name.ToLower().Contains("fkmarca"));
            var propFkModelo = properties.FirstOrDefault(pM => pM.Name.Contains(index.ToString()) && pM.Name.ToLower().Contains("fkmodelo"));
            var propColor = properties.FirstOrDefault(pM => pM.Name.Contains(index.ToString()) && pM.Name.ToLower().Contains("color"));
            otroVehiculoInvlucradoNew.id = (int)propId.GetValue(reporte);
            otroVehiculoInvlucradoNew.numeroDePlaca = (string)propPlaca.GetValue(reporte);
            otroVehiculoInvlucradoNew.fkmarca = (int)propFkMarca.GetValue(reporte);
            otroVehiculoInvlucradoNew.fkmodelo = (int)propFkModelo.GetValue(reporte);
            otroVehiculoInvlucradoNew.color = (string)propColor.GetValue(reporte);
            otrosVehiculosInvolucrados.Add(otroVehiculoInvlucradoNew);
            otroVehiculoInvlucradoNew = new OtroVehiculoInvolucrado();
        }
        return otrosVehiculosInvolucrados;
    }

}