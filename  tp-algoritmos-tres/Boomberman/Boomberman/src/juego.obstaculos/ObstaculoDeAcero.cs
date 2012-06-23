using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.obstaculos;
using TP2.Elementales;
using TP2.src.Juego.bombas;

namespace TP2.src.Juego.obstaculos
{
    class ObstaculoDeAcero : Obstaculo
    {
        private bool destruido;

        // crea un obstaculo de acero
        public ObstaculoDeAcero()
            : base()
        {
            this.destruido = false;
        }


        // crea un obstaculo de acero
        public ObstaculoDeAcero(Casilla posicion)
            : base(posicion)
        {
            this.destruido = false;
        }


        // crea un obstaculo de acero
        public ObstaculoDeAcero(bool guardaSalida)
            : base(guardaSalida)
        {
            this.destruido = false;
            this.guardaSalida = false;
        }


        // implementacion de la interfaz IDestruible
        public override bool FueDestruido()
        {
            return (this.destruido);
        }


        // implementacion de la interfaz IDaniable
        public override void DaniarPorMolotov(Molotov bomba) { }

        public override void DaniarPorProyectil(Proyectil bomba) { }

        public override void DaniarPorToletole(ToleTole bomba)
        {
            this.destruido = true;
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "ObstaculoDeAcero";
        }
        
    }
}
