using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src;

namespace TP2_Bomberman
{
    class Bombita : Personaje
    {
        private static int RESISTENCIA = 1;

        // crea a bombita con una resistencia y posicion inicial dentro del tablero
        public Bombita(Casillero casilleroPosicion)
            : base(RESISTENCIA, casilleroPosicion)
        {   }

        // BORRAR COMENTARIO: agrego este constructor porque lo usan los tests, pero el que vale es el de arriba
        public Bombita()
            : base(RESISTENCIA)
        {   }


        public void LanzarBomba()
        {

        }
    }
}
