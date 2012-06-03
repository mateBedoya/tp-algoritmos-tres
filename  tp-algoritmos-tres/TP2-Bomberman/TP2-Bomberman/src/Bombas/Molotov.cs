using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;

namespace TP2_Bomberman.src
{
    public class Molotov: Bomba,IDependienteDelTiempo
    {
        public Molotov()
        { 
            this.destruccion = 5;
            this.retardo = 1;
            this.rango = 3;
        }

        public override void Explotar()
        {
            // Aca tendria que ir recorriendo y agarrando los elementos de cada casillero e ir daniandolos llamando a 
            // Dañar(elementoDelCasillero)
        }
        public override void Daniar(IDaniable daniable)
        {
            daniable.DaniarConMolotov(this); // Uso de patron doble dipatch
        }

        public void CuandoPaseElTiempo(int tiempo)
        {
            // TODAVIA NO TERMINO DE ENTENDER COMO IMPLEMENTAR ESTO
        }

        

    }
}
