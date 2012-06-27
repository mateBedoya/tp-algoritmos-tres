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
    public class ToleToleTest
    {
        private Tablero tablero = Tablero.GetInstancia();

        [Test]
        public void TestCreaUnaToleTole()
        {
            Bomba toleTole = new ToleTole();

            // asserts
            Assert.IsFalse(toleTole.EsArticulo());
            Assert.IsTrue(toleTole.EsBomba());
            Assert.IsFalse(toleTole.EsBombita());
            Assert.IsFalse(toleTole.EsEnemigo());
            Assert.IsFalse(toleTole.EsObstaculo());
            Assert.IsFalse(toleTole.EsPersonaje());
            Assert.IsFalse(toleTole.FueDestruido());
            Assert.IsFalse(toleTole.PuedeSuperponerse());
        }



        [Test]
        public void TestLaToleToleEsDestruidaPorLaMolotov()
        {
            Bomba toleTole = new ToleTole();

            toleTole.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(toleTole.FueDestruido());
        }



        [Test]
        public void TestLaToleToleEsDestruidaPorLaToleTole()
        {
            Bomba toleTole = new ToleTole();

            toleTole.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(toleTole.FueDestruido());
        }



        [Test]
        public void TestLaToleToleEsDestruidaPorElProyectil()
        {
            Bomba toleTole = new ToleTole();

            toleTole.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(toleTole.FueDestruido());
        }



        [Test]
        public void TestElObstaculoDeAceroEsDestruidoPorLaOndaExpansivaDeLaToleToleAlExplotar()
        {
            Obstaculo obstaculoDeAcero = new ObstaculoDeAcero();
            tablero.AgregarEntidad(obstaculoDeAcero, 5, 5);

            Bomba toleTole = new ToleTole();
            tablero.AgregarEntidad(toleTole, 5, 10);

            // asserts
            Assert.IsFalse(obstaculoDeAcero.FueDestruido());
            Assert.IsFalse(toleTole.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.Casilla(5, 10).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 2);

            // se invoca 5 veces el metodo explotar para hacer pasar el tiempo
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();

            // actualiza el tablero, removiendo a aquellas entidades que fueron destruidas
            tablero.Actualizar();

            // asserts
            Assert.IsTrue(obstaculoDeAcero.FueDestruido());
            Assert.IsTrue(toleTole.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.Casilla(5, 10).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 0);
        }



        [Test]
        public void TestLopezReggaeesDestruidoPorLaExplosionDeLaToleToleQueEstaEnSuMismaCasilla()
        {
            Personaje lopezReggae = new LopezReggae();
            tablero.AgregarEntidad(lopezReggae, 5, 5);

            Bomba toleTole = new ToleTole();
            tablero.AgregarEntidad(toleTole, 5, 5);

            // asserts
            Assert.IsFalse(lopezReggae.FueDestruido());
            Assert.IsFalse(toleTole.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 2);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 2);

            // se invoca 5 veces el metodo explotar para hacer pasar el tiempo
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();

            // actualiza el tablero, removiendo a aquellas entidades que fueron destruidas
            tablero.Actualizar();

            // asserts
            Assert.IsTrue(lopezReggae.FueDestruido());
            Assert.IsTrue(toleTole.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 0);
        }



        [Test]
        public void TestCecilioYElObstaculoDeLadrilloSonDestruidosPorLaOndaExpansivaDeLaToleToleAlExplotar()
        {
            Personaje cecilio = new Cecilio();
            tablero.AgregarEntidad(cecilio, 5, 5);

            Obstaculo obstaculoDeLadrillo = new ObstaculoDeLadrillo();
            tablero.AgregarEntidad(obstaculoDeLadrillo, 5, 14);

            Bomba toleTole = new ToleTole();
            tablero.AgregarEntidad(toleTole, 5, 10);

            // asserts
            Assert.IsFalse(cecilio.FueDestruido());
            Assert.IsFalse(obstaculoDeLadrillo.FueDestruido());
            Assert.IsFalse(toleTole.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.Casilla(5, 10).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.Casilla(5, 14).CantidadDeEntidades(), 1);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 3);

            // se invoca 5 veces el metodo explotar para hacer pasar el tiempo
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();
            toleTole.Explotar();

            // actualiza el tablero, removiendo a aquellas entidades que fueron destruidas
            tablero.Actualizar();

            // asserts
            Assert.IsTrue(cecilio.FueDestruido());
            Assert.IsTrue(obstaculoDeLadrillo.FueDestruido());
            Assert.IsTrue(toleTole.FueDestruido());
            Assert.AreEqual(tablero.Casilla(5, 5).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.Casilla(5, 10).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.Casilla(5, 14).CantidadDeEntidades(), 0);
            Assert.AreEqual(tablero.CantidadDeEntidades(), 0);
        }
    }
}
