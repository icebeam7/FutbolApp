using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace FutbolApp.Modelos
{
    public class Equipo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nombre { get; set; }
        public string Escudo { get; set; }

        [ManyToMany(typeof(JugadorEquipo))]
        public List<Jugador> Jugadores { get; set; }
    }
}
