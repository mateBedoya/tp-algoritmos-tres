using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Elementales;

namespace TP2_Bomberman.src
{
    public abstract class Enemigo : Personaje
    {
        public Enemigo()
            : base() { }

        public Enemigo(Casillero posicion)
            : base(posicion) { }

        //A todos los enemigos se les baja la resistencia dependiendo de la bomba
        public override void DaniarConMolotov(Molotov molotov)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.resistencia = this.resistencia - molotov.Destruccion;        
        }

        public override void DaniarConToleTole(ToleTole toleTole)//ToleTole le saca toda la resistencia
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.resistencia = 0;
        }

        public override void DaniarConProyectil(Proyectil proyectil)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.resistencia = this.resistencia - proyectil.Destruccion;
        }
        
        public override bool FueDestruido()
        {
            if(this.resistencia <= 0) return true;
            return false;
        }

        public override void Chocar(Personaje personaje)
        {
            personaje.DaniarConMolotov(new Molotov());//EL choque hace el mismo danio que una MOLOTOV
        }

        public abstract void LanzarBomba();

    }
}
