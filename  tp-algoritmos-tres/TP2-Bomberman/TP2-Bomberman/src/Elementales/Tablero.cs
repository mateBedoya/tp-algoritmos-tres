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

        public Tablero(bool ConObstaculos=false) //inicializa los obstaculos si le paso true
        {
            tablero = new Casillero[MAXIMO_FILA, MAXIMO_COLUMNA];
            InicializarCasilleros(ConObstaculos);
        }


        //Metodo que inicializa los casilleros del tablero
        private void InicializarCasilleros(bool ConObstaculos)
        {
            for (int i = 0; i < MAXIMO_FILA; i++)
            {
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
                {
                    tablero[i, j] = new Casillero(i, j);

                    if(ConObstaculos) CargarObstaculo(i, j);
                }
            }                    
        }

        private void CargarObstaculo(int i, int j)
        {
            if (i % 2 == 1 && j % 2 == 1)
                AgregarEntidadEnCasillero(new BloqueDeAcero(), i, j);

            else if (i < 2 && j < 2) // Evita encerrar a bombita.
                return;

            else
            {
                Random random = new Random();
                if (random.Next(1, 10) == 1)
                {
                    AgregarEntidadEnCasillero(new BloqueDeLadrillos(), i, j);
                    //SortearArticuloEnObstaculo(); Sería similar al sorteo de obstaculos.

                }
                else if (random.Next(1, 20) == 1)
                {
                    AgregarEntidadEnCasillero(new BloqueDeCemento(), i, j);
                    //SortearArticuloEnObstaculo();
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
        public void AgregarEntidadEnCasillero(Entidad entidad, int x, int y)
        {
            try
            {
                Casillero casillero = ObtenerCasillero(x, y);
                casillero.Entidad = entidad;
                entidad.Posicion = casillero;
                entidad.Tablero = this;
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
