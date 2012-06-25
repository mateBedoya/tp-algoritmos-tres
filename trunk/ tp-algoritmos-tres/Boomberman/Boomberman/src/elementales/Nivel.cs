using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Elementales;
using TP2.src.Juego.personajes;
using TP2.src.Juego.obstaculos;
using Boomberman.src.interfaces;

namespace Boomberman.src.elementales
{
    public abstract class Nivel
    {
        protected int numero;
        protected int VIDAS_POSIBLES = 3;
        protected Tablero tablero;
        protected Bombita bombita;
        protected int cantidadDeCecilios;
        protected int cantidadDeLopezReggaes;
        protected int cantidadDeLopezReggaesAlados;
        protected int cantidadDeObstaculosDeLadrillo;
        protected int cantidadDeObstaculosDeCemento;
        protected int cantidadDeObstaculosDeAcero;
        protected int vidas;


        public Nivel()
        {
            this.cantidadDeCecilios = 0;
            this.cantidadDeLopezReggaes = 0;
            this.cantidadDeLopezReggaesAlados = 0;
            this.cantidadDeObstaculosDeLadrillo = 0;
            this.cantidadDeObstaculosDeCemento = 0;
            this.cantidadDeObstaculosDeAcero = 0;
            this.vidas = VIDAS_POSIBLES;
            this.bombita = Bombita.GetInstancia();
            this.tablero = Tablero.GetInstancia();
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
            this.vidas = VIDAS_POSIBLES;
            this.bombita = Bombita.GetInstancia();
            this.tablero = Tablero.GetInstancia();
        }

        // todo nivel comienza con bombita en la posicion (0, 0) del tablero; este metodo permite
        // cargar el tablero con los datos iniciales
        public virtual void Cargar()
        {
            this.tablero.Reiniciar();
            this.tablero = Tablero.GetInstancia();           
           
            this.bombita.Reiniciar();
            this.bombita = Bombita.GetInstancia();         
            this.tablero.AgregarEntidad(bombita, 0, 0);
        }


        // asigna el numero de nivel
        public void SetNumero(int numero)
        {
            this.numero = numero;
        }


        // retorna el numero de nivel
        public int Numero()
        {
            return (this.numero);
        }


        // retorna a bombita
        public Bombita GetBombita()
        {
            return (this.bombita);
        }

        public void SetBombita(Bombita _bombita)
        {
            this.bombita = _bombita;
        }

        public void SetTablero(Tablero _tablero)
        {
            this.tablero = _tablero;
        }


        // retorna el tablero
        public Tablero GetTablero()
        {
            return (this.tablero);
        }


        // retorna si el nivel fue ganado
        public bool Ganado()
        {
            return (this.bombita.EncontroSalida());
        }


        // el nivel esta perdido si el usuario perdio todas las vidas
        public bool Perdido()
        {
            return (this.vidas == 0);
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

    }
}
