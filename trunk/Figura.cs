using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2
{
    public abstract class Figura
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

    }
}
