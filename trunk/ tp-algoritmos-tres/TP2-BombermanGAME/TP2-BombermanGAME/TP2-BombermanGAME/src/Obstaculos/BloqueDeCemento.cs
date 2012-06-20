using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Articulos;

namespace TP2_Bomberman.src.Obstaculos
{
    public class BloqueDeCemento: Obstaculo
    {
        public BloqueDeCemento()
            :base()
        {
            this.resistencia = 10;
        }
        public BloqueDeCemento(Casillero posicion)
            : base(posicion)
        {
            this.resistencia = 10;
        }


        internal override void AgregarArticulo(Articulo articulo)
        {
            this.articulo = articulo;
        }


    }
}
