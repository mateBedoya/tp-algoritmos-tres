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

        public Bombita()
            : base()
        {
            this.resistencia = 1;
            this.bomba = new Molotov(); //Inicialmente tiene una molotov
        }

        // Bombita pierde una vida con cualquier bomba que se lo danie
        public override void DaniarConMolotov(Molotov molotov)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vidas--;
            VolverAtributosAEstadoOriginal();
        }
        public override void DaniarConToleTole(ToleTole toleTole)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vidas--;
            VolverAtributosAEstadoOriginal();
        }
        public override void DaniarConProyectil(Proyectil proyectil)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.vidas--;
            VolverAtributosAEstadoOriginal();
        }

        // Lo hace cada vez que se muere asi le saca todos los articulos que pueda llegar a tener
        private void VolverAtributosAEstadoOriginal()
        {
            this.porcentajeDeRetardo = 1;
            this.bomba = new Molotov();
            this.velocidad = 5;
        }

        // Devuelve si no tiene mas vidas o no
        public override bool FueDestruido()
        {
            if (this.vidas == 0) return true;
            return false;
        }


        public void LanzarBomba()
        {
            if (bomba.FueDestruido())//Le permite agregar otra bomba si la anterior ya ha explotado
            {
                if (bomba is Molotov)// MEJORAR ESTO!!!!!!
                {
                    bomba = new Molotov();
                }
                else
                {
                    bomba = new ToleTole();
                }
                bomba.RetardoAdquirido = porcentajeDeRetardo;
            }
            else if (bomba.EstaActivada)
            {
                return;
            }
            this.tablero.AgregarEntidadEnCasillero(bomba, posicion.Fila, posicion.Columna);
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


    }
}
