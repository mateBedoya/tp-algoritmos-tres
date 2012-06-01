using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2.src;

namespace TP2.Tests
{
    [TestFixture]
    class CecilioTest
    {
        [Test]
        public void CrearCecilioTiene5Vida()
        {
            Cecilio cecilio = new Cecilio();
            Assert.AreEqual(cecilio.Vida, 5);
        }
    }
}
