    using System;
    using System.IO;

    namespace FutbolApp.Droid.Helpers
    {
        public class FileHelper
        {
            public static string ObtenerRutaLocal(string archivo)
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                return Path.Combine(ruta, archivo);
            }
        }
    }