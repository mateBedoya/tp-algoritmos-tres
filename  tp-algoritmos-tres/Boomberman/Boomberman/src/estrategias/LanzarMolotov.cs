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
            Tablero.GetInstancia().AgregarEntidad(molotov, posicionDeLaMolotov.GetX(), posicionDeLaMolotov.GetY());
            molotov.Direccionar(this.aplicador.Direccion());
            molotov.CuandoPaseElTiempo(this.aplicador.PorcentajeDeRetardo());
            molotov.AnotarLanzador(this.aplicador);
        }
    }
}
