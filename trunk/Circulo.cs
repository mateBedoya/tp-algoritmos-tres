using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2
{
    public class Circulo: Figura, Intersecable
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

        // retorna si el circulo se interseca con otro circulo
        public bool SeIntersecaConElCirculo(Circulo circulo)
        {
            return (posicion.DistanciaA(circulo.GetPosicion()) <=
                (circulo.GetRadio() + this.radio));
        }

       

    }
}
