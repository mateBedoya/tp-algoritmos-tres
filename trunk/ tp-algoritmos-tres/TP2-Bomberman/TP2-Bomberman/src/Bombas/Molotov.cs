using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    class Molotov: Bomba,IExplotable,IDependienteDelTiempo
    {
        public Molotov()
        { 
            this.destruccion = 5;
            this.retardo = 1;
            this.rango = 3;
        }

        public void explotar()
        {
            
        }

        public void CuandoPaseElTiempo(int tiempo)
        {
        }

        public object Destruccion 
        {
            get {return this.destruccion ;}  
        }

        public object Retardo
        {
            get { return this.retardo; }
        }


        public object Rango
        {
            get { return this.rango; }
        }

    }
}
