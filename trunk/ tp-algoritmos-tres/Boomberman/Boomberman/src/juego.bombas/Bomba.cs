using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.src.Elementales;
using TP2.Elementales;
using TP2.src.Interfaces;
using TP2.src.Juego.bombas;
using TP2.src.interfaces;
using TP2.src.estrategias;
using Boomberman.src.interfaces;
using Boomberman.src.vistas;

namespace TP2.Juego.bombas
{
    public abstract class Bomba : Entidad, ILanzable, IDependienteDelTiempo
    {
        private bool exploto;
        private int rango;
        private double retardo;
        private IEstrategia explosion;
        private ILanzador lanzador;

        // inicializa las estrategias
        private void Inicializar()
        {
            this.explosion = new Explosion(this);
        }


        // crea una bomba
        public Bomba(int rango, double retardo)
            : base()
        {
            this.exploto = false;
            this.rango = rango;
            this.retardo = retardo;
            this.Inicializar();
        }


        // crea una bomba
        public Bomba(Casilla posicion, int rango, double retardo)
            : base(posicion)
        {
            this.exploto = false;
            this.rango = rango;
            this.retardo = retardo;
            this.Inicializar();
        }


        // retorna el rango que abarca su explosion
        public int GetRango()
        {
            return (this.rango);
        }


        // debe ser redefinido por las clases derivadas
        public abstract void Daniar(List<Entidad> daniables);

        
        // implementacion d ela interfaz ILanzable
        public void AnotarLanzador(ILanzador lanzador)
        {
            this.lanzador = lanzador;
            this.lanzador.NotificarExplosion(false);
        }


        // realiza la explosion
        public virtual void Explotar()
        {
            if (!this.FueDestruido() & this.PasoElTiempo())
            {
                this.explosion.Aplicar();
                if(lanzador != null)    // esta linea es para hacer pasar las pruebas solamente, ya que siempre la bomba va a explotar porque alguien la coloco
                    this.lanzador.NotificarExplosion(true);
            }
        }


        // retorna si paso el tiempo para explotar
        public bool PasoElTiempo()
        {
            if (this.retardo >= 0)
                this.retardo--;
            return (this.retardo < 0);
        }


        // implementacion de la interfaz IDestruible
        public override bool FueDestruido()
        {
            return (this.exploto);
        }


        public override void Destruir()
        {
           
        }


        // implementacion de la interfaz IDaniable
        public override void DaniarPorMolotov(Molotov molotov) 
        {
            this.exploto = true;
            this.lanzador.NotificarExplosion(true);
        }


        public override void DaniarPorProyectil(Proyectil proyectil) 
        {
            this.exploto = true;
            this.lanzador.NotificarExplosion(true);
        }


        public override void DaniarPorToletole(ToleTole toletole)
        {
            this.exploto = true;
            this.lanzador.NotificarExplosion(true);
        }


        // implementacion de los metodos abstractos heredados
        public override bool EsArticulo()
        {
            return false;
        }


        public override bool EsBomba()
        {
            return true;
        }


        public override bool EsObstaculo()
        {
            return false;
        }


        public override bool EsPersonaje()
        {
            return false;
        }


        public override bool EsBombita()
        {
            return false;
        }


        public override bool EsEnemigo()
        {
            return false;
        }


        public override bool PuedeSuperponerse()
        {
            return false;
        }


        // reduce el retardo, segun el porcentaje pasado
        public void CuandoPaseElTiempo(double porcentajeDeRetardo)
        {
            this.retardo = this.retardo * porcentajeDeRetardo;
        }


        // metodo utilizado por el controlador
        public override void Actuar()
        {
            this.Explotar();
        }
    }
}
