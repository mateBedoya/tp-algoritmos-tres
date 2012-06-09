using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Elementales;

namespace TP2_Bomberman.src
{
    public abstract class Bomba: Entidad, IDependienteDelTiempo,IDestruible
    {
        protected int destruccion;
        protected int retardo;
        protected int rango;
        protected int vida = 1;
        protected int tiempoTranscurrido = 0;
        protected bool estaActivada = false;

        public Bomba()
            : base() { }
        public Bomba(Casillero posicion)
            : base(posicion) 
        {
            posicion.Entidad = this;
        }




        // porcentajeRetardo es por si bombita agarra el articulo 
        // Timer y se le pasa el porcentaje respecto del retardo original
        // que debe esperar la bomba para explotar. De no pasarse, vale
        // 1 (100%)
        public abstract void Explotar();
        
        
        public abstract void Daniar(IDaniable daniable);

        public bool FueDestruido()
        {
            if (vida == 0) return true;
            return false;
        }

        public void CuandoPaseElTiempo(int tiempo)
        {
            tiempoTranscurrido = tiempoTranscurrido + tiempo;
            if (estaActivada) this.RealizarExplosion(); 
        }

        public void RealizarExplosion(double porcentajeRetardo = 1)
        {
            if (this.tiempoTranscurrido < this.retardo*porcentajeRetardo) return;
            this.vida = 0;
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
                
    }
}
