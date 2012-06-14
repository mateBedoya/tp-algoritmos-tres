using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Articulos
{
    public class Salida : Articulo
    {
        public Salida()
            : base() { }

        public Salida(Casillero posicion)
            : base(posicion) { }

        // Se termina el nivel cuando se lo "agarra". Esto sucede si ya no quedan mas enemigos en el tablero
        public override void UtilizarArticuloEn(Personaje personaje)
        {
            if (tablero.CantidadEnemigosVivos() == 0) tablero.avanzarNivel();
        }

        //La salida NUNCA puede ser destruida
        public override bool FueDestruido() { return false; }



    }
}
