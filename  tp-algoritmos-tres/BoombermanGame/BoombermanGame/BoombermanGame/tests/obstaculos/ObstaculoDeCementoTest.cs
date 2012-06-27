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
    public class ObstaculoDeCementoTest
    {
        private Obstaculo obstaculoDeCemento;

        [Test]
        public void TestCreaUnObstaculoDeCemento()
        {
            obstaculoDeCemento = new ObstaculoDeCemento();

            // asserts
            Assert.IsFalse(obstaculoDeCemento.EsArticulo());
            Assert.IsFalse(obstaculoDeCemento.EsBomba());
            Assert.IsTrue(obstaculoDeCemento.EsObstaculo());
            Assert.IsFalse(obstaculoDeCemento.EsPersonaje());
            Assert.IsFalse(obstaculoDeCemento.EsBombita());
            Assert.IsFalse(obstaculoDeCemento.EsEnemigo());
            Assert.IsFalse(obstaculoDeCemento.FueDestruido());
            Assert.IsFalse(obstaculoDeCemento.PuedeSuperponerse());
        }



        [Test]
        public void TestElObstaculoDeCementoEsDestruidoPorLaSegundaMolotov()
        {
            obstaculoDeCemento = new ObstaculoDeCemento();

            obstaculoDeCemento.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsFalse(obstaculoDeCemento.FueDestruido());

            obstaculoDeCemento.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(obstaculoDeCemento.FueDestruido());
        }



        [Test]
        public void TestElObstaculoDeCementoEsDestruidoPorLaToleTole()
        {
            obstaculoDeCemento = new ObstaculoDeCemento();

            obstaculoDeCemento.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(obstaculoDeCemento.FueDestruido());
        }



        [Test]
        public void TestElObstaculoDeCementoEsDestruidoPorElTercerProyectil()
        {
            obstaculoDeCemento = new ObstaculoDeCemento();

            obstaculoDeCemento.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(obstaculoDeCemento.FueDestruido());

            obstaculoDeCemento.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(obstaculoDeCemento.FueDestruido());

            obstaculoDeCemento.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(obstaculoDeCemento.FueDestruido());
        }
    }
}
