using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.src.Articulos
{
    public class Salida : Articulo
    {
        public Salida()
            : base() { }

        public Salida(Casillero posicion)
            : base(posicion) { }

        // Se termina el nivel cuando se lo "agarra". Esto sucede si ya no quedan mas enemigos en el tablero
        public override void UtilizarArticuloEn(Personaje personaje)
        {
            /*if (tablero.CantidadEnemigosVivos() == 0)*/ tablero.avanzarNivel();
        }

        //La salida NUNCA puede ser destruida
        public override bool FueDestruido() { return false; }

        public override void Chocar(Personaje personaje)
        {
            if (tablero.CantidadEnemigosVivos() == 0)
            {
                this.UtilizarArticuloEn(personaje);
                //if (tablero.CantidadEnemigosVivos() != 0)
                //{
                //    throw new MovimientoInvalidoException();
                //}
                this.posicion.Entidad = null;
                personaje.CambiarPosicionA(this.posicion);
                this.Utilizado = true;
                this.posicion = null;
            }
        }


    }
}
