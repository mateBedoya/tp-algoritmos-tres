using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.src
{
    class Bombita: Personaje
    {
        private int vida;
        private int velocidad;
        private Casillero posicion;

        public Bombita()
        {
            this.vida = 1;
            this.velocidad = 5;
            this.posicion = new Casillero(0, 0); //Que bombita empiece siempre en el casillero 0,0
        }


        public void LanzarBomba()
        {
            
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



    }
}
