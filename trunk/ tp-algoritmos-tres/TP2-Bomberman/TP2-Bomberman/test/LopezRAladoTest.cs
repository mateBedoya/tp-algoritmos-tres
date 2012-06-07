using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Obstaculos;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class LopezRAladoAladoTest
    {
        [Test]
        public void crearLopezRAladoTiene5DeResistencia()
        {
            LopezRAlado lopez = new LopezRAlado();
            Assert.AreEqual(lopez.Resistencia, 5);
        }


        [Test]
        public void CuandoCreoALopezRAladoQueTenga5DeVelocidad() //vemos despues que significa tener "5" de velocidad
        {
            LopezRAlado lopez = new LopezRAlado();

            Assert.AreEqual(5, lopez.Velocidad);
        }

        [Test]
        public void CuandoSeMueveLopezRAladoALaDerechaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            LopezRAlado lopez = new LopezRAlado();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);
            
            lopez.MoverDerecha();

            Assert.AreEqual(1, lopez.Posicion.Columna);
            Assert.AreEqual(0, lopez.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveLopezRAladoALaIzquierdaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            LopezRAlado lopez = new LopezRAlado();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);

            lopez.MoverDerecha();
            lopez.MoverIzquierda();

            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(0, lopez.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveLopezRAladoAbajoCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            LopezRAlado lopez = new LopezRAlado();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);

            lopez.MoverAbajo();

            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(1, lopez.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveLopezRAladoArribaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            LopezRAlado lopez = new LopezRAlado();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);

            lopez.MoverAbajo();
            lopez.MoverAbajo();
            lopez.MoverArriba();

            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(1, lopez.Posicion.Fila);
        }

        [Test]
        public void IntentarMoverseAUnaPosicionInvalidaDejaALopezRAladoEnElLugarQueEstaba()
        {
            Tablero tablero = new Tablero();
            LopezRAlado lopez = new LopezRAlado();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);

            lopez.MoverArriba();

            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(0, lopez.Posicion.Fila);
        }

        [Test]
        public void QueLopezRAladoSeaDañandoPorUnaMolotovLeQuiteUnaVida()
        {
            LopezRAlado lopez = new LopezRAlado();

            Molotov molotov = new Molotov();

            lopez.DaniarConMolotov(molotov);

            Assert.IsTrue(lopez.FueDestruido());
        }

        [Test]
        public void QueLopezRAladoSeaDañandoPorUnaToleToleLeQuiteUnaVida()
        {
            LopezRAlado lopez = new LopezRAlado();

            ToleTole toleTole = new ToleTole();

            lopez.DaniarConToleTole(toleTole);

            Assert.IsTrue(lopez.FueDestruido());
        }

        [Test]
        public void QueLopezRAladoSeaDañandoPorUnProyectilLeQuiteUnaVida()
        {
            LopezRAlado lopez = new LopezRAlado();

            Proyectil proyectil = new Proyectil();

            lopez.DaniarConProyectil(proyectil);

            Assert.IsTrue(lopez.FueDestruido());
        }

        [Test]
        public void TratarDeSeguirDaniandoALopezRAladoDestruidoLanceUnaExcepcion()
        {
            LopezRAlado lopez = new LopezRAlado();
            ToleTole toleTole = new ToleTole();
            lopez.DaniarConToleTole(toleTole); //Ya lo destruyo

            Assert.Throws<EntidadYaDestruidaException>(() => lopez.DaniarConToleTole(toleTole));
        }

        /*[Test]
        public void QueLopezRAladoPuedaMoversePorArribaDeLosObstaculos()
        {
            Tablero tablero = new Tablero();
            LopezRAlado lopez = new LopezRAlado();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);
            BloqueDeAcero bloque = new BloqueDeAcero();
            tablero.AgregarEntidadEnCasillero(bloque, 0, 1);

            lopez.MoverDerecha();
            lopez.MoverDerecha();

            Assert.AreEqual(2, lopez.Posicion.Columna);
        }*/
    }
}
