using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Elementales;
using TP2.src.Juego.bombas;
using TP2.src.interfaces;

namespace TP2.src.estrategias
{
    public class LanzarProyectil : IEstrategia
    {
        private Personaje aplicador;

        // crea una estrategia para lanzar una bomba molotov con el correspondiente aplicador
        public LanzarProyectil(Personaje aplicador)
        {
            this.aplicador = aplicador;
        }


        // se aplica la estrategia
        public void Aplicar()
        {
            Casilla posicionDelProyectil = this.aplicador.Posicion();
            Proyectil proyectil = new Proyectil();
            Tablero.GetInstancia().AgregarEntidad(proyectil, posicionDelProyectil.GetX(), posicionDelProyectil.GetY());
            proyectil.Direccionar(aplicador.Direccion());
            proyectil.RetardoAdquirido(aplicador.PorcentajeDeRetardo());
            proyectil.AnotarLanzador(aplicador);
        }
    }
}
