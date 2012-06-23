using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Elementales;
using TP2.src.Juego.personajes;
using TP2.src.Elementales;

namespace TP2.src.juego.personajes
{
    public abstract class Enemigo : Personaje
    {
        // crea un enemigo
        public Enemigo(int resistencia, int velocidad)
            : base(resistencia, velocidad)
        { }


        // crea un enemigo
        public Enemigo(Casilla posicion, int resistencia, int velocidad)
            : base(posicion, resistencia, velocidad)
        { }


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


        // todo enemigo puede moverse si en la proxima posicioon esta bombita, 
        // si esta vacia o si hay un objeto que puede superponerse
        public override bool PuedeMoverseA(Casilla proximaPosicion)
        {
            int indice = 0;
            while (indice < proximaPosicion.CantidadDeEntidades())
            {
                Entidad entidad = proximaPosicion.GetEntidades()[indice];
                if (!entidad.PuedeSuperponerse() & !entidad.EsBombita())
                    return false;
                indice++;
            }
            return true;
        }
    }
}
