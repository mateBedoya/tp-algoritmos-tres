using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2.src;

namespace TP2.Tests
{
    [TestFixture]
    class BombitaTest
    {

        [Test]
        public void CuandoCreoABombitaQueTenga1Vida()
        {
            Bombita bombita = new Bombita();

            Assert.AreEqual(bombita.Vida, 1);
        }

        [Test]
        public void CuandoCreoABombitaQueTenga5DeVelocidad() //vemos despues que significa tener "5" de velocidad
        {
            Bombita bombita = new Bombita();

            Assert.AreEqual(5, bombita.Velocidad);
        }

        [Test]
        public void CuandoSeMueveBombitaCambiaSuPosicionEnElTablero()
        {
            Bombita bombita = new Bombita();

            bombita.mover();

            Assert.AreNotEqual(bombita.Columna, 0);
            Assert.AreNotEqual(bombita.Fila, 0);
        }

    }
}
