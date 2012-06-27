using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.excepciones;
using BoombermanGame.src.obstaculos;
using BoombermanGame.src.personajes;
using BoombermanGame.src.articulos;
using System.Xml.Serialization;

namespace BoombermanGame.src.elementales
{
    
    /// <summary>
    /// Esta clase contendra todos los casilleros tanto los vacios como los 
    /// ocupados por las entidades (personajes, bombas, obstaculos o articulos)
    /// Implementa el patron singleton
    /// </summary>
    public class Tablero
    {
        public static int MAXIMO_FILA = 13;
        public static int MAXIMO_COLUMNA = 21;
        private static int SALIDA_DE_LADRILLO = 0;
        private static int SALIDA_DE_CEMENTO = 1;
        private static int OBSTACULOS_QUE_ADMITEN_SALIDA = 2;
        private static Tablero INSTANCIA = null;
        private Casilla[,] casillas;
        private Entidad obstaculoQueOcultaSalida;
        private bool seAgregoLaSalida;
        
        public List<Entidad> entidades;  // esta lista es para facilitar la ctualizacion del juego por parte del controlador
        

        // inicializa los casilleros que compondran al tablero, en principio vacios
        private void InicializarCasillas()
        {
            for (int i = 0; i < MAXIMO_FILA; i++)
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
                   casillas [i, j] = new Casilla (i, j);
            INSTANCIA = this;
        }


        // solo puede crearse una instancia de esta clase
        public Tablero()
        {
            this.casillas = new Casilla [MAXIMO_FILA, MAXIMO_COLUMNA];
            entidades = new List<Entidad>();
            this.InicializarCasillas();
            this.seAgregoLaSalida = false;
        }


        // retorna la instancia de tablero
        public static Tablero GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new Tablero();
            return (INSTANCIA);
        }

        public static void SetInstancia(Tablero tablero)
        {
            INSTANCIA = tablero;
        }

        // retorna el alto
        public int Alto()
        {
            return (MAXIMO_FILA);
        }


        // retorna el ancho
        public int Ancho()
        {
            return (MAXIMO_COLUMNA);
        }


        // vacia el tablero. 
        // Este metodo es usado para hacer pasar las pruebas mas de una vez
        // ya que tablero es un singleton, al igual que bombita
        public static void Vaciar()
        {
            for (int i = 1; i < MAXIMO_FILA; i++)
                for (int j = 1; j < MAXIMO_COLUMNA; j++)
                    GetInstancia().casillas[i, j].Vaciar();
            Bombita.LimpiarInstancia();
        }


        // retorna la cantidad de casillas que tiene
        public int GetTamanio()
        {
            return (MAXIMO_FILA * MAXIMO_COLUMNA);
        }


        // retorna si el casillero con las coordenadas pasadas, esta dentro de
        // los limites del tablero
        private bool CasillaFueraDeRango(int fila, int columna)
        {
            return (fila >= MAXIMO_FILA - 1 || fila < 1 ||
                columna >= MAXIMO_COLUMNA - 1 || columna < 1);
        }


        // retorna la casilla coincidente con la fila y columna pasada;
        // en caso de que la casilla solicitada exceda los limites del tablero,
        // se lanzara una excepcion90'
        public Casilla Casilla(int fila, int columna)
        {
            if (this.CasillaFueraDeRango(fila, columna))
                throw new CasillaFueraDeRangoError();
            return (casillas [fila, columna]);
        }


        // este metodo es utilizado cuando se comienza el primer nivel,
        // cuando se pasa de nivel o cuando el usuario pierde una vida
        public void Reiniciar()
        {
            INSTANCIA = null;
        }


        // retorna un numero aleatorio entre 0 y el maximo de fila
        private int FilaSorteada()
        {
            Random rand = new Random();
            return (rand.Next(MAXIMO_FILA - 1));
        }


        // retorna un numero aleatorio entre 0 y el maximo de columna
        private int ColumnaSorteada()
        {
            Random rand = new Random();
            return (rand.Next(MAXIMO_COLUMNA - 1));
        }


        // este metodo genera posiciones aleatorias para la entidad pasada 
        // hasta que la misma es posicionada en una casilla vacia
        private void GenerarPosicionPara(Entidad entidad)
        {
            bool fueUbicado = false;
            while(!fueUbicado)
            {
                try
                {    
                    Casilla casilla = this.Casilla(this.FilaSorteada(), this.ColumnaSorteada());
                    if(casilla.EstaVacia())
                    {
                        entidad.PosicionarEn(casilla);
                        fueUbicado = true;
                    }
                }
                catch (CasillaFueraDeRangoError e)
                {
                    e.NoHacerNada();
                }
            }
        }


