using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Elementales;

namespace TP2_Bomberman.src
{
    public abstract class Personaje : Entidad, IMovible, IDestruible
    {
        private int VELOCIDAD_INICIAL = 5; //BORRAR ESTE COMENTARIO: esto es para inicializar atributos con valores, para si despues
        //se quiere cambiar el valor asignado, no tocas el constructor o el codigo, tocas este valor y listo!!!
        protected int resistencia;
        protected int velocidad;

        // se crea un personaje con una resistencia y velocidad inicial
        public Personaje(int resistencia)
            : base()
        {
            this.resistencia = resistencia;
            this.velocidad = VELOCIDAD_INICIAL;
        }

        // se crea un personaje con una resistencia y velocidad inicial
        // y su casillero- posicion en el tablero
        public Personaje(int resistencia, Casillero casilleroPosicion)
            : base(casilleroPosicion)
        {
            this.resistencia = resistencia;
            this.velocidad = VELOCIDAD_INICIAL;
        }

        // retorna la resistencia actual
        public object Resistencia
        {
            get { return this.resistencia; }
        }

        // un personaje es destruido cuando su resistencia es menor o igual a 0
        public virtual bool FueDestruido()
        {
            return (this.resistencia <= 0);
        }

        // retorna la velocidad
        public virtual int GetVelocidad()
        {
            return (this.velocidad);
        }


        public void MoverArriba()
        {
            
        }

        public void MoverAbajo()
        {
           
        }

        public void MoverDerecha()
        {
            
        }

        public void MoverIzquierda()
        {
            
        }

        public bool PuedeMoverseA(Casillero casilla)
        {
            return true;
        }
    }
}
