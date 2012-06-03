using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;


namespace TP2_Bomberman.src
{
    public abstract class Personaje : Entidad,IMovible,IDaniable,IDestruible
    {
        protected int resistencia;
        protected int velocidad;

        public Personaje()
        {
            this.velocidad = 5; // Único atributo compartido por todos los personajes.
        }

        
        //Metodos de movimiento
        public void MoverArriba()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroSuperior());
            }
            catch(CasilleroFueraDeRangoException)
            {
                
            }
        }

        public void MoverAbajo()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroInferior());
            }
            catch (CasilleroFueraDeRangoException)
            {
                
            }
            
        }

        public void MoverDerecha()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroDerecho());
            }
            catch (CasilleroFueraDeRangoException)
            {
                
            }
            
        }

        public void MoverIzquierda()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroIzquierdo());
            }
            catch (CasilleroFueraDeRangoException)
            {
                
            }
            
        }


        public void CambiarPosicionA(Casillero casilleroNuevo)
        {
            posicion.Personaje = null;
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
        }

    }
}
