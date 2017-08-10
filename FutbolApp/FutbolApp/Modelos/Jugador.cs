using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace FutbolApp.Modelos
{
    public class Jugador
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nombre { get; set; }
        public string FechaNacimiento { get; set; } = DateTime.MinValue.ToString();
        public string Foto { get; set; }

        [ManyToMany(typeof(JugadorEquipo))]
        public List<Equipo> Equipos { get; set; }
    }
}