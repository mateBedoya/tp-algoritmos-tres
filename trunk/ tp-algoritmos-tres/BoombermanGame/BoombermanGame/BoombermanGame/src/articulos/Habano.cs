using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.personajes;

namespace BoombermanGame.src.articulos
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
            return "BonusHabano";
        }
    }
}
