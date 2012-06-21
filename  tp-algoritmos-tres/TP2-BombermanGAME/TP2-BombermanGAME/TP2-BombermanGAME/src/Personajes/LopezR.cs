using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Bombas;

namespace TP2_Bomberman.src
{
    public class LopezR : Enemigo
    {
        public LopezR()
            :base()
        {
            this.resistencia = 10;
            this.bomba = new Proyectil();
        }

        public LopezR(Casillero posicion)
            :base(posicion)
        {
            this.resistencia = 10;
            this.bomba = new Proyectil();
        }

        public override void LanzarBomba()//la lanza solo si bombita esta en su misma fila o columna
        {
            if (bomba.FueDestruido())//Le permite agregar otra bomba si la anterior ya ha explotado
            {
                bomba = new Proyectil();
            }
            else if (bomba.EstaActivada)
            {
                return;
            }
            this.tablero.AgregarEntidadEnCasillero(bomba, posicion.Fila, posicion.Columna);
            tablero.AgregarBomba(bomba);
            int filaBombita = tablero.PosicionBombita.Fila;
            int columnaBombita = tablero.PosicionBombita.Columna;
            Proyectil proyectil = (Proyectil)this.bomba;
            

            if (filaBombita == posicion.Fila)
            {
                if ((columnaBombita - posicion.Columna) < 0)
                {
                    for (int i = 0; i < bomba.Rango; i++)
                    {
                        proyectil.MoverIzquierda();
                    }
                }
                else
                {
                    for (int i = 0; i < bomba.Rango; i++)
                    {
                        proyectil.MoverDerecha();
                    }
                }
            }
            if (columnaBombita == posicion.Columna)
            {
                if ((filaBombita - posicion.Fila) < 0)
                {
                    for (int i = 0; i < bomba.Rango; i++)
                    {
                        proyectil.MoverArriba();
                    }
                }
                else
                {
                    for (int i = 0; i < bomba.Rango; i++)
                    {
                        proyectil.MoverAbajo();
                    }
                }
            }
        }
        private void MoverEnDireccion()
        {
        }
    }
}
