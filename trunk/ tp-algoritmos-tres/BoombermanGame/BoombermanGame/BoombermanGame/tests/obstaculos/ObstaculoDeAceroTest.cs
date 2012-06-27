using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.obstaculos;
using BoombermanGame.src.bombas;

namespace BoombermanGame.tests.obstaculos
{
    [TestFixture]
    public class ObstaculoDeAceroTest
    {
        private Obstaculo obstaculoDeAcero;

        [Test]
        public void TestCreaUnObstaculoDeAcero()
        {
            obstaculoDeAcero = new ObstaculoDeAcero();

            // asserts
            Assert.IsFalse(obstaculoDeAcero.EsArticulo());
            Assert.IsFalse(obstaculoDeAcero.EsBomba());
            Assert.IsTrue(obstaculoDeAcero.EsObstaculo());
            Assert.IsFalse(obstaculoDeAcero.EsPersonaje());
            Assert.IsFalse(obstaculoDeAcero.EsBombita());
            Assert.IsFalse(obstaculoDeAcero.EsEnemigo());
            Assert.IsFalse(obstaculoDeAcero.FueDestruido());
            Assert.IsFalse(obstaculoDeAcero.PuedeSuperponerse());
        }



        [Test]
        public void TestElObstaculoDeAceroEsAlcanzadoPorLaMolotovPeroNoSufreDanioAlguno()
        {
            obstaculoDeAcero = new ObstaculoDeAcero();

            obstaculoDeAcero.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsFalse(obstaculoDeAcero.FueDestruido());

            obstaculoDeAcero.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsFalse(obstaculoDeAcero.FueDestruido());

            obstaculoDeAcero.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsFalse(obstaculoDeAcero.FueDestruido());
        }



        [Test]
        public void TestElObstaculoDeAceroEsDestruidoPorLaToleTole()
        {
            obstaculoDeAcero = new ObstaculoDeAcero();

            obstaculoDeAcero.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(obstaculoDeAcero.FueDestruido());
        }



        [Test]
        public void TestElObstaculoDeAceroEsAlcanzadoPorElProyectilPeroNoSufreDanioAlguno()
        {
            obstaculoDeAcero = new ObstaculoDeAcero();

            obstaculoDeAcero.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(obstaculoDeAcero.FueDestruido());

            obstaculoDeAcero.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(obstaculoDeAcero.FueDestruido());

            obstaculoDeAcero.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(obstaculoDeAcero.FueDestruido());
        }
    }
}
