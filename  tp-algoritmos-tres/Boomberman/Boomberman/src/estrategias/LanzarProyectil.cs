using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Elementales;
using TP2.src.Juego.bombas;
using TP2.src.interfaces;
using TP2.src.excepciones;

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
