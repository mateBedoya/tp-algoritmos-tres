using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.bombas;
using BoombermanGame.src.articulos;
using BoombermanGame.src.elementales;
using BoombermanGame.src.personajes;

namespace BoombermanGame.tests.articulos
{
    [TestFixture]
    public class BombaToleToleTest
    {
        private Articulo bombaToleTole;

        [Test]
        public void TestCreaUnArticuloBombaToleTole()
        {
            bombaToleTole = new BombaToleTole();

            // asserts
            Assert.IsTrue(bombaToleTole.EsArticulo());
            Assert.IsFalse(bombaToleTole.EsBomba());
            Assert.IsFalse(bombaToleTole.EsBombita());
            Assert.IsFalse(bombaToleTole.EsEnemigo());
            Assert.IsFalse(bombaToleTole.EsObstaculo());
            Assert.IsFalse(bombaToleTole.EsPersonaje());
            Assert.IsFalse(bombaToleTole.FueDestruido());
            Assert.IsTrue(bombaToleTole.PuedeSuperponerse());
        }



        [Test]
        public void TestElArticuloBombaToleToleHaceQueBombitaPaseAColocarBombasToleToleUnicamente()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(1, 1);

            Bombita bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(posicion);
            bombaToleTole = new BombaToleTole();
            bombaToleTole.PosicionarEn(posicion);

            bombaToleTole.ModificarABombita();

            bombita.LanzarExplosivo();

            // se comprueba que ahora bombita lance bombas tole tole unicamente
            Entidad toleTole = posicion.GetEntidades()[2];
            // asserts
            Assert.AreEqual(((Bomba)toleTole).GetRango(), 6);

            // limpia el tablero y la instancia de bombita
            Tablero.Vaciar();
        }



        [Test]
        public void TestElArticuloBombaToleToleEsDestruidoPorLaMolotov()
        {
            bombaToleTole = new BombaToleTole();

            bombaToleTole.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(bombaToleTole.FueDestruido());
        }



        [Test]
        public void TestElArticuloBombaToleToleEsDestruidoPorLaToleTole()
        {
            bombaToleTole = new BombaToleTole();

            bombaToleTole.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(bombaToleTole.FueDestruido());
        }



        [Test]
        public void TestElArticuloBombaToleToleEsDestruidoPorElProyectil()
        {
            bombaToleTole = new BombaToleTole();

            bombaToleTole.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(bombaToleTole.FueDestruido());
        }
    }
}
