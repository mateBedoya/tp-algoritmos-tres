using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.personajes;
using BoombermanGame.src.obstaculos;
using System.Xml.Serialization;

namespace BoombermanGame.src.niveles
{
    [Serializable]
    public class Nivel
    {
        protected int numero;
        protected Tablero tablero;
        protected Bombita bombita;
        protected int cantidadDeCecilios;
        protected int cantidadDeLopezReggaes;
        protected int cantidadDeLopezReggaesAlados;
        protected int cantidadDeObstaculosDeLadrillo;
        protected int cantidadDeObstaculosDeCemento;
        protected int cantidadDeObstaculosDeAcero;


        public Nivel()
        {
            this.cantidadDeCecilios = 0;
            this.cantidadDeLopezReggaes = 0;
            this.cantidadDeLopezReggaesAlados = 0;
            this.cantidadDeObstaculosDeLadrillo = 0;
            this.cantidadDeObstaculosDeCemento = 0;
            this.cantidadDeObstaculosDeAcero = 0;
            this.bombita = new Bombita();
            this.tablero = new Tablero();
            
        }


        public Nivel(int cecilios, int lopezReggaes, int lopezReggaesAlados,
            int obstaculosDeLadrillo, int obstaculosDeCemento, int obstaculosDeAcero)
        {
            this.cantidadDeCecilios = cecilios;
            this.cantidadDeLopezReggaes = lopezReggaes;
            this.cantidadDeLopezReggaesAlados = lopezReggaesAlados;
            this.cantidadDeObstaculosDeLadrillo = obstaculosDeLadrillo;
            this.cantidadDeObstaculosDeCemento = obstaculosDeCemento;
            this.cantidadDeObstaculosDeAcero = obstaculosDeAcero;
            this.bombita = new Bombita();
            this.tablero = new Tablero();
            
        }

        // todo nivel comienza con bombita en la posicion (0, 0) del tablero; este metodo permite
        // cargar el tablero con los datos iniciales
        public virtual void Cargar()
        {
            this.tablero.Reiniciar();
            this.tablero = new Tablero();

            this.bombita.Reiniciar();
            this.bombita = new Bombita();
            this.tablero.AgregarEntidad(bombita, 1, 1);
            
            this.inicializar();
            
        }

        public virtual void CargarseGuardado(Casilla posicionBombita, Entidad ObstaculoDeSalida, List<Entidad> listaEntidades)
        {
            this.tablero.Reiniciar();
            this.tablero = new Tablero();

            this.bombita.Reiniciar();
            this.bombita = new Bombita();
            this.tablero.AgregarEntidad(bombita, posicionBombita.X, posicionBombita.Y);

            this.inicializarGuardado(ObstaculoDeSalida, listaEntidades);
            
        }

        private void inicializarGuardado(Entidad ObstaculoDeSalida, List<Entidad> listaEntidades)
        {

            foreach (Entidad entidad in listaEntidades)
            {
                if (entidad is Cecilio && this.tablero.Casillas[entidad.PosicionActual.X,entidad.PosicionActual.Y].Entidades != null ) this.tablero.AgregarEntidad(new Cecilio(), entidad.PosicionActual.X, entidad.PosicionActual.Y);
                else if (!entidad.EsBombita()) this.tablero.AgregarEntidad(entidad, entidad.PosicionActual.X, entidad.PosicionActual.Y);
            }


            this.tablero.AgregarEntidad(ObstaculoDeSalida,ObstaculoDeSalida.PosicionActual.X,ObstaculoDeSalida.PosicionActual.Y);
            this.tablero.ObstaculoQueOcultaSalida = ObstaculoDeSalida;

        }

        // carga obtsaculos de forma predeterminada en el tablero
        private void inicializar()
        {
            
            this.AgregarCecilios();
            this.AgregarLopezReggaes();
            this.AgregarLopezReggaesAlados();

            int X = 2;
            int Y = 2;
            while (X < this.tablero.Alto())
            {
                while (Y < this.tablero.Ancho())
                {
                    this.tablero.AgregarEntidad(new ObstaculoDeAcero(), X, Y);
                    Y = Y + 2;
                }
                Y = 2;
                X = X + 2;
            }

            this.AgregarObstaculosDeAcero();
            this.AgregarObstaculosDeCemento();
            this.AgregarObstaculosDeLadrillo();

            this.tablero.AgregarObstaculoQueOcultaSalida();

        }
         
        

        // retorna si el nivel fue ganado
        public bool Ganado()
        {
            return (this.bombita.EncontroLaSalida());
        }


        // el nivel esta perdido si el usuario perdio todas las vidas
        public bool Perdido()
        {
            return (this.bombita.FueDestruido());
        }


        // se le informa que el usuario pierde una vida al ser destruido bombita
        public void Actualizar()
        {
            this.tablero.Actualizar();
        }


        // el nivel esta terminado si esta ganado o perdido
        public bool Terminado()
        {
            return (this.Ganado() || this.Perdido());
        }


        // estos metodos se encargan de agregar la cantidad de entidades que tendra el tablero
        protected void AgregarCecilios()
        {
            int cantidadDeCeciliosAgregados = 0;
            while (cantidadDeCeciliosAgregados < this.cantidadDeCecilios)
            {
                tablero.AgregarEntidad(new Cecilio());
                cantidadDeCeciliosAgregados++;
            }
        }


        protected void AgregarLopezReggaes()
        {
            int cantidadDeLopezReggaesAgregados = 0;
            while (cantidadDeLopezReggaesAgregados < this.cantidadDeLopezReggaes)
            {
                tablero.AgregarEntidad(new LopezReggae());
                cantidadDeLopezReggaesAgregados++;
            }
        }


        protected void AgregarLopezReggaesAlados()
        {
            int cantidadDeLopezReggaesAladosAgregados = 0;
            while (cantidadDeLopezReggaesAladosAgregados < this.cantidadDeLopezReggaesAlados)
            {
                tablero.AgregarEntidad(new LopezReggaeAlado());
                cantidadDeLopezReggaesAladosAgregados++;
            }
        }


        protected void AgregarObstaculosDeLadrillo()
        {
            int cantidadDeObstaculosDeLadrilloAgregados = 0;
            while (cantidadDeObstaculosDeLadrilloAgregados < this.cantidadDeObstaculosDeLadrillo)
            {
                tablero.AgregarEntidad(new ObstaculoDeLadrillo());
                cantidadDeObstaculosDeLadrilloAgregados++;
            }
        }


        protected void AgregarObstaculosDeCemento()
        {
            int cantidadDeObstaculosDeCementoAgregados = 0;
            while (cantidadDeObstaculosDeCementoAgregados < this.cantidadDeObstaculosDeCemento)
            {
                tablero.AgregarEntidad(new ObstaculoDeCemento());
                cantidadDeObstaculosDeCementoAgregados++;
            }
        }


        protected void AgregarObstaculosDeAcero()
        {
            int cantidadDeObstaculosDeAceroAgregados = 0;
            while (cantidadDeObstaculosDeAceroAgregados < this.cantidadDeObstaculosDeAcero)
            {
                tablero.AgregarEntidad(new ObstaculoDeAcero());
                cantidadDeObstaculosDeAceroAgregados++;
            }
        }

        
        public Bombita Bombita
        {
            get { return this.bombita; }
            set { this.bombita = value; }
        }

        public Tablero Tablero
        {
            get{ return this.tablero; }
            set{ this.tablero = value; }
        }

        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

    }
}
