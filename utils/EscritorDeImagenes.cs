using SigesivServer.Models.ViewModels;
using System.Collections.Generic;
using System.Reflection;

namespace SigesivServer.utils
{
    public class EscritorDeImagenes
    {
        public List<string> guadarImagenes(ViewModelReporteDeIncidenteCreate reporte) {
            PropertyInfo[] lst = typeof(ViewModelReporteDeIncidenteCreate).GetProperties();
            List<string> urlsDeAcceso = new List<string>();
            
            foreach (PropertyInfo oProperty in lst)
            {
              
                string NombreAtributo = oProperty.Name;
                if (NombreAtributo.Equals("urlImagen1") || 
                    NombreAtributo.Equals("urlImagen2")||
                    NombreAtributo.Equals("urlImagen3")||
                    NombreAtributo.Equals("urlImagen4")||
                    NombreAtributo.Equals("urlImagen5")||
                    NombreAtributo.Equals("urlImagen6")||
                    NombreAtributo.Equals("urlImagen7")||
                    NombreAtributo.Equals("urlImagen8"))
                {
                    if (oProperty.GetValue(reporte) != null)
                    {
                        urlsDeAcceso.Add("http://urlimagen/imagen");
                    }
                    else {
                        urlsDeAcceso.Add(null);
                    }    
                }
                
            }
            return urlsDeAcceso;
        }
    }
}
