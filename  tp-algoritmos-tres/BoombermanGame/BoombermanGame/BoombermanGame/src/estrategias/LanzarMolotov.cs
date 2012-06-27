using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.interfaces;
using BoombermanGame.src.personajes;
using BoombermanGame.src.elementales;
using BoombermanGame.src.bombas;

namespace BoombermanGame.src.estrategias
{
    public class LanzarMolotov : IEstrategia
    {
        private Personaje aplicador;

        // crea una estrategia para lanzar una bomba molotov con el correspondiente aplicador
        public LanzarMolotov(Personaje aplicador)
        {
            this.aplicador = aplicador;
        }


        // se aplica la estrategia
        public void Aplicar()
        {
            Casilla posicionDeLaMolotov = this.aplicador.Posicion();
            Molotov molotov = new Molotov();
            Tablero.GetInstancia().AgregarEntidad(molotov, posicionDeLaMolotov.X, posicionDeLaMolotov.Y);
            molotov.Direccionar(this.aplicador.Direccion());
            molotov.CuandoPaseElTiempo(this.aplicador.PorcentajeDeRetardo());
            molotov.AnotarLanzador(this.aplicador);
        }
    }
}
