using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Elementales;


namespace TP2_Bomberman.src
{
    public class Casillero
    {
        protected int fila;
        protected int columna;
        private Entidad entidad;
        

        public Casillero(int x, int y)
        {
            this.fila = x;
            this.columna = y;
            this.entidad = null;
        }



        // retorna el casillero adyacente- derecha
        public virtual Casillero ObtenerCasilleroDerechoEn(Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila, this.columna + 1));
        }

        // retorna el casillero adyacente- superior 
        public virtual Casillero ObtenerCasilleroSuperiorEn(Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila - 1, this.columna));
        }

        // retorna el casillero adyacente- inferior
        public virtual Casillero ObtenerCasilleroInferiorEn(Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila + 1, this.columna));
        }

        // retorna el casillero adyacente- izquierda
        public virtual Casillero ObtenerCasilleroIzquierdoEn(Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila, this.columna - 1));
        }

        // retorna si esta vacio
        public virtual bool EstaVacio()
        {
            return (this.entidad == null);
        }

        public bool TienePersonaje()
        {
            if (entidad is Personaje) return true;
            return false;
        }



        //Properties
        public int Columna
        {
            get { return this.columna; }
        }

        public int Fila
        {
            get { return this.fila; }
        }

        public Entidad Entidad
        {
            get { return this.entidad; }
            set
            {
                this.entidad = value;
                if (value != null) value.Posicion = this;
            }
        }

    }
}
