using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.Fisica
{
    public class Circulo: Figura
    {
        private double radio;

        // crea un circulo asignandole un radio
        public Circulo(double radio)
            : base()
        {
            if (radio < 0)
                throw new Exception("El radio debe ser mayor a cero");
            this.radio = radio;
        }

        // crea un circulo asignandole un radio y una posicion
        public Circulo(double radio, Punto posicion)
            : base(posicion)
        {
            if(radio < 0)
                throw new Exception("El radio debe ser mayor a cero");
            this.radio = radio;
        }

        // retorna el radio 
        public double GetRadio()
        {
            return (this.radio);
        }

        // retorna si el circulo se encuentra dentro de los limites pasados; se entiende
        // por limite valido, a aquel comprendido entre el vertice inferior
        // izquierdo y el vertice superior derecho del rectangulo que conforman
        public override bool EstaDentroDeLosLimites(Punto inferior, Punto superior)
        {
            return (this.posicion.GetX() - this.radio >= inferior.GetX() &&
                    this.posicion.GetY() - this.radio >= inferior.GetY() &&
                    this.posicion.GetX() + this.radio <= superior.GetX() &&
                    this.posicion.GetY() + this.radio <= superior.GetY());
        }

        ///
        /// <Implementacion de la interfaz Intersecable>
        /// 

        // retorna si el circulo se interseca con otro circulo
        public override bool SeIntersecaConElCirculo(Figura figura)
        {
            return (this.posicion.DistanciaA(figura.GetPosicion()) <=
                (((Circulo) figura).GetRadio() + this.radio));
        }

        /// </Implementacion>

        public string Esta { get; set; }
    }
}
