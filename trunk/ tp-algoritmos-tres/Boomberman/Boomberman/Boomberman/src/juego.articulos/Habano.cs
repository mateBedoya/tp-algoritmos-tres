using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.articulos;
using TP2.Elementales;
using TP2.src.Juego.personajes;

namespace TP2.src.juego.articulos
{
    public class Habano : Articulo
    {

        // crea un articulo habano/chala
        public Habano()
            : base()
        { }


        // crea un articulo habano/chala
        public Habano(Casilla posicion)
            : base(posicion)
        { }


        // aumenta la velocidad de bombita
        public override void ModificarABombita()
        {
            Bombita bombita = Bombita.GetInstancia();
            if (!this.FueDestruido() & this.MismaPosicionQue(bombita))
            {
                bombita.AumentarVelocidad();
                this.capturado = true;
            }
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "Vacio";
        }
    }
}
