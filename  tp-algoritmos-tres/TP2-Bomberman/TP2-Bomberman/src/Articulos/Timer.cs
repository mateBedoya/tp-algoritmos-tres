using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Articulos
{
    public class Timer: Articulo
    {

        public Timer()
            :base() { }

        public Timer(Casillero posicion)
            : base(posicion) { }

        // Baja un 15% en el retardo de las bombas que lanza bombita
        public override void UtilizarArticuloEn(Personaje personaje)
        {
            personaje.PorcentajeDeRetardo = personaje.PorcentajeDeRetardo * 0.85;
            personaje.Bomba.RetardoAdquirido = personaje.Bomba.RetardoAdquirido * 0.85;
        }
    }
}
