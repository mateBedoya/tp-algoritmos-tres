using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.src
{
    class Bombita: Personaje
    {

        public Bombita()
        {
            this.vida = 1;
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
