using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;

namespace TP2_BombermanGAME.src.Bombas
{
    public class Explosion: Entidad, IDependienteDelTiempo
    {
        public Bomba bomba;
        private double tiempoTranscurrido = 0;

        public Explosion(Bomba bomba)
        {
            this.bomba = bomba;
        }
        
        public void CuandoPaseElTiempo(double tiempo)
        {
            tiempoTranscurrido = tiempoTranscurrido + tiempo;
            if (tiempoTranscurrido >= 1)
            {
                this.posicion = null;
            }
        }
    }
}
