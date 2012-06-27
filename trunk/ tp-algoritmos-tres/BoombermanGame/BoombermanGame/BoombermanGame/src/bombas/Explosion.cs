using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;

namespace BoombermanGame.src.bombas
{
    public class Explosion : Entidad
    {
        private static int RETARDO = 50;
        private int retardo;

        // crea una explosion, producto del estallido de una bomba
        public Explosion()
            : base()
        {
            this.retardo = RETARDO;
        }


        // retorna si el tiempo para hacer danio, termino
        private bool PasoElTiempo()
        {
            if (this.retardo > 0)
                this.retardo--;
            return (this.retardo == 0);
        }


        // implementacion de los metodos abstractos heredados de la clase entidad
        public override bool FueDestruido()
        {
            return (this.PasoElTiempo());
        }

        public override void Destruir() { }


        public override void DaniarPorMolotov(Molotov molotov) { }


        public override void DaniarPorProyectil(Proyectil proyectil) { }


        public override void DaniarPorToletole(ToleTole toletole) { }


        public override bool EsArticulo()
        {
            return false;
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
            return false;
        }


        // metodo heredado de la interfaz IPosicionable
        public override string GetDescripcion()
        {
            return "Estallido";
        }
    }
}
