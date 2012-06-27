using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.interfaces;
using BoombermanGame.src.bombas;
using BoombermanGame.src.excepciones;

namespace BoombermanGame.src.personajes
{
    public abstract class Personaje : Entidad, ILanzador
    {
        private static double PORCENTAJE_DE_RETARDO = 1;
        protected int resistencia;
        protected int velocidad;
        protected double porcentajeDeRetardo;
        protected bool explotoLaBombaLanzada;
        protected IEstrategia estrategiaDeLanzamiento;

        // crea un personaje
        public Personaje(int resistencia, int velocidad)
            : base()
        {
            this.resistencia = resistencia;
            this.velocidad = velocidad;
            this.porcentajeDeRetardo = PORCENTAJE_DE_RETARDO;
            this.explotoLaBombaLanzada = true;
            this.estrategiaDeLanzamiento = null;
        }


        // crea un personaje
        public Personaje(Casilla posicion, int resistencia, int velocidad)
            : base(posicion)
        {
            this.resistencia = resistencia;
            this.velocidad = velocidad;
            this.porcentajeDeRetardo = PORCENTAJE_DE_RETARDO;
            this.explotoLaBombaLanzada = true;
            this.estrategiaDeLanzamiento = null;
        }


        // retorna la resistencia actual del personaje
        public int Resistencia()
        {
            return (this.resistencia);
        }


        // retorna la velocidad actual del personaje
        public int Velocidad()
        {
            return (this.velocidad);
        }


        // retorna el porcentaje de retardo que reduce el tiempo de retardo de la bomba que coloca
        public double PorcentajeDeRetardo()
        {
            return (this.porcentajeDeRetardo);
        }


        // un personaje puede moverse solo si la proxima casilla 
        // posee objetos que pueden superponerse
        public virtual bool PuedeMoverseA(Casilla proximaPosicion)
        {
            foreach (Entidad entidad in proximaPosicion.GetEntidades())
                if (!entidad.PuedeSuperponerse())
                    return false;
            return true;
        }


        // aplica el movimiento en la direccion actual
        public void Mover()
        {
            try
            {
                Casilla proximaPosicion = this.posicion.CasillaAdyacenteEnLaDireccion(this.direccion);

                if (this.PuedeMoverseA(proximaPosicion))
                {
                    this.posicion.RemoverEntidad(this);
                    this.PosicionarEn(proximaPosicion);
                }
            }
            catch (CasillaFueraDeRangoError e)
            {
                e.NoHacerNada();
            }
        }


        // movimiento hacia arriba
        public void MoverAlNorte()
        {
            this.Direccionar(NORTE);
            this.Mover();
        }


        // movimiento hacia abajo
        public void MoverAlSur()
        {
            this.Direccionar(SUR);
            this.Mover();
        }


        // movimiento hacia la derecha
        public void MoverAlEste()
        {
            this.Direccionar(ESTE);
            this.Mover();
        }


        // movimiento hacia la izquierda
        public void MoverAlOeste()
        {
            this.Direccionar(OESTE);
            this.Mover();
        }


        // implementacion de la interfaz IDestruible
        public override bool FueDestruido()
        {
            return (this.resistencia <= 0);
        }


        public override void Destruir()
        {

        }


        // implementacion de la interfaz IDaniable
        public override void DaniarPorMolotov(Molotov bomba)
        {
            this.resistencia = this.resistencia - bomba.GetDanio();
        }


        public override void DaniarPorProyectil(Proyectil bomba)
        {
            this.resistencia = this.resistencia - bomba.GetDanio();
        }


        public override void DaniarPorToletole(ToleTole bomba)
        {
            this.resistencia = 0;
        }


        // implementacion de los metodos abstractos heredados
        public override bool EsArticulo()
        {
            return false;
        }


        public override bool EsBomba()
        {
            return false;
        }


        public override bool EsObstaculo()
        {
            return false;
        }


        public override bool EsPersonaje()
        {
            return true;
        }


        public override bool PuedeSuperponerse()
        {
            return false;
        }


        public abstract override bool EsBombita();
        public abstract override bool EsEnemigo();


        // retorna si la bomba que lanzo, exploto
        public bool ExplotoLaBombaLanzada()
        {
            return (this.explotoLaBombaLanzada);
        }


        // implementacion de la interfaz ILanzador
        public void NotificarExplosion(bool estadoDeLaBomba)
        {
            this.explotoLaBombaLanzada = estadoDeLaBomba;
        }


        // aplica el lanzamiento del explosivo
        public void LanzarExplosivo()
        {
            if (this.explotoLaBombaLanzada)
                this.estrategiaDeLanzamiento.Aplicar();
        }
    }
}
