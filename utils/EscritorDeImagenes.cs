using SigesivServer.Models.ViewModels;
using System.Collections.Generic;
using System.Reflection;

namespace SigesivServer.utils
{
    public class EscritorDeImagenes
    {
        public List<string> guadarImagenes(ViewModelReporteDeIncidenteCreate reporte)
        {
            PropertyInfo[] lst = typeof(ViewModelReporteDeIncidenteCreate).GetProperties();
            List<string> urlsDeAcceso = new List<string>();

            foreach (PropertyInfo oProperty in lst)
            {
                string NombreAtributo = oProperty.Name;
                if (NombreAtributo.Equals("urlImagenes"))
                {
                    if (oProperty.GetValue(reporte) != null)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (i <= reporte.urlImagenes.Count -1)
                            {
                                urlsDeAcceso.Add("http://urlimagen/imagen");
                            }else{
                                urlsDeAcceso.Add(null);
                            }
                            
                        }
                    }
                }

            }
            return urlsDeAcceso;
        }
    }
}
