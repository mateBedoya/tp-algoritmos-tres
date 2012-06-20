using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Articulos;



namespace TP2_Bomberman.test
{
    [TestFixture]
    class BombitaTest
    {

        [Test]
        public void CuandoCreoABombitaQueTenga1DeResistencia()
        {
            Bombita bombita = new Bombita();

            Assert.AreEqual(bombita.Resistencia, 1);
        }

        [Test]
        public void CuandoCreoABombitaQueTenga3Vidas()
        {
            Bombita bombita = new Bombita();

            Assert.AreEqual(bombita.Vidas, 3);
        }

        [Test]
        public void CuandoCreoABombitaQueTenga5DeVelocidad() //vemos despues que significa tener "5" de velocidad
        {
            Bombita bombita = new Bombita();

            Assert.AreEqual(5, bombita.Velocidad);
        }

        [Test]
        public void CuandoSeMueveBombitaALaDerechaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);

            bombita.MoverDerecha();

            Assert.AreEqual(1, bombita.Posicion.Columna);
            Assert.AreEqual(0, bombita.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveBombitaALaIzquierdaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);
            
            bombita.MoverDerecha();
            bombita.MoverIzquierda();

            Assert.AreEqual(0, bombita.Posicion.Columna);
            Assert.AreEqual(0, bombita.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveBombitaAbajoCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);

            bombita.MoverAbajo();

            Assert.AreEqual(0, bombita.Posicion.Columna);
            Assert.AreEqual(1, bombita.Posicion.Fila);
        }

        [Test]
        public void CuandoSeMueveBombitaArribaCambiaSuPosicionEnElTablero()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);

            bombita.MoverAbajo();
            bombita.MoverAbajo();
            bombita.MoverArriba();

            Assert.AreEqual(0, bombita.Posicion.Columna);
            Assert.AreEqual(1, bombita.Posicion.Fila);
        }

        [Test]
        public void IntentarMoverseAUnaPosicionInvalidaDejaABombitaEnElLugarQueEstaba()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);

            bombita.MoverArriba();

            Assert.AreEqual(0, bombita.Posicion.Columna);
            Assert.AreEqual(0, bombita.Posicion.Fila);
        }

        [Test]
        public void QueBombitaSeaDañandoPorUnaMolotovLeQuiteUnaVida()
        {
            Bombita bombita = new Bombita();

            Molotov molotov = new Molotov();

            bombita.DaniarConMolotov(molotov);

            Assert.Less(bombita.Vidas, 3);
        }

        [Test]
        public void QueBombitaSeaDañandoPorUnaToleToleLeQuiteUnaVida()
        {
            Bombita bombita = new Bombita();

            ToleTole toleTole = new ToleTole();

            bombita.DaniarConToleTole(toleTole);

            Assert.Less(bombita.Vidas, 3);
        }

        [Test]
        public void QueBombitaSeaDañandoPorUnProyectilLeQuiteUnaVida()
        {
            Bombita bombita = new Bombita();

            Proyectil proyectil = new Proyectil();

            bombita.DaniarConProyectil(proyectil);

            Assert.Less(bombita.Vidas, 3);
        }

        [Test]
        public void QueABombitaNoLeQuedenMasVidasYQueEsteDestruido()
        {
            Bombita bombita = new Bombita();
            ToleTole toleTole = new ToleTole();

            for (int i = 0; i < 3; i++)
            {
                bombita.DaniarConToleTole(toleTole);
            }

            Assert.IsTrue(bombita.FueDestruido());

        }

        [Test]
        public void TratarDeSeguirDaniandoAUnBombitaDestruidoLanceUnaExcepcion()
        {
            Bombita bombita = new Bombita();
            ToleTole toleTole = new ToleTole();

            for (int i = 0; i < 3; i++)
            {
                bombita.DaniarConToleTole(toleTole);
            }

            Assert.Throws<EntidadYaDestruidaException>(() => bombita.DaniarConToleTole(toleTole));
        }

        [Test]
        public void QueBombitaAgarreUnHabanoYQueModifiqueSuVelocidad()
        {
            Bombita bombita = new Bombita();
            Habano articulo = new Habano();
            int velocidadInicial = bombita.Velocidad;

            bombita.AgarrarArticulo(articulo);

            Assert.Greater(bombita.Velocidad, velocidadInicial);
        }

        [Test]
        public void QueBombitaAgarreUnBombaToleToleYQueModifiqueSuTipoDeBombaALanzar()
        {
            Bombita bombita = new Bombita();
            BombaToleTole articulo = new BombaToleTole();
            int destruccionInicial = bombita.Bomba.Destruccion;

            bombita.AgarrarArticulo(articulo);

            Assert.Greater(bombita.Bomba.Destruccion, destruccionInicial);
        }

        [Test]
        public void QueBombitaAgarreUnTimerYQueModifiqueElRetardoConQueVaALanzarSusBombas()
        {
            Bombita bombita = new Bombita();
            Timer articulo = new Timer();
            double porcentajeInicial = bombita.PorcentajeDeRetardo;

            bombita.AgarrarArticulo(articulo);

            Assert.Greater(bombita.Bomba.Destruccion, porcentajeInicial);
        }

    }
}
