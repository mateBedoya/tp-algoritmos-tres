using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.elementales;
using BoombermanGame.src.obstaculos;

namespace BoombermanGame.tests.elementales
{
    [TestFixture]
    public class EntidadTest
    {

        [Test]
        public void TestCreaUnaEntidadSinPosicion()
        {
            Entidad entidad = new ObstaculoDeAcero();

            // asserts
            Assert.IsTrue(entidad.Posicion() == null);
            Assert.AreEqual(entidad.Direccion()[0], 0);
            Assert.AreEqual(entidad.Direccion()[1], 1);
        }



        [Test]
        public void TestCreaUnaEntidadConPosicion()
        {
            Entidad entidad = new ObstaculoDeAcero(new Casilla(10, 20));

            // asserts
            Assert.AreEqual(entidad.Posicion().X, 10);
            Assert.AreEqual(entidad.Posicion().Y, 20);
            Assert.AreEqual(entidad.Direccion()[0], 0);
            Assert.AreEqual(entidad.Direccion()[1], 1);
        }



        [Test]
        public void TestCreaUnaEntidadSinPosicionYLaPosicionaLuego()
        {
            Entidad entidad = new ObstaculoDeAcero();

            entidad.PosicionarEn(new Casilla(10, 20));

            // asserts
            Assert.AreEqual(entidad.Posicion().X, 10);
            Assert.AreEqual(entidad.Posicion().Y, 20);
        }



        [Test]
        public void TestDireccionarALaEntidad()
        {
            Entidad entidad = new ObstaculoDeAcero();
            int[] direccion = { 1, 0 };

            entidad.Direccionar(direccion);

            // asserts
            Assert.AreEqual(entidad.Direccion()[0], 1);
            Assert.AreEqual(entidad.Direccion()[1], 0);
        }



        [Test]
        public void TestLaEntidadEstaEnLaMismaPosicionQueLaOtraEntidad()
        {
            Casilla posicion = new Casilla(1, 1);

            Entidad obstaculo_1 = new ObstaculoDeAcero();
            obstaculo_1.PosicionarEn(posicion);

            Entidad obstaculo_2 = new ObstaculoDeAcero();
            obstaculo_2.PosicionarEn(posicion);

            // asserts
            Assert.IsTrue(obstaculo_1.MismaPosicionQue(obstaculo_2));
        }



        [Test]
        public void TestLaEntidadEstaEnDistintaPosicionQueLaOtraEntidad()
        {
            Casilla posicion_1 = new Casilla(1, 1);
            Casilla posicion_2 = new Casilla(2, 2);

            Entidad obstaculo_1 = new ObstaculoDeAcero();
            obstaculo_1.PosicionarEn(posicion_1);

            Entidad obstaculo_2 = new ObstaculoDeAcero();
            obstaculo_2.PosicionarEn(posicion_2);

            // asserts
            Assert.IsFalse(obstaculo_1.MismaPosicionQue(obstaculo_2));
        }
    }
}
