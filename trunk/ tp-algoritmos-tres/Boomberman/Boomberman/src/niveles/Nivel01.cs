using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boomberman.src.elementales;
using TP2.src.Juego.obstaculos;

namespace Boomberman.src.niveles
{
    public class Nivel01 : Nivel
    {

        public Nivel01()
            : base() 
        {
            this.SetNumero(1);
        }


        public Nivel01(int cecilios, int lopezReggaes, int lopezReggaesAlados,
            int obstaculosDeLadrillo, int obstaculosDeCemento, int obstaculosDeAcero)
            : base(cecilios, lopezReggaes, lopezReggaesAlados, obstaculosDeLadrillo, obstaculosDeCemento, obstaculosDeAcero)
        {
            this.SetNumero(1);
        }


        // se crea el tablero y se carga con datos predeterminados
        public override void Cargar()
        {
            base.Cargar();

            this.AgregarCecilios();
            this.AgregarLopezReggaes();
            this.AgregarLopezReggaesAlados();
            
            this.tablero.AgregarObstaculosDeAceroIniciales();
            
            this.AgregarObstaculosDeAcero();
            this.AgregarObstaculosDeCemento();
            this.AgregarObstaculosDeLadrillo();

            this.tablero.AgregarObstaculoQueOcultaSalida();
        }

    }
}
