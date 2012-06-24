using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boomberman.src.elementales;

namespace Boomberman.src.niveles
{
    public class Nivel03: Nivel
    {
        public Nivel03()
            : base()
        {
            this.SetNumero(3);
        }


        public Nivel03(int cecilios, int lopezReggaes, int lopezReggaesAlados,
            int obstaculosDeLadrillo, int obstaculosDeCemento, int obstaculosDeAcero)
            : base(cecilios, lopezReggaes, lopezReggaesAlados, obstaculosDeLadrillo, obstaculosDeCemento, obstaculosDeAcero)
        {
            this.SetNumero(3);
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
