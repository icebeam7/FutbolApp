using FutbolApp.Modelos;
using FutbolApp.Clases;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbolApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaEquipo : ContentPage
    {
        Equipo Equipo;

        public PaginaEquipo(Equipo equipo)
        {
            InitializeComponent();

            Equipo = equipo;
            this.BindingContext = equipo;
        }

        private async void btnEscudo_Clicked(object sender, EventArgs e)
        {
            var escudo = await ServicioImagenes.SeleccionarImagen();
            Equipo.Escudo = escudo.Path;
            imgEscudo.Source = ImageSource.FromFile(escudo.Path);
        }

        private void Guardar_Clicked(object sender, EventArgs e)
        {
            if (Equipo.ID > 0)
                App.BaseDatos.ActualizarEquipo(Equipo);
            else
                App.BaseDatos.AgregarEquipo(Equipo);
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Eliminar", "¿Deseas eliminar el equipo?", "Si", "No"))
            {
                App.BaseDatos.EliminarEquipo(Equipo);
            }
        }

        private async void lsvJugadores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Jugador jugador = (Jugador)e.SelectedItem;
            await Navigation.PushAsync(new PaginaJugadorEquipo(jugador, Equipo, false));
        }

        private async void Agregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaListaJugadores(Equipo));
        }
    }
}