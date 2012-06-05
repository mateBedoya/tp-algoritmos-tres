using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Interfaces;

namespace TP2_Bomberman.src.Bombas
{
    public class Proyectil: Bomba, IMovible
    {
        //private int distancia; //BORRAR COMENTARIO: La distancia en casilleros que puede recorrer el proyectil (LO PUSE COMO COMENTARIO PARA NO TENER UN WARNING)
        public Proyectil()
            :base()
        {
            this.destruccion = 5;//Esto era a determinar, lo dejo en 5 por ahora
            this.retardo = 1;
            this.rango = 3;
        }

        public Proyectil(Casillero posicion)
            :base(posicion)
        {
            this.destruccion = 5;//Esto era a determinar, lo dejo en 5 por ahora
            this.retardo = 1;
            this.rango = 3;
        }

        public override void Explotar(double porcentajeRetardo = 1)
        {
            // Aca tendria que ir MOVIENDOSE Y CUANDO LLEGUE A LA DISTANCIA HACER 
            // Dañar(elementoDelCasillero)
        }
        public override void Daniar(IDaniable daniable)
        {
            daniable.DaniarConProyectil(this); // Uso de patron doble dipatch
        }




        // FALTA HACER ESTO DE QUE EL PROYECTIL SE PUEDA MOVER
        public void MoverArriba()
        {
            throw new NotImplementedException();
        }

        public void MoverAbajo()
        {
            throw new NotImplementedException();
        }

        public void MoverDerecha()
        {
            throw new NotImplementedException();
        }

        public void MoverIzquierda()
        {
            throw new NotImplementedException();
        }
    }
}
