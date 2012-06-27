﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.interfaces;
using BoombermanGame.src.personajes;
using BoombermanGame.src.bombas;
using BoombermanGame.src.excepciones;
using BoombermanGame.src.elementales;

namespace BoombermanGame.src.estrategias
{
    public class LanzarProyectil : IEstrategia
    {
        private Personaje aplicador;

        // crea una estrategia para lanzar una bomba molotov con el correspondiente aplicador
        public LanzarProyectil(Personaje aplicador)
        {
            this.aplicador = aplicador;
        }


        // se aplica la estrategia solo si el aplicador esta a una distancia 
        // valida para disparar y no ser daniado por el proyectil
        public void Aplicar()
        {
            Casilla posicionDelProyectil = this.aplicador.Posicion();
            int[] direccionDelProyectil = this.aplicador.Direccion();
            int rangoDelProyectil = Proyectil.RANGO;
            try
            {
                Casilla posicionAdyacente = posicionDelProyectil.CasillaAdyacenteEnLaDireccion(direccionDelProyectil);
                bool puedeAplicarse = true;
                while (rangoDelProyectil >= 0 && puedeAplicarse)
                {
                    if (!posicionAdyacente.EstaVacia())
                        puedeAplicarse = false;
                    rangoDelProyectil--;
                    posicionAdyacente = posicionAdyacente.CasillaAdyacenteEnLaDireccion(direccionDelProyectil);
                }
                if (puedeAplicarse)
                {
                    Proyectil proyectil = new Proyectil();
                    Tablero.GetInstancia().AgregarEntidad(proyectil, posicionDelProyectil.X, posicionDelProyectil.Y);
                    proyectil.Direccionar(this.aplicador.Direccion());
                    proyectil.CuandoPaseElTiempo(this.aplicador.PorcentajeDeRetardo());
                    proyectil.AnotarLanzador(this.aplicador);
                }
                else
                    this.aplicador.NotificarExplosion(true);
            }
            catch (CasillaFueraDeRangoError e)
            {
                e.NoHacerNada();
                this.aplicador.NotificarExplosion(true);
            }
        }        
    }
}
