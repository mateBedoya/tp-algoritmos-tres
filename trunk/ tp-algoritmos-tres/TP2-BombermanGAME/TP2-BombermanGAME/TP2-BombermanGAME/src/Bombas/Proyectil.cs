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
            this.destruccion = 5;
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




        //Metodos de movimiento
        private void Mover()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(this.direccion, this.tablero));
                if (this.distanciaRecorrida == 4) ActivarBomba();
            }
            catch (CasilleroFueraDeRangoException) { }
            catch (MovimientoInvalidoException)
            {
                ActivarBomba(); //Cuando se encuentra con algo, se activa
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
        
    }
}
