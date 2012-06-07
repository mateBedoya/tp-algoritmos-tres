using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class LopezRTest
    {
        [Test]
        public void crearLopezRTiene10Resistencia()
        {
            LopezR lopezR = new LopezR();
            Assert.AreEqual(lopezR.Resistencia, 10);
        }


        [Test]
        public void CuandoCreoALopezRQueTenga5DeVelocidad() //vemos despues que significa tener "5" de velocidad
        {
            LopezR lopez = new LopezR();

            Assert.AreEqual(5, lopez.Velocidad);
        }

        [Test]
        public void CuandoSeMueveLopezRALaDerechaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            LopezR lopez = new LopezR();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);
            
            lopez.MoverDerecha();

            Assert.AreEqual(1, lopez.Posicion.Columna);
            Assert.AreEqual(0, lopez.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveLopezRALaIzquierdaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            LopezR lopez = new LopezR();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);

            lopez.MoverDerecha();
            lopez.MoverIzquierda();

            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(0, lopez.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveLopezRAbajoCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            LopezR lopez = new LopezR();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);

            lopez.MoverAbajo();

            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(1, lopez.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveLopezRArribaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            LopezR lopez = new LopezR();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);

            lopez.MoverAbajo();
            lopez.MoverAbajo();
            lopez.MoverArriba();

            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(1, lopez.Posicion.Fila);
        }

        [Test]
        public void IntentarMoverseAUnaPosicionInvalidaDejaALopezREnElLugarQueEstaba()
        {
            Tablero tablero = new Tablero();
            LopezR lopez = new LopezR();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 0);

            lopez.MoverArriba();

            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(0, lopez.Posicion.Fila);
        }

        [Test]
        public void QueLopezRSeaDañandoPorUnaMolotovLeQuiteUnaVida()
        {
            LopezR lopez = new LopezR();

            Molotov molotov = new Molotov();

            lopez.DaniarConMolotov(molotov);

            Assert.AreEqual(5,lopez.Resistencia);
        }

        [Test]
        public void QueLopezRSeaDañandoPorUnaToleToleLeQuiteUnaVida()
        {
            LopezR lopez = new LopezR();

            ToleTole toleTole = new ToleTole();

            lopez.DaniarConToleTole(toleTole);

            Assert.IsTrue(lopez.FueDestruido());
        }

        [Test]
        public void QueLopezRSeaDañandoPorUnProyectilLeQuiteUnaVida()
        {
            LopezR lopez = new LopezR();

            Proyectil proyectil = new Proyectil();

            lopez.DaniarConProyectil(proyectil);

            Assert.AreEqual(5,lopez.Resistencia);
        }

        [Test]
        public void TratarDeSeguirDaniandoALopezRDestruidoLanceUnaExcepcion()
        {
            LopezR lopez = new LopezR();
            ToleTole toleTole = new ToleTole();
            lopez.DaniarConToleTole(toleTole); //Ya lo destruyo

            Assert.Throws<EntidadYaDestruidaException>(() => lopez.DaniarConToleTole(toleTole));
        }
    }
}
