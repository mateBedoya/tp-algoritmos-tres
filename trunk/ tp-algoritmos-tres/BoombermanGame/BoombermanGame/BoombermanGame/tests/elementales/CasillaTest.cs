using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.elementales;
using BoombermanGame.src.personajes;
using BoombermanGame.src.obstaculos;
using BoombermanGame.src.bombas;
using BoombermanGame.src.articulos;

namespace BoombermanGame.tests.elementales
{
    [TestFixture]
    public class CasillaTest
    {
        private Casilla casilla;

        [Test]
        public void TestCreaUnaCasillaVacia()
        {
            casilla = new Casilla(10, 20);

            // asserts
            Assert.AreEqual(casilla.X, 10);
            Assert.AreEqual(casilla.Y, 20);
            Assert.AreEqual(casilla.CantidadDeEntidades(), 0);
            Assert.IsTrue(casilla.EstaVacia());
            Assert.IsFalse(casilla.TieneArticulo());
            Assert.IsFalse(casilla.TieneBomba());
            Assert.IsFalse(casilla.TieneObstaculo());
            Assert.IsFalse(casilla.TienePersonaje());
        }



        [Test]
        public void TestSolicitarLaCasillaAdyacenteIzquierda()
        {
            casilla = new Casilla(1, 1);
            int[] oeste = { 0, -1 };

            Casilla casillaIzquierda = casilla.CasillaAdyacenteEnLaDireccion(oeste);

            // asserts
            Assert.AreEqual(casillaIzquierda.X, 1);
            Assert.AreEqual(casillaIzquierda.Y, 0);
        }



        [Test]
        public void TestSolicitarLaCasillaAdyacenteDerecha()
        {
            casilla = new Casilla(1, 1);
            int[] este = { 0, 1 };

            Casilla casillaIzquierda = casilla.CasillaAdyacenteEnLaDireccion(este);

            // asserts
            Assert.AreEqual(casillaIzquierda.X, 1);
            Assert.AreEqual(casillaIzquierda.Y, 2);
        }



        [Test]
        public void TestSolicitarLaCasillaAdyacenteArriba()
        {
            casilla = new Casilla(1, 1);
            int[] norte = { -1, 0 };

            Casilla casillaIzquierda = casilla.CasillaAdyacenteEnLaDireccion(norte);

            // asserts
            Assert.AreEqual(casillaIzquierda.X, 0);
            Assert.AreEqual(casillaIzquierda.Y, 1);
        }



        [Test]
        public void TestSolicitarLaCasillaAdyacenteAbajo()
        {
            casilla = new Casilla(1, 1);
            int[] sur = { 1, 0 };

            Casilla casillaIzquierda = casilla.CasillaAdyacenteEnLaDireccion(sur);

            // asserts
            Assert.AreEqual(casillaIzquierda.X, 2);
            Assert.AreEqual(casillaIzquierda.Y, 1);
        }



        [Test]
        public void TestAgregarEntidadesALaCasilla()
        {
            casilla = new Casilla(1, 1);

            casilla.AgregarEntidad(new Cecilio());
            casilla.AgregarEntidad(new Molotov());

            // asserts
            Assert.AreEqual(casilla.CantidadDeEntidades(), 2);
        }



        [Test]
        public void TestAgregarEntidadesALaCasillaYEliminarlas()
        {
            casilla = new Casilla(1, 1);

            Molotov molotov = new Molotov();
            Cecilio cecilio = new Cecilio();

            casilla.AgregarEntidad(cecilio);
            casilla.AgregarEntidad(molotov);

            // asserts
            Assert.AreEqual(casilla.CantidadDeEntidades(), 2);
            Assert.IsFalse(casilla.EstaVacia());

            casilla.RemoverEntidad(molotov);
            casilla.RemoverEntidad(cecilio);

            // asserts
            Assert.AreEqual(casilla.CantidadDeEntidades(), 0);
            Assert.IsTrue(casilla.EstaVacia());
        }



        [Test]
        public void TestLaCasillaTieneUnArticulo()
        {
            casilla = new Casilla(1, 1);

            casilla.AgregarEntidad(new BombaToleTole());

            // asserts
            Assert.IsTrue(casilla.TieneArticulo());
            Assert.IsFalse(casilla.TieneBomba());
            Assert.IsFalse(casilla.TieneObstaculo());
            Assert.IsFalse(casilla.TienePersonaje());
        }



        [Test]
        public void TestLaCasillaTieneUnaBomba()
        {
            casilla = new Casilla(1, 1);

            casilla.AgregarEntidad(new Molotov());

            // asserts
            Assert.IsFalse(casilla.TieneArticulo());
            Assert.IsTrue(casilla.TieneBomba());
            Assert.IsFalse(casilla.TieneObstaculo());
            Assert.IsFalse(casilla.TienePersonaje());
        }



        [Test]
        public void TestLaCasillaTieneUnObstaculo()
        {
            casilla = new Casilla(1, 1);

            casilla.AgregarEntidad(new ObstaculoDeLadrillo());

            // asserts
            Assert.IsFalse(casilla.TieneArticulo());
            Assert.IsFalse(casilla.TieneBomba());
            Assert.IsTrue(casilla.TieneObstaculo());
            Assert.IsFalse(casilla.TienePersonaje());
        }



        [Test]
        public void TestLaCasillaTieneUnPersonaje()
        {
            casilla = new Casilla(1, 1);

            casilla.AgregarEntidad(new LopezReggae());

            // asserts
            Assert.IsFalse(casilla.TieneArticulo());
            Assert.IsFalse(casilla.TieneBomba());
            Assert.IsFalse(casilla.TieneObstaculo());
            Assert.IsTrue(casilla.TienePersonaje());
        }
    }
}
