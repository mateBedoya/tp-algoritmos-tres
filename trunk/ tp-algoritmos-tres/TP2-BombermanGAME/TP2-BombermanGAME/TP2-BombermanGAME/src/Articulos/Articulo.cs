using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.src.Articulos
{
    public abstract class Articulo: Entidad, IDestruible
    {
        protected int vida = 1; //Tienen una vida ya que con cualquier cosa que sea daniado, se destruye
        protected bool Utilizado = false;

        public Articulo()
            :base() { }

        public Articulo(Casillero posicion)
            : base(posicion) 
        {
            posicion.Entidad = this;        
        }

        // Metodo que se redefine en cada articulo y modifica las caracteristicas del personaje
        public abstract void UtilizarArticuloEn(Personaje personaje);



        // Todas las bombas lo destruyen (le sacan la unica vida que tiene)
        // menos a la salida (se redefinen)
        public override void DaniarConMolotov(Molotov molotov)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public override void DaniarConToleTole(Bombas.ToleTole toleTole)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public override void DaniarConProyectil(Bombas.Proyectil proyectil)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vida = 0;
        }
        public virtual bool FueDestruido()
        {
            return (this.vida == 0);
        }
        public virtual bool FueUtilizado()
        {
            return (this.Utilizado);
        }


        // Metodo que maneja la "colision" entre un personaje y un articulo.
        // Esto se produce cuando un personaje va a la casilla donde esta el articulo
        // Al chocar, el articulo es utilizado en el personaje.
        public override void Chocar(Personaje personaje)
        {
            this.UtilizarArticuloEn(personaje);
            this.posicion.Entidad = null;
            personaje.CambiarPosicionA(this.posicion);
            this.Utilizado = true;
            this.posicion = null;
        }

    }
}
