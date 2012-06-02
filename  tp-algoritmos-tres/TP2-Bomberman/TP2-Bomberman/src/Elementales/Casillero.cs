using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    class Casillero
    {
        protected int fila;
        protected int columna;
        private Personaje personaje;

        public Casillero(int x, int y)
        {
            this.fila = x;
            this.columna = y;
            this.personaje = null;
        }

        public int Columna
        {
            get { return this.columna; }
        }

        public int Fila
        {
            get { return this.fila; }
        }

        public Personaje Personaje 
        {
            get {return this.personaje ;}
            set {this.personaje = value ;} 
        }

        // retorna el casillero adyacente- derecha
        public virtual Casillero ObtenerCasilleroDerecho()
        {
            return (Tablero.GetInstancia().ObtenerCasillero(this.fila, this.columna + 1));
        }

        // retorna el casillero adyacente- superior 
        public virtual Casillero ObtenerCasilleroSuperior()
        {
            return (Tablero.GetInstancia().ObtenerCasillero(this.fila - 1, this.columna));
        }

        // retorna el casillero adyacente- inferior
        public virtual Casillero ObtenerCasilleroInferior()
        {
            return (Tablero.GetInstancia().ObtenerCasillero(this.fila + 1, this.columna));
        }

        // retorna el casillero adyacente- izquierda
        public virtual Casillero ObtenerCasilleroIzquierda()
        {
            return (Tablero.GetInstancia().ObtenerCasillero(this.fila, this.columna - 1));
        }

    }
}
