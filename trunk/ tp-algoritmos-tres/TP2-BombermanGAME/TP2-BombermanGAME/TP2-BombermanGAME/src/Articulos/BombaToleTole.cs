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

        // Hace que el personaje pueda tirar bombas tole tole hasta que se muera
        public override void UtilizarArticuloEn(Personaje personaje)
        {
            personaje.Bomba = new ToleTole();
            personaje.Bomba.Duenio = personaje;
            if (personaje.EsBombita())
            {
                Bombita bombita = (Bombita)personaje;
                bombita.PoseeBombaToleTole = true;
            }
        }

    }
}
