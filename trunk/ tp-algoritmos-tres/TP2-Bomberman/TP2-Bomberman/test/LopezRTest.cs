using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class LopezRTest
    {
        [Test]
        public void crearLopezRTiene10Vida()
        {
            LopezR lopezR = new LopezR();
            Assert.AreEqual(lopezR.Resistencia, 10);
        }
    }
}
