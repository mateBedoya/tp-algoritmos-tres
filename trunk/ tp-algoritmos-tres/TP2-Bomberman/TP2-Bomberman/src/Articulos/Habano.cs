using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Articulos
{
    class Habano: Articulo
    {

        public Habano()
            :base() { }

        public Habano(Casillero posicion)
            : base(posicion) { }

        //Aumenta en 5 la velocidad de bombita
        public override void UtilizarArticuloEn(Bombita bombita)
        {
            bombita.Velocidad = bombita.Velocidad + 5;
        }
    }
}
