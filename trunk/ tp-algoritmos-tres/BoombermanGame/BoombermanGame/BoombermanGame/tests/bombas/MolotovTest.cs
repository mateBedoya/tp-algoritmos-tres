using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.elementales;
using BoombermanGame.src.bombas;
using BoombermanGame.src.obstaculos;
using BoombermanGame.src.personajes;

namespace BoombermanGame.tests.bombas
{
    [TestFixture]
    public class MolotovTest
    {
        private Tablero tablero = Tablero.GetInstancia();

        [Test]
        public void TestCreaUnaMolotov()
        {
            Bomba molotov = new Molotov();

            // asserts
            Assert.IsFalse(molotov.EsArticulo());
            Assert.IsTrue(molotov.EsBomba());
            Assert.IsFalse(molotov.EsBombita());
            Assert.IsFalse(molotov.EsEnemigo());
            Assert.IsFalse(molotov.EsObstaculo());
            Assert.IsFalse(molotov.EsPersonaje());
            Assert.IsFalse(molotov.FueDestruido());
            Assert.IsFalse(molotov.PuedeSuperponerse());
        }



        [Test]
        public void TestElObstaculoDeCementoEsDestruidoPorLasOndasExpansivasDeLas2MolotovsAlExplotar()
        {
            Obstaculo obstaculoDeCemento = new ObstaculoDeCemento();
            tablero.AgregarEntidad(obstaculoDeCemento, 5, 5);

            Bomba molotov_1 = new Molotov();
            tablero.AgregarEntidad(molotov_1, 5, 7);

            Bomba molotov_2 = new Molotov();
            tablero.AgregarEntidad(molotov_2, 7, 5);

            // asserts
            Assert.IsFalse(obstaculoDeCemento.FueDestruido());
            Assert.IsFalse(molotov_1.FueDestruido());
            Assert.IsFalse(molotov_2.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.Casilla(5, 7).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.Casilla(7, 5).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 3);

            molotov_1.Explotar();
            molotov_2.Explotar();

            // actualiza el tablero, removiendo a aquellas entidades que fueron destruidas
            tablero.Actualizar();

            // asserts
            Assert.IsTrue(obstaculoDeCemento.FueDestruido());
            Assert.IsTrue(molotov_1.FueDestruido());
            Assert.IsTrue(molotov_2.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.Casilla(5, 7).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.Casilla(7, 5).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 0);
        }



        [Test]
        public void TestCecilioEsDestruidoPorLaMolotovQueEstaEnSuMismaCasillaAlExplotar()
        {
            Personaje cecilio = new Cecilio();
            tablero.AgregarEntidad(cecilio, 5, 5);

            Bomba molotov = new Molotov();
            tablero.AgregarEntidad(molotov, 5, 5);

            // asserts
            Assert.IsFalse(cecilio.FueDestruido());
            Assert.IsFalse(molotov.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 2);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 2);

            molotov.Explotar();

            // actualiza el tablero, removiendo a aquellas entidades que fueron destruidas
            tablero.Actualizar();

            // asserts
            Assert.IsTrue(cecilio.FueDestruido());
            Assert.IsTrue(molotov.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 0);
        }



        [Test]
        public void TestLopezReggaeAladoYElObstaculoDeLadrilloSonDestruidosPorLaOndaExpansivaDeLaMolotovAlExplotar()
        {
            Personaje lopezReggaeAlado = new LopezReggaeAlado();
            tablero.AgregarEntidad(lopezReggaeAlado, 5, 5);

            Obstaculo obstaculoDeLadrillo = new ObstaculoDeLadrillo();
            tablero.AgregarEntidad(obstaculoDeLadrillo, 5, 10);

            Bomba molotov = new Molotov();
            tablero.AgregarEntidad(molotov, 5, 7);

            // asserts
            Assert.IsFalse(lopezReggaeAlado.FueDestruido());
            Assert.IsFalse(obstaculoDeLadrillo.FueDestruido());
            Assert.IsFalse(molotov.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.Casilla(5, 7).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.Casilla(5, 10).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 3);

            molotov.Explotar();

            // actualiza el tablero, removiendo a aquellas entidades que fueron destruidas
            tablero.Actualizar();

            // asserts
            Assert.IsTrue(lopezReggaeAlado.FueDestruido());
            Assert.IsTrue(obstaculoDeLadrillo.FueDestruido());
            Assert.IsTrue(molotov.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.Casilla(5, 7).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.Casilla(5, 10).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 0);
        }
    }
}
