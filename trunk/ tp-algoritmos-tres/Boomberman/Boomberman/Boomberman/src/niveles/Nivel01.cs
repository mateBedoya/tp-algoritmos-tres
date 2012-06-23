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
        { }


        // se crea el tablero y se carga con datos predeterminados
        public override void Cargar()
        {
            base.Cargar();

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 1);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 1);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 1);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 1);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 1);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 1);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 3);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 3);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 3);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 3);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 3);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 3);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 5);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 5);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 5);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 5);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 5);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 5);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 7);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 7);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 7);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 7);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 7);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 7);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 9);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 9);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 9);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 9);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 9);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 9);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 11);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 11);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 11);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 11);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 11);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 11);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 13);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 13);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 13);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 13);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 13);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 13);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 15);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 15);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 15);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 15);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 15);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 15);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 17);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 17);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 17);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 17);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 17);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 17);

            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 19);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 3, 19);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 5, 19);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 7, 19);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 9, 19);
            this.tablero.AgregarEntidad(new ObstaculoDeAcero(), 11, 19);

            this.tablero.AgregarObstaculoQueOcultaSalida();

            this.AgregarCecilios();
            this.AgregarLopezReggaes();
            this.AgregarLopezReggaesAlados();
            this.AgregarObstaculosDeAcero();
            this.AgregarObstaculosDeCemento();
            this.AgregarObstaculosDeLadrillo();
        }

    }
}
