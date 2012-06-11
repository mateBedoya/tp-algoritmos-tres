using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Excepciones;

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




        public void ActivarBomba()
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.estaActivada = true;
        }

        
        public abstract void Daniar(IDaniable daniable);


        public bool FueDestruido()
        {
            if (vida == 0) return true;
            return false;
        }

        public void CuandoPaseElTiempo(int tiempo)
        {
            tiempoTranscurrido = tiempoTranscurrido + tiempo;
            if (estaActivada) this.Explotar(); 
        }

        // porcentajeRetardo es por si bombita agarra el articulo 
        // Timer y se le pasa el porcentaje respecto del retardo original
        // que debe esperar la bomba para explotar. De no pasarse, vale
        // 1 (100%)
        public void Explotar(double porcentajeRetardo = 1)
        {
            if (!PasoTiempoDeRetardo(porcentajeRetardo)) return;
            this.vida = 0;
            ExpandirExplosion();
            this.posicion.Entidad = null;
            this.posicion = null;
        }

        private void ExpandirExplosion()
        {
            ExpandirDerecha();
            ExpandirIzquierda();
            ExpandirArriba();
            ExpandirAbajo();
        }

        private void ExpandirDerecha()
        {
            Casillero casilleroADaniar;
            try
            {
                casilleroADaniar = posicion.ObtenerCasilleroDerechoEn(this.tablero);
            }
            catch(CasilleroFueraDeRangoException)
            {
                return;
            }
            for(int i = 0; i < rango-1; i++)
            {
                IDaniable entidad = null;
                if(casilleroADaniar != null) entidad = (IDaniable)casilleroADaniar.Entidad;
                if(entidad != null) this.Daniar(entidad);
                try
                {
                    if (casilleroADaniar != null) casilleroADaniar = casilleroADaniar.ObtenerCasilleroDerechoEn(this.tablero);
                }
                catch(CasilleroFueraDeRangoException)
                {
                    casilleroADaniar = null;
                }
            }
        }

        private void ExpandirIzquierda()
        {
            Casillero casilleroADaniar;
            try
            {
                casilleroADaniar = posicion.ObtenerCasilleroIzquierdoEn(this.tablero);
            }
            catch (CasilleroFueraDeRangoException)
            {
                return;
            }
            for(int i = 0; i < rango-1; i++)
            {
                IDaniable entidad = null;
                if(casilleroADaniar != null) entidad = (IDaniable)casilleroADaniar.Entidad;
                if(entidad != null) this.Daniar(entidad);
                try
                {
                    if (casilleroADaniar != null) casilleroADaniar = casilleroADaniar.ObtenerCasilleroIzquierdoEn(this.tablero);
                }
                catch (CasilleroFueraDeRangoException)
                {
                    casilleroADaniar = null;
                }
            }
        }

        private void ExpandirArriba()
        {
            Casillero casilleroADaniar;
            try
            {
                casilleroADaniar = posicion.ObtenerCasilleroSuperiorEn(this.tablero);
            }
            catch (CasilleroFueraDeRangoException)
            {
                return;
            }
            
            for(int i = 0; i < rango-1; i++)
            {
                IDaniable entidad = null;
                if(casilleroADaniar != null) entidad = (IDaniable)casilleroADaniar.Entidad;
                if(entidad != null) this.Daniar(entidad);
                try
                {
                    if (casilleroADaniar != null) casilleroADaniar = casilleroADaniar.ObtenerCasilleroSuperiorEn(this.tablero);
                }
                catch(CasilleroFueraDeRangoException)
                {
                    casilleroADaniar = null;
                }
            }
        }

        private void ExpandirAbajo()
        {
            Casillero casilleroADaniar;
            try
            {
                casilleroADaniar = posicion.ObtenerCasilleroInferiorEn(this.tablero);
            }
            catch (CasilleroFueraDeRangoException)
            {
                return;
            }
            for(int i = 0; i < rango-1; i++)
            {
                IDaniable entidad = null;
                if(casilleroADaniar != null) entidad = (IDaniable)casilleroADaniar.Entidad;
                if(entidad != null) this.Daniar(entidad);
                try
                {
                    if (casilleroADaniar != null) casilleroADaniar = casilleroADaniar.ObtenerCasilleroInferiorEn(this.tablero);
                }
                catch(CasilleroFueraDeRangoException)
                {
                    casilleroADaniar = null;
                }
            }
        }


        private bool PasoTiempoDeRetardo(double porcentajeRetardo = 1)
        {
            if (this.tiempoTranscurrido < this.retardo * porcentajeRetardo) return false;
            return true;
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
