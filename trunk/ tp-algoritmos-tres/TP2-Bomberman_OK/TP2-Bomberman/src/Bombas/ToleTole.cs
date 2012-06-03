using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;

namespace TP2_Bomberman.src.Bombas
{
    public class ToleTole: Bomba
    {
        public ToleTole()
        { 
            this.destruccion = 10000;//Esto quiere decir que destruye todo
            this.retardo = 5;
            this.rango = 6;
        }

        public override void Explotar()
        {
            // Aca tendria que ir recorriendo y agarrando los elementos de cada casillero e ir daniandolos llamando a 
            // Dañar(elementoDelCasillero)
        }
        public override void Daniar(IDaniable daniable)
        {
            daniable.DaniarConToleTole(this); // Uso de patron doble dipatch
        }
    }
}
