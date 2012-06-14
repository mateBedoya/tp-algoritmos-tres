using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Interfaces;

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
            DaniarConBomba(molotov);        
        }

        public override void DaniarConToleTole(ToleTole toleTole)//ToleTole le saca toda la resistencia
        {
            DaniarConBomba(toleTole);

        }

        public override void DaniarConProyectil(Proyectil proyectil)
        {
            DaniarConBomba(proyectil);
        }

        // Metodo general para cuando se dania con una bomba
        public virtual void DaniarConBomba(Bomba bomba)
        {
            if (FueDestruido()) throw new EntidadYaDestruidaException();
            this.resistencia = this.resistencia - bomba.Destruccion;
        }
        
        public override bool FueDestruido()
        {
            if(this.resistencia <= 0) return true;
            return false;
        }

        // Metodo que maneja las colisiones. Si bombita se choca con otro personaje pierde vida
        public override void Chocar(Personaje personaje)
        {
            personaje.DaniarConMolotov(new Molotov());//EL choque hace el mismo danio que una MOLOTOV
        }

        public abstract void LanzarBomba();

    }
}
