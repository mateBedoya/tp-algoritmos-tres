using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Personajes
{
    public class LopezRAlado : Enemigo
    {
        public LopezRAlado()
            :base()
        {
            this.resistencia = 5;
            this.bomba = new Molotov();
        }

        public LopezRAlado(Casillero posicion)
            :base(posicion)
        {
            this.resistencia = 5;
            this.bomba = new Molotov();
        }

        // Lanzamiento de la bomba. La deja activada.
        public override void LanzarBomba()
        {
            if (bomba.FueDestruido())//Le permite agregar otra bomba si la anterior ya ha explotado
            {
                bomba = new Molotov();
            }
            else if (bomba.EstaActivada)
            {
                return;
            }
            this.tablero.AgregarEntidadEnCasillero(bomba, posicion.Fila, posicion.Columna);
            bomba.ActivarBomba();
        }

        // Redefine que puede moverse por cualquier lado menos si hay un personaje
        public override bool PuedeMoverseA(Casillero casilleroNuevo)
        {
            if (casilleroNuevo.TienePersonaje()) return false;
            return true;
        }
    }
}
