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

        // crea una entidad sin casillero- posicion asignado
        public Entidad()
        {
            this.posicion = null;
        }

        public Entidad(Casillero posicion)
        {
            if(Tablero.GetInstancia().CasilleroFueraDeRango(posicion.Fila,posicion.Columna)) throw new CasilleroFueraDeRangoException();
            this.posicion = posicion;
        }

        public Casillero Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }
    }
}
