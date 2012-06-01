using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private static int FILAS_MAXIMAS = 100;
        private static int COLUMNAS_MAXIMAS = 100;
        private static Tablero INSTANCIA = null;
        private Casilla[,] casillas;

        // inicializa los casilleros que compondran al tablero, en principio vacios
        private void InicializarCasillas()
        {
            int fila = 0;
            int columna = 0;
            while (fila < FILAS_MAXIMAS)
            {
                columna = 0;
                while (columna < COLUMNAS_MAXIMAS)
                {
                    casillas [fila, columna] = new Casilla (fila, columna);
                    columna++;
                }
                fila++;
            }
        }

        // solo puede crearse una instancia de esta clase
        private Tablero()
        {
            this.casillas = new Casilla [FILAS_MAXIMAS, COLUMNAS_MAXIMAS];
            this.InicializarCasillas();
        }

        // retorna la instancia de tablero
        public static Tablero GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new Tablero();
            return (INSTANCIA);
        }

        // retorna la casilla coincidente con la fila y columna pasada;
        // en caso de que la casilla solicitada exceda los limites del tablero,
        // se lanzara una excepcion informando el error
        public Casilla GetCasilla(int fila, int columna)
        {
            if (fila > FILAS_MAXIMAS || fila < 0 ||
                columna > COLUMNAS_MAXIMAS || columna < 0)
            {
                CasillaNull.GetInstancia();
            }
            return (casillas [fila, columna]);
        }
    }
}
