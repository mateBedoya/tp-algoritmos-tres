using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.Fisica
{
    public class ModeloFisicoPersonaje : ModeloFisicoEstandar
    {
        private static double RADIO = 3;

        // crea un modelo fisico para un personaje
        public ModeloFisicoPersonaje()
            : base(new Circulo(RADIO))
        { }

        // crea un modelo fisico para un personaje con una posicion
        public ModeloFisicoPersonaje(Punto posicion)
            : base(new Circulo(RADIO, posicion))
        { }
    }
}
