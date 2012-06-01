using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Juego.obstaculos;
using TP2.Juego.bombas;
using TP2.Juego.articulos;

namespace TP2.Elementales
{
    public class Casilla
    {
        protected int fila;
        protected int columna;
        protected Personaje personaje;
        protected Obstaculo obstaculo;
        protected Bomba bomba;
        protected Articulo articulo;

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
        public virtual Casilla GetCasillaSuperior()
        { 
            return (Tablero.GetInstancia().GetCasilla(this.fila + 1, this.columna));
        }

        // retorna la casilla adyacente- inferior
        public virtual Casilla GetCasillaInferior()
        {
            return (Tablero.GetInstancia().GetCasilla(this.fila - 1, this.columna));
        }

        // retorna la casilla adyacente- derecha
        public virtual Casilla GetCasillaDerecha()
        {
            return (Tablero.GetInstancia().GetCasilla(this.fila, this.columna + 1));
        }

        // retorna la casilla adyacente- izquierda
        public virtual Casilla GetCasillaIzquierda()
        {
           return (Tablero.GetInstancia().GetCasilla(this.fila, this.columna - 1));  
        }

        // retorna las casillas adyacentes 
        public virtual List<Casilla> GetCasillasAdyacentes()
        {
            List<Casilla> casillasAdyacentes = new List<Casilla>();
            casillasAdyacentes.Add(this.GetCasillaSuperior());
            casillasAdyacentes.Add(this.GetCasillaInferior());
            casillasAdyacentes.Add(this.GetCasillaDerecha());
            casillasAdyacentes.Add(this.GetCasillaIzquierda());
            return (casillasAdyacentes);
        }

        // retorna si la casilla esta vacia
        public virtual bool EstaVacia()
        {
            return (this.personaje == PersonajeNull.GetInstancia() & 
                    this.obstaculo == ObstaculoNull.GetInstancia() &
                    this.bomba == BombaNull.GetInstancia() & 
                    this.articulo == ArticuloNull.GetInstancia());
        }

        // agrega un personaje a la casilla
        public virtual void AgregarPersonaje(Personaje personaje)
        {
            this.personaje = personaje;
        }

        // agrega un obstaculo a la casilla
        public virtual void AgregarObstaculo(Obstaculo obstaculo)
        {
            this.obstaculo = obstaculo;
        }

        // agrega una bomba a la casilla
        public virtual void AgregarBomba(Bomba bomba)
        {
            this.bomba = bomba;
        }

        // agrega un articulo a la casilla
        public virtual void AgregarArticulo(Articulo articulo)
        {
            this.articulo = articulo;
        }

        // retorna el personaje 
        public virtual Personaje GetPersonaje()
        {
            return (this.personaje);
        }

        // retorna el obstaculo
        public virtual Obstaculo GetObstaculo()
        {
            return (this.obstaculo);
        }

        // retorna la bomba 
        public virtual Bomba GetBomba()
        {
            return (this.bomba);
        }

        // retorna el articulo
        public virtual Articulo GetArticulo()
        {
            return (this.articulo);
        }
    }
}
