using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Articulos
{
    class Timer: Articulo
    {

        public Timer()
            :base() { }

        public Timer(Casillero posicion)
            : base(posicion) { }

        // Baja un 15% en el retardo de las bombas que lanza bombita
        public override void UtilizarArticuloEn(Bombita bombita)
        {
            bombita.PorcentajeDeRetardo = bombita.PorcentajeDeRetardo * 0.85;
        }
    }
}
