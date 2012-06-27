using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.elementales;
using BoombermanGame.src.bombas;
using BoombermanGame.src.personajes;
using BoombermanGame.src.obstaculos;

namespace BoombermanGame.tests.personajes
{
    [TestFixture]
    class CecilioTest
    {
        private Enemigo cecilio;

        [Test]
        public void TestCreaACecilio()
        {
            cecilio = new Cecilio();

            // asserts
            Assert.IsFalse(cecilio.EsArticulo());
            Assert.IsFalse(cecilio.EsBomba());
            Assert.IsFalse(cecilio.EsObstaculo());
            Assert.IsTrue(cecilio.EsPersonaje());
            Assert.IsFalse(cecilio.EsBombita());
            Assert.IsTrue(cecilio.EsEnemigo());
            Assert.IsFalse(cecilio.FueDestruido());
            Assert.IsFalse(cecilio.PuedeSuperponerse());
            Assert.AreEqual(cecilio.Resistencia(), 5);
            Assert.AreEqual(cecilio.Velocidad(), 1);
            Assert.AreEqual(cecilio.PorcentajeDeRetardo(), 1.0);
        }



        [Test]
        public void TestCecilioSeMueveHaciaArriba()
        {
            cecilio = new Cecilio(Tablero.GetInstancia().Casilla(2, 2));
            cecilio.MoverAlNorte();

            // asserts
            Assert.AreEqual(cecilio.Posicion().X, 1);
            Assert.AreEqual(cecilio.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestCecilioSeMueveHaciaAbajo()
        {
            cecilio = new Cecilio(Tablero.GetInstancia().Casilla(2, 2));
            cecilio.MoverAlSur();

            // asserts
            Assert.AreEqual(cecilio.Posicion().X, 3);
            Assert.AreEqual(cecilio.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestCecilioSeMueveHaciaLaIzquierda()
        {
            cecilio = new Cecilio(Tablero.GetInstancia().Casilla(2, 2));
            cecilio.MoverAlOeste();

            // asserts
            Assert.AreEqual(cecilio.Posicion().X, 2);
            Assert.AreEqual(cecilio.Posicion().Y, 1);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestCecilioSeMueveHaciaLaDerecha()
        {
            cecilio = new Cecilio(Tablero.GetInstancia().Casilla(2, 2));
            cecilio.MoverAlEste();

            // asserts
            Assert.AreEqual(cecilio.Posicion().X, 2);
            Assert.AreEqual(cecilio.Posicion().Y, 3);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestCecilioNoSePuedeMoverPorqueHayUnObstaculo()
        {
            cecilio = new Cecilio(Tablero.GetInstancia().Casilla(2, 2));
            Obstaculo obstaculo = new ObstaculoDeLadrillo(Tablero.GetInstancia().Casilla(2, 1));

            cecilio.MoverAlOeste();

            // asserts
            Assert.AreEqual(cecilio.Posicion().X, 2);
            Assert.AreEqual(cecilio.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestCecilioColocaUnaBombaMolotov()
        {
            cecilio = new Cecilio(Tablero.GetInstancia().Casilla(1, 1));

            // asserts
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TienePersonaje());
            Assert.IsFalse(Tablero.GetInstancia().Casilla(1, 1).TieneBomba());

            cecilio.LanzarExplosivo();

            // asserts
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TienePersonaje());
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TieneBomba());

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestCecilioColocaUnaBombaMolotovYContinuaMoviendoseAlejandoseDelExplosivo()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(1, 1);
            cecilio = new Cecilio(posicion);
            cecilio.LanzarExplosivo();

            // asserts
            Assert.IsTrue(posicion.TieneBomba());
            Assert.IsTrue(posicion.TienePersonaje());

            cecilio.MoverAlSur();
            cecilio.MoverAlEste();

            // asserts
            Assert.IsTrue(posicion.TieneBomba());
            Assert.IsFalse(posicion.TienePersonaje());
            Assert.AreEqual(cecilio.Posicion().X, 2);
            Assert.AreEqual(cecilio.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestCecilioEsDestruidoPorLaMolotov()
        {
            cecilio = new Cecilio();

            cecilio.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(cecilio.FueDestruido());
        }



        [Test]
        public void TestCecilioEsDestruidoPorLaToleTole()
        {
            cecilio = new Cecilio();

            cecilio.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(cecilio.FueDestruido());
        }



        [Test]
        public void TestCecilioEsDestruidoPorElSegundoProyectil()
        {
            cecilio = new Cecilio();

            cecilio.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(cecilio.FueDestruido());

            cecilio.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(cecilio.FueDestruido());
        }
    }
}
