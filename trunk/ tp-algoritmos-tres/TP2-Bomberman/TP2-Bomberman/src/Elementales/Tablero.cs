using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;

namespace TP2_Bomberman.src
{
    // La posicion (0,0) esta en el vertice superior izquierdo y hacia la derecha
    // aumentan las columnas y hacia abajo las filas
    public class Tablero
    {
        private static int MAXIMO_FILA = 30;
        private static int MAXIMO_COLUMNA = 30;
        private Casillero[,] tablero;
        private static Tablero INSTANCIA = null;

        public Tablero()
        {
            tablero = new Casillero[MAXIMO_FILA, MAXIMO_COLUMNA];
            InicializarCasilleros();
        }


        //Metodo que inicializa los casilleros del tablero
        private void InicializarCasilleros()
        {
            for (int i = 0; i < MAXIMO_FILA; i++)
            {
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
                {
                    tablero[i, j] = new Casillero(i, j);
                }
            }                    
        }


        // retorna la instancia de tablero
        public static Tablero GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new Tablero();
            return (INSTANCIA);
        }

        // Devuelve un ArrayList con los casilleros adyacentes en el siguiente orden:
        // {izquierdo, arriba, derecho, abajo}
        // En caso de no poseer alguno de los adyacentes, pone un null en la lista
        public ArrayList ObtenerAdyacentes(int fila, int columna) 
        {
            ArrayList listaDeAdyacentes = new ArrayList();
            
            if (CasilleroFueraDeRango(fila, columna)) throw new CasilleroFueraDeRangoException();

            if (CasilleroFueraDeRango(fila, columna - 1)) listaDeAdyacentes.Add(null); //izq
            else listaDeAdyacentes.Add(tablero[fila, columna - 1]);

            if (CasilleroFueraDeRango(fila - 1, columna)) listaDeAdyacentes.Add(null); //arriba
            else listaDeAdyacentes.Add(tablero[fila - 1, columna]);

            if (CasilleroFueraDeRango(fila, columna + 1)) listaDeAdyacentes.Add(null);//der
            else listaDeAdyacentes.Add(tablero[fila, columna + 1]);

            if (CasilleroFueraDeRango(fila + 1, columna)) listaDeAdyacentes.Add(null);//abajo
            else listaDeAdyacentes.Add(tablero[fila + 1, columna]);


            return listaDeAdyacentes;
        }

        // Se fija si un casillero esta dentro de los parametros del tablero
        public bool CasilleroFueraDeRango(int x, int y)
        {
            if (x > MAXIMO_FILA || x < 0 || y > MAXIMO_COLUMNA || y < 0) return true;
            return false;
        }

        //Metodos para agregar entidad en el tablero
        public void AgregarPersonajeEnCasillero(Personaje personaje, int x, int y)
        {
            try
            {
                Casillero casillero = ObtenerCasillero(x, y);
                casillero.Personaje = personaje;
                personaje.Posicion = casillero;
            }
            catch (CasilleroFueraDeRangoException e)
            {
                throw e;
            }

        }

        public void AgregarArticuloEnCasillero(Articulo articulo, int x, int y)
        {
            try
            {
                Casillero casillero = ObtenerCasillero(x, y);
                casillero.Articulo = articulo;
                articulo.Posicion = casillero;
            }
            catch (CasilleroFueraDeRangoException e)
            {
                throw e;
            }

        }

        public void AgregarObstaculoEnCasillero(Obstaculo obstaculo, int x, int y)
        {
            try
            {
                Casillero casillero = ObtenerCasillero(x, y);
                casillero.Obstaculo = obstaculo;
                obstaculo.Posicion = casillero;
            }
            catch (CasilleroFueraDeRangoException e)
            {
                throw e;
            }

        }

        public void AgregarBombaEnCasillero(Bomba bomba, int x, int y)
        {
            try
            {
                Casillero casillero = ObtenerCasillero(x, y);
                casillero.Bomba = bomba;
                bomba.Posicion = casillero;
            }
            catch (CasilleroFueraDeRangoException e)
            {
                throw e;
            }

        }


        //Propiedades y getters y setters

        public Casillero ObtenerCasillero(int x, int y)
        {
            if (CasilleroFueraDeRango(x, y)) throw new CasilleroFueraDeRangoException();
            return tablero[x, y];
        }

        public double Tamanio
        {
            get { return (MAXIMO_FILA * MAXIMO_COLUMNA); }
        }
    }
}
