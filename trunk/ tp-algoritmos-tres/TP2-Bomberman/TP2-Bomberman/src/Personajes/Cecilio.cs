using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    public class Cecilio : Enemigo
    {
        public Cecilio()
            :base()
        {
            this.resistencia = 5;
            this.bomba = new Molotov();
        }

        public Cecilio(Casillero posicion)
            :base(posicion)
        {
            this.resistencia = 5;
            this.bomba = new Molotov();
        }

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

        
    }
}
