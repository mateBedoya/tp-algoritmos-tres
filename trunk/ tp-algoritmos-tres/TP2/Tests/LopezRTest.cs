using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2.src;

namespace TP2.Tests
{
    [TestFixture]
    class LopezRTest
    {
        [Test]
        public void crearLopezRTiene10Vida()
        {
            LopezR lopezR = new LopezR();
            Assert.AreEqual(lopezR.Vida, 10);
        }
    }
}
