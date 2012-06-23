using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Elementales;
using TP2.src.Juego.bombas;
using TP2.src.estrategias;
using TP2.src.juego.personajes;

namespace TP2.src.Juego.personajes
{
    public class LopezReggaeAlado : Enemigo
    {
        private static int RESISTENCIA_INICIAL = 5;
        private static int VELOCIDAD_INICIAL = 1;

        // inicializa los atributos
        private void Inicializar()
        {
            this.estrategiaDeLanzamiento = new LanzarMolotov(this);
        }


        // crea a Lopez Reggae Alado
        public LopezReggaeAlado()
            : base(RESISTENCIA_INICIAL, VELOCIDAD_INICIAL)
        {
            this.Inicializar();
        }


        // crea a Lopez Reggae Alado
        public LopezReggaeAlado(Casilla posicion)
            : base(posicion, RESISTENCIA_INICIAL, VELOCIDAD_INICIAL)
        {
            this.Inicializar();
        }


        // puede moverse siempre
        public override bool PuedeMoverseA(Casilla casilla)
        {
            return true;
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            if (this.direccion == ESTE)
                return ("LopezRAladoDerecha");
            if (this.direccion == NORTE)
                return ("LopezRAladoArriba");
            if (this.direccion == OESTE)
                return ("LopezRAladoIzquierda");
            return ("LopezRAladoAbajo");
        }
    }
}
