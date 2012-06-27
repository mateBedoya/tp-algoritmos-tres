using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.interfaces;
using BoombermanGame.src.personajes;
using BoombermanGame.src.bombas;
using BoombermanGame.src.elementales;

namespace BoombermanGame.src.estrategias
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
            Tablero.GetInstancia().AgregarEntidad(toleTole, posicionDeLaToleTole.X, posicionDeLaToleTole.Y);
            toleTole.Direccionar(this.aplicador.Direccion());
            toleTole.CuandoPaseElTiempo(this.aplicador.PorcentajeDeRetardo());
            toleTole.AnotarLanzador(this.aplicador);
        }
    }
}
