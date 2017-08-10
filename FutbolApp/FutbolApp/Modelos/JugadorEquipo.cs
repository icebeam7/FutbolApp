using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace FutbolApp.Modelos
{
    public class JugadorEquipo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Equipo))]
        public int IDEquipo { get; set; }

        [ForeignKey(typeof(Jugador))]
        public int IDJugador { get; set; }

        public int Numero { get; set; }
        public int Goles { get; set; }
    }
}
