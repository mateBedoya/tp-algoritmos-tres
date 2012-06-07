using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Personajes;


namespace TP2_Bomberman.src
{
    public abstract class Personaje : Entidad,IMovible,IDaniable,IDestruible
    {
        protected int resistencia;
        protected int velocidad;
        protected Bomba bomba;
        protected Tablero tablero;

        public Personaje()
            :base()
        {
            this.velocidad = 5; // Único atributo compartido por todos los personajes.
        }

        public Personaje(Casillero posicion)
            : base(posicion) 
        {
            posicion.Personaje = this;
            this.posicion = posicion;
        }

        
        //Metodos de movimiento
        public void MoverArriba()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroSuperiorDe(this.tablero));
            }
            catch(CasilleroFueraDeRangoException)
            {
                
            }
        }

        public void MoverAbajo()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroInferiorDe(this.tablero));
            }
            catch (CasilleroFueraDeRangoException)
            {
                
            }
            
        }

        public void MoverDerecha()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroDerechoDe(this.tablero));
            }
            catch (CasilleroFueraDeRangoException)
            {
                
            }
            
        }

        public void MoverIzquierda()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroIzquierdoDe(this.tablero));
            }
            catch (CasilleroFueraDeRangoException)
            {
                
            }
            
        }


        public void CambiarPosicionA(Casillero casilleroNuevo)
        {

            if (!casilleroNuevo.EstaVacio())
            {
                throw new MovimientoInvalidoException();
            }
            posicion.Personaje = PersonajeNull.GetInstancia();
            casilleroNuevo.Personaje = this;
            posicion = casilleroNuevo;
        }

        //Metodos abstractos a definir en los hijos
        public abstract void DaniarConMolotov(Molotov molotov);
        public abstract void DaniarConToleTole(Bombas.ToleTole toleTole);
        public abstract void DaniarConProyectil(Bombas.Proyectil proyectil);
        public abstract bool FueDestruido();


        //Propiedades
        public int Resistencia
        {
            get { return this.resistencia; }
        }

        public int Velocidad
        {
            get { return this.velocidad; }
            set { this.velocidad = value; }
        }

        public Bomba Bomba
        {
            get { return this.bomba;}
            set { this.bomba = value; }
        }

        public Tablero Tablero
        {
            get { return this.tablero; }
            set { this.tablero = value; }
        }
    }
}
