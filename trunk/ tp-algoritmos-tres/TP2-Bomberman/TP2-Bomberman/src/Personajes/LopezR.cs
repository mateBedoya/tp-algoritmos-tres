using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Bombas;

namespace TP2_Bomberman.src
{
    public class LopezR : Enemigo
    {
        public LopezR()
            :base()
        {
            this.resistencia = 10;
            this.bomba = new Proyectil();
        }

        public LopezR(Casillero posicion)
            :base(posicion)
        {
            this.resistencia = 10;
            this.bomba = new Proyectil();
        }

        public override void LanzarBomba()
        {
            // FALTA IMPLEMENTAR
            // LO QUE PENSE ES QUE CUANDO LANCE UNA BOMBA, TIRE LA QUE TIENE GUARDADA EN EL ATRIBUTO "bomba"
            // E INMEDIATAMENTE CREE UNA NUEVA INSTANCIA Y LA GUARDE EN EL ATRIBUTO
        }
    }
}
