using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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

        public ArrayList ObtenerAdyacentes(int fila, int columna) //Devuelve el izquierdo, despues el de arriba, despues el derecho, y despues el de abajo
        {
            ArrayList listaDeAdyacentes = new ArrayList();
            listaDeAdyacentes.Add(tablero[fila,columna-1]);//izq
            listaDeAdyacentes.Add(tablero[fila-1,columna]);//arriba
            listaDeAdyacentes.Add(tablero[fila,columna+1]);//der
            listaDeAdyacentes.Add(tablero[fila+1,columna]);//abajo

            return listaDeAdyacentes;
        }
    }
}

//  0 1 2 3
//0 1 1 1 1
//1 1 1 1 1
//2 1 1 1 1
//3 1 1 1 1