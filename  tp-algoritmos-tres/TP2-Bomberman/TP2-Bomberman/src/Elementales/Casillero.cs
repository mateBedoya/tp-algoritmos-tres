﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Personajes;


namespace TP2_Bomberman.src
{
    public class Casillero
    {
        protected int fila;
        protected int columna;
        private Personaje personaje; // Aca tiene todo lo que podria contener
        private Obstaculo obstaculo;
        private Bomba bomba;
        private Articulo articulo;
        

        public Casillero(int x, int y)
        {
            this.fila = x;
            this.columna = y;
            this.personaje = PersonajeNull.GetInstancia();
            this.obstaculo = ObstaculoNull.GetInstancia();
            this.bomba = BombaNull.GetInstancia();
            this.articulo = ArticuloNull.GetInstancia();
        }



        // retorna el casillero adyacente- derecha
        public virtual Casillero ObtenerCasilleroDerechoDe(Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila, this.columna + 1));
        }

        // retorna el casillero adyacente- superior 
        public virtual Casillero ObtenerCasilleroSuperiorDe(Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila - 1, this.columna));
        }

        // retorna el casillero adyacente- inferior
        public virtual Casillero ObtenerCasilleroInferiorDe(Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila + 1, this.columna));
        }

        // retorna el casillero adyacente- izquierda
        public virtual Casillero ObtenerCasilleroIzquierdoDe(Tablero tablero)
        {
            return (tablero.ObtenerCasillero(this.fila, this.columna - 1));
        }

        // retorna si esta vacio
        public virtual bool EstaVacio()
        {
            return (this.articulo == ArticuloNull.GetInstancia() &
                    this.bomba == BombaNull.GetInstancia() &
                    this.obstaculo == ObstaculoNull.GetInstancia() &
                    this.personaje == PersonajeNull.GetInstancia());
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

        public Personaje Personaje 
        {
            get {return this.personaje ;}
            set 
            {
                this.personaje = value;
                if (value!=null) value.Posicion = this;
            } 
        }

        public Obstaculo Obstaculo
        {
            get { return this.obstaculo; }
            set 
            {
                this.obstaculo = value;
                if (value != null) value.Posicion = this;
            } 
        }

        public Bomba Bomba
        {
            get { return this.bomba; }
            set
            {
                this.bomba = value;
                if (value != null) value.Posicion = this;
            }
        }

        public Articulo Articulo
        {
            get { return this.articulo; }
            set
            {
                this.articulo = value;
                if (value != null) value.Posicion = this;
            }
        }

    }
}