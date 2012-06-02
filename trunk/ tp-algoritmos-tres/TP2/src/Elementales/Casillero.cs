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

    public class Casillero
    {
        protected int fila;
        protected int columna;
        protected Personaje personaje;
        protected Obstaculo obstaculo;
        protected Bomba bomba;
        protected Articulo articulo;

        // crea un casillero vacio con una posicion en el tablero
        public Casillero(int fila, int columna)
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

        // retorna el casillero adyacente- superior 
        public virtual Casillero GetCasilleroSuperior()
        { 
            return (Tablero.GetInstancia().GetCasillero(this.fila + 1, this.columna));
        }

        // retorna el casillero adyacente- inferior
        public virtual Casillero GetCasilleroInferior()
        {
            return (Tablero.GetInstancia().GetCasillero(this.fila - 1, this.columna));
        }

        // retorna el casillero adyacente- derecha
        public virtual Casillero GetCasilleroDerecha()
        {
            return (Tablero.GetInstancia().GetCasillero(this.fila, this.columna + 1));
        }

        // retorna el casillero adyacente- izquierda
        public virtual Casillero GetCasilleroIzquierda()
        {
           return (Tablero.GetInstancia().GetCasillero(this.fila, this.columna - 1));  
        }

        // retorna los casilleros adyacentes 
        public virtual List<Casillero> GetCasillerosAdyacentes()
        {
            List<Casillero> casillerosAdyacentes = new List<Casillero>();
            casillerosAdyacentes.Add(this.GetCasilleroSuperior());
            casillerosAdyacentes.Add(this.GetCasilleroInferior());
            casillerosAdyacentes.Add(this.GetCasilleroDerecha());
            casillerosAdyacentes.Add(this.GetCasilleroIzquierda());
            return (casillerosAdyacentes);
        }

        // retorna si el casillero esta vacia
        public virtual bool EstaVacio()
        {
            return (this.personaje == PersonajeNull.GetInstancia() & 
                    this.obstaculo == ObstaculoNull.GetInstancia() &
                    this.bomba == BombaNull.GetInstancia() & 
                    this.articulo == ArticuloNull.GetInstancia());
        }

        // agrega un personaje al casillero
        public virtual void AgregarPersonaje(Personaje personaje)
        {
            this.personaje = personaje;
        }

        // agrega un obstaculo al casillero
        public virtual void AgregarObstaculo(Obstaculo obstaculo)
        {
            this.obstaculo = obstaculo;
        }

        // agrega una bomba al casillero
        public virtual void AgregarBomba(Bomba bomba)
        {
            this.bomba = bomba;
        }

        // agrega un articulo al casillero
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
