using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Bombas;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class IntegracionTest
    {
        [Test]
        public void CreaUnTableroConUnBombitaYUnCecilioYLosMueve()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            Cecilio cecilio = new Cecilio();
            tablero.AgregarEntidadEnCasillero(cecilio, 5, 0);

            bombita.MoverAbajo();
            cecilio.MoverArriba();
            cecilio.MoverArriba();
            cecilio.MoverArriba();

            Assert.AreEqual(1, bombita.Posicion.Fila);
            Assert.AreEqual(2, cecilio.Posicion.Fila);
        }

        [Test]
        public void CreaUnTableroConUnBombitaYUnCecilioYLosMueveHastaChocarse()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            Cecilio cecilio = new Cecilio();
            tablero.AgregarEntidadEnCasillero(cecilio, 5, 0);

            bombita.MoverAbajo();
            cecilio.MoverArriba();
            cecilio.MoverArriba();
            cecilio.MoverArriba();
            bombita.MoverAbajo();

            Assert.IsTrue(bombita.Vidas == 2);
            Assert.AreEqual(2, cecilio.Posicion.Fila);
            Assert.AreEqual(0, cecilio.Posicion.Columna);
            Assert.AreEqual(1, bombita.Posicion.Fila);//bombita pierde una vida y no avanza
            Assert.AreEqual(0, bombita.Posicion.Columna);
        }

        [Test]
        public void CreaUnTableroConBombitaYUnLopezRYLosMueveHastaChocarseYQueBombitaPierdaUnaVida()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            LopezR lopez = new LopezR();
            tablero.AgregarEntidadEnCasillero(lopez, 0, 3);

            bombita.MoverAbajo();
            lopez.MoverIzquierda();
            lopez.MoverIzquierda();
            lopez.MoverIzquierda();
            bombita.MoverArriba();

            Assert.IsTrue(bombita.Vidas == 2);
            Assert.AreEqual(0, lopez.Posicion.Fila);
            Assert.AreEqual(0, lopez.Posicion.Columna);
            Assert.AreEqual(1, bombita.Posicion.Fila);//bombita pierde una vida y no avanza
            Assert.AreEqual(0, bombita.Posicion.Columna);
        }

        [Test]
        public void CreaUnTableroConBombitaYUnLopezRAladoYLosMueveHastaChocarseYQueBombitaPierdaUnaVida()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 29, 29);// Arranca en (0,0)
            LopezRAlado lopez = new LopezRAlado();
            tablero.AgregarEntidadEnCasillero(lopez, 1, 29);

            for (int i = 0; i < 28; i++)
            {
                bombita.MoverArriba();
            }
            lopez.MoverAbajo();

            Assert.IsTrue(bombita.Vidas == 2);
            Assert.AreEqual(1, lopez.Posicion.Fila);
            Assert.AreEqual(29, lopez.Posicion.Columna);
            Assert.AreEqual(2, bombita.Posicion.Fila);
            Assert.AreEqual(29, bombita.Posicion.Columna);
        }

        [Test]
        public void CreaUnTableroConBombitaYUnObstaculoYMueveABombitaHastaChocarse()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            BloqueDeAcero bloque = new BloqueDeAcero();
            tablero.AgregarEntidadEnCasillero(bloque, 0, 2);

            bombita.MoverDerecha();
            bombita.MoverDerecha();
            //Cuando trata de ir a donde hay un bloque no pasa nada
            Assert.AreEqual(0, bloque.Posicion.Fila);
            Assert.AreEqual(2, bloque.Posicion.Columna);
            Assert.AreEqual(0, bombita.Posicion.Fila);
            Assert.AreEqual(1, bombita.Posicion.Columna);
        }

        [Test]
        public void CreaUnTableroConBombitaYUnHabanoYMueveABombitaHastaAgarrarlo()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            Habano habano = new Habano();
            tablero.AgregarEntidadEnCasillero(habano, 0, 2);

            bombita.MoverDerecha();
            bombita.MoverDerecha();
            //Con un articulo, bombita debe agarrarlo y avanzar a su posicion. El articulo no debe estar mas en el tablero
            Assert.IsNull(habano.Posicion);
            Assert.AreEqual(0, bombita.Posicion.Fila);
            Assert.AreEqual(2, bombita.Posicion.Columna);
            Assert.AreEqual(10, bombita.Velocidad);
        }

        [Test]
        public void CreaUnTableroConBombitaYUnBombaToleToleYMueveABombitaHastaAgarrarlo()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            BombaToleTole articulo = new BombaToleTole();
            tablero.AgregarEntidadEnCasillero(articulo, 0, 2);

            bombita.MoverDerecha();
            bombita.MoverDerecha();
            //Con un articulo, bombita debe agarrarlo y avanzar a su posicion. El articulo no debe estar mas en el tablero
            Assert.IsNull(articulo.Posicion);
            Assert.AreEqual(0, bombita.Posicion.Fila);
            Assert.AreEqual(2, bombita.Posicion.Columna);
            Assert.IsInstanceOf<ToleTole>(bombita.Bomba);
        }

        [Test]
        public void CreaUnTableroConBombitaYUnTimerYMueveABombitaHastaAgarrarlo()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            Timer articulo = new Timer();
            tablero.AgregarEntidadEnCasillero(articulo, 0, 2);

            bombita.MoverDerecha();
            bombita.MoverDerecha();
            //Con un articulo, bombita debe agarrarlo y avanzar a su posicion. El articulo no debe estar mas en el tablero
            Assert.IsNull(articulo.Posicion);
            Assert.AreEqual(0, bombita.Posicion.Fila);
            Assert.AreEqual(2, bombita.Posicion.Columna);
            Assert.AreEqual(0.85, bombita.PorcentajeDeRetardo);
        }

        [Test]
        public void CreaUnTableroConBombitaYUnaBombaYMueveABombitaHastaChocar()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            Molotov bomba = new Molotov();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 2);

            bombita.MoverDerecha();
            bombita.MoverDerecha();
            //Con una bomba, no pasa nada, bombita no puede avanzar
            Assert.AreEqual(0, bombita.Posicion.Fila);
            Assert.AreEqual(1, bombita.Posicion.Columna);
            Assert.AreEqual(0, bomba.Posicion.Fila);
            Assert.AreEqual(2, bomba.Posicion.Columna);
        }
        
        [Test]
        public void CreaUnTableroConBombitaYUnProyectilYSeColisionanEntoncesBombitaPierdeUnaVida()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            Proyectil bomba = new Proyectil();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 2);

            bomba.MoverIzquierda();
            bomba.MoverIzquierda();
            
            Assert.AreEqual(0, bombita.Posicion.Fila);
            Assert.AreEqual(0, bombita.Posicion.Columna);
            Assert.AreEqual(2, bombita.Vidas);
            Assert.IsNull(bomba.Posicion);
            
        }

        [Test]
        public void CreaUnTableroConBombitaYUnBloqueConUnArticuloYQueBombitaLoAgarre()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita,0,0);

            BloqueDeCemento bloque = new BloqueDeCemento();
            tablero.AgregarEntidadEnCasillero(bloque, 0, 1);
            Habano habano = new Habano();
            bloque.Articulo = habano;

            bloque.DaniarConToleTole(new ToleTole());

            bombita.MoverDerecha();

            Assert.AreEqual(0, bombita.Posicion.Fila);
            Assert.AreEqual(1, bombita.Posicion.Columna);
            Assert.AreEqual(10, bombita.Velocidad);


            

        }
    }
}
