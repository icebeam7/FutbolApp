using System.IO;

namespace FutbolApp.UWP.Helpers
{
    public class FileHelper
    {
        public static string ObtenerRutaLocal(string archivo)
        {
            string ruta = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return Path.Combine(ruta, archivo);
        }
    }
}
