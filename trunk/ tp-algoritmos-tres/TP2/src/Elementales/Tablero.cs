using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Juego.obstaculos;
using TP2.Juego.bombas;
using TP2.Juego.articulos;
using TP2.Excepciones;

namespace TP2.Elementales
{
    /// <summary>
    /// Esta clase contendra todos los casilleros tanto los vacios como los 
    /// ocupados por las entidades (personajes, bombas, obstaculos o articulos)
    /// Implementa el patron singleton
    /// </summary>
    public class Tablero
    {
        private static int MAXIMO_FILA = 30;
        private static int MAXIMO_COLUMNA = 30;
        private static Tablero INSTANCIA = null;
        private Casillero[,] casilleros;

        // inicializa los casilleros que compondran al tablero, en principio vacios
        private void InicializarCasilleros()
        {
            int indiceFila = 0;
            int indiceColumna = 0;
            while (indiceFila < MAXIMO_FILA)
            {
                indiceColumna = 0;
                while (indiceColumna < MAXIMO_COLUMNA)
                {
                    casilleros [indiceFila, indiceColumna] = new Casillero (indiceFila, indiceColumna);
                    indiceColumna++;
                }
                indiceFila++;
            }
        }

        // solo puede crearse una instancia de esta clase
        private Tablero()
        {
            this.casilleros = new Casillero [MAXIMO_FILA, MAXIMO_COLUMNA];
            this.InicializarCasilleros();
        }

        // retorna la instancia de tablero
        public static Tablero GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new Tablero();
            return (INSTANCIA);
        }

        // retorna la cantidad de casilleros que tiene
        public int GetTamanio()
        {
            return (MAXIMO_FILA * MAXIMO_COLUMNA);
        }

        // retorna el casillero coincidente con la fila y columna pasada;
        // en caso de que el casillero solicitada exceda los limites del tablero,
        // se lanzara un casillero nulo
        public Casillero GetCasillero(int fila, int columna)
        {
            if (fila > MAXIMO_FILA || fila < 0 ||
                columna > MAXIMO_COLUMNA || columna < 0)
            {
                return (CasilleroNull.GetInstancia());
            }
            return (casilleros [fila, columna]);
        }

        // agrega un personaje al casillero que coincida con las 
        // coordenadas pasadas, siempre y cuando el mismo este vacio
        public void AgregarPersonaje(Personaje personaje, int fila, int columna)
        {
            Casillero casillero = this.casilleros[fila, columna];
            if (casillero.EstaVacio())
                casillero.AgregarPersonaje(personaje);
            else
                throw new CasilleroOcupadoError();
        }

        // agrega un obstaculo al casillero que coincida con las 
        // coordenadas pasadas, siempre y cuando el mismo este vacio
        public void AgregarObstaculo(Obstaculo obstaculo, int fila, int columna)
        {
            Casillero casillero = this.casilleros[fila, columna];
            if (casillero.EstaVacio())
                casillero.AgregarObstaculo(obstaculo);
            else
                throw new CasilleroOcupadoError();
        }       
    }
}
