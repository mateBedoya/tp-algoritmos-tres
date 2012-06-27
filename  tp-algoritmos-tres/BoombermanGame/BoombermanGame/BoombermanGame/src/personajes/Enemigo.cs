using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.interfaces;
using BoombermanGame.src.estrategias;

namespace BoombermanGame.src.personajes
{
    public abstract class Enemigo : Personaje
    {
        private IEstrategia inteligencia;

        // asigna la IA
        private void Inicializar()
        {
            this.inteligencia = new IAEnemigos(this);
        }

        // crea un enemigo
        public Enemigo(int resistencia, int velocidad)
            : base(resistencia, velocidad)
        {
            this.Inicializar();
        }


        // crea un enemigo
        public Enemigo(Casilla posicion, int resistencia, int velocidad)
            : base(posicion, resistencia, velocidad)
        {
            this.Inicializar();
        }


        // retorna que no es bombita
        public override bool EsBombita()
        {
            return false;
        }


        // retorna que es enemigo
        public override bool EsEnemigo()
        {
            return true;
        }


        // dania a bombita si es que bombita esta en su misma posicion
        public void DaniarABombita()
        {
            Bombita bombita = Bombita.GetInstancia();
            if (this.MismaPosicionQue(bombita))
                bombita.SerDaniadoPorEnemigo();
        }


        // metodo utilizado por el controlador
        public override void Actuar()
        {
            this.inteligencia.Aplicar();
        }
    }
}
