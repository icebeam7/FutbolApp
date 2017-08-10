using System;
using FutbolApp.Modelos;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbolApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListaJugadores : ContentPage
    {
        Equipo Equipo;

        public PaginaListaJugadores(Equipo equipo = null)
        {
            InitializeComponent();

            Equipo = equipo;

            if (Equipo != null)
            {
                if (this.ToolbarItems.Count > 0)
                    this.ToolbarItems.RemoveAt(0);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lsvJugadores.ItemsSource = App.BaseDatos.ObtenerJugadores();
        }

        private async void lsvJugadores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Jugador jugador = (Jugador)e.SelectedItem;

                if (Equipo == null)
                {
                    await Navigation.PushAsync(new PaginaJugador(jugador));
                }
                else
                {
                    await Navigation.PushAsync(new PaginaJugadorEquipo(jugador, Equipo, true));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async void Agregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaJugador(new Jugador()));
        }
    }
}