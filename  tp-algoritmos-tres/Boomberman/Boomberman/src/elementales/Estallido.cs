using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.src.Elementales;
using TP2.src.interfaces;
using TP2.src.estrategias;
using TP2.Elementales;
using TP2.src.Interfaces;

namespace Boomberman.src.elementales
{
    public class Estallido: Entidad, IDependienteDelTiempo, IDestruible
    {
        private double tiempoTranscurrido;

        public Estallido(Casilla pos)
        {
            this.posicion = pos;
        }

        public void CuandoPaseElTiempo(double tiempo)
        {
            tiempoTranscurrido = tiempoTranscurrido + tiempo;
            if (PasoElTiempo())
            {
                this.posicion = null;
            }
        }

        public void Aplicar()
        {
            Tablero.GetInstancia().AgregarEntidad(this, posicion.X, posicion.Y);
            this.CuandoPaseElTiempo(0.05);
        }

        public override bool PuedeSuperponerse()
        {
            return true;
        }

        public override bool EsEnemigo()
        {
            return false;
        }

        public override bool EsArticulo()
        {
            return false;
        }

        public override bool EsBomba()
        {
            return false;
        }

        public override bool EsBombita()
        {
            return false;
        }

        public override bool EsPersonaje()
        {
            return false;
        }

        public override bool EsObstaculo()
        {
            return false;
        }

        public override void DaniarPorMolotov(TP2.src.Juego.bombas.Molotov molotov) { }
        public override void DaniarPorToletole(TP2.src.Juego.bombas.ToleTole molotov) { }
        public override void DaniarPorProyectil(TP2.src.Juego.bombas.Proyectil molotov) { }

        public override void Destruir() { }

        public override bool FueDestruido()
        {
            return PasoElTiempo();
        }

        public bool PasoElTiempo()
        {
            return (tiempoTranscurrido <= 1);
        }

        public override string GetDescripcion()
        {
            return "Estallido";
        }


    }
}
