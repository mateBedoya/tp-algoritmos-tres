using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.src.juego.personajes;
using TP2.src.interfaces;
using TP2.Elementales;
using TP2.src.Juego.personajes;


namespace TP2.src.estrategias
{
    public class IAEnemigos : IEstrategia
    {
        private static int PRIORIDAD_DE_ESTRATEGIA_HORIZONTAL = 0;
        private static int PRIORIDAD_DE_ESTRATEGIA_VERTICAL = 1;
        private static int RANGO_DE_PRIORIDAD = 2;
        private static int[] ESTE = { 0, 1 };
        private static int[] NORTE = { -1, 0 };
        private static int[] OESTE = { 0, -1 };
        private static int[] SUR = { 1, 0 };
        private int prioridadDeMovmientoActual;
        private Enemigo aplicador;

        // crea una inteligencia para una entidad enemiga
        public IAEnemigos(Enemigo aplicador)
        {
            this.aplicador = aplicador;
            this.prioridadDeMovmientoActual = this.ConseguirPrioridad();
        }


        // retorna una prioridad que determinara como empezara a moverse el enemigo
        private int ConseguirPrioridad()
        {
            Random rand = new Random();
            return (rand.Next(RANGO_DE_PRIORIDAD));
        }


        // permite que se realice los movimientos y ataques del enemigo
        public void Aplicar() 
        {
            if (this.prioridadDeMovmientoActual == PRIORIDAD_DE_ESTRATEGIA_HORIZONTAL)
                this.AplicarEstrategiaHorizontal();
            if(this.prioridadDeMovmientoActual == PRIORIDAD_DE_ESTRATEGIA_VERTICAL)
                this.AplicarEstrategiaVertical();
        }


        // realiza un movimiento horizontal para el enemigo (a derecha o a izquierda)
        public void AplicarEstrategiaHorizontal() 
        {
           

        }


        // intenta colocar una bomba y escapar al este para no ser alcanzado por la explosion



        // realiza un movimiento vertical para el enemigo (hacia arriba o hacia abajo)
        public void AplicarEstrategiaVertical() { }
    }
}
