using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2
{
    class Tablero
    {
        private int ancho;
        private int alto;
        private Casillero[,] tablero;

        public Tablero(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
            tablero = new Casillero[ancho,alto];
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < alto; j++)
                {
                    tablero[i, j] = new Casillero(i, j);
                }
            }
        }
        public double Tamanio
        {
            get { return (this.ancho*this.alto); }
        }
        public Casillero ObtenerCasillero(uint x,uint y)
        {
            return tablero[x, y];
        }
    }
}
