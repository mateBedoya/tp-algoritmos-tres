using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Articulos
{
    class Salida : Articulo
    {
        public Salida()
            : base() { }

        public Salida(Casillero posicion)
            : base(posicion) { }


        public override void UtilizarArticuloEn(Personaje personaje)
        {
            if (tablero.CantidadEnemigosVivos() == 0) tablero.avanzarNivel();
        }

        public override bool FueDestruido() { return false; }



    }
}
