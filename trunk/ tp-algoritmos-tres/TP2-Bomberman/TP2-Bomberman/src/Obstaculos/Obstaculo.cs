using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Personajes;

namespace TP2_Bomberman.src.Obstaculos
{
    public abstract class Obstaculo: Entidad, IDaniable, IDestruible
    {
        protected int resistencia;

        public Obstaculo()
            : base() { }

        public Obstaculo(Casillero posicion)
            : base(posicion) 
        {
            posicion.Entidad = this;
        }
        
        // MEtodos abstractos a definir en los hijos
        public abstract void DaniarConMolotov(Molotov molotov);
        public abstract void DaniarConProyectil(Bombas.Proyectil proyectil);

        // Para todos los obstaculos es de la misma forma. La bomba tole tole los destruye cualquiera sea el obstaculo
        public void DaniarConToleTole(Bombas.ToleTole toleTole)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.resistencia = 0;
        }

        //devuelve si un elemento fue destruido o no
        public bool FueDestruido() // Un obstaculo esta destruido cuando no tiene resistencia
        {
            if (this.resistencia <= 0) return true;
            return false;
        }

        public virtual void Chocar(LopezRAlado lopez)
        {
            lopez.CambiarPosicionA(this.posicion);
        }

        // Propiedades
        public int Resistencia
        {
            get { return this.resistencia; }
        }

    }
}
