using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src;
using BoombermanGame.src.interfaces;
using BoombermanGame.src.bombas;
using System.Xml.Serialization;
using BoombermanGame.src.personajes;
using BoombermanGame.src.obstaculos;
using BoombermanGame.src.articulos;

namespace BoombermanGame.src.elementales
{
    [Serializable]
    [XmlInclude(typeof(Bombita))]
    [XmlInclude(typeof(Cecilio))]
    [XmlInclude(typeof(LopezReggae))]
    [XmlInclude(typeof(LopezReggaeAlado))]
    [XmlInclude(typeof(ObstaculoDeAcero))]
    [XmlInclude(typeof(ObstaculoDeCemento))]
    [XmlInclude(typeof(ObstaculoDeLadrillo))]
    [XmlInclude(typeof(Molotov))]
    [XmlInclude(typeof(Proyectil))]
    [XmlInclude(typeof(ToleTole))]
    [XmlInclude(typeof(BombaToleTole))]
    [XmlInclude(typeof(Habano))]
    [XmlInclude(typeof(Salida))]
    [XmlInclude(typeof(Timer))]
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
            return (this.posicion.X);
        }


        public virtual int Y()
        {
            return (this.posicion.Y);
        }


        public bool DejaDePosisionarse()
        {
            return (this.FueDestruido());
        }


        public abstract string GetDescripcion();

        public Casilla PosicionActual
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }
    }
}
