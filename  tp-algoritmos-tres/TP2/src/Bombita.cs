using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.src
{
    class Bombita: Movible
    {
        private int cantidadDeBombas;
        private int vida;
        private int velocidad;
        private Casillero posicion;

        public Bombita(int cantidadDeBombas)
        {
            this.cantidadDeBombas = cantidadDeBombas;
            this.vida = 1;
            this.velocidad = 5;
            this.posicion = new Casillero(0, 0); //Que bombita empiece siempre en el casillero 0,0
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

        public object Columna
        {
            get { return this.posicion.Columna; }
        }

        public object Fila
        {
            get { return this.posicion.Fila; }
        }


        public bool mover()
        {
            return true;
        }
    }
}
