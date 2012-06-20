using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Articulos;

namespace TP2_Bomberman.src.Obstaculos
{
    public abstract class Obstaculo: Entidad, IDestruible
    {
        protected int resistencia;
        protected Articulo articulo;

        public Obstaculo()
            : base() { }

        public Obstaculo(Casillero posicion)
            : base(posicion) 
        {
            posicion.Entidad = this;
        }
        

        //Danios por bombas

        // Para todos los obstaculos es de la misma forma. La bomba tole tole los destruye cualquiera sea el obstaculo
        public override void DaniarConToleTole(Bombas.ToleTole toleTole)
        {
            try
            {
                DaniarConBomba(toleTole);
            }
            catch (EntidadYaDestruidaException) { }
        }

        public override void DaniarConMolotov(Molotov molotov)
        {
            try
            {
                DaniarConBomba(molotov);
            }
            catch (EntidadYaDestruidaException) { }
        }

        public override void DaniarConProyectil(Bombas.Proyectil proyectil)
        {
            try
            {
                DaniarConBomba(proyectil);
            }
            catch (EntidadYaDestruidaException) { }
        }

        // Metodo general para el daño producido por una bomba
        public virtual void DaniarConBomba(Bomba bomba)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.resistencia = this.resistencia - bomba.Destruccion;
            if (FueDestruido())
            {
                if (this.articulo != null)
                {
                    this.posicion.Entidad = this.articulo;
                    this.articulo.Posicion = this.posicion;
                }
                else
                {
                    this.posicion.Entidad = null;
                }
                this.posicion = null;
            }
        }
            

        //devuelve si un elemento fue destruido o no
        public bool FueDestruido() // Un obstaculo esta destruido cuando no tiene resistencia
        {
            if (this.resistencia <= 0)
            {
                return true;
            }
            return false;
        }

        //Metodo para el movimiento del LopezRAlado
        //Este puede moverse por todos lados, por lo tanto puede
        //pasar por encima de los obstaculos
        public virtual void Chocar(LopezRAlado lopez)
        {
            lopez.CambiarPosicionA(this.posicion);
        }

        

        // Propiedades
        public int Resistencia
        {
            get { return this.resistencia; }
        }

        public Articulo Articulo
        {
            get { return this.articulo; }
            set { this.articulo = value; }
        }

    }
}
