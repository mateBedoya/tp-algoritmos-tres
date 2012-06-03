using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Elementales;

namespace TP2_Bomberman.src
{
    public abstract class Bomba: Entidad
    {
        protected int destruccion;
        protected int retardo;
        protected int rango;

        public abstract void Explotar();
        public abstract void Daniar(IDaniable daniable);



        // Properties
        public int Destruccion
        {
            get { return this.destruccion; }
        }

        public int Retardo
        {
            get { return this.retardo; }
        }


        public int Rango
        {
            get { return this.rango; }
        }
    }
}
