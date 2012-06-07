using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.src.Obstaculos
{
    public class BloqueDeLadrillos: Obstaculo
    {
        public BloqueDeLadrillos()
            :base()
        {
            this.resistencia = 5;
        }

        public BloqueDeLadrillos(Casillero posicion)
            : base(posicion)
        {
            this.resistencia = 5;
        }

        public override void DaniarConMolotov(Molotov molotov)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.resistencia = this.resistencia - molotov.Destruccion;
            if (FueDestruido())
            {
                if (this.articulo != null)
                {
                    this.posicion.Entidad = this.articulo;
                    this.articulo.Posicion = this.posicion;
                }
                this.posicion = null;                
            }
        }

        public override void DaniarConProyectil(Bombas.Proyectil proyectil)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.resistencia = this.resistencia - proyectil.Destruccion;
            if (FueDestruido())
            {
                if (this.articulo != null)
                {
                    this.posicion.Entidad = this.articulo;
                    this.articulo.Posicion = this.posicion;
                }
                this.posicion = null;
            }
        }

        
    }
}
