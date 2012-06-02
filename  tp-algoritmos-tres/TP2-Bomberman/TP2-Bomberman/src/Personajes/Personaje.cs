using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    class Personaje : IMovible
    {
        protected int vida;
        protected int velocidad;
        protected Casillero posicion;

        public Personaje()
        {
            this.velocidad = 5; // Único atributo compartido por todos los personajes.
        }

        public object Vida
        {
            get { return this.vida; }
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
