using FutbolApp.Datos;
using SQLite.Net.Interop;
using Xamarin.Forms;

namespace FutbolApp
{
    public partial class App : Application
    {
        public static BaseDatos BaseDatos { get; set; }

        public App(string rutaBD, ISQLitePlatform plataforma)
        {
            BaseDatos = new BaseDatos(plataforma, rutaBD);
            BaseDatos.Conectar();

            InitializeComponent();

            MainPage = new NavigationPage(new FutbolApp.Paginas.PaginaMenu());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
