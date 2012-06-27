using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.elementales;
using BoombermanGame.src.obstaculos;
using BoombermanGame.src.personajes;
using BoombermanGame.src.bombas;
using BoombermanGame.src.excepciones;

namespace BoombermanGame.tests.elementales
{
    [TestFixture]
    public class TableroTest
    {
        private static Tablero tablero = Tablero.GetInstancia();

        [Test]
        public void TestSolicitarCasillaDentroDelTablero()
        {
            Casilla casilla = tablero.Casilla(7, 5);

            // asserts
            Assert.IsFalse(casilla == null);
        }



        [Test]
        public void TestSolicitarCasillaFueraDelTablero()
        {
            try
            {
                Casilla casilla = tablero.Casilla(-10, -20);
            }
            catch (CasillaFueraDeRangoError e)
            {
                e.NoHacerNada();
            }
        }



        [Test]
        public void TestAgregarEntidadesAlTableroConLasCoordenadasDeSuPosicion()
        {
            tablero.AgregarEntidad(new ObstaculoDeCemento(), 1, 1);
            tablero.AgregarEntidad(new ObstaculoDeAcero(), 2, 2);
            tablero.AgregarEntidad(new Cecilio(), 3, 3);
            tablero.AgregarEntidad(new LopezReggae(), 4, 4);

            // asserts
            Assert.AreEqual(tablero.CantidadDeEntidades(), 4);
            Assert.AreEqual(tablero.CantidadDeEnemigos(), 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestNoSeEliminaNingunaEntidadPorqueNoEstanDestruidas()
        {
            tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 1);
            tablero.AgregarEntidad(new ObstaculoDeAcero(), 2, 2);
            tablero.AgregarEntidad(new LopezReggaeAlado(), 3, 3);
            tablero.AgregarEntidad(new Cecilio(), 4, 4);

            tablero.Actualizar();

            // asserts
            Assert.AreEqual(tablero.CantidadDeEntidades(), 4);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestIntentarAgregarEntidadesEnCasillasQueNoEstenDentroDeLosLimitesDelTablero()
        {
            tablero.AgregarEntidad(new Cecilio(), -10, -20);
            tablero.AgregarEntidad(new ObstaculoDeCemento(), -20, -15);

            // asserts
            Assert.AreEqual(tablero.CantidadDeEntidades(), 0);
        }



        [Test]
        public void TestSolicitarLaCantidadActualDeEnemigosEnElTablero()
        {
            tablero.AgregarEntidad(new ObstaculoDeAcero(), 1, 1);
            tablero.AgregarEntidad(new ObstaculoDeCemento(), 2, 2);
            tablero.AgregarEntidad(new Cecilio(), 3, 3);
            tablero.AgregarEntidad(new ObstaculoDeLadrillo(), 4, 4);
            tablero.AgregarEntidad(new LopezReggae(), 5, 5);
            tablero.AgregarEntidad(new Cecilio(), 6, 6);
            tablero.AgregarEntidad(new Molotov(), 7, 7);

            // asserts
            Assert.AreEqual(tablero.CantidadDeEnemigos(), 3);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestAgregarElObstaculoQueOcultaraLaSalida()
        {
            tablero.AgregarObstaculoQueOcultaSalida();

            // asserts
            Assert.AreEqual(tablero.CantidadDeEntidades(), 1);

            // limpia el tablero
            Tablero.Vaciar();
        }
    }
}
