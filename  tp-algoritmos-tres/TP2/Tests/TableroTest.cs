using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2.Elementales;

namespace TP2.tests
{
    [TestFixture]
    class TableroTest
    {
        private Tablero tablero;

        // crea un tablero con sus casilleros inicializados
        [Test]
        public void TestCrearTableroConSusCasillerosInicializados()
        {
            this.tablero = Tablero.GetInstancia();

            // assert
            Assert.AreEqual(tablero.GetTamanio(), 900);
            
        }
    }
}
