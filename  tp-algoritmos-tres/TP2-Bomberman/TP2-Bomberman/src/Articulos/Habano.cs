using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Articulos
{
    public class Habano: Articulo
    {

        public Habano()
            :base() { }

        public Habano(Casillero posicion)
            : base(posicion) { }

        //Aumenta en 5 la velocidad del personaje
        public override void UtilizarArticuloEn(Personaje personaje)
        {
            personaje.Velocidad = personaje.Velocidad + 5;
        }
    }
}
