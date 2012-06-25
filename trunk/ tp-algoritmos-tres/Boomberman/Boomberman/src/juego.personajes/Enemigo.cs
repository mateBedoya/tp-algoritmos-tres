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
        private int contadorDeCiclos = 0;

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
                if (!entidad.PuedeSuperponerse() /*& !entidad.EsBombita()*/)
                    return false;
                indice++;
            }
            return true;
        }

        public override void Actuar()
        {
            Casilla posicionActual = this.Posicion();
            if ((contadorDeCiclos >= (30 - this.Velocidad())) &&
                (contadorDeCiclos % (30 - this.Velocidad()) == 0))
            {
                Random rand = new Random();
                int direccion = rand.Next(4);
                if(BombitaEstaCerca()) LanzarExplosivo();
                switch (direccion)
                {
                    case 0:
                        MoverAlEste();
                        contadorDeCiclos++;
                        return;
                    case 1:
                        MoverAlOeste();
                        contadorDeCiclos++;
                        return;
                    case 2:
                        MoverAlNorte();
                        contadorDeCiclos++;
                        return;
                    case 3:
                        MoverAlSur();
                        contadorDeCiclos++;
                        return;
                }
                
            }
            contadorDeCiclos++;
        }

        private bool BombitaEstaCerca()
        {
            Casilla posicionBombita = Bombita.GetInstancia().Posicion();
            if ((Math.Abs(posicionBombita.X - this.posicion.X) <= 6) & (Math.Abs(posicionBombita.Y - this.posicion.Y) <= 6)) return true;
            return false;
        }
    }
}
