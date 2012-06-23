using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.bombas;
using TP2.Elementales;
using TP2.src.Interfaces;
using TP2.src.Elementales;
using TP2.src.interfaces;
using TP2.src.excepciones;
using Boomberman.src.interfaces;
using Boomberman.src.vistas;

namespace TP2.src.Juego.bombas
{
    public class Proyectil : Bomba
    {
        private static int DANIO = 4;
        private static int RANGO = 1;
        private static double RETARDO = 0;
        private int danio;


        // crea un proyectil
        public Proyectil()
            : base(RANGO, RETARDO)
        {
            this.danio = DANIO;
        }


        // crea un proyectil
        public Proyectil(Casilla posicion)
            : base(posicion, RANGO, RETARDO)
        {
            this.danio = DANIO;
        }


        // retorna el danio que produce
        public int GetDanio()
        {
            return (this.danio);
        }


        // dania a las entidades pasadas
        public override void Daniar(List<Entidad> daniables)
        {
            int indice = 0;
            while (indice < daniables.Count())
            {
                IDaniable daniable = daniables[indice];
                daniable.DaniarPorProyectil(this);
                indice++;
            }
        }


        // un personaje puede moverse solo si la proxima casilla esta vacia
        public bool PuedeMoverseA(Casilla proximaPosicion)
        {
            if (proximaPosicion.EstaVacia())
                return true;
            return false;
        }


        // aplica el movimiento en la direccion actual
        public void Mover()
        {
            try
            {
               Casilla proximaPosicion = this.posicion.CasillaAdyacenteEnLaDireccion(this.direccion);
               if (this.PuedeMoverseA(proximaPosicion))
               {
                    this.posicion.RemoverEntidad(this);
                    this.PosicionarEn(proximaPosicion);
               }
            }
            catch (CasillaFueraDeRangoError e)
            {
                e.NoHacerNada();
            }
        }


        // explota cuando en su proxima posicion hay un objeto o cuando 
        // su proxima posicion esta fuera de rango
        public override void Explotar()
        {
            try
            {
                Casilla proximaPosicion = this.posicion.CasillaAdyacenteEnLaDireccion(this.direccion);
                if (!proximaPosicion.EstaVacia())
                    base.Explotar();
            }
            catch (CasillaFueraDeRangoError e)
            {
                e.NoHacerNada();
                base.Explotar();
            }
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "Vacio";
        }


        // metodo utilizado por el controlador
        public override void Actuar()
        {
            this.Mover();
            this.Explotar();
        }

    }
}
