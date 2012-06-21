using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Interfaces;
using TP2_BombermanGAME.src.Bombas;

namespace TP2_Bomberman.src
{
    // La posicion (0,0) esta en el vertice superior izquierdo y hacia la derecha
    // aumentan las columnas y hacia abajo las filas
    public class Tablero
    {
        private static int MAXIMO_FILA = 15;
        private static int MAXIMO_COLUMNA = 15;
        private Casillero[,] tablero;
        private static Tablero INSTANCIA = null;
        private int PROBABILIDAD_BLOQUE_CEMENTO = 20;
        private int PROBABILIDAD_BLOQUE_LADRILLO = 10;
        private int PROBABILIDAD_ARTICULO = 5;
        private int CANTIDAD_DE_NIVELES = 6;
        private static int nivelActual = 1;
        private List<Cecilio> listaCecilios = new List<Cecilio>();
        private List<LopezR> listaLopezR = new List<LopezR>();
        private List<LopezRAlado> listaLopezRAlado = new List<LopezRAlado>();
        private List<BloqueDeAcero> listaBloqueDeAcero = new List<BloqueDeAcero>();
        private List<BloqueDeCemento> listaBloqueDeCemento = new List<BloqueDeCemento>();
        private List<BloqueDeLadrillos> listaBloqueDeLadrillos = new List<BloqueDeLadrillos>();
        private List<Timer> listaTimer = new List<Timer>();
        private List<Habano> listaHabano = new List<Habano>();
        private List<BombaToleTole> listaBombaToleTole = new List<BombaToleTole>();
        private List<Bomba> listaBombas = new List<Bomba>();
        private static Dictionary<int, int> ceciliosPorNivel = new Dictionary<int,int>();
        private static Dictionary<int, int> lopezRPorNivel = new Dictionary<int,int>();
        private static Dictionary<int, int> lopezRAladoPorNivel = new Dictionary<int,int>();
        //private Casillero posicionBombita;
        private Bombita bombita;
        private Salida salidaTablero;
        private Random random = new Random();

        public Tablero(bool ConObstaculos=false) //inicializa los obstaculos si le paso true
        {
            tablero = new Casillero[MAXIMO_FILA, MAXIMO_COLUMNA];
            if (nivelActual == 1) CargarEnemigosPorNivel();
            InicializarTablero(ConObstaculos);
        }

        public void Reiniciar(Bombita bombita)
        {
            tablero = new Casillero[MAXIMO_FILA, MAXIMO_COLUMNA];
            listaCecilios = new List<Cecilio>();
            listaLopezR = new List<LopezR>();
            listaLopezRAlado = new List<LopezRAlado>();
            listaBloqueDeAcero = new List<BloqueDeAcero>();
            listaBloqueDeCemento = new List<BloqueDeCemento>();
            listaBloqueDeLadrillos = new List<BloqueDeLadrillos>();
            listaTimer = new List<Timer>();
            listaHabano = new List<Habano>();
            listaBombaToleTole = new List<BombaToleTole>();
            InicializarTablero(true);
            AgregarEntidadEnCasillero(bombita, 0, 0);
        }
        
        // Inicializa el tablero con casilleros, obstaculos y personajes.
        public void InicializarTablero(bool ConObstaculos)
        {
            InicializarCasilleros(ConObstaculos);
            if (ConObstaculos == true)
            {
                AgregarEnemigos();
                /*int fila;
                int columna;
                while (true)
                {
                    fila = SortearFila();
                    columna = SortearColumna();
                    if (EstaVacio(fila, columna)) break;
                }
                LopezR enemigo = new LopezR();
                Cecilio enemigo2 = new Cecilio();
                AgregarEntidadEnCasillero(enemigo2, fila, columna);
                //AgregarEntidadEnCasillero(enemigo, fila, columna);
                //listaLopezR.Add(enemigo);
                listaCecilios.Add(enemigo2);
                //listaCecilios.Add(enemigo);
                //listaLopezR.Add(enemigo);*/
                AgregarSalida();
                AgregarBombita();
            }
        }


        //Metodo que inicializa los casilleros del tablero
        public void InicializarCasilleros(bool ConObstaculos)
        {
            for (int i = 0; i < MAXIMO_FILA; i++)
            {
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
                {
                    tablero[i, j] = new Casillero(i, j);

                    if (ConObstaculos) CargarBloqueDeAcero(i, j);
                }
            }
        }

        // Carga un obstaculo en una posicion segun su probabilidad.
        private void CargarBloqueDeAcero(int i, int j)
        {
            // Los obstaculos fijos del bomberman original son de acero en esta version.
            BloqueDeAcero bloque = new BloqueDeAcero();
            if (i % 2 == 1 && j % 2 == 1)
            {
                AgregarEntidadEnCasillero(bloque, i, j);
                listaBloqueDeAcero.Add(bloque);
            }


            // Evita encerrar a bombita.
            else if (i < 3 && j < 3) return;

            else SortearObstaculoEnCasillero(i, j);
        }
        
