using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using SQLite.Net.Interop;
using FutbolApp.Modelos;
using SQLiteNetExtensions.Extensions;
using FutbolApp.Clases;

namespace FutbolApp.Datos
{
    public class BaseDatos
    {
        static object locker = new object();
        readonly ISQLitePlatform _plataforma;
        string _rutaBD;

        public SQLiteConnection Conexion { get; set; }

        public BaseDatos(ISQLitePlatform plataforma, string rutaBD)
        {
            _plataforma = plataforma;
            _rutaBD = rutaBD;
        }

        public void Conectar()
        {
            Conexion = new SQLiteConnection(_plataforma, _rutaBD, 
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create 
                | SQLiteOpenFlags.FullMutex, true);

            Conexion.CreateTable<Jugador>();
            Conexion.CreateTable<Equipo>();
            Conexion.CreateTable<JugadorEquipo>();
        }

        #region Metodos de la tabla Jugador

        public void AgregarJugador(Jugador jugador, Equipo equipo = null)
        {
            lock(locker)
            {
                Conexion.Insert(jugador);
            }
        }

        public void ActualizarJugador(Jugador jugador, Equipo equipo = null)
        {
            lock (locker)
            {
                Conexion.Update(jugador);

                if (equipo != null)
                {
                    if (jugador.Equipos == null)
                    {
                        jugador.Equipos = new List<Equipo>();
                    }

                    if (jugador.Equipos.Where(x => x.ID == equipo.ID).Count() == 0)
                        jugador.Equipos.Add(equipo);

                    Conexion.UpdateWithChildren(jugador);
                }
            }
        }

        public void EliminarJugador(Jugador jugador)
        {
            lock (locker)
            {
                Conexion.Delete(jugador);
            }
        }

        public List<Jugador> ObtenerJugadores()
        {
            lock (locker)
            {
                return Conexion.GetAllWithChildren<Jugador>().OrderBy(x => x.Nombre).ToList();
            }
        }

        public Jugador ObtenerJugador(int id)
        {
            lock (locker)
            {
                return Conexion.GetWithChildren<Jugador>(id);
            }
        }

        public List<Equipo> ObtenerEquiposJugador(int id)
        {
            lock (locker)
            {
                return Conexion.GetWithChildren<Jugador>(id).Equipos;
            }
        }

        #endregion

        #region Metodos de la tabla Equipo
        public void AgregarEquipo(Equipo equipo)
        {
            lock (locker)
            {
                Conexion.Insert(equipo);
            }
        }

        public void ActualizarEquipo(Equipo equipo)
        {
            lock (locker)
            {
                Conexion.Update(equipo);
            }
        }

        public void EliminarEquipo(Equipo equipo)
        {
            lock (locker)
            {
                Conexion.Delete(equipo);
            }
        }

        public List<Equipo> ObtenerEquipos()
        {
            lock (locker)
            {
                return Conexion.GetAllWithChildren<Equipo>().OrderBy(x => x.Nombre).ToList();
            }
        }

        public Equipo ObtenerEquipo(int id)
        {
            lock (locker)
            {
                return Conexion.GetWithChildren<Equipo>(id);
            }
        }

        public List<Jugador> ObtenerJugadoresEquipo(int id)
        {
            lock (locker)
            {
                return Conexion.GetWithChildren<Equipo>(id).Jugadores;
            }
        }
        #endregion

        #region Metodos de la tabla JugadorEquipo
        public JugadorEquipo ObtenerJugadorEquipo(int idEquipo, int idJugador)
        {
            lock(locker)
            {
                var tabla = Conexion.Table<JugadorEquipo>().ToList();
                var num = tabla.Where(x => x.IDEquipo == idEquipo && x.IDJugador == idJugador).Count();

                if (num > 0)
                    return tabla.Where(x => x.IDEquipo == idEquipo && x.IDJugador == idJugador).First();
                else
                    return new JugadorEquipo() { IDEquipo = idEquipo, IDJugador = idJugador, Goles = 0, Numero = 0 };
            }
        }

        public DetalleJugadorEquipo ObtenerDetalleJugadorEquipo(Equipo equipo, Jugador jugador)
        {
            lock (locker)
            {
                var jugadorEquipo = ObtenerJugadorEquipo(equipo.ID, jugador.ID);

                var detalle = new DetalleJugadorEquipo()
                {
                    NombreJugador = jugador.Nombre,
                    FotoJugador = jugador.Foto,
                    NombreEquipo = equipo.Nombre,
                    EscudoEquipo = equipo.Escudo,
                    Goles = (jugadorEquipo != null) ? jugadorEquipo.Goles : 0,
                    Numero = (jugadorEquipo != null) ? jugadorEquipo.Numero : 0
                };

                return detalle;
            }
        }

        public void ActualizarJugadorEquipo(JugadorEquipo jugadorEquipo)
        {
            lock (locker)
            {
                Conexion.Update(jugadorEquipo);
            }
        }
        #endregion
    }
}
