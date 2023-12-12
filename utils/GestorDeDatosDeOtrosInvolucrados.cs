using System.Reflection;
using System.Resources;
using Microsoft.IdentityModel.Tokens;
using SigesivServer.Models;
using SigesivServer.Models.ViewModels;
using SigesivServer.Models.StoredProdecuresTypes;

class GestorDeDatosDeOtrosInvolucrados
{


    public List<OtroInvolucrado> extraerOtrosInvolucradosDeFormulario(ViewModelReporteDeIncidenteCompletoCreate reporte)
    {

        //int[] cantidadOtrosInvolucradosYVehiculos = determinarNumDeOtrosInvolucrados(reporte);
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
        int contadorPropsOtrosInvolucradosAgregados = 0;
        foreach (var property in properties)
        {
            contadorPropsOtrosInvolucradosAgregados++;

            var valor = property.GetValue(reporte);
            foreach (var prop in otroInvlucradoNew.GetType().GetProperties())
            {
                if (property.Name.ToLower().Contains(prop.Name))
                {
                    Type tipoDeDato = prop.PropertyType;
                    TypeCode codigoTipo = Type.GetTypeCode(tipoDeDato);
                    switch (codigoTipo)
                    {
                        case TypeCode.Int32:
                            prop.SetValue(otroInvlucradoNew, (int)valor); // Copia el valor de la propiedad actual al nuevo objeto    
                            break;
                        case TypeCode.String:
                            prop.SetValue(otroInvlucradoNew, (string)valor); // Copia el valor de la propiedad actual al nuevo objeto    
                            break;
                    }
                }
            }
            if (contadorPropsOtrosInvolucradosAgregados % 2 == 0)
            {
                otrosInvolucrados.Add(otroInvlucradoNew);
                otroInvlucradoNew = new OtroInvolucrado();
            }
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
        .Where(p => (p.Name.ToLower().Contains("otrovehiculo") || p.Name.ToLower().Contains("fkmarca") || p.Name.ToLower().Contains("fkmodelo") )&&
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
        int contadorPropsOtrosVehiculosAgregados = 0;
        foreach (var property in properties)
        {
            contadorPropsOtrosVehiculosAgregados++;
            var valor = property.GetValue(reporte);
            foreach (var prop in otroVehiculoInvlucradoNew.GetType().GetProperties())
            {
                if (property.Name.ToLower().Contains(prop.Name.ToLower()))
                {
                    Type tipoDeDato = prop.PropertyType;
                    TypeCode codigoTipo = Type.GetTypeCode(tipoDeDato);
                    switch (codigoTipo)
                    {
                        case TypeCode.Int32:
                            prop.SetValue(otroVehiculoInvlucradoNew, (int)valor); // Copia el valor de la propiedad actual al nuevo objeto    
                            break;
                        case TypeCode.String:
                            prop.SetValue(otroVehiculoInvlucradoNew, (string)valor); // Copia el valor de la propiedad actual al nuevo objeto    
                            break;
                    }
                }
            }
            if (contadorPropsOtrosVehiculosAgregados % 5 == 0)
            {
                otrosVehiculosInvolucrados.Add(otroVehiculoInvlucradoNew);
                otroVehiculoInvlucradoNew = new OtroVehiculoInvolucrado();
            }
        }
        return otrosVehiculosInvolucrados;
    }

}