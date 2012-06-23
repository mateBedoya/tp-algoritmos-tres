using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.src.interfaces;
using TP2.Juego.personajes;
using TP2.Elementales;
using TP2.src.Juego.bombas;

namespace TP2.src.estrategias
{
    public class LanzarToleTole : IEstrategia
    {
        private Personaje aplicador;

        // crea una estrategia para lanzar una bomba tole tole con el correspondiente aplicador
        public LanzarToleTole(Personaje aplicador)
        {
            this.aplicador = aplicador;
        }


        // se aplica la estrategia
        public void Aplicar()
        {
            Casilla posicionDeLaToleTole = this.aplicador.Posicion();
            ToleTole toleTole = new ToleTole();
            Tablero.GetInstancia().AgregarEntidad(toleTole, posicionDeLaToleTole.GetX(), posicionDeLaToleTole.GetY());
            toleTole.Direccionar(aplicador.Direccion());
            toleTole.RetardoAdquirido(aplicador.PorcentajeDeRetardo());
            toleTole.AnotarLanzador(aplicador);
        }
    }
}
