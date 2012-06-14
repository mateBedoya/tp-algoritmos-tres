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
            :base()
        { 
            this.destruccion = 100000;//Esto quiere decir que destruye todo
            this.retardo = 5;
            this.rango = 6;
        }

        public ToleTole(Casillero posicion)
            : base(posicion)
        {
            this.destruccion = 100000;//Esto quiere decir que destruye todo
            this.retardo = 5;
            this.rango = 6;
        }

        // Uso del patron double dispatch. Se redefinio el metodo danias y se 
        // dania con el toleTole segun le corresponda al daniable
        public override void Daniar(IDaniable daniable)
        {
            daniable.DaniarConToleTole(this); 
        }

    }
}
