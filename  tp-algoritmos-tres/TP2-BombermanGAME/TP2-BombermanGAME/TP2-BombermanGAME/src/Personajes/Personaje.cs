using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Personajes;


namespace TP2_Bomberman.src
{
    public abstract class Personaje : Entidad,IMovible,IDestruible
    {
        protected int resistencia;
        protected int velocidad;
        protected Bomba bomba;
        protected double porcentajeDeRetardo = 1; //Empieza con un retardo normal de la bomba incorporada (100%)
        protected string ultimaDireccion = "";
        
        public Personaje()
            :base()
        {
            this.velocidad = 1; // Único atributo compartido por todos los personajes.
        }

        public Personaje(Casillero posicion)
            : base(posicion) 
        {
            posicion.Entidad = this;
            this.posicion = posicion;
        }

        
        //Metodos de movimiento

        // Metodo general
        private void Mover()
        {
            try
            {
                CambiarPosicionA(posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(this.direccion,this.tablero));
            }
            catch (CasilleroFueraDeRangoException e) { throw e; }
            catch(MovimientoInvalidoException)
            {
                Entidad entidad = posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(this.direccion, this.tablero).Entidad;
                entidad.Chocar(this);
            }
        }

        public void MoverArriba()
        {
            this.Direccionar(NORTE);
            this.Mover();
            ultimaDireccion = "norte";
        }
        public void MoverAbajo()
        {
            this.Direccionar(SUR);
            this.Mover();
            ultimaDireccion = "sur";
        }
        public void MoverDerecha()
        {
            this.Direccionar(ESTE);
            this.Mover();
            ultimaDireccion = "este";
        }
        public void MoverIzquierda()
        {
            this.Direccionar(OESTE);
            this.Mover();
            ultimaDireccion = "oeste";
        }


        // Para el movimiento, verifica si el movimiento es legal y cambia las referencias
        public void CambiarPosicionA(Casillero casilleroNuevo)
        {

            if (!PuedeMoverseA(casilleroNuevo))
            {
                throw new MovimientoInvalidoException();
            }
            posicion.Entidad = null;
            casilleroNuevo.Entidad = this;
            posicion = casilleroNuevo;
            //if (this.EsBombita()) this.tablero.PosicionBombita = casilleroNuevo;
        }

        // Define si el movimiento es legal o no.
        public virtual bool PuedeMoverseA(Casillero casilleroNuevo)
        {
            if (casilleroNuevo.EstaVacio()) return true;
            return false;
        }

        //Metodos abstractos a definir en los hijos
        public override void DaniarConMolotov(Molotov molotov){}
        public override void DaniarConToleTole(Bombas.ToleTole toleTole) { }
        public override void DaniarConProyectil(Bombas.Proyectil proyectil) { }
        public abstract bool FueDestruido();


        //Propiedades
        public int Resistencia
        {
            get { return this.resistencia; }
        }

        public int Velocidad
        {
            get { return this.velocidad; }
            set { this.velocidad = value; }
        }

        public Bomba Bomba
        {
            get { return this.bomba;}
            set { this.bomba = value; }
        }

        public double PorcentajeDeRetardo
        {
            get { return this.porcentajeDeRetardo; }
            set { this.porcentajeDeRetardo = value; }
        }

        public string Direccion
        {
            get { return this.ultimaDireccion; }
        }
        
    }
}
