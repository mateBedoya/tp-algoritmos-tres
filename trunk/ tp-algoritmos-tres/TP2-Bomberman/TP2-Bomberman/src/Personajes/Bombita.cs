using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman
{
    public class Bombita : Personaje
    {
        private int vidas = 3;
        
        public Bombita()
            :base()
        {
            this.resistencia = 1;
            Casillero casilleroInicial = new Casillero(0, 0);
            this.posicion = casilleroInicial; //Que bombita empiece siempre en el casillero (0,0)
            casilleroInicial.Personaje = this;
        }

        // Bombita pierde una vida con cualquier bomba que se lo danie
        public override void DaniarConMolotov(Molotov molotov) 
        {
            if(FueDestruido()) throw new EntidadYaDestruidaException();
            this.vidas--;
        }
        public override void DaniarConToleTole(ToleTole toleTole) 
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vidas--;
        }
        public override void DaniarConProyectil(Proyectil proyectil) 
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vidas--;
        }
        

        // Devuelve si no tiene mas vidas o no
        public override bool FueDestruido()
        {
            if (this.vidas == 0) return true;
            return false;
        }


        public void LanzarBomba()
        {
            // FALTA IMPLEMENTAR
        }

        

        //Propiedades
        public int Vidas
        {
            get { return this.vidas;}
        }
    }
}
