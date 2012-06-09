using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    // Interfaz para las clases que poseen la habilidad del movimiento
    public interface IMovible
    {
        void MoverArriba();

        void MoverAbajo();

        void MoverDerecha();

        void MoverIzquierda();

        bool PuedeMoverseA(Casillero nuevoCasillero);

    }
}
