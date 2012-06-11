using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Elementales;

namespace TP2_Bomberman.src.Bombas
{
    public class Proyectil: Bomba, IMovible
    {
        private int distanciaRecorrida = 0;//Solo puede moverse 4 casilleros
        public Proyectil()
            :base()
        {
            this.destruccion = 5;//Esto era a determinar, lo dejo en 5 por ahora
            this.retardo = 0;//Explota apenas se la activa
            this.rango = 3;
        }

        public Proyectil(Casillero posicion)
            :base(posicion)
        {
            this.destruccion = 5;//Esto era a determinar, lo dejo en 5 por ahora
            this.retardo = 1;
            this.rango = 3;
        }


        public override void Daniar(IDaniable daniable)
        {
            daniable.DaniarConProyectil(this); // Uso de patron doble dipatch
        }




        //Metodos de movimiento
        public void MoverArriba()
        {
            try
            {
                Casillero casilleroNuevo = posicion.ObtenerCasilleroSuperiorEn(this.tablero);
                CambiarPosicionA(casilleroNuevo);
                if (this.distanciaRecorrida == 4) ActivarBomba();
            }
            catch (CasilleroFueraDeRangoException)
            {

            }
            catch (MovimientoInvalidoException)
            {
                ActivarBomba();
            }
        }

        public void MoverAbajo()
        {
            try
            {
                Casillero casilleroNuevo = posicion.ObtenerCasilleroInferiorEn(this.tablero);
                CambiarPosicionA(casilleroNuevo);
                if (this.distanciaRecorrida == 4) ActivarBomba();
            }
            catch (CasilleroFueraDeRangoException)
            {

            }
            catch (MovimientoInvalidoException)
            {
                ActivarBomba();
            }

        }

        public void MoverDerecha()
        {
            try
            {
                Casillero casilleroNuevo = posicion.ObtenerCasilleroDerechoEn(this.tablero);
                CambiarPosicionA(casilleroNuevo);
                if (this.distanciaRecorrida == 4) ActivarBomba();
            }
            catch (CasilleroFueraDeRangoException)
            {

            }
            catch (MovimientoInvalidoException)
            {
                ActivarBomba();
            }

        }

        public void MoverIzquierda()
        {
            try
            {
                Casillero casilleroNuevo = posicion.ObtenerCasilleroIzquierdoEn(this.tablero);
                CambiarPosicionA(casilleroNuevo);
                if (this.distanciaRecorrida == 4) ActivarBomba();
            }
            catch (CasilleroFueraDeRangoException)
            {

            }
            catch (MovimientoInvalidoException)
            {
                ActivarBomba();
            }

        }

        public void CambiarPosicionA(Casillero casilleroNuevo)
        {
            if (!PuedeMoverseA(casilleroNuevo))
            {
                throw new MovimientoInvalidoException();
            }
            posicion.Entidad = null;
            casilleroNuevo.Entidad = this;
            posicion = casilleroNuevo;
            this.distanciaRecorrida++;
        }

        public bool PuedeMoverseA(Casillero casilleroNuevo)
        {
            if (casilleroNuevo.EstaVacio() && (this.distanciaRecorrida < 4)) return true;
            return false;
        }
        
    }
}
