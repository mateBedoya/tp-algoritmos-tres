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
            posicion.Articulo = this;        
        }

        public abstract void UtilizarArticuloEn(Bombita bombita);



        // Todas las bombas lo destruyen (le sacan la unica vida que tiene)
        public void DaniarConMolotov(Molotov molotov)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public void DaniarConToleTole(Bombas.ToleTole toleTole)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public void DaniarConProyectil(Bombas.Proyectil proyectil)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public bool FueDestruido()
        {
            return (this.vida == 0);
        }

    }
}
