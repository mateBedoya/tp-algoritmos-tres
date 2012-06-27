using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.articulos;
using BoombermanGame.src.bombas;

namespace BoombermanGame.tests.articulos
{
    [TestFixture]
    public class SalidaTest
    {
        private Articulo salida;

        [Test]
        public void TestCreaUnArticuloSalida()
        {
            salida = new Salida();

            // asserts
            Assert.IsTrue(salida.EsArticulo());
            Assert.IsFalse(salida.EsBomba());
            Assert.IsFalse(salida.EsBombita());
            Assert.IsFalse(salida.EsEnemigo());
            Assert.IsFalse(salida.EsObstaculo());
            Assert.IsFalse(salida.EsPersonaje());
            Assert.IsFalse(salida.FueDestruido());
            Assert.IsTrue(salida.PuedeSuperponerse());
        }



        [Test]
        public void TestElArticuloSalidaEsAlcanzadoPorLaMolotovPeroNoSufreDanioAlguno()
        {
            salida = new Salida();

            salida.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsFalse(salida.FueDestruido());
        }



        [Test]
        public void TestElArticuloSalidaEsAlcanzadoPorLaToleTolePeroNoSufreDanioAlguno()
        {
            salida = new Salida();

            salida.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsFalse(salida.FueDestruido());
        }



        [Test]
        public void TestElArticuloSalidaEsAlcanzadoPorElProyectilPeroNoSufreDanioAlguno()
        {
            salida = new Salida();

            salida.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(salida.FueDestruido());
        }
    }
}
