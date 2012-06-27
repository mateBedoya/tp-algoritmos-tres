using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.personajes;

namespace BoombermanGame.src.articulos
{
    public class BombaToleTole : Articulo
    {
        // crea un articulo bomba tole tole
        public BombaToleTole()
            : base()
        { }


        // crea un articulo bomba tole tole
        public BombaToleTole(Casilla posicion)
            : base(posicion)
        { }


        // cambia la estrategia de lanzamiento de bombita
        public override void ModificarABombita()
        {
            Bombita bombita = Bombita.GetInstancia();
            if (!this.FueDestruido() & this.MismaPosicionQue(bombita))
            {
                bombita.CambiarAToleTole();
                this.capturado = true;
            }
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "BonusToleTole";
        }
    }
}
