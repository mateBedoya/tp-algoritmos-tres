using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Elementales
{
    /// <summary>
    /// esta clase generaliza a todas las entidades que ocupan o pueden ocupar un
    /// lugar en el tablero como ser personajes, obstaculos, bombas y articulos
    /// </summary>
    public abstract class Entidad
    {
        protected Casillero casilleroPosicion;

        // crea una entidad sin casillero- posicion asignado
        public Entidad()
        {
            this.casilleroPosicion = CasilleroNull.GetInstancia();
        }

        // crea una entidad con casillero- posicion
        public Entidad(Casillero casilleroPosicion)
        {
            this.casilleroPosicion = casilleroPosicion;
        }

        // retorna su casillero- posicion actual
        public Casillero GetPosicion()
        {
            return (this.casilleroPosicion);
        }

        // posiciona a la entidad 
        public void Posicionar(Casillero casilleroPosicion)
        {
            this.casilleroPosicion = casilleroPosicion;
        }
    }
}
