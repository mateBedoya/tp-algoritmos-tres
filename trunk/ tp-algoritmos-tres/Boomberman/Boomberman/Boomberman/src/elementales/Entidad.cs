using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Elementales;
using TP2.src.Interfaces;
using TP2.src.Juego.bombas;
using Boomberman.src.interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TP2.src.interfaces;
using Boomberman.src.vistas;

namespace TP2.src.Elementales
{
    public abstract class Entidad : IDaniable, IActuable, IPosicionable
    {
        protected static int[] ESTE = { 0, 1 };
        protected static int[] NORTE = { -1, 0 };
        protected static int[] OESTE = { 0, -1 };
        protected static int[] SUR = { 1, 0 };
        protected Casilla posicion;
        protected int[] direccion;


        // crea una entidad
        public Entidad()
        {
            this.direccion = ESTE;
            this.posicion = null;
        }


        // crea una entidad posicionada en una casilla
        public Entidad(Casilla posicion)
        {
            this.direccion = ESTE;
            this.PosicionarEn(posicion);
        }


        // retorna la posicion actual del objeto
        public Casilla Posicion()
        {
            return (this.posicion);
        }


        // posiciona al objeto en una nueva casilla
        public void PosicionarEn(Casilla posicion)
        {
            this.posicion = posicion;
            this.posicion.AgregarEntidad(this);
        }


        // cambia de direccion
        public void Direccionar(int[] direccion)
        {
            this.direccion = direccion;
        }


        // retorna la direccion actual
        public int[] Direccion()
        {
            return (this.direccion);
        }


        // retorna si esta en la misma posicion que la entidad pasada
        public bool MismaPosicionQue(Entidad entidad)
        {
            return (this.posicion == entidad.Posicion());
        }


        // cada clase derivada debe implementar estos metodos heredados de las interfaces
        public abstract bool FueDestruido();
        public abstract void Destruir();
        public abstract void DaniarPorMolotov(Molotov molotov);
        public abstract void DaniarPorProyectil(Proyectil proyectil);
        public abstract void DaniarPorToletole(ToleTole toletole);


        // metodos abstractos
        public abstract bool EsArticulo();
        public abstract bool EsBomba();
        public abstract bool EsObstaculo();
        public abstract bool EsPersonaje();
        public abstract bool EsBombita();
        public abstract bool EsEnemigo();
        public abstract bool PuedeSuperponerse();


        // implementacion de la interfaz IActuable
        public virtual void Actuar() { }

        public bool EstaVivo()
        {
            return (!this.FueDestruido());
        }


        // implementacion de la interfaz IPosicionable
        public virtual int X()
        {
            return (this.posicion.GetX());
        }


        public virtual int Y()
        {
            return (this.posicion.GetY());
        }


        public bool DejaDePosisionarse()
        {
            return (this.FueDestruido());
        }


        public abstract string GetDescripcion();
       
    }
}
