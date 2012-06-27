using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.articulos;
using BoombermanGame.src.elementales;
using BoombermanGame.src.personajes;
using BoombermanGame.src.bombas;

namespace BoombermanGame.tests.articulos
{
    [TestFixture]
    class HabanoTest
    {
        private Articulo habano;

        [Test]
        public void TestCreaUnArticuloHabano()
        {
            habano = new Habano();

            // asserts
            Assert.IsTrue(habano.EsArticulo());
            Assert.IsFalse(habano.EsBomba());
            Assert.IsFalse(habano.EsBombita());
            Assert.IsFalse(habano.EsEnemigo());
            Assert.IsFalse(habano.EsObstaculo());
            Assert.IsFalse(habano.EsPersonaje());
            Assert.IsFalse(habano.FueDestruido());
            Assert.IsTrue(habano.PuedeSuperponerse());
        }



        [Test]
        public void TestElArticuloHabanoAumentaLaVelocidadDeDesplazamientoDeBombita()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(1, 1);

            Bombita bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(posicion);
            habano = new Habano();
            habano.PosicionarEn(posicion);

            habano.ModificarABombita();

            // bombita aumento su velocidad por lo que se mueve dos casilleros
            bombita.MoverAlEste();

            // asserts
            Assert.AreEqual(bombita.Posicion().X, 1);
            Assert.AreEqual(bombita.Posicion().Y, 3);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestElArticuloHabanoEsDestruidoPorLaMolotov()
        {
            habano = new Habano();

            habano.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(habano.FueDestruido());
        }



        [Test]
        public void TestElArticuloHabanoEsDestruidoPorLaToleTole()
        {
            habano = new Habano();

            habano.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(habano.FueDestruido());
        }


        [Test]
        public void TestElArticuloHabanoEsDestruidoPorElProyectil()
        {
            habano = new Habano();

            habano.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(habano.FueDestruido());
        }
    }
}
