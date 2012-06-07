using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Bombas;

namespace TP2_Bomberman.src.Articulos
{
    public class BombaToleTole : Articulo
    {
        public BombaToleTole()
            :base() { }

        public BombaToleTole(Casillero posicion)
            : base(posicion) { }

        public override void UtilizarArticuloEn(Personaje personaje)
        {
            personaje.Bomba = new ToleTole();
        }

    }
}
