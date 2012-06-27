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
    public class BombitaTest
    {
        private Personaje bombita;

        [Test]
        public void TestCreaABombita()
        {
            bombita = Bombita.GetInstancia(); ;

            // asserts
            Assert.IsFalse(bombita.EsArticulo());
            Assert.IsFalse(bombita.EsBomba());
            Assert.IsFalse(bombita.EsObstaculo());
            Assert.IsTrue(bombita.EsPersonaje());
            Assert.IsTrue(bombita.EsBombita());
            Assert.IsFalse(bombita.EsEnemigo());
            Assert.IsFalse(bombita.FueDestruido());
            Assert.IsFalse(bombita.PuedeSuperponerse());
            Assert.AreEqual(bombita.Resistencia(), 1);
            Assert.AreEqual(bombita.Velocidad(), 1);
            Assert.AreEqual(bombita.PorcentajeDeRetardo(), 1.0);
        }



        [Test]
        public void TestBombitaSeMueveHaciaArriba()
        {
            bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(Tablero.GetInstancia().Casilla(2, 2));
            bombita.MoverAlNorte();

            // asserts
            Assert.AreEqual(bombita.Posicion().X, 1);
            Assert.AreEqual(bombita.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestBombitaSeMueveHaciaAbajo()
        {
            bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(Tablero.GetInstancia().Casilla(2, 2));
            bombita.MoverAlSur();

            // asserts
            Assert.AreEqual(bombita.Posicion().X, 3);
            Assert.AreEqual(bombita.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestBombitaSeMueveHaciaLaIzquierda()
        {
            bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(Tablero.GetInstancia().Casilla(2, 2));
            bombita.MoverAlOeste();

            // asserts
            Assert.AreEqual(bombita.Posicion().X, 2);
            Assert.AreEqual(bombita.Posicion().Y, 1);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestBombitaSeMueveHaciaLaDerecha()
        {
            bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(Tablero.GetInstancia().Casilla(2, 2));
            bombita.MoverAlEste();

            // asserts
            Assert.AreEqual(bombita.Posicion().X, 2);
            Assert.AreEqual(bombita.Posicion().Y, 3);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestBombitaNoSePuedeMoverPorqueHayUnObstaculo()
        {
            bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(Tablero.GetInstancia().Casilla(1, 1));
            Obstaculo obstaculo = new ObstaculoDeAcero(Tablero.GetInstancia().Casilla(2, 1));

            bombita.MoverAlSur();

            // asserts
            Assert.AreEqual(bombita.Posicion().X, 1);
            Assert.AreEqual(bombita.Posicion().Y, 1);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestBombitaNoSePuedeMoverPorqueSuProximaPosicionEstaFueraDelTablero()
        {
            bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(Tablero.GetInstancia().Casilla(1, 1));

            bombita.MoverAlOeste();

            // asserts
            Assert.AreEqual(bombita.Posicion().X, 1);
            Assert.AreEqual(bombita.Posicion().Y, 1);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestBombitaColocaUnaBombaMolotov()
        {
            bombita = Bombita.GetInstancia();
            Casilla posicion = Tablero.GetInstancia().Casilla(1, 1);
            bombita.PosicionarEn(posicion);

            // asserts
            Assert.IsTrue(posicion.TienePersonaje());
            Assert.IsFalse(posicion.TieneBomba());

            bombita.LanzarExplosivo();

            // asserts
            Assert.IsTrue(posicion.TienePersonaje());
            Assert.IsTrue(posicion.TieneBomba());

            // comprueba que en verdad bombita haya plantado una molotov (tiene rango 3 expansivo)
            Entidad bomba = posicion.GetEntidades()[1];
            // asserts
            Assert.AreEqual(((Bomba)bomba).GetRango(), 3);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestBombitaEsDestruidoPorLaMolotov()
        {
            bombita = Bombita.GetInstancia();

            bombita.DaniarPorMolotov(new Molotov());

            // asserts
            Assert.IsTrue(bombita.FueDestruido());

            // limpia la instancia de bombita
            Bombita.LimpiarInstancia();
        }



        [Test]
        public void TestBombitaEsDestruidoPorLaToleTole()
        {
            bombita = Bombita.GetInstancia();

            bombita.DaniarPorToletole(new ToleTole());

            // asserts
            Assert.IsTrue(bombita.FueDestruido());

            // limpia la instancia de bombita
            Bombita.LimpiarInstancia();
        }



        [Test]
        public void TestBombitaEsDestruidoPorElProyectil()
        {
            bombita = Bombita.GetInstancia();

            bombita.DaniarPorProyectil(new Proyectil());

            // asserts
            Assert.IsTrue(bombita.FueDestruido());

            // limpia la instancia de bombita
            Bombita.LimpiarInstancia();
        }



        [Test]
        public void TestSeIntentaQueBombitaAumenteSuVelocidadPor5VezPeroNoSufreEfectoPorqueAlcanzoSuVelocidadMaximaIgualA3()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(1, 1);

            Bombita bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(posicion);

            // se intenta que bombita aumente 5 veces su velocidad
            bombita.AumentarVelocidad();
            bombita.AumentarVelocidad();
            bombita.AumentarVelocidad();
            bombita.AumentarVelocidad();
            bombita.AumentarVelocidad();

            // bombita se mueve 3 casilleros y no 5 como deberia ya que alcanzo su velocidad maxima
            bombita.MoverAlEste();
            // asserts
            Assert.AreEqual(bombita.Posicion().X, 1);
            Assert.AreEqual(bombita.Posicion().Y, 4);

            // limpia el tablero y la instancia de bombita
            Tablero.Vaciar();
        }



        [Test]
        public void TestSeIntentaQueBombitaReduzcaSuRetardoMasDeUnaVezPeroNoSufreEfectoPorqueAlcanzoSuRetardoMinimo()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(1, 1);

            Bombita bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(posicion);

            bombita.ReducirRetardo(0.85);

            // asserts
            Assert.AreEqual(bombita.PorcentajeDeRetardo(), 0.85);

            bombita.ReducirRetardo(0.5);
            bombita.ReducirRetardo(0.2);

            // no reduce mas el retardo, sigue siendo 0.85
            // asserts
            Assert.AreEqual(bombita.PorcentajeDeRetardo(), 0.85);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestIntentarQueBombitaLanceBombasSinEsperarQueLaAnteriorHayaExplotadoNoTieneEfecto()
        {
            Casilla posicion = Tablero.GetInstancia().Casilla(1, 1);

            bombita = Bombita.GetInstancia();
            bombita.PosicionarEn(posicion);

            // en principio en la posicion d ebombita, no hay bombas
            // asserts
            Assert.IsFalse(posicion.TieneBomba());
            Assert.AreEqual(posicion.CantidadDeEntidades(), 1);

            // bombita lanza su primera bomba
            bombita.LanzarExplosivo();
            // asserts
            Assert.IsTrue(posicion.TieneBomba());
            Assert.AreEqual(posicion.CantidadDeEntidades(), 2);

            // pero ahora cuando intenta lanzar la segunda, la tercera y la cuarta, 
            // no puede hacerlo ya que la primera colocada, aun no exploto
            bombita.LanzarExplosivo();
            bombita.LanzarExplosivo();
            bombita.LanzarExplosivo();
            // asserts
            Assert.IsTrue(posicion.TieneBomba());
            Assert.AreEqual(posicion.CantidadDeEntidades(), 2);

            // limpia el tablero
            Tablero.Vaciar();
        }
    }
}
