using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Elementales;

namespace TP2_Bomberman
{
    public class Bombita : Personaje
    {
        private int vidas = 3;
        private bool poseeBombaToleTole;

        public Bombita()
            : base()
        {
            this.resistencia = 1;
            this.bomba = new Molotov(); //Inicialmente tiene una molotov
            bomba.Duenio = this;
            this.velocidad = 2;
            this.poseeBombaToleTole = false;
        }

        // Bombita pierde una vida con cualquier bomba que se lo danie
        public override void DaniarConMolotov(Molotov molotov)
        {
            DaniarConBomba();
        }
        public override void DaniarConToleTole(ToleTole toleTole)
        {
            DaniarConBomba();
        }
        public override void DaniarConProyectil(Proyectil proyectil)
        {
            DaniarConBomba();
        }

        // Metodo general. Pierde una vida y vuelve a su estado original
        private void DaniarConBomba()
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vidas--;
            if (FueDestruido())
            {
                this.posicion.Entidad = null;
            }
            VolverAtributosAEstadoOriginal();
        }

        // Lo hace cada vez que se muere asi le saca todos los articulos que pueda llegar a tener
        private void VolverAtributosAEstadoOriginal()
        {
            this.porcentajeDeRetardo = 1;
            this.bomba = new Molotov();
            bomba.Duenio = this;
            this.velocidad = 2;
            this.poseeBombaToleTole = false;
        }

        // Devuelve si no tiene mas vidas o no
        public override bool FueDestruido()
        {
            if (this.vidas == 0) return true;
            return false;
        }

        // Deja una bomba activada en el lugar donde estaba
        public void LanzarBomba()
        {
            if (bomba.FueDestruido())//Le permite agregar otra bomba si la anterior ya ha explotado
            {
                if (poseeBombaToleTole)
                {
                    bomba = new ToleTole();
                }
                else
                {
                    bomba = new Molotov();
                }
                bomba.RetardoAdquirido = porcentajeDeRetardo;
                bomba.Duenio = this;
            }
            else if (bomba.EstaActivada)
            {
                return;
            }
            this.tablero.AgregarEntidadEnCasillero(bomba, posicion.Fila, posicion.Columna);
            tablero.AgregarBomba(bomba);
            bomba.ActivarBomba();
        }


        public void AgarrarArticulo(Articulo articulo)
        {
            articulo.UtilizarArticuloEn(this);
        }


        //Propiedades
        public int Vidas
        {
            get { return this.vidas; }
            set { this.vidas = value; }
        }
        
        public bool PoseeBombaToleTole
        {
            set { this.poseeBombaToleTole = value; }
        }

    }
}
