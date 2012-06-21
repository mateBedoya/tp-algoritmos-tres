using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Excepciones;
using TP2_BombermanGAME.src.Bombas;

namespace TP2_Bomberman.src
{
    public abstract class Bomba : Entidad, IDependienteDelTiempo, IDestruible
    {
        protected int destruccion;
        protected int retardo;
        protected int rango;
        protected int vida = 1;
        protected double tiempoTranscurrido = 0;
        protected bool estaActivada = false;
        protected double retardoAdquirido = 1;
        protected List<Explosion> listaExplosiones = new List<Explosion>();

        public Bomba()
            : base() { }
        public Bomba(Casillero posicion)
            : base(posicion)
        {
            posicion.Entidad = this;
        }



        //Cuando un personaje lanza una bomba, esta queda activada. Luego cuando pase el tiempo
        //necesario para que explote, explotara.
        public void ActivarBomba()
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.estaActivada = true;
        }

        // Metodo que se redefine en cada bomba de como daniar a un daniable
        public abstract void Daniar(IDaniable daniable);

        // Las bombas tienen una vida, quiere decir que con cualquier cosa que sean dañadas, son destruidas
        public bool FueDestruido()
        {
            if (vida == 0) return true;
            return false;
        }

        //Metodo para simular el paso del tiempo
        public void CuandoPaseElTiempo(double tiempo)
        {
            tiempoTranscurrido = tiempoTranscurrido + tiempo;
            if (estaActivada && !FueDestruido()) this.Explotar(retardoAdquirido);
        }

        // Si paso el tiempo necesario, explota, y se expande.
        // porcentajeRetardo es por si bombita agarra el articulo 
        // Timer y se le pasa el porcentaje respecto del retardo original
        // que debe esperar la bomba para explotar. De no pasarse, vale
        // 1 (100%)
        public void Explotar(double porcentajeRetardo = 1)
        {
            if (!PasoTiempoDeRetardo(porcentajeRetardo)) return;
            this.vida = 0;
            ExpandirExplosion();
            //this.posicion.Entidad = null;
            //this.posicion = null;
        }

        // Hace expandir su explosion en todas las direcciones
        private void ExpandirExplosion()
        {
            ExpandirDerecha();
            ExpandirIzquierda();
            ExpandirArriba();
            ExpandirAbajo();
        }

        // Expande la explosion hacia la direccion que se le pase
        private void ExpandirExplosionHacia(int[] direccion)
        {
            Casillero casilleroADaniar;
            int rangoACubrir = this.rango;
            bool encontroDaniable = false;
            try
            {
                casilleroADaniar = posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(direccion, this.tablero);
                AgregarExplosion(casilleroADaniar);
            }
            catch (Exception)
            {
                return;
            }
            while((!encontroDaniable)&&(rangoACubrir != 0))
            {
                IDaniable entidad = null;
                if((casilleroADaniar!=null) && (!casilleroADaniar.EstaVacio()))
                {
                    entidad = (IDaniable)casilleroADaniar.Entidad;
                    this.Daniar(entidad);
                    encontroDaniable = true;
                }
                try
                {
                    if (casilleroADaniar != null)
                    {
                        casilleroADaniar = casilleroADaniar.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(direccion, this.tablero);
                        if (!encontroDaniable && rangoACubrir != 1) AgregarExplosion(casilleroADaniar);
                    }
                    rangoACubrir--;

                }
                catch (Exception)
                {
                    casilleroADaniar = null;
                }
            }
        }

        private void AgregarExplosion(Casillero posicion)
        {
            Explosion explosion = new Explosion(this);
            explosion.Posicion = posicion;
            this.listaExplosiones.Add(explosion);
        }

        // Metodos de expansion
        private void ExpandirDerecha()
        {
            ExpandirExplosionHacia(ESTE);
        }
        private void ExpandirIzquierda()
        {
            ExpandirExplosionHacia(OESTE);
        }
        private void ExpandirArriba()
        {
            ExpandirExplosionHacia(NORTE);
        }
        private void ExpandirAbajo()
        {
            ExpandirExplosionHacia(SUR);
        }

        // Devuelve si se cumplio el tiempo del retardo para poder explotarse
        private bool PasoTiempoDeRetardo(double porcentajeRetardo = 1)
        {
            if (this.tiempoTranscurrido < this.retardo * porcentajeRetardo) return false;
            return true;
        }


        // Si son daniadas por cualquiera sea la otra bomba, explotan.
        public override void DaniarConMolotov(Molotov molotov)
        {
            this.Explotar(retardoAdquirido);
        }
        public override void DaniarConToleTole(Bombas.ToleTole toleTole)
        {
            this.Explotar(retardoAdquirido);
        }
        public override void DaniarConProyectil(Bombas.Proyectil proyectil)
        {
            this.Explotar(retardoAdquirido);
        }




        // Properties
        public int Destruccion
        {
            get { return this.destruccion; }
        }

        public int Retardo
        {
            get { return this.retardo; }
        }

        public int Rango
        {
            get { return this.rango; }
        }

        public bool EstaActivada
        {
            get { return this.estaActivada; }
        }

        public double RetardoAdquirido
        {
            get { return this.retardoAdquirido; }
            set { this.retardoAdquirido = value; }
        }

        public List<Explosion> ListaExplosiones
        {
            get { return this.listaExplosiones; }
        }

    }
}