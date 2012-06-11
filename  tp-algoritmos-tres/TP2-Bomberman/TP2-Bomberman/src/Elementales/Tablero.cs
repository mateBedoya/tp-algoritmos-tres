using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Personajes;

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
        private int PROBABILIDAD_BLOQUE_CEMENTO = 20;
        private int PROBABILIDAD_BLOQUE_LADRILLO = 10;
        private int PROBABILIDAD_ARTICULO = 10;
        private int CANTIDAD_DE_NIVELES = 6;
        private int nivelActual = 1;
        private Dictionary<int, int> ceciliosPorNivel = new Dictionary<int,int>();
        private Dictionary<int, int> lopezRPorNivel = new Dictionary<int,int>();
        private Dictionary<int, int> lopezRAladoPorNivel = new Dictionary<int,int>();

        public Tablero(bool ConObstaculos=false) //inicializa los obstaculos si le paso true
        {
            tablero = new Casillero[MAXIMO_FILA, MAXIMO_COLUMNA];
            if (nivelActual == 1) CargarEnemigosPorNivel();
            InicializarCasilleros(ConObstaculos);
            AgregarEnemigos();
        }

        // En cada nivel aumenta en 1 la cantidad de LopezRAlado y 
        // disminuye proporcionalmente la cantidad de cecilios.
        // La cantidad de LopezR es siempre 3.
        private void CargarEnemigosPorNivel()
        {
            for ( int nivel = 1; nivel <= CANTIDAD_DE_NIVELES; nivel++)
            {
                ceciliosPorNivel.Add(nivel,CANTIDAD_DE_NIVELES-nivel);
                lopezRPorNivel.Add(nivel, 3);
                lopezRAladoPorNivel.Add(nivel, nivel);
            }
        }

        // Agrega la cantidad de enemigos correspondientes segun el nivel actual
        // reemplazando las entidades existentes en el casillero.
        private void AgregarEnemigos()
        {
            for ( int cantidadDeCecilios = ceciliosPorNivel[nivelActual]; cantidadDeCecilios > 0 ; cantidadDeCecilios-- ) 
            {
                int fila = SortearFila();
                int columna = SortearColumna();
                AgregarEntidadEnCasillero(new Cecilio(), fila, columna);
            }
            for (int cantidadDeLopezR = lopezRPorNivel[nivelActual]; cantidadDeLopezR > 0 ; cantidadDeLopezR--)
            {
                int fila = SortearFila();
                int columna = SortearColumna();
                AgregarEntidadEnCasillero(new LopezR(), fila, columna);
            }
            for (int cantidadDeLopezRAlado = lopezRAladoPorNivel[nivelActual]; cantidadDeLopezRAlado > 0 ; cantidadDeLopezRAlado--)
            {
                int fila = SortearFila();
                int columna = SortearColumna();
                AgregarEntidadEnCasillero(new LopezRAlado(), fila, columna);
            }


            }

        // Sortea una fila dentro del rango del tablero
        private int SortearFila()
        {
            Random filaRandom = new Random();
            int fila;
            fila = filaRandom.Next(4,MAXIMO_FILA-1);
            return fila;
            
        }

        // Sortea una columna par dentro del rango del tablero
        private int SortearColumna()
        {
            Random columnaRandom = new Random();
            int columna;
            columna = columnaRandom.Next(2,MAXIMO_COLUMNA-1);
            columna = ConvertirEnPar(columna);
            return columna;
        }
        

        private int ConvertirEnPar(int numero)
        {
            return (numero/2) * 2;
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
        
        // Carga un obstaculo en una posicion segun su probabilidad.
        private void CargarObstaculo(int i, int j)
        {
            // Los obstaculos fijos del bomberman original son de acero en esta version.
            if (i % 2 == 1 && j % 2 == 1) 
                AgregarEntidadEnCasillero(new BloqueDeAcero(), i, j);

            // Evita encerrar a bombita.
            else if (i < 2 && j < 2) 
                return;

            else
            {
                SortearObstaculoEnCasillero(i, j);
            }
        }

        // Sortea la posibilidad de colocar un obstaculo en el casillero y lo agrega si corresponde.
        private void SortearObstaculoEnCasillero(int i, int j)
        {
            Random random = new Random();

            if (random.Next(1, PROBABILIDAD_BLOQUE_LADRILLO) == 1)
            {
                AgregarEntidadEnCasillero(new BloqueDeLadrillos(), i, j);
                SortearArticuloEnCasillero(i, j);

            }

            else if (random.Next(1, PROBABILIDAD_BLOQUE_CEMENTO) == 1)
            {
                AgregarEntidadEnCasillero(new BloqueDeCemento(), i, j);
                SortearArticuloEnCasillero(i, j);
            }
        }

        // Sortea la posibilidad de colocar un articulo en el casillero y lo agrega si corresponde.
        private void SortearArticuloEnCasillero(int i, int j)
        {
            Random random = new Random();

            if (random.Next(1, PROBABILIDAD_ARTICULO) == 1)
            {
                switch (random.Next(1, 4))
                {
                    case 1:
                        AgregarEntidadEnCasillero(new Timer(), i, j);
                        return;

                    case 2:
                        AgregarEntidadEnCasillero(new Habano(), i, j);
                        return;

                    case 3:
                        AgregarEntidadEnCasillero(new BombaToleTole(), i, j);
                        return;

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
