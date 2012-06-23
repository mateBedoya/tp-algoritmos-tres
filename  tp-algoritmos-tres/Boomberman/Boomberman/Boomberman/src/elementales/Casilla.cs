using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Juego.obstaculos;
using TP2.Juego.bombas;
using TP2.Juego.articulos;
using TP2.src.Elementales;

namespace TP2.Elementales
{
    public class Casilla
    {
        private int X;
        private int Y;
        private List<Entidad> entidades;

        // crea una casilla vacia con una posicion en el tablero
        public Casilla(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.entidades = new List<Entidad>();
        }


        // retorna la fila que ocupa en el tablero
        public int GetX()
        {
            return (this.X);
        }


        // retorna la columna que ocupa en el tablero
        public int GetY()
        {
            return (this.Y);
        }


        // retorna la casilla adyacente en la direccion pasada
        public Casilla CasillaAdyacenteEnLaDireccion(int[] direccion)
        {
            return (Tablero.GetInstancia().Casilla(this.X + direccion[0], this.Y + direccion[1]));
        }


        // agrega una entidad a la casilla
        public void AgregarEntidad(Entidad entidad)
        {
            this.entidades.Add(entidad);
        }


        // remueve la entidad pasada
        public void RemoverEntidad(Entidad entidad)
        {
            entidad.Destruir();
            this.entidades.Remove(entidad);
        }


        // remueve a aquellas entidades que fueron destruidas
        public void RemoverEntidades()
        {
            List<Entidad> copiaDeEntidades = this.entidades;
            int cantidadDeEntidades = 0;
            while (cantidadDeEntidades < this.entidades.Count)
            {
                Entidad entidad = copiaDeEntidades[cantidadDeEntidades];
                if (entidad.FueDestruido())
                    this.RemoverEntidad(entidad);
                else
                    cantidadDeEntidades++;
            }
        }


        // retorna las entidades 
        public List<Entidad> GetEntidades()
        {
            return (this.entidades);
        }


        // retorna la cantidad de entidades
        public int CantidadDeEntidades()
        {
            return (this.entidades.Count());
        }


        // retorna la cantidad de entidades enemigas
        public int CantidadDeEnemigos()
        {
            int indice = 0;
            int cantidadDeEnemigos = 0;
            while(indice < this.CantidadDeEntidades())
            {
                if(this.entidades[indice].EsEnemigo())
                    cantidadDeEnemigos++;
                indice++;
            }
            return cantidadDeEnemigos;
        }


        // remueve todas las entidades de la casilla
        public void Vaciar()
        {
            this.entidades.RemoveRange(0, this.CantidadDeEntidades());
        }


        // retorna si la casilla esta vacia
        public bool EstaVacia()
        {
            return (this.CantidadDeEntidades() == 0);
        }


        // retorna si contiene un personaje
        public bool TienePersonaje()
        {
            int indice = 0;
            while (indice < this.CantidadDeEntidades())
            {
                if (entidades[indice].EsPersonaje())
                    return true;
                indice++;
            }
            return false;
        }


        // retorna si contiene un obstaculo
        public bool TieneObstaculo()
        {
            int indice = 0;
            while (indice < this.CantidadDeEntidades())
            {
                if (entidades[indice].EsObstaculo())
                    return true;
                indice++;
            }
            return false;
        }


        // retorna si contiene una bomba
        public bool TieneBomba()
        {
            int indice = 0;
            while (indice < this.CantidadDeEntidades())
            {
                if (entidades[indice].EsBomba())
                    return true;
                indice++;
            }
            return false;
        }


        // retorna si contiene un articulo
        public bool TieneArticulo()
        {
            int indice = 0;
            while (indice < this.CantidadDeEntidades())
            {
                if (entidades[indice].EsArticulo())
                    return true;
                indice++;
            }
            return false;
        }
    }
}
