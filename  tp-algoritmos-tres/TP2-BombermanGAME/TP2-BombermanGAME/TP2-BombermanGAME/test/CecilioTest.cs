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
    class CecilioTest
    {
        [Test]
        public void CrearCecilioTiene5Vida()
        {
            Cecilio cecilio = new Cecilio();
            Assert.AreEqual(cecilio.Resistencia, 5);
        }

        [Test]
        public void CuandoCreoACecilioQueTenga5DeVelocidad() //vemos despues que significa tener "5" de velocidad
        {
            Cecilio cecilio = new Cecilio();

            Assert.AreEqual(5, cecilio.Velocidad);
        }

        [Test]
        public void CuandoSeMueveCecilioALaDerechaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            Cecilio cecilio = new Cecilio();
            tablero.AgregarEntidadEnCasillero(cecilio, 0, 0);
            
            cecilio.MoverDerecha();

            Assert.AreEqual(1, cecilio.Posicion.Columna);
            Assert.AreEqual(0, cecilio.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveCecilioALaIzquierdaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            Cecilio cecilio = new Cecilio();
            tablero.AgregarEntidadEnCasillero(cecilio, 0, 0);

            cecilio.MoverDerecha();
            cecilio.MoverIzquierda();

            Assert.AreEqual(0, cecilio.Posicion.Columna);
            Assert.AreEqual(0, cecilio.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveCecilioAbajoCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            Cecilio cecilio = new Cecilio();
            tablero.AgregarEntidadEnCasillero(cecilio, 0, 0);

            cecilio.MoverAbajo();

            Assert.AreEqual(0, cecilio.Posicion.Columna);
            Assert.AreEqual(1, cecilio.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveCecilioArribaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            Cecilio cecilio = new Cecilio();
            tablero.AgregarEntidadEnCasillero(cecilio, 0, 0);

            cecilio.MoverAbajo();
            cecilio.MoverAbajo();
            cecilio.MoverArriba();

            Assert.AreEqual(0, cecilio.Posicion.Columna);
            Assert.AreEqual(1, cecilio.Posicion.Fila);
        }

        [Test]
        public void IntentarMoverseAUnaPosicionInvalidaDejaACecilioEnElLugarQueEstaba()
        {
            Tablero tablero = new Tablero();
            Cecilio cecilio = new Cecilio();
            tablero.AgregarEntidadEnCasillero(cecilio, 0, 0);

            cecilio.MoverArriba();

            Assert.AreEqual(0, cecilio.Posicion.Columna);
            Assert.AreEqual(0, cecilio.Posicion.Fila);
        }

        [Test]
        public void QueCecilioSeaDañandoPorUnaMolotovLeQuiteUnaVida()
        {
            Cecilio cecilio = new Cecilio();

            Molotov molotov = new Molotov();

            cecilio.DaniarConMolotov(molotov);

            Assert.IsTrue(cecilio.FueDestruido());
        }

        [Test]
        public void QueCecilioSeaDañandoPorUnaToleToleLeQuiteUnaVida()
        {
            Cecilio cecilio = new Cecilio();

            ToleTole toleTole = new ToleTole();

            cecilio.DaniarConToleTole(toleTole);

            Assert.IsTrue(cecilio.FueDestruido());
        }

        [Test]
        public void QueCecilioSeaDañandoPorUnProyectilLeQuiteUnaVida()
        {
            Cecilio cecilio = new Cecilio();

            Proyectil proyectil = new Proyectil();

            cecilio.DaniarConProyectil(proyectil);

            Assert.IsTrue(cecilio.FueDestruido());
        }

        [Test]
        public void TratarDeSeguirDaniandoACecilioDestruidoLanceUnaExcepcion()
        {
            Cecilio cecilio = new Cecilio();
            ToleTole toleTole = new ToleTole();
            cecilio.DaniarConToleTole(toleTole); //Ya lo destruyo

            Assert.Throws<EntidadYaDestruidaException>(() => cecilio.DaniarConToleTole(toleTole));
        }

        [Test]
        public void QueCecilioLanceUnaBombaYSeDanieASiMismo()
        {
            Tablero tablero = new Tablero();
            Cecilio cecilio = new Cecilio();
            tablero.AgregarEntidadEnCasillero(cecilio, 0, 0);

            cecilio.LanzarBomba();
            cecilio.MoverAbajo();

            Bomba bomba = cecilio.Bomba;

            bomba.CuandoPaseElTiempo(5);

            Assert.IsTrue(cecilio.FueDestruido());
        }
    }
}
