using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TP2_Bomberman.src.Elementales;

namespace TP2_Bomberman.src
{
    class Tablero
    {
        private static int MAXIMO_FILA = 30;
        private static int MAXIMO_COLUMNA = 30;
        private Casillero[,] casilleros; //BORRAR COMENTARIO: Queda confuso que la clase Tablero tenga un atributo "tablero", lo cambio a "casilleros"
        private static Tablero INSTANCIA = null;

        // crea un tablero 
        public Tablero()
        {
            casilleros = new Casillero[MAXIMO_FILA, MAXIMO_COLUMNA];
            InicializarCasilleros();
        }

        // inicializa los casilleros, en principio vacios
        private void InicializarCasilleros()
        {
            for (int i = 0; i < MAXIMO_FILA; i++)
            {
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
                {
                    casilleros[i, j] = new Casillero(i, j);
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

        // retorna el tamanio
        public double Tamanio
        {
            get { return (MAXIMO_FILA * MAXIMO_COLUMNA); }
        }

        // 
        public Casillero ObtenerCasillero(int x, int y)
        {
            if (CasilleroFueraDeRango(x, y)) 
                throw new CasilleroFueraDeRangoException();
            return casilleros[x, y];
        }

        public bool CasilleroFueraDeRango(int x, int y)
        {
            if (x > MAXIMO_FILA || x < 0 || y > MAXIMO_COLUMNA || y < 0) 
                return true;
            return false;
        }

        // retorna el casillero coincidente con la fila y columna pasada;
        // en caso de que el casillero solicitado exceda los limites del tablero,
        // se lanzara un casillero nulo
        public Casillero GetCasillero(int fila, int columna)
        {
            if (fila > MAXIMO_FILA || fila < 0 ||
                columna > MAXIMO_COLUMNA || columna < 0)
            {
                return (CasilleroNull.GetInstancia());
            }
            return (casilleros[fila, columna]);
        }

        // BORRAR COMENTARIO : capaz que este metodo tendria que ser de casillero, ya que los casilleros adyacentes son adyacentes al
        // casillero y no al tablero (yo agregue un metodo en casillero "ObtenerAdyacentes"); en vez de preguntar si esta fuera de rango 
        // y lanzar una excepcion se podria devolver un CasilleroNull y cuando se valla a usar en otro lado del codigo preguntar 
        // casilleroPedido == CasilleroNull.GetInstancia; de esta forma te olvidas de que tenes que capturar una excepcion en varias
        // partes del codigo, te evitas los iF de este metodo y si es CasilleroNull haces otra cosa o no haces nada; 
        // si les convence esta forma, eliminar este metodo,  CasilleroFueraDeRango y ObtenerCasillero (dejar GetCasillero(int,int))
        public ArrayList ObtenerAdyacentes(int fila, int columna) 
        {
            ArrayList listaDeAdyacentes = new ArrayList();
            
            if (CasilleroFueraDeRango(fila, columna)) 
                throw new CasilleroFueraDeRangoException();

            if (CasilleroFueraDeRango(fila, columna - 1)) 
                listaDeAdyacentes.Add(null); //izq
            else 
                listaDeAdyacentes.Add(casilleros[fila, columna - 1]);

            if (CasilleroFueraDeRango(fila - 1, columna)) 
                listaDeAdyacentes.Add(null); //arriba
            else
                listaDeAdyacentes.Add(casilleros[fila - 1, columna]);

            if (CasilleroFueraDeRango(fila, columna + 1)) 
                listaDeAdyacentes.Add(null);//der
            else 
                listaDeAdyacentes.Add(casilleros[fila, columna + 1]);

            if (CasilleroFueraDeRango(fila + 1, columna)) 
                listaDeAdyacentes.Add(null);//abajo
            else 
                listaDeAdyacentes.Add(casilleros[fila + 1, columna]);


            return listaDeAdyacentes;
        }
    }
}
