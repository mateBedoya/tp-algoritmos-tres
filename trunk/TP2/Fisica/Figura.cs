using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.Fisica
{
    public abstract class Figura : Intersecable
    {
        protected Punto posicion;

        // crea una figura posicionada en el origen del plano XY
        public Figura()
        {
            this.posicion = new Punto();
        }

        // crea una figura asignandole una posicion dada en el plano XY
        public Figura(Punto posicion)
        {
            this.posicion = posicion;
        }

        // posiciona a la figura 
        public void Posicionar(Punto posicion)
        {
            this.posicion = posicion;
        }

        // retorna la posicion actual de la figura
        public Punto GetPosicion()
        {
            return (this.posicion);
        }

        // se traslada por el plano XY
        public void Trasladar(double deltaX, double deltaY)
        {
            this.posicion.Desplazar(deltaX, deltaY);
        }

        // cada figura en particular debe implementar si se encuentra 
        // o no dentro de los limites pasados
        public abstract bool EstaDentroDeLosLimites(Punto inferior, Punto superior);

        ///
        /// <Implementacion de la interfaz Intersecable>
        /// 

        // implementacion de la interfaz intersecable
        public abstract bool SeIntersecaConElCirculo(Figura figura);

        /// </Implementacion>

    }
}
