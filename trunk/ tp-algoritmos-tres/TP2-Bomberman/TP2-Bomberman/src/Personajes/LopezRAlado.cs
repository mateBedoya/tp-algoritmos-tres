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

        public override void LanzarBomba()
        {
            // FALTA IMPLEMENTAR
            // LO QUE PENSE ES QUE CUANDO LANCE UNA BOMBA, TIRE LA QUE TIENE GUARDADA EN EL ATRIBUTO "bomba"
            // E INMEDIATAMENTE CREE UNA NUEVA INSTANCIA Y LA GUARDE EN EL ATRIBUTO
        }


        //TAMBIEN FALTA VER EL TEMA DE QUE ESTE SE PUEDE MOVER POR DONDE QUIERA
    }
}
