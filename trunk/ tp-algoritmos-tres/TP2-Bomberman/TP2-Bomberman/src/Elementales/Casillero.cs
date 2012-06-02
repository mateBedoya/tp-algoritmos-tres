using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Bombas;

namespace TP2_Bomberman.src
{
    public class Casillero
    {
        protected int fila;
        protected int columna;
        private Personaje personaje;
        private Obstaculo obstaculo;
        private Bomba bomba;
        private Articulo articulo;

        // crea una casilla con posicion en el tablero y vacia
        public Casillero(int x, int y)
        {
            this.fila = x;
            this.columna = y;
            this.personaje = PersonajeNull.GetInstancia();
            this.obstaculo = ObstaculoNull.GetInstancia();
            this.bomba = BombaNull.GetInstancia();
            this.articulo = ArticuloNull.GetInstancia();
        }

        // getters y setters
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

        // retorna el casillero adyacente- derecho
        public virtual Casillero ObtenerCasilleroDerecho()
        {
            return (Tablero.GetInstancia().GetCasillero(this.fila, this.columna + 1));
        }

        // retorna el casillero adyacente- superior 
        public virtual Casillero ObtenerCasilleroSuperior()
        {
            return (Tablero.GetInstancia().GetCasillero(this.fila - 1, this.columna));
        }

        // retorna el casillero adyacente- inferior
        public virtual Casillero ObtenerCasilleroInferior()
        {
            return (Tablero.GetInstancia().GetCasillero(this.fila + 1, this.columna));
        }

        // retorna el casillero adyacente- izquierdo
        public virtual Casillero ObtenerCasilleroIzquierdo()
        {
            return (Tablero.GetInstancia().GetCasillero(this.fila, this.columna - 1));
        }

        // retorna los casilleros adyacentes 
        public virtual List<Casillero> ObtenerCasillerosAdyacentes()
        {
            List<Casillero> casillerosAdyacentes = new List<Casillero>();
            casillerosAdyacentes.Add(this.ObtenerCasilleroSuperior());
            casillerosAdyacentes.Add(this.ObtenerCasilleroInferior());
            casillerosAdyacentes.Add(this.ObtenerCasilleroDerecho());
            casillerosAdyacentes.Add(this.ObtenerCasilleroIzquierdo());

            return casillerosAdyacentes;
        }

        // agrega un personaje
        public virtual void AgregarPersonaje(Personaje personaje) {
            this.personaje = personaje;
        }

        // agrega un obstaculo
        public virtual void AgregarObstaculo(Obstaculo obstaculo) {
            this.obstaculo = obstaculo;    
        }

        // agrega una bomba
        public virtual void AgregarBomba(Bomba bomba) {
            this.bomba = bomba;
        }

        // agrega un articulo
        public virtual void AgregarArticulo(Articulo articulo) { }

        // retorna el personaje 
        public virtual Personaje GetPersonaje()
        {
            return (this.personaje);
        }

        // retorna el obstaculo nulo
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

        // retorna si esta vacio
        public virtual bool EstaVacio()
        {
            return (this.articulo == ArticuloNull.GetInstancia() &
                    this.bomba == BombaNull.GetInstancia() &
                    this.obstaculo == ObstaculoNull.GetInstancia() &
                    this.personaje == PersonajeNull.GetInstancia());
        }
    }
}
