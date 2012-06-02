using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Elementales;
using TP2.Interfaces;

namespace TP2.Juego.personajes
{
    public abstract class Personaje: Entidad, Destruible
    {
        private static int VELOCIDAD_INICIAL = 5;
        protected int resistencia;
        protected int velocidad;

        // crea un personaje con una resistencia y velocidad inicial
        public Personaje(int resistencia)
            : base()
        {
            this.resistencia = resistencia;
            this.velocidad = VELOCIDAD_INICIAL;
        }

        // crea un personaje con una resistencia, velocidad inicial
        // y un casillero- posicion en el tablero
        public Personaje(int resistencia, Casillero casilleroPosicion)
            : base(casilleroPosicion)
        {
            this.resistencia = resistencia;
            this.velocidad = VELOCIDAD_INICIAL;
        }

        // un personaje es destruido cuando su resistencia es igual o menor a cero
        public bool FueDestruido()
        {
            return (this.resistencia <= 0);
        }
    }
}
