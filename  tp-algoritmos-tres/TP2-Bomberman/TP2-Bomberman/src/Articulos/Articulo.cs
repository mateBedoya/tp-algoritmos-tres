using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.src.Articulos
{
    public abstract class Articulo: Entidad, IDaniable, IDestruible
    {
        protected int vida = 1;

        public Articulo()
            :base() { }

        public Articulo(Casillero posicion)
            : base(posicion) 
        {
            posicion.Entidad = this;        
        }

        public abstract void UtilizarArticuloEn(Personaje personaje);



        // Todas las bombas lo destruyen (le sacan la unica vida que tiene)
        // menos a la salida (se redefinen)
        public virtual void DaniarConMolotov(Molotov molotov)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public virtual void DaniarConToleTole(Bombas.ToleTole toleTole)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public virtual void DaniarConProyectil(Bombas.Proyectil proyectil)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public virtual bool FueDestruido()
        {
            return (this.vida == 0);
        }

        public override void Chocar(Personaje personaje)
        {
            this.UtilizarArticuloEn(personaje);
            this.posicion.Entidad = null;
            personaje.CambiarPosicionA(this.posicion);
            this.posicion = null;
        }

    }
}
