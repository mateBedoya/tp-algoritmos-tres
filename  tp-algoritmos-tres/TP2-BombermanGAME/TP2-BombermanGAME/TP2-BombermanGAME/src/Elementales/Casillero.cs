using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Elementales;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TP2_Bomberman.src
{
    public class Casillero
    {
        public Vector2 posicionEnVentana;
        public Texture2D textura;
        protected int fila;
        protected int columna;
        private Entidad entidad; 
        

        public Casillero(int x, int y)
        {
            this.fila = x;
            this.columna = y;
            this.entidad = null;
        }

        // retorna la casilla adyacente en la direccion pasada
        public virtual Casillero ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(int[] direccion, Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila + direccion[0], this.columna + direccion[1]));
        }

        // retorna si esta vacio
        public virtual bool EstaVacio()
        {
            return (this.entidad == null);
        }

        //Devuelve si su entidad es un personaje
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
