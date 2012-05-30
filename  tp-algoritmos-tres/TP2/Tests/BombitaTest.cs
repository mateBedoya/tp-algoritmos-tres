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
        public void CuandoBombitaLanceUnaBombaSeLeResteUna()
        {
            Bombita bombita = new Bombita(5);

            bombita.LanzarBomba();

            Assert.AreEqual(bombita.CantidadDeBombas, 4);
                    
        }

        [Test]
        public void CuandoCreoABombitaQueTenga1Vida()
        {
            Bombita bombita = new Bombita(5);

            Assert.AreEqual(bombita.Vida, 1);
        }

        [Test]
        public void CuandoCreoABombitaQueTenga5DeVelocidad() //vemos despues que significa tener "5" de velocidad
        {
            Bombita bombita = new Bombita(0);

            Assert.AreEqual(5, bombita.Velocidad);
        }

        [Test]
        public void CuandoSeMueveBombitaCambiaSuPosicionEnElTablero()
        {
            Bombita bombita = new Bombita(4);

            bombita.mover();

            Assert.AreNotEqual(bombita.Columna, 0);
            Assert.AreNotEqual(bombita.Fila, 0);
        }

    }
}
