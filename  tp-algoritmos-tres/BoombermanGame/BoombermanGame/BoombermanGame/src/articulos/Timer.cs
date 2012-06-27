using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.personajes;

namespace BoombermanGame.src.articulos
{
    public class Timer : Articulo
    {
        private static double REDUCCION = 0.85;

        // crea un articulo timer
        public Timer()
            : base()
        { }


        // crea un articulo timer
        public Timer(Casilla posicion)
            : base(posicion)
        { }


        // reduce el retardo de las bombas que coloca el modificable
        public override void ModificarABombita()
        {
            Bombita bombita = Bombita.GetInstancia();
            if (!bombita.FueDestruido() & this.MismaPosicionQue(bombita))
            {
                bombita.ReducirRetardo(REDUCCION);
                this.capturado = true;
            }
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "BonusTimer";
        }
    }
}
