using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.bombas;
using TP2.src.interfaces;
using TP2.src.excepciones;
using TP2.Elementales;
using TP2.src.Elementales;
using Boomberman.src.elementales;

namespace TP2.src.estrategias
{
   public class Explosion :  IEstrategia
    {
       private static int[] ESTE = { 0, 1 };
       private static int[] NORTE = { -1, 0 };
       private static int[] OESTE = { 0, -1 };
       private static int[] SUR = { 1, 0 };
       private List<Casilla> posicionesDaniadas = new List<Casilla>();
       private Bomba aplicador;

       // crea una onda expansiva para la explosion de una bomba
       public Explosion(Bomba aplicador)
       {
           this.aplicador = aplicador;
       }


       // se aplica la estrategia
       public void Aplicar()
       {
           aplicador.Daniar(aplicador.Posicion().GetEntidades());
           this.ExpandirOndaHaciaEl(ESTE);
           this.ExpandirOndaHaciaEl(NORTE);
           this.ExpandirOndaHaciaEl(OESTE);
           this.ExpandirOndaHaciaEl(SUR);
       }

       // se aplica la expansion 
       public void ExpandirOndaHaciaEl(int[] direccion)
       {
           bool encontroDaniable = false;
           int rango = this.aplicador.GetRango();
           try
           {
               Casilla posicionActual = aplicador.Posicion().CasillaAdyacenteEnLaDireccion(direccion);
               while ((!encontroDaniable) & (rango != 0))
               {
                   //Estallido estallido = new Estallido(posicionActual);
                   //estallido.Aplicar();
                   if (posicionActual.EstaVacia())
                   {
                       posicionActual = posicionActual.CasillaAdyacenteEnLaDireccion(direccion);
                       rango--;
                   }
                   else
                   {
                       aplicador.Daniar(posicionActual.GetEntidades());
                       encontroDaniable = true;
                   }
               }
           }
           catch (CasillaFueraDeRangoError e)
           {
               e.NoHacerNada();
           }
       }

   }
}
