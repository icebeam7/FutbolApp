using FutbolApp.Clases;
using FutbolApp.Modelos;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutbolApp.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaJugadorEquipo : ContentPage
    {
        DetalleJugadorEquipo Detalle;
        JugadorEquipo JugadorEquipo;
        Jugador Jugador;
        Equipo Equipo;
        bool Nuevo;

        public PaginaJugadorEquipo(Jugador jugador, Equipo equipo, bool nuevo)
        {
            InitializeComponent();

            Jugador = jugador;
            Equipo = equipo;
            Detalle = App.BaseDatos.ObtenerDetalleJugadorEquipo(equipo, jugador);
            JugadorEquipo = App.BaseDatos.ObtenerJugadorEquipo(equipo.ID, jugador.ID);
            Nuevo = nuevo;

            this.BindingContext = Detalle;
        }

        private void Guardar_Clicked(object sender, EventArgs e)
        {
            JugadorEquipo.Goles = Detalle.Goles;
            JugadorEquipo.Numero = Detalle.Numero;

            App.BaseDatos.ActualizarJugador(Jugador, Equipo);
            App.BaseDatos.ActualizarJugadorEquipo(JugadorEquipo);
        }
    }
}