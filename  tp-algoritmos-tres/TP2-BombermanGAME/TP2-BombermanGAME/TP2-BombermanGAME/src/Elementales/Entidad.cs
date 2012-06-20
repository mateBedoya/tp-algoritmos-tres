using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Interfaces;

namespace TP2_Bomberman.src.Elementales
{
    /// <summary>
    /// esta clase generaliza a todas las entidades que ocupan o pueden ocupar un
    /// lugar en el tablero como ser personajes, obstaculos, bombas y articulos
    /// </summary>
    public abstract class Entidad: IDaniable
    {
        public Vector2 posicionEnVentana;
        public Texture2D textura;
        public static int[] ESTE = { 0, 1 };
        public static int[] NORTE = { -1, 0 };
        public static int[] OESTE = { 0, -1 };
        public static int[] SUR = { 1, 0 };
        protected int[] direccion;
        protected Casillero posicion;
        protected Tablero tablero;

        // crea una entidad sin posicion asignada
        public Entidad()
        {
            this.posicion = null;
        }

        // crea una entidad con una posicion asignada
        public Entidad(Casillero posicion)
        {
            if(Tablero.GetInstancia().CasilleroFueraDeRango(posicion.Fila,posicion.Columna)) throw new CasilleroFueraDeRangoException();
            this.posicion = posicion;
        }

        public virtual void Chocar(Personaje personaje) { }

        // cambia de direccion
        public void Direccionar(int[] direccion)
        {
            this.direccion = direccion;
        }

        // Devuelve si se trata de Bombita
        public bool EsBombita()
        {
            if (this is Bombita) return true;
            return false;
        }

        // Devuelve si se trata de un Articulo
        public bool EsArticulo()
        {
            if (this is Articulo) return true;
            return false;
        }

        // Devuelve si se trata de la Salida
        public bool EsSalida()
        {
            if (this is Salida) return true;
            return false;
        }

        // Propiedad Posicion
        public Casillero Posicion
        {
            get { return this.posicion; }
            set { this.posicion = value; }
        }

        public Tablero Tablero
        {
            get { return this.tablero; }
            set { this.tablero = value; }
        }



        virtual internal void AgregarArticulo(Articulo articulo)
        {
        }

        public virtual void DaniarConMolotov(Molotov molotov){}
        public virtual void DaniarConToleTole(Bombas.ToleTole toleTole){}
        public virtual void DaniarConProyectil(Bombas.Proyectil proyectil) { }

    }
}
