using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.src
{
    class Bombita
    {
        private int cantidadDeBombas;
        private int vida;
        private int velocidad;

        public Bombita(int cantidadDeBombas)
        {
            this.cantidadDeBombas = cantidadDeBombas;
            this.vida = 1;
            this.velocidad = 5;
        }

        public int CantidadDeBombas
        {
            get { return this.cantidadDeBombas;}
        }

        public void LanzarBomba()
        {
            this.cantidadDeBombas = this.cantidadDeBombas - 1;
        }

        public object Vida
        {
            get { return this.vida;}
        }

        public object Velocidad 
        {
            get { return this.velocidad ;} 
        }


    }
}
