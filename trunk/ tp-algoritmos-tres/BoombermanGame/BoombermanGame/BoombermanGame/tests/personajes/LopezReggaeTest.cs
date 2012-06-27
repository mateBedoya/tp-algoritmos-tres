using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.personajes;
using BoombermanGame.src.bombas;
using BoombermanGame.src.elementales;
using BoombermanGame.src.obstaculos;

namespace BoombermanGame.tests.personajes
{
    [TestFixture]
    public class LopezReggaeTest
    {
        private Enemigo lopezReggae;

        [Test]
        public void TestCreaALopezReggae()
        {
            lopezReggae = new LopezReggae();

            // asserts
            Assert.IsFalse(lopezReggae.EsArticulo());
            Assert.IsFalse(lopezReggae.EsBomba());
            Assert.IsFalse(lopezReggae.EsObstaculo());
            Assert.IsTrue(lopezReggae.EsPersonaje());
            Assert.IsFalse(lopezReggae.EsBombita());
            Assert.IsTrue(lopezReggae.EsEnemigo());
            Assert.IsFalse(lopezReggae.FueDestruido());
            Assert.IsFalse(lopezReggae.PuedeSuperponerse());
            Assert.AreEqual(lopezReggae.Resistencia(), 10);
            Assert.AreEqual(lopezReggae.Velocidad(), 2);
            Assert.AreEqual(lopezReggae.PorcentajeDeRetardo(), 1.0);
        }



        [Test]
        public void TestLopezReggaeSeMueveHaciaArriba()
        {
            lopezReggae = new LopezReggae(Tablero.GetInstancia().Casilla(2, 2));
            lopezReggae.MoverAlNorte();

            // asserts
            Assert.AreEqual(lopezReggae.Posicion().X, 1);
            Assert.AreEqual(lopezReggae.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeSeMueveHaciaAbajo()
        {
            lopezReggae = new LopezReggae(Tablero.GetInstancia().Casilla(2, 2));
            lopezReggae.MoverAlSur();

            // asserts
            Assert.AreEqual(lopezReggae.Posicion().X, 4);
            Assert.AreEqual(lopezReggae.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeSeMueveHacialaIzquierda()
        {
            lopezReggae = new LopezReggae(Tablero.GetInstancia().Casilla(2, 2));
            lopezReggae.MoverAlOeste();

            // asserts
            Assert.AreEqual(lopezReggae.Posicion().X, 2);
            Assert.AreEqual(lopezReggae.Posicion().Y, 1);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeSeMueveHaciaLaDerecha()
        {
            lopezReggae = new LopezReggae(Tablero.GetInstancia().Casilla(2, 2));
            lopezReggae.MoverAlEste();

            // asserts
            Assert.AreEqual(lopezReggae.Posicion().X, 2);
            Assert.AreEqual(lopezReggae.Posicion().Y, 4);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeNoSePuedeMoverPorqueHayUnObstaculo()
        {
            lopezReggae = new LopezReggae(Tablero.GetInstancia().Casilla(2, 2));
            Obstaculo obstaculo = new ObstaculoDeCemento(Tablero.GetInstancia().Casilla(1, 2));

            lopezReggae.MoverAlNorte();

            // asserts
            Assert.AreEqual(lopezReggae.Posicion().X, 2);
            Assert.AreEqual(lopezReggae.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeLanzaUnProyectil()
        {
            lopezReggae = new LopezReggae(Tablero.GetInstancia().Casilla(1, 1));

            // asserts
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TienePersonaje());
            Assert.IsFalse(Tablero.GetInstancia().Casilla(1, 1).TieneBomba());

            lopezReggae.LanzarExplosivo();

            // asserts
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TienePersonaje());
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TieneBomba());

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeColocaUnaBombaMolotovYContinuaMoviendoseAlejandoseDelExplosivo()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(2, 2);
            lopezReggae = new LopezReggae(posicion);
            lopezReggae.LanzarExplosivo();

            // asserts
            Assert.IsTrue(posicion.TieneBomba());
            Assert.IsTrue(posicion.TienePersonaje());

            lopezReggae.MoverAlEste();
            lopezReggae.MoverAlEste();
            lopezReggae.MoverAlNorte();

            // asserts
            Assert.IsTrue(posicion.TieneBomba());
            Assert.IsFalse(posicion.TienePersonaje());
            Assert.AreEqual(lopezReggae.Posicion().X, 1);
            Assert.AreEqual(lopezReggae.Posicion().Y, 6);
        }



        [Test]
        public void TestLopezReggaeEsDestruidoPorLaSegundaMolotov()
        {
            lopezReggae = new LopezReggae();

            lopezReggae.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsFalse(lopezReggae.FueDestruido());

            lopezReggae.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(lopezReggae.FueDestruido());
        }



        [Test]
        public void TestLopezReggaeEsDestruidoPorLaToleTole()
        {
            lopezReggae = new LopezReggae();

            lopezReggae.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(lopezReggae.FueDestruido());
        }



        [Test]
        public void TestLopezReggaeEsDestruidoPorElTercerProyectil()
        {
            lopezReggae = new LopezReggae();

            lopezReggae.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(lopezReggae.FueDestruido());

            lopezReggae.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(lopezReggae.FueDestruido());

            lopezReggae.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(lopezReggae.FueDestruido());
        }
    }
}
