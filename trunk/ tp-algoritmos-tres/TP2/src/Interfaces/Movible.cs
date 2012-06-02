using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Elementales;

namespace TP2.Interfaces
{
    public interface Movible
    {
        void MoverArriba();

        void MoverAbajo();

        void MoverDerecha();

        void MoverIzquierda();

        bool PuedeMoverseA(Casillero casilla);
    }
}
