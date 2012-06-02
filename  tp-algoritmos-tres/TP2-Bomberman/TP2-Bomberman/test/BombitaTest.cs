using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TP2_Bomberman.test
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

            bombita.MoverDerecha();

            Assert.AreEqual(0, bombita.Columna);
            Assert.AreEqual(1, bombita.Fila);
        }

    }
}
