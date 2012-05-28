using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TP2
{
    public class Punto
    {
        private double coordenadaX, coordenadaY;

        // crea un punto nulo
        public Punto()
        {
            this.coordenadaX = 0;
            this.coordenadaY = 0;
        }

        // crea un punto asignandole coordenada X e Y
        public Punto(double coordenadaX, double coordenadaY)
        {
            this.coordenadaX = coordenadaX;
            this.coordenadaY = coordenadaY;
        }

        // retorna la coordenada X 
        public double GetX()
        {
            return (this.coordenadaX);
        }

        //retorna la coordenada Y
        public double GetY()
        {
            return (this.coordenadaY);
        }

        // se desplaza un delta X y un delta Y
        public void Desplazar(double deltaX, double deltaY)
        {
            this.coordenadaX = this.coordenadaX + deltaX;
            this.coordenadaY = this.coordenadaY + deltaY;
        }

        // retorna la distancia con el punto pasado
        public double DistanciaA(Punto punto)
        {
            double X = this.coordenadaX - punto.GetX();
            double Y = this.coordenadaY - punto.GetY();
            X = Math.Pow(X, 2);
            Y = Math.Pow(Y, 2);
            return (Math.Sqrt(X + Y));
        }
    }
}
