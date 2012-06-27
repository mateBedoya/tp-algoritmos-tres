using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.bombas;
using BoombermanGame.src.personajes;

namespace BoombermanGame.src.articulos
{
    public class Salida : Articulo
    {
        // crea un articulo salida
        public Salida()
            : base()
        { }


        // crea un articulo salida
        public Salida(Casilla posicion)
            : base(posicion)
        { }


        // si esta activada, permitira a bombita avanzar de nivel
        public override void ModificarABombita()
        {
            Bombita bombita = Bombita.GetInstancia();
            if (!this.FueDestruido() & this.PuedeSuperponerse() & this.MismaPosicionQue(bombita))
            {
                bombita.EncontrarSalida();
                this.capturado = true;
            }
        }


        // puede tomarse solo si en el escenario no hay enemigos vivos
        public override bool PuedeSuperponerse()
        {
            return (Tablero.GetInstancia().CantidadDeEnemigos() == 0);
        }


        // la salida no puede ser daniada
        public override void DaniarPorMolotov(Molotov bomba) { this.capturado = false; }

        public override void DaniarPorProyectil(Proyectil bomba) { this.capturado = false; }

        public override void DaniarPorToletole(ToleTole bomba) { this.capturado = false; }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "Salida";
        }
    }
}
