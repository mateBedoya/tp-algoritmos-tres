using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.bombas;

namespace BoombermanGame.src.articulos
{
    public abstract class Articulo : Entidad
    {
        protected bool capturado;

        // crea un articulo
        public Articulo()
            : base()
        {
            this.capturado = false;
        }


        // crea un articulo
        public Articulo(Casilla posicion)
            : base(posicion)
        {
            this.capturado = false;
        }


        // implementacion de la interfaz IDestruible 
        public override bool FueDestruido()
        {
            return (this.capturado);
        }


        public override void Destruir()
        {

        }


        // implementacion de la interfaz IDaniable
        public override void DaniarPorMolotov(Molotov bomba)
        {
            this.capturado = true;
        }


        public override void DaniarPorProyectil(Proyectil bomba)
        {
            this.capturado = true;
        }


        public override void DaniarPorToletole(ToleTole bomba)
        {
            this.capturado = true;
        }


        // implementacion de los metodos abstractos heredados
        public override bool EsArticulo()
        {
            return true;
        }


        public override bool EsBomba()
        {
            return false;
        }


        public override bool EsObstaculo()
        {
            return false;
        }


        public override bool EsPersonaje()
        {
            return false;
        }


        public override bool EsBombita()
        {
            return false;
        }


        public override bool EsEnemigo()
        {
            return false;
        }


        public override bool PuedeSuperponerse()
        {
            return true;
        }


        // debe ser implementado por las clases derivadas
        public abstract void ModificarABombita();


        // metodo utilizado por el controlador
        public override void Actuar()
        {
            this.ModificarABombita();
        }
    }
}
