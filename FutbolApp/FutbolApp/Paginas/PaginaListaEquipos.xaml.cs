using System;
using FutbolApp.Modelos;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbolApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListaEquipos : ContentPage
    {
        public PaginaListaEquipos()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lsvEquipos.ItemsSource = App.BaseDatos.ObtenerEquipos();
        }

        private async void lsvEquipos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Equipo equipo = (Equipo)e.SelectedItem;
                await Navigation.PushAsync(new PaginaEquipo(equipo));
            }
            catch (Exception ex)
            {
            }
        }

        private async void Agregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaEquipo(new Equipo()));
        }
    }
}