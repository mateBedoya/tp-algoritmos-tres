using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    public class Enemigo : Personaje
    {
        private static int RESISTENCIA = 5;

        public Enemigo()
            : base(RESISTENCIA)
        { }
            
    }
}
