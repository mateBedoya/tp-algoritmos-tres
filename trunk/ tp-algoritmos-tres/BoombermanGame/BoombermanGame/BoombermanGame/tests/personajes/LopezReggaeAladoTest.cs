using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.personajes;
using BoombermanGame.src.elementales;
using BoombermanGame.src.obstaculos;
using BoombermanGame.src.bombas;

namespace BoombermanGame.tests.personajes
{
    [TestFixture]
    public class LopezReggaeAladoTest
    {
        private Enemigo lopezReggaeAlado;

        [Test]
        public void TestCreaALopezReggaeAlado()
        {
            lopezReggaeAlado = new LopezReggaeAlado();

            // asserts
            Assert.IsFalse(lopezReggaeAlado.EsArticulo());
            Assert.IsFalse(lopezReggaeAlado.EsBomba());
            Assert.IsFalse(lopezReggaeAlado.EsObstaculo());
            Assert.IsTrue(lopezReggaeAlado.EsPersonaje());
            Assert.IsFalse(lopezReggaeAlado.EsBombita());
            Assert.IsTrue(lopezReggaeAlado.EsEnemigo());
            Assert.IsFalse(lopezReggaeAlado.FueDestruido());
            Assert.IsFalse(lopezReggaeAlado.PuedeSuperponerse());
            Assert.AreEqual(lopezReggaeAlado.Resistencia(), 5);
            Assert.AreEqual(lopezReggaeAlado.Velocidad(), 1);
            Assert.AreEqual(lopezReggaeAlado.PorcentajeDeRetardo(), 1.0);
        }



        [Test]
        public void TestLopezReggaeAladoSeMueveHaciaArriba()
        {
            lopezReggaeAlado = new LopezReggaeAlado(Tablero.GetInstancia().Casilla(2, 2));
            lopezReggaeAlado.MoverAlNorte();

            // asserts
            Assert.AreEqual(lopezReggaeAlado.Posicion().X, 1);
            Assert.AreEqual(lopezReggaeAlado.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeAladoSeMueveHaciaAbajo()
        {
            lopezReggaeAlado = new LopezReggaeAlado(Tablero.GetInstancia().Casilla(2, 2));
            lopezReggaeAlado.MoverAlSur();

            // asserts
            Assert.AreEqual(lopezReggaeAlado.Posicion().X, 3);
            Assert.AreEqual(lopezReggaeAlado.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeAladoSeMueveHacialaIzquierda()
        {
            lopezReggaeAlado = new LopezReggaeAlado(Tablero.GetInstancia().Casilla(2, 2));
            lopezReggaeAlado.MoverAlOeste();

            // asserts
            Assert.AreEqual(lopezReggaeAlado.Posicion().X, 2);
            Assert.AreEqual(lopezReggaeAlado.Posicion().Y, 1);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeAladoSeMueveHaciaLaDerecha()
        {
            lopezReggaeAlado = new LopezReggaeAlado(Tablero.GetInstancia().Casilla(2, 2));
            lopezReggaeAlado.MoverAlEste();

            // asserts
            Assert.AreEqual(lopezReggaeAlado.Posicion().X, 2);
            Assert.AreEqual(lopezReggaeAlado.Posicion().Y, 3);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeAladoPasaPorSobreUnObstaculo()
        {
            lopezReggaeAlado = new LopezReggaeAlado(Tablero.GetInstancia().Casilla(1, 1));
            Obstaculo obstaculo = new ObstaculoDeCemento(Tablero.GetInstancia().Casilla(1, 2));

            lopezReggaeAlado.MoverAlEste();

            // asserts
            // en la misma posicion que el obstaculo
            Assert.AreEqual(lopezReggaeAlado.Posicion().X, 1);
            Assert.AreEqual(lopezReggaeAlado.Posicion().Y, 2);

            lopezReggaeAlado.MoverAlEste();

            // asserts
            // paso por encima del obstaculo
            Assert.AreEqual(lopezReggaeAlado.Posicion().X, 1);
            Assert.AreEqual(lopezReggaeAlado.Posicion().Y, 3);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeAladoColocaUnaBombaMolotov()
        {
            lopezReggaeAlado = new LopezReggaeAlado(Tablero.GetInstancia().Casilla(1, 1));

            // asserts
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TienePersonaje());
            Assert.IsFalse(Tablero.GetInstancia().Casilla(1, 1).TieneBomba());

            lopezReggaeAlado.LanzarExplosivo();

            // asserts
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TienePersonaje());
            Assert.IsTrue(Tablero.GetInstancia().Casilla(1, 1).TieneBomba());

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeAladoColocaUnaBombaMolotovYContinuaMoviendoseAlejandoseDelExplosivo()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(2, 2);
            lopezReggaeAlado = new LopezReggaeAlado(posicion);
            lopezReggaeAlado.LanzarExplosivo();

            // asserts
            Assert.IsTrue(posicion.TieneBomba());
            Assert.IsTrue(posicion.TienePersonaje());

            lopezReggaeAlado.MoverAlNorte();
            lopezReggaeAlado.MoverAlOeste();

            // asserts
            Assert.IsTrue(posicion.TieneBomba());
            Assert.IsFalse(posicion.TienePersonaje());
            Assert.AreEqual(lopezReggaeAlado.Posicion().X, 1);
            Assert.AreEqual(lopezReggaeAlado.Posicion().Y, 1);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestLopezReggaeAladoEsDestruidoPorLaMolotov()
        {
            lopezReggaeAlado = new LopezReggaeAlado();

            lopezReggaeAlado.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(lopezReggaeAlado.FueDestruido());
        }



        [Test]
        public void TestLopezReggaeAladoEsDestruidoPorLaToleTole()
        {
            lopezReggaeAlado = new LopezReggae();

            lopezReggaeAlado.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(lopezReggaeAlado.FueDestruido());
        }



        [Test]
        public void TestLopezReggaeAladoEsDestruidoPorElSegundoProyectil()
        {
            lopezReggaeAlado = new LopezReggaeAlado();

            lopezReggaeAlado.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsFalse(lopezReggaeAlado.FueDestruido());

            lopezReggaeAlado.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(lopezReggaeAlado.FueDestruido());
        }
    }
}