        private void AgregarBombita()
        {
            Bombita bombita = new Bombita();
            AgregarEntidadEnCasillero(bombita,0,0);
        }


        // Sortea la posibilidad de colocar un obstaculo en el casillero y lo agrega si corresponde.
        private void SortearObstaculoEnCasillero(int i, int j)
        {
            BloqueDeLadrillos bloqueLadrillos;
            BloqueDeCemento bloqueCemento;
            if (random.Next(1, PROBABILIDAD_BLOQUE_LADRILLO) == 1)
            {
                bloqueLadrillos = new BloqueDeLadrillos();
                AgregarEntidadEnCasillero(bloqueLadrillos, i, j);
                listaBloqueDeLadrillos.Add(bloqueLadrillos);
                SortearArticuloEnCasillero(i, j);
            }

            else if (random.Next(1, PROBABILIDAD_BLOQUE_CEMENTO) == 1)
            {
                bloqueCemento = new BloqueDeCemento();
                AgregarEntidadEnCasillero(bloqueCemento, i, j);
                listaBloqueDeCemento.Add(bloqueCemento);
                SortearArticuloEnCasillero(i, j);
            }
        }

        // Agrega la cantidad de enemigos correspondientes segun el nivel actual
        // reemplazando las entidades existentes en el casillero.
        public void AgregarEnemigos()
        {
            Cecilio cecilio;
            LopezR lopezR;
            LopezRAlado lopezRAlado;
            for (int cantidadDeCecilios = ceciliosPorNivel[nivelActual]; cantidadDeCecilios > 0; cantidadDeCecilios--)
            {
                int fila;
                int columna;
                while (true)
                {
                    fila = SortearFila();
                    columna = SortearColumna();
                    if (EstaVacio(fila, columna)) break;
                }
                cecilio = new Cecilio();
                AgregarEntidadEnCasillero(cecilio, fila, columna);
                listaCecilios.Add(cecilio);
            }
            for (int cantidadDeLopezR = lopezRPorNivel[nivelActual]; cantidadDeLopezR > 0; cantidadDeLopezR--)
            {
                int fila;
                int columna;
                while (true)
                {
                    fila = SortearFila();
                    columna = SortearColumna();
                    if (EstaVacio(fila, columna)) break;
                }
                lopezR = new LopezR();
                AgregarEntidadEnCasillero(lopezR, fila, columna);
                listaLopezR.Add(lopezR);
            }
            for (int cantidadDeLopezRAlado = lopezRAladoPorNivel[nivelActual]; cantidadDeLopezRAlado > 0; cantidadDeLopezRAlado--)
            {
                int fila;
                int columna;
                while (true)
                {
                    fila = SortearFila();
                    columna = SortearColumna();
                    if (EstaVacio(fila, columna)) break;
                }
                lopezRAlado = new LopezRAlado();
                AgregarEntidadEnCasillero(lopezRAlado, fila, columna);
                listaLopezRAlado.Add(lopezRAlado);
            }
        }

        private bool EstaVacio(int fila, int columna)
        {
            if (ObtenerCasillero(fila, columna).EstaVacio()) return true;
            return false;
        }

        // Sortea una fila dentro del rango del tablero
        private int SortearFila()
        {
            int fila = random.Next(4, MAXIMO_FILA);
            return fila;
        }

        // Sortea una columna par dentro del rango del tablero
        private int SortearColumna()
        {
            int columna = random.Next(4, MAXIMO_COLUMNA);
            columna = ConvertirEnPar(columna);
            return columna;
        }

        private int ConvertirEnPar(int numero)
        {
            return (numero / 2) * 2;
        }

        // En cada nivel aumenta en 1 la cantidad de LopezRAlado y 
        // disminuye proporcionalmente la cantidad de cecilios.
        // La cantidad de LopezR es siempre 3.
        private void CargarEnemigosPorNivel()
        {
            for (int nivel = 1; nivel <= CANTIDAD_DE_NIVELES; nivel++)
            {
                ceciliosPorNivel.Add(nivel, CANTIDAD_DE_NIVELES - nivel);
                lopezRPorNivel.Add(nivel, 3);
                lopezRAladoPorNivel.Add(nivel, nivel);
            }
        }
        
        // Agrega un obstaculo con salida en una posicion aleatoria del tablero.
        public void AgregarSalida()
        {
            while (true)
            {
                int fila = SortearFila();
                int columna = SortearColumna();
                if (ObtenerCasillero(fila, columna).EstaVacio() == true)
                {
                    int resultado = random.Next(1, 3);
                    Obstaculo bloque = null;
                    if (resultado == 1)
                    {
                        bloque = new BloqueDeCemento();
                        AgregarEntidadEnCasillero(bloque, fila, columna);
                        listaBloqueDeCemento.Add((BloqueDeCemento)bloque);
                    }
                    if (resultado == 2)
                    {
                        bloque = new BloqueDeLadrillos();
                        AgregarEntidadEnCasillero(bloque, fila, columna);
                        listaBloqueDeLadrillos.Add((BloqueDeLadrillos)bloque);
                    }
                    //AgregarArticuloEnCasillero(new Salida(), fila, columna);
                    Salida salida = new Salida();
                    bloque.Articulo = salida;
                    salidaTablero = salida;
                    salida.Posicion = ObtenerCasillero(fila, columna);
                    salida.Tablero = this;
                    break;
                }
            }
        }

                     

