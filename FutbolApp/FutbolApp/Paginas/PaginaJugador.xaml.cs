using FutbolApp.Modelos;
using FutbolApp.Clases;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbolApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaJugador : ContentPage
    {
        Jugador Jugador;

        public PaginaJugador(Jugador jugador)
        {
            InitializeComponent();

            Jugador = jugador;
            this.BindingContext = jugador;
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            var foto = await ServicioImagenes.SeleccionarImagen();
            Jugador.Foto = foto.Path;
            imgFoto.Source = ImageSource.FromFile(foto.Path);
        }

        private void Guardar_Clicked(object sender, EventArgs e)
        {
            if (Jugador.ID > 0)
                App.BaseDatos.ActualizarJugador(Jugador);
            else
                App.BaseDatos.AgregarJugador(Jugador);
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Eliminar", "¿Deseas eliminar el jugador?", "Si", "No"))
            {
                App.BaseDatos.EliminarJugador(Jugador);
            }
        }

        private async void lsvEquipos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Equipo equipo = (Equipo)e.SelectedItem;
            await Navigation.PushAsync(new PaginaJugadorEquipo(Jugador, equipo, false));
        }
    }
}