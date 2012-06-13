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
            // FALTA IMPLEMENTAR
            // LO QUE PENSE ES QUE CUANDO LANCE UNA BOMBA, TIRE LA QUE TIENE GUARDADA EN EL ATRIBUTO "bomba"
            // E INMEDIATAMENTE CREE UNA NUEVA INSTANCIA Y LA GUARDE EN EL ATRIBUTO
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
