using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class BombaTest
    {
        [Test]
        public void PruebaLaCreacionDeUnaMolotov()
        {
            Molotov molotov = new Molotov();

            Assert.AreEqual(5, molotov.Destruccion);
            Assert.AreEqual(1, molotov.Retardo);
            Assert.AreEqual(3, molotov.Rango);

        }

        [Test]
        public void PruebaCrearOtraMolotov()
        {
            Molotov molotov = new Molotov();

            Assert.AreEqual(5, molotov.Destruccion);
        }


    }
}
