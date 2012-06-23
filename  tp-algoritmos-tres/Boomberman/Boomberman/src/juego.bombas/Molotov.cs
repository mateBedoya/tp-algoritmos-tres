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
    public class Molotov : Bomba
    {
        private static int DANIO = 5;
        private static int RANGO = 3;
        private static double RETARDO = 200;
        private int danio;

        // crea una bomba molotov
        public Molotov()
            : base(RANGO, RETARDO)
        {
            this.danio = DANIO;
        }


        // crea una bomba molotov
        public Molotov(Casilla posicion)
            : base(posicion, RANGO, RETARDO)
        {
            this.danio = DANIO;
        }


        // retorna el danio que produce al explotar
        public int GetDanio()
        {
            return (this.danio);
        }


        // dania a las entidades pasadas
        public override void Daniar(List<Entidad> daniables)
        {
            int indice = 0;
            while (indice < daniables.Count())
            {
                IDaniable daniable = daniables[indice];
                daniable.DaniarPorMolotov(this);
                indice++;
            }
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "Molotov";
        }

    }
}
