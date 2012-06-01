using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Juego.obstaculos;
using TP2.Juego.bombas;
using TP2.Juego.articulos;
using TP2.Excepciones;

namespace TP2.Elementales
{
    public class Casilla
    {
        private int fila;
        private int columna;
        private Personaje personaje;
        private Obstaculo obstaculo;
        private Bomba bomba;
        private Articulo articulo;

        // crea una casilla vacia con una posicion en el tablero
        public Casilla(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
            this.personaje = PersonajeNull.GetInstancia();
            this.obstaculo = ObstaculoNull.GetInstancia();
            this.bomba = BombaNull.GetInstancia();
            this.articulo = ArticuloNull.GetInstancia();
        }

        // retorna la fila que ocupa en el tablero
        public int GetFila()
        {
            return (this.fila);
        }

        // retorna la columna que ocupa en el tablero
        public int GetColumna()
        {
            return (this.columna);
        }

        // retorna la casilla adyacente- superior 
        public Casilla GetCasillaSuperior()
        { 
            return (Tablero.GetInstancia().GetCasilla(this.fila + 1, this.columna));
        }

        // retorna la casilla adyacente- inferior
        public Casilla GetCasillaInferior()
        {
            return (Tablero.GetInstancia().GetCasilla(this.fila - 1, this.columna));
        }

        // retorna la casilla adyacente- derecha
        public Casilla GetCasillaDerecha()
        {
            return (Tablero.GetInstancia().GetCasilla(this.fila, this.columna + 1));
        }

        // retorna la casilla adyacente- izquierda
        public Casilla GetCasillaIzquierda()
        {
           return (Tablero.GetInstancia().GetCasilla(this.fila, this.columna - 1));  
        }

        // retorna si la casilla esta vacia
        public bool EstaVacia()
        {
            return (this.personaje == PersonajeNull.GetInstancia() & 
                    this.obstaculo == ObstaculoNull.GetInstancia() &
                    this.bomba == BombaNull.GetInstancia() & 
                    this.articulo == ArticuloNull.GetInstancia());
        }
    }
}
