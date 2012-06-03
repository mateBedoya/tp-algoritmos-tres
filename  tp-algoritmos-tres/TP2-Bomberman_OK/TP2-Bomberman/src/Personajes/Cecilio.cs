using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    public class Cecilio : Enemigo
    {
        public Cecilio()
            :base()
        {
            this.resistencia = 5;
        }

        public Cecilio(Casillero posicion)
            :base()
        {
            this.resistencia = 5;
            this.posicion = posicion;
        }


    }
}