        // Sortea el tipo de articulo a colocar en el casillero y lo agrega si corresponde.
        private void SortearArticuloEnCasillero(int i, int j)
        {

            if (random.Next(1, PROBABILIDAD_ARTICULO) == 1)
            {
                Obstaculo bloque = (Obstaculo)ObtenerCasillero(i, j).Entidad;
                switch (random.Next(1, 4))
                {
                    case 1:
                        Timer timer = new Timer();
                        bloque.Articulo = timer;
                        listaTimer.Add(timer);
                        timer.Posicion = ObtenerCasillero(i,j);
                        return;

                    case 2:
                        Habano habano = new Habano();
                        bloque.Articulo = habano;
                        listaHabano.Add(habano);
                        habano.Posicion = ObtenerCasillero(i, j);
                        return;

                    case 3:
                        BombaToleTole bombaToleTole = new BombaToleTole();
                        bloque.Articulo = bombaToleTole;
                        listaBombaToleTole.Add(bombaToleTole);
                        bombaToleTole.Posicion = ObtenerCasillero(i, j);
                        return;
                }
                
                //if(articulo != null)
                    //AgregarArticuloEnCasillero(articulo, i, j);
            }
        }
        

        private void AgregarArticuloEnCasillero(Articulo articulo, int fila, int columna)
        {
            try
            {
                Casillero casillero = ObtenerCasillero(fila, columna);
                casillero.Entidad.AgregarArticulo(articulo);
            }
            catch (CasilleroFueraDeRangoException e)
            {
                throw e;
            }
        }


        // retorna la instancia de tablero
        public static Tablero GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new Tablero();
            return (INSTANCIA);
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
                if (entidad.EsBombita()) bombita = (Bombita)entidad;
            }
            catch (CasilleroFueraDeRangoException e)
            {
                throw e;
            }

        }

        public void AgregarBomba(Bomba bomba)
        {
            listaBombas.Add(bomba);
        }

        internal void avanzarNivel()
        {
            //if (Tablero.nivelActual == CANTIDAD_DE_NIVELES) terminarJuego();
            Tablero.nivelActual += 1;
            //InicializarTablero(true);
        }

        private void terminarJuego()
        {
            throw new NotImplementedException(); // Habria que cortar el game loop
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

        public double Dimension
        {
            get { return MAXIMO_COLUMNA; }
        }

        public Casillero PosicionBombita
        {
            get { return this.bombita.Posicion; }
            //set { this.posicionBombita = value; }
        }

        public Bombita Bombita
        {
            get { return this.bombita; }
        }

        public Salida Salida
        {
            get { return this.salidaTablero; }
        }

        public int NivelActual
        {
            get { return nivelActual; }
            set { nivelActual = value; }
        }

        public int CantidadEnemigosVivos()
        {
            int cantidad = 0;
            foreach (Cecilio enemigo in listaCecilios)
            {
                if (! enemigo.FueDestruido()) cantidad ++;
            }
            foreach (LopezR enemigo in listaLopezR)
            {
                if (!enemigo.FueDestruido()) cantidad++;
            }
            foreach (LopezRAlado enemigo in listaLopezRAlado)
            {
                if (!enemigo.FueDestruido()) cantidad++;
            }
            return cantidad;
        }

        public Casillero[,] Mapa
        {
            get { return tablero;}
        }

        public List<BloqueDeAcero> ListaDeBloqueDeAcero
        {
            get { return listaBloqueDeAcero; }
        }

        public List<BloqueDeCemento> ListaDeBloqueDeCemento
        {
            get { return listaBloqueDeCemento; }
        }

        public List<BloqueDeLadrillos> ListaDeBloqueDeLadrillos
        {
            get { return listaBloqueDeLadrillos; }
        }
        public List<Cecilio> ListaCecilios
        {
            get { return listaCecilios; }
        }
        public List<LopezR> ListaLopezR
        {
            get { return listaLopezR; }
        }
        public List<LopezRAlado> ListaLopezRAlado
        {
            get { return listaLopezRAlado; }
        }
        public List<Timer> ListaTimer
        {
            get { return listaTimer; }
        }
        public List<Habano> ListaHabano
        {
            get { return listaHabano; }
        }
        public List<BombaToleTole> ListaBombaToleTole
        {
            get { return listaBombaToleTole; }
        }
        public List<Bomba> ListaBombas
        {
            get { return listaBombas; }
        }
        public int CantidadDeNiveles
        {
            get { return CANTIDAD_DE_NIVELES; }
        }
    }
}
