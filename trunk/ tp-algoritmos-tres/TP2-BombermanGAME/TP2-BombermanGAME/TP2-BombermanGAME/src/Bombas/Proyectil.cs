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
        private int velocidad;

        private int distanciaRecorrida = 0;//Solo puede moverse 4 casilleros
        public Proyectil()
            :base()
        {
            this.destruccion = 5;
            this.retardo = 0;//Explota apenas se la activa
            this.rango = 3;
            this.velocidad = 1;
        }

        public Proyectil(Casillero posicion)
            :base(posicion)
        {
            this.destruccion = 5;//Esto era a determinar, lo dejo en 5 por ahora
            this.retardo = 1;
            this.rango = 3;
            this.velocidad = 1;
        }

        // Uso del patron double dispatch. Se redefinio el metodo danias y se 
        // dania con el proyectil segun le corresponda al daniable
        public override void Daniar(IDaniable daniable)
        {
            try
            {
                daniable.DaniarConProyectil(this);
            }
            catch (Exception) { }
        }

        //Metodo para simular el paso del tiempo
        public override void CuandoPaseElTiempo(double tiempo)
        {
            tiempoTranscurrido = tiempoTranscurrido + tiempo;
            if (estaActivada && !FueDestruido()) this.MoverEnDireccion();
        }


        //Metodos de movimiento
        private void Mover()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(this.direccion, this.tablero));
                if (this.distanciaRecorrida == 4) Explotar();
            }
            catch (CasilleroFueraDeRangoException) { }
            catch (MovimientoInvalidoException)
            {
                Explotar(); //Cuando se encuentra con algo, se activa
            }
        }

        public void MoverArriba()
        {
            Direccionar(NORTE);
            Mover();
        }

        public void MoverAbajo()
        {
            Direccionar(SUR);
            Mover();
        }

        public void MoverDerecha()
        {
            Direccionar(ESTE);
            Mover();
        }

        public void MoverIzquierda()
        {
            Direccionar(OESTE);
            Mover();
        }

        public void MoverEnDireccion()
        {
            if (this.duenio.Direccion == "este")
            {
                MoverDerecha();
            }
            if (this.duenio.Direccion == "oeste")
            {
                MoverIzquierda();
            }
            if (this.duenio.Direccion == "norte")
            {
                MoverArriba();
            }
            if (this.duenio.Direccion == "sur")
            {
                MoverAbajo();
            }
        }


        // Verifica si puede cambiarse a una posicion y si es asi
        // renueva las referencias y se cambia a la otra posicion
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

        //Devuelve si un movimiento es legal o no
        public bool PuedeMoverseA(Casillero casilleroNuevo)
        {
            if (casilleroNuevo.EstaVacio() && (this.distanciaRecorrida < 4)) return true;
            return false;
        }

        // Devuelve si se cumplio el tiempo del retardo para poder explotarse
        private bool PasoTiempoDeRetardo(double porcentajeRetardo = 1)
        {
            return true;
        }

        public int Velocidad
        {
            get { return this.velocidad; }

        }
        
    }
}
