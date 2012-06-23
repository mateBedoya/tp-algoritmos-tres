using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.articulos;
using TP2.Elementales;
using TP2.src.interfaces;
using TP2.src.Juego.personajes;
using TP2.src.Juego.bombas;

namespace TP2.src.juego.articulos
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