        // agrega la entidad en una posicion generada aleatoriamente
        public void AgregarEntidad(Entidad entidad)
        {
            this.GenerarPosicionPara(entidad);
            this.entidades.Add(entidad);
        }


        // permite agregar una entidad al tablero
        // Se agrega a la entidad en la casilla correspondiente a las coordenadas pasadas
        public void AgregarEntidad(Entidad entidad, int fila, int columna)
        {
            try
            {
                entidad.PosicionarEn(this.Casilla(fila, columna));
                this.entidades.Add(entidad);
            }
            catch (CasillaFueraDeRangoError e)
            {
                e.NoHacerNada();
            }
        }


        // agrega la salida que estara oculta por un obstaculo de ladrillo o de cemento
        public void AgregarObstaculoQueOcultaSalida()
        {
            Random rand = new Random();
            int prioridadDeSalida = rand.Next(OBSTACULOS_QUE_ADMITEN_SALIDA);
            Entidad obstaculoQueOcultaSalida = null;
         
            if (prioridadDeSalida == SALIDA_DE_LADRILLO)
                obstaculoQueOcultaSalida = new ObstaculoDeLadrillo(true);
            if (prioridadDeSalida == SALIDA_DE_CEMENTO)
                obstaculoQueOcultaSalida = new ObstaculoDeCemento(true);

            this.AgregarEntidad(obstaculoQueOcultaSalida);
            this.obstaculoQueOcultaSalida = obstaculoQueOcultaSalida;
        }


        // actualiza el tablero
        public void Actualizar()
        {
            this.AgregarSalida();
        }


        // agrega la salida
        public void AgregarSalida()
        {
            if (!seAgregoLaSalida)
            {
                if (this.obstaculoQueOcultaSalida.FueDestruido())
                {
                    this.seAgregoLaSalida = true;
                    int X = this.obstaculoQueOcultaSalida.PosicionActual.X;
                    int Y = this.obstaculoQueOcultaSalida.PosicionActual.Y;
                    this.AgregarEntidad(new Salida(), X, Y);
                    this.obstaculoQueOcultaSalida = null;
                }
            }
        }


        // retorna la cantidad de entidades en el tablero
        public int CantidadDeEntidades()
        {
            int cantidadDeEntidades = 0;
            for (int i = 1; i < MAXIMO_FILA - 1; i++)
                for (int j = 1; j < MAXIMO_COLUMNA - 1; j++)
                    cantidadDeEntidades = cantidadDeEntidades + this.Casilla(i, j).CantidadDeEntidades();
            return cantidadDeEntidades;
        }


        // retorna la cantidad de entidades enemigas
        public int CantidadDeEnemigos()
        {
            int cantidadDeEnemigos = 0;
            for (int i = 1; i < MAXIMO_FILA - 1; i++)
                for (int j = 1; j < MAXIMO_COLUMNA - 1; j++)
                {
                    try
                    {
                        cantidadDeEnemigos = cantidadDeEnemigos + this.Casilla(i, j).CantidadDeEnemigos();
                    }
                    catch (CasillaFueraDeRangoError e)
                    {
                        e.NoHacerNada();
                    }
                }
            return cantidadDeEnemigos;
        }


        // remueve la entidad pasada de la casilla pasada
        public void RemoverEntidad(Entidad entidad)
        {
            entidad.Destruir();
            int X = entidad.Posicion().X;
            int Y = entidad.Posicion().Y;
            Casilla posicionAModificar = this.Casilla(X, Y);
            posicionAModificar.RemoverEntidad(entidad);
            this.entidades.Remove(entidad);
        }

        public List<Entidad> Entidades
        {
            get { return this.entidades; }
            set { this.entidades = value; }
        }

        public bool SeAgregoLASalida
        {
            get { return this.seAgregoLaSalida; }
            set { this.seAgregoLaSalida = value; }
        }

        public Entidad ObstaculoQueOcultaSalida
        {
            get { return this.obstaculoQueOcultaSalida; }
            set { this.obstaculoQueOcultaSalida = value; }
        }

        [XmlIgnore]
        public Casilla[,] Casillas
        {
            get { return this.casillas; }
        }
        


    }
}
