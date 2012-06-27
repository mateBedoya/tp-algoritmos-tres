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
    public class TimerTest
    {
        private Articulo timer;

        [Test]
        public void TestCreaUnArticuloTimer()
        {
            timer = new Timer();

            // asserts
            Assert.IsTrue(timer.EsArticulo());
            Assert.IsFalse(timer.EsBomba());
            Assert.IsFalse(timer.EsBombita());
            Assert.IsFalse(timer.EsEnemigo());
            Assert.IsFalse(timer.EsObstaculo());
            Assert.IsFalse(timer.EsPersonaje());
            Assert.IsFalse(timer.FueDestruido());
            Assert.IsTrue(timer.PuedeSuperponerse());
        }



        [Test]
        public void TestElArticuloTimerReduceEnUn15PorcientoElRetardoQueTieneBombitaParaQueExplotenLasBombasQueColoca()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(1, 1);
            Bombita bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(posicion);
            timer = new Timer();
            timer.PosicionarEn(posicion);

            timer.ModificarABombita();

            // bombita tiene 0.85 como porcentaje de retardo
            Assert.AreEqual(bombita.PorcentajeDeRetardo(), 0.85);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestElArticuloTimerEsDestruidoPorLaMolotov()
        {
            timer = new Timer();

            timer.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(timer.FueDestruido());
        }



        [Test]
        public void TestElArticuloTimerEsDestruidoPorLaToleTole()
        {
            timer = new Timer();

            timer.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(timer.FueDestruido());
        }



        [Test]
        public void TestElArticuloTimerEsDestruidoPorElProyectil()
        {
            timer = new Timer();

            timer.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(timer.FueDestruido());
        }
    }
}
