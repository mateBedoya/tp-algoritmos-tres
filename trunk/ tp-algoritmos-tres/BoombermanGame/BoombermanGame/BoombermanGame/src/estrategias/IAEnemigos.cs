using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.personajes;
using BoombermanGame.src.interfaces;
using BoombermanGame.src.elementales;

namespace BoombermanGame.src.estrategias
{
    public class IAEnemigos : IEstrategia
    {
        private static int CICLOS_PARA_ACTUAR = 50;
        private static int POSIBLES_DIRECCIONES = 4;
        private static int DISTANCIA_MINIMA_A_BOMBITA = 5;
        private Enemigo aplicador;
        private int contadorDeCiclos;


        // crea una IA para el enemigo pasado
        public IAEnemigos(Enemigo aplicador)
        {
            this.aplicador = aplicador;
            this.contadorDeCiclos = 0;
        }


        // se aplica solo si se esta en un ciclo valido para ser aplicada
        public void Aplicar()
        {
            if (this.contadorDeCiclos > (CICLOS_PARA_ACTUAR - this.aplicador.Velocidad()) &&
                (this.contadorDeCiclos % (CICLOS_PARA_ACTUAR - this.aplicador.Velocidad())) == 0)
            {  
                
                if (this.BombitaEstaCerca())
                    this.aplicador.LanzarExplosivo();

                Random rand = new Random();
                int direccion = rand.Next(POSIBLES_DIRECCIONES);
                switch (direccion)
                {
                    case 0:
                        this.aplicador.MoverAlEste();
                        break;
                    case 1:
                        this.aplicador.MoverAlNorte();
                        break;
                    case 2:
                        this.aplicador.MoverAlOeste();
                        break;
                    case 3:
                        this.aplicador.MoverAlSur();
                        break;
                }
            }
            this.contadorDeCiclos++;
        }


        // retorna si bombita esta cerca
        private bool BombitaEstaCerca()
        {
            Casilla posicionBombita = Bombita.GetInstancia().Posicion();
            if ((Math.Abs(posicionBombita.X - this.aplicador.Posicion().X) <= DISTANCIA_MINIMA_A_BOMBITA) &&
                (Math.Abs(posicionBombita.Y - this.aplicador.Posicion().Y) <= DISTANCIA_MINIMA_A_BOMBITA)) 
                return true;
            return false;
        }

        
    }
}
