using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.src.Elementales;
using TP2.Elementales;
using TP2.src.Interfaces;
using TP2.src.Juego.bombas;
using TP2.Juego.articulos;
using TP2.src.excepciones;
using Boomberman.src.interfaces;
using Boomberman.src.vistas;

namespace TP2.Juego.obstaculos
{
    public abstract class Obstaculo : Entidad
    {

        protected bool guardaSalida;

        // crea un obstaculo
        public Obstaculo()
            : base()
        {
            this.guardaSalida = false;
        }


        // crea un obstaculo
        public Obstaculo(Casilla posicion)
            : base(posicion)
        {
            this.guardaSalida = false;
        }


        // cre un obstaculo
        public Obstaculo(bool guardaSalida)
            : base()
        {
            this.guardaSalida = guardaSalida;
        }


        // deben implementarlos las clases derivadas
        public override abstract bool FueDestruido();
        public override abstract void DaniarPorMolotov(Molotov bomba);
        public override abstract void DaniarPorProyectil(Proyectil bomba);
        public override abstract void DaniarPorToletole(ToleTole bomba);


        // implementacion de la interfaz IDestruible
        public override void Destruir()
        {
            if (!this.guardaSalida)
                this.ArticuloPorDestruccion();
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
            return true;
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


        // este metodo a traves de la fabrica de articulos, permite agregar un articulo al
        // tablero siempre y cuando este articulo no este vacio
        public void ArticuloPorDestruccion()
        {
            try
            {
                Articulo articulo = FabricaDeArticulos.GetInstancia().SolicitarArticulo();
                Tablero.GetInstancia().AgregarEntidad(articulo, this.Posicion().X, this.Posicion().Y);
            }
            catch (ArticuloVacioError e)
            {
                e.NoHacerNada();
            }
        }

    }
}
