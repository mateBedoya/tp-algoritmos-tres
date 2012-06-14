using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.src
{
    public class Molotov: Bomba
    {
        public Molotov()
            :base()
        { 
            this.destruccion = 5;
            this.retardo = 1;
            this.rango = 3;
        }

        public Molotov(Casillero posicion)
            : base(posicion)
        {
            this.destruccion = 5;
            this.retardo = 1;
            this.rango = 3;
        }

        // Uso del patron double dispatch. Se redefinio el metodo danias y se 
        // dania con la molotov segun le corresponda al daniable
        public override void Daniar(IDaniable daniable)
        {
            daniable.DaniarConMolotov(this);
        }


    }
}
