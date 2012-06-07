using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;

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
            tablero.AgregarPersonajeEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            Cecilio cecilio = new Cecilio();
            tablero.AgregarPersonajeEnCasillero(cecilio, 5, 0);

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
            tablero.AgregarPersonajeEnCasillero(bombita, 0, 0);// Arranca en (0,0)
            Cecilio cecilio = new Cecilio();
            tablero.AgregarPersonajeEnCasillero(cecilio, 5, 0);

            bombita.MoverAbajo();
            cecilio.MoverArriba();
            cecilio.MoverArriba();
            cecilio.MoverArriba();
            cecilio.MoverArriba();

            Assert.IsTrue(bombita.Vidas == 2);
            Assert.AreEqual(1, cecilio.Posicion.Fila);
            Assert.AreEqual(0, cecilio.Posicion.Columna);
            
        }

    }
}
