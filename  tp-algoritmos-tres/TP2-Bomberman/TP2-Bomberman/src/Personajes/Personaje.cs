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
        protected double porcentajeDeRetardo = 1; //Empieza con un retardo normal de la bomba incorporada (100%)
        
        public Personaje()
            :base()
        {
            this.velocidad = 5; // Único atributo compartido por todos los personajes.
        }

        public Personaje(Casillero posicion)
            : base(posicion) 
        {
            posicion.Entidad = this;
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
            catch (MovimientoInvalidoException)
            {
                Entidad entidad = posicion.ObtenerCasilleroSuperiorDe(this.tablero).Entidad;
                entidad.Chocar(this);

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
            catch (MovimientoInvalidoException)
            {
                Entidad entidad = posicion.ObtenerCasilleroInferiorDe(this.tablero).Entidad;
                entidad.Chocar(this);

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
            catch (MovimientoInvalidoException)
            {
                Entidad entidad = posicion.ObtenerCasilleroDerechoDe(this.tablero).Entidad;
                entidad.Chocar(this);

            }
            
        }

        public void MoverIzquierda()
        {
            try
            {
                Casillero casilleroNuevo = posicion.ObtenerCasilleroIzquierdoDe(this.tablero);
                CambiarPosicionA(casilleroNuevo);
            }
            catch (CasilleroFueraDeRangoException)
            {

            }
            catch (MovimientoInvalidoException)
            {
                Entidad entidad = posicion.ObtenerCasilleroIzquierdoDe(this.tablero).Entidad;
                entidad.Chocar(this);

            }
            
        }


        public void CambiarPosicionA(Casillero casilleroNuevo)
        {

            if (!casilleroNuevo.EstaVacio())
            {
                throw new MovimientoInvalidoException();
            }
            posicion.Entidad = null;
            casilleroNuevo.Entidad = this;
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

        public double PorcentajeDeRetardo
        {
            get { return this.porcentajeDeRetardo; }
            set { this.porcentajeDeRetardo = value; }
        }

        
    }
}
