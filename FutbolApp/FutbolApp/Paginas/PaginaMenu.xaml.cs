using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbolApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaMenu : ContentPage
    {
        public PaginaMenu()
        {
            InitializeComponent();
        }

        private async void Jugadores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaListaJugadores());
        }

        private async void Equipos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaListaEquipos());
        }
    }
}