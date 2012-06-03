using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    public class LopezR : Enemigo
    {
        public LopezR()
            :base()
        {
            this.resistencia = 10;
        }

        public LopezR(Casillero posicion)
            :base()
        {
            this.resistencia = 10;
            this.posicion = posicion;
        }
    }
}
