using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class CecilioTest
    {
        [Test]
        public void CrearCecilioTiene5Vida()
        {
            Cecilio cecilio = new Cecilio();
            Assert.AreEqual(cecilio.Resistencia, 5);
        }
    }
}
