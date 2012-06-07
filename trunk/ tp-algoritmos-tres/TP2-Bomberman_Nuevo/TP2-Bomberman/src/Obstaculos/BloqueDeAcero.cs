using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.src.Obstaculos
{
    public class BloqueDeAcero: Obstaculo
    {
        public BloqueDeAcero()
            :base()
        {
            this.resistencia = 100000; //Mucha resistencia, es decir, solo se puede destruir con bomba toletole
        }
        public BloqueDeAcero(Casillero posicion)
            : base(posicion)
        {
            this.resistencia = 100000;
        }

        public override void DaniarConMolotov(Molotov molotov)
        {
            //No le hace nada
            if (FueDestruido()) throw new EntidadYaDestruidaException();
        }

        public override void DaniarConProyectil(Bombas.Proyectil proyectil)
        {
            //No le hace nada
            if (FueDestruido()) throw new EntidadYaDestruidaException();
        }


    }
}
