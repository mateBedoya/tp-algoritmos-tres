using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    interface IMovible
    {
        void MoverArriba();

        void MoverAbajo();

        void MoverDerecha();

        void MoverIzquierda();

        bool PuedeMoverseA(Casillero casilla);
    }
}
