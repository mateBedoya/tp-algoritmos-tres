using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TP2
{
    [TestFixture]
    public class CasilleroTest
    {
        [Test]
        public void PruebaLaCreacionDeUnCasillero()
        {
            Casillero casillero = new Casillero(1, 5);

            Assert.AreEqual(casillero.Fila, 1);
            Assert.AreEqual(casillero.Columna, 5);

        }
    }
}
