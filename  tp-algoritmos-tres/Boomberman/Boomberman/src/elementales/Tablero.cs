using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.src.Juego.personajes;
using TP2.src.Elementales;
using TP2.src.excepciones;
using TP2.src.Juego.obstaculos;
using TP2.src.juego.articulos;
using Boomberman.src.interfaces;
using Boomberman.src.vistas;

namespace TP2.Elementales
{
    /// <summary>
    /// Esta clase contendra todos los casilleros tanto los vacios como los 
    /// ocupados por las entidades (personajes, bombas, obstaculos o articulos)
    /// Implementa el patron singleton
    /// </summary>
    public class Tablero
    {
        private static int MAXIMO_FILA = 13;
        private static int MAXIMO_COLUMNA = 21;
        private static int SALIDA_DE_LADRILLO = 0;
        private static int SALIDA_DE_CEMENTO = 1;
        private static int OBSTACULOS_QUE_ADMITEN_SALIDA = 2;
        private static Tablero INSTANCIA = null;
        private Casilla[,] casillas;
        private Entidad obstaculoQueOcultaSalida;
        private bool seAgregoLaSalida;
        
        public List<Entidad> entidades = new List<Entidad>(); // esta lista es para facilitar la ctualizacion del juego por parte del controlador
        

        // inicializa los casilleros que compondran al tablero, en principio vacios
        private void InicializarCasillas()
        {
            for (int i = 0; i < MAXIMO_FILA; i++)
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
                   casillas [i, j] = new Casilla (i, j);
        }


        // solo puede crearse una instancia de esta clase
        private Tablero()
        {
            this.casillas = new Casilla [MAXIMO_FILA, MAXIMO_COLUMNA];
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
            for (int i = 0; i < MAXIMO_FILA; i++)
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
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
            return (fila >= MAXIMO_FILA || fila < 0 ||
                columna >= MAXIMO_COLUMNA || columna < 0);
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
            INSTANCIA = new Tablero();
        }


        // retorna un numero aleatorio entre 0 y el maximo de fila
        private int FilaSorteada()
        {
            Random rand = new Random();
            return (rand.Next(MAXIMO_FILA));
        }


        // retorna un numero aleatorio entre 0 y el maximo de columna
        private int ColumnaSorteada()
        {
            Random rand = new Random();
            return (rand.Next(MAXIMO_COLUMNA));
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

        // Agrega los obstáculos de acero al tablero
        public void AgregarObstaculosDeAceroIniciales()
        {
            for (int i = 0; i < MAXIMO_FILA; i++)
            {
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
                {
                    if (i % 2 == 1 && j % 2 == 1)
                        AgregarEntidad(new ObstaculoDeAcero(), i, j);
                }
            }
                
            
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
                    int X = this.obstaculoQueOcultaSalida.Posicion().GetX();
                    int Y = this.obstaculoQueOcultaSalida.Posicion().GetY();
                    this.AgregarEntidad(new Salida(), X, Y);
                    this.obstaculoQueOcultaSalida = null;
                }
            }
        }


        // retorna la cantidad de entidades en el tablero
        public int CantidadDeEntidades()
        {
            int cantidadDeEntidades = 0;
            for (int i = 0; i < MAXIMO_FILA; i++)
                for (int j = 0; j < MAXIMO_COLUMNA; j++)
                    cantidadDeEntidades = cantidadDeEntidades + this.Casilla(i, j).CantidadDeEntidades();
            return cantidadDeEntidades;
        }


        // retorna la cantidad de entidades enemigas
        public int CantidadDeEnemigos()
        {
           int cantidadDeEnemigos = 0;
           for (int i = 0; i < MAXIMO_FILA; i++)
               for (int j = 0; j < MAXIMO_COLUMNA; j++)
                   cantidadDeEnemigos = cantidadDeEnemigos + this.Casilla(i, j).CantidadDeEnemigos();
           return cantidadDeEnemigos;
        }


        // remueve la entidad pasada de la casilla pasada
        public void RemoverEntidad(Entidad entidad)
        {
            entidad.Destruir();
            int X = entidad.Posicion().GetX();
            int Y = entidad.Posicion().GetY();
            Casilla posicionAModificar = this.Casilla(X, Y);
            posicionAModificar.RemoverEntidad(entidad);
            this.entidades.Remove(entidad);
        }


    }
}
