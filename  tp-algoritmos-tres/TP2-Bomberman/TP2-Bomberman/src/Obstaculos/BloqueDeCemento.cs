using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Articulos;

namespace TP2_Bomberman.src.Obstaculos
{
    public class BloqueDeCemento: Obstaculo
    {
        public BloqueDeCemento()
            :base()
        {
            this.resistencia = 10;
        }
        public BloqueDeCemento(Casillero posicion)
            : base(posicion)
        {
            this.resistencia = 10;
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

        internal override void AgregarArticulo(Articulo articulo)
        {
            this.articulo = articulo;
        }


    }
}
