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
    public class ObstaculoDeLadrilloTest
    {
        private Obstaculo obstaculoDeLadrillo;

        [Test]
        public void TestCreaObstaculoDeLadrillo()
        {
            obstaculoDeLadrillo = new ObstaculoDeLadrillo();

            // asserts
            Assert.IsFalse(obstaculoDeLadrillo.EsArticulo());
            Assert.IsFalse(obstaculoDeLadrillo.EsBomba());
            Assert.IsTrue(obstaculoDeLadrillo.EsObstaculo());
            Assert.IsFalse(obstaculoDeLadrillo.EsPersonaje());
            Assert.IsFalse(obstaculoDeLadrillo.EsBombita());
            Assert.IsFalse(obstaculoDeLadrillo.EsEnemigo());
            Assert.IsFalse(obstaculoDeLadrillo.FueDestruido());
            Assert.IsFalse(obstaculoDeLadrillo.PuedeSuperponerse());
        }



        [Test]
        public void TestElObstaculoDeLadrilloEsDestruidoPorLaMolotov()
        {
            obstaculoDeLadrillo = new ObstaculoDeLadrillo();

            obstaculoDeLadrillo.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(obstaculoDeLadrillo.FueDestruido());
        }



        [Test]
        public void TestElObstaculoDeLadrilloEsDestruidoPorLaToleTole()
        {
            obstaculoDeLadrillo = new ObstaculoDeLadrillo();

            obstaculoDeLadrillo.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(obstaculoDeLadrillo.FueDestruido());
        }



        [Test]
        public void TestElObstaculoDeLadrilloEsDestruidoPorElSegundoProyectil()
        {
            obstaculoDeLadrillo = new ObstaculoDeLadrillo();

            obstaculoDeLadrillo.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(obstaculoDeLadrillo.FueDestruido());

            obstaculoDeLadrillo.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(obstaculoDeLadrillo.FueDestruido());
        }
    }
}
