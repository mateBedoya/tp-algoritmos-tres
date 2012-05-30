using TP2.Elementales;
using TP2.Fisica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP__Tests
{
    /// <summary>
    ///Se trata de una clase de prueba para ServiciosTest y se pretende que
    ///contenga todas las pruebas unitarias ServiciosTest.
    ///</summary>
   
    [TestClass()]
    public class ServiciosTest
    {
        private Servicios servicios = Servicios.GetInstancia();

        // verifica la solicitud de servicios direccionales
        [TestMethod()]
        public void TestSolicitarDireccionesPosibles()
        {
            // asserts
            Assert.AreEqual(servicios.DIRECCION_ESTE, 0.0);
            Assert.AreEqual(servicios.DIRECCION_NORTE, 90.0);
            Assert.AreEqual(servicios.DIRECCION_OESTE, 180.0);
            Assert.AreEqual(servicios.DIRECCION_SUR, 270.0);
        }
    }
}
