using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.interfaces;
using BoombermanGame.src.excepciones;

namespace BoombermanGame.src.bombas
{
    public class Proyectil : Bomba
    {
        private static int DANIO = 4;
        public static int RANGO = 1;
        private static double RETARDO = 0;
        private static double RETARDO_DE_MOVIMIENTO = 5;
        private int danio;
        private double retardoDeMovimiento;


        // crea un proyectil
        public Proyectil()
            : base(RANGO, RETARDO)
        {
            this.danio = DANIO;
            this.retardoDeMovimiento = 0;
        }


        // crea un proyectil
        public Proyectil(Casilla posicion)
            : base(posicion, RANGO, RETARDO)
        {
            this.danio = DANIO;
            this.retardoDeMovimiento = 0;
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
            if (this.retardoDeMovimiento == 0)
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
                    this.Explotar();
                }
                this.retardoDeMovimiento = RETARDO_DE_MOVIMIENTO;
            }
            else
                retardoDeMovimiento--;
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
            if (this.direccion == ESTE)
                return ("ProyectilDerecha");
            if (this.direccion == NORTE)
                return ("ProyectilArriba");
            if (this.direccion == OESTE)
                return ("ProyectilIzquierda");
            return ("ProyectilAbajo");
        }


        // metodo utilizado por el controlador
        public override void Actuar()
        {
            this.Explotar();
            this.Mover();
        }
    }
}
