using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.src
{
    class Personaje : Movible
    {
        protected int vida;
        protected int velocidad;
        protected Casillero posicion;

        public Personaje() 
        {
            this.velocidad = 5; // Único atributo compartido por todos los personajes.
        }

        public bool mover()
        {
            return true;
        }
    }
}
