using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.bombas;
using TP2.Elementales;
using TP2.src.Interfaces;
using TP2.src.Elementales;

namespace TP2.src.Juego.bombas
{
    public class ToleTole : Bomba
    {
        private static int RANGO = 6;
        private static double RETARDO = 400;

        // crea una bomba tole tole
        public ToleTole()
            : base(RANGO, RETARDO)
        { }


        // crea una bomba tole tole
        public ToleTole(Casilla posicion)
            : base(posicion, RANGO, RETARDO)
        { }


        // dania a las entidades pasadas
        public override void Daniar(List<Entidad> daniables)
        {
            int indice = 0;
            while (indice < daniables.Count())
            {
                IDaniable daniable = daniables[indice];
                daniable.DaniarPorToletole(this);
                indice++;
            }
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "ToleTole";
        }
    }
}
