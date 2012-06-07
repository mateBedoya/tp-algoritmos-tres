using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Elementales
{
    /// <summary>
    /// esta clase generaliza a todas las entidades que ocupan o pueden ocupar un
    /// lugar en el tablero como ser personajes, obstaculos, bombas y articulos
    /// </summary>
    public abstract class Entidad
    {
        protected Casillero posicion;
        protected Tablero tablero;

        // crea una entidad sin posicion asignada
        public Entidad()
        {
            this.posicion = null;
        }

        // crea una entidad con una posicion asignada
        public Entidad(Casillero posicion)
        {
            if(Tablero.GetInstancia().CasilleroFueraDeRango(posicion.Fila,posicion.Columna)) throw new CasilleroFueraDeRangoException();
            this.posicion = posicion;
        }

        public virtual void Chocar(Personaje personaje) { }

        // Propiedad Posicion
        public Casillero Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }

        public Tablero Tablero
        {
            get { return this.tablero; }
            set { this.tablero = value; }
        }
    }
}
