using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TP2.Tests
{
    [TestFixture]
    class TableroTest
    {
        [Test]
        public void PruebaCrearUnTableroConDimension1()
        {
            Tablero tablero = new Tablero(1, 1);

            Assert.AreEqual(tablero.Tamanio, 1);
        }

        [Test]
        public void PruebaQueDevuelvaElCasilleroDeUnaPosicionDada()
        {
            Tablero tablero = new Tablero(4, 4);

            Casillero casillero = tablero.ObtenerCasillero(1, 2);

            Assert.AreEqual(casillero.Columna,2);
            Assert.AreEqual(casillero.Fila, 1);
            
        }
    }
}
