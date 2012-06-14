using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Articulos;

namespace TP2_Bomberman.src.Obstaculos
{
    public class BloqueDeLadrillos: Obstaculo
    {
        public BloqueDeLadrillos()
            :base()
        {
            this.resistencia = 5;
        }

        public BloqueDeLadrillos(Casillero posicion)
            : base(posicion)
        {
            this.resistencia = 5;
        }


        internal override void AgregarArticulo(Articulo articulo)
        {
            this.articulo = articulo;
        }
        
    }
}
