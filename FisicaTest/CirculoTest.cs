using TP2.Fisica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP__Tests
{
    /// <summary>
    ///Se trata de una clase de prueba para CirculoTest y se pretende que
    ///contenga todas las pruebas unitarias CirculoTest.
    ///</summary>
   
    [TestClass()]
    public class CirculoTest
    {
        private Circulo circulo;

        // verifica la creacion de un circulo asignandole radio 
        // y centrado en el origen del plano XY
        [TestMethod()]
        public void TestCrearUnCirculoCentradoEnElOrigenYConUnRadio()
        {
            circulo = new Circulo(3);

            // asserts
            Assert.AreEqual(circulo.GetRadio(), 3.0);
            Assert.AreEqual(circulo.GetPosicion().GetX(), 0.0);
            Assert.AreEqual(circulo.GetPosicion().GetY(), 0.0);
        }



        // verifica la creacion de un circulo asignandole radio
        // y una posicion en el plano XY
        [TestMethod()]
        public void TestCrearUnCirculoConUnaPosicionDadaYConUnRadio()
        {
            circulo = new Circulo(3, new Punto(4, 5));

            // asserts
            Assert.AreEqual(circulo.GetRadio(), 3.0);
            Assert.AreEqual(circulo.GetPosicion().GetX(), 4.0);
            Assert.AreEqual(circulo.GetPosicion().GetY(), 5.0);
        }



        // verifica que no pueda crearse un circulo con radio negativo
        [TestMethod()]
        public void TestCrearUnCirculoInvalidoPorTenerRadioNegativo()
        {
            try
            {
                circulo = new Circulo(-5, new Punto(3, 3));
            } 
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }



        // verifica que se posicione correctamente al circulo en el plano XY
        [TestMethod()]
        public void TestPosicionarCirculoEnElPlano()
        {
            circulo = new Circulo(4);
            circulo.Posicionar(new Punto(3, 3));

            // asserts
            Assert.AreEqual(circulo.GetPosicion().GetX(), 3.0);
            Assert.AreEqual(circulo.GetPosicion().GetY(), 3.0);
        }



        // verifica que un circulo se interseque con otro
        [TestMethod()]
        public void TestSeIntersecanLosCirculos()
        {
            Circulo unCirculo = new Circulo(3, new Punto(4, 2));
            circulo = new Circulo(2, new Punto(0, 2));

            // asserts
            Assert.AreEqual(circulo.SeIntersecaConElCirculo(unCirculo), true);
        }



        // verifica que un circulo no se interseque con otro
        [TestMethod()]
        public void TestNoSeIntersecanLosCirculos()
        {
            Circulo unCirculo = new Circulo(1, new Punto(4, 2));
            circulo = new Circulo(1, new Punto(0, 2));

            // asserts
            Assert.AreEqual(circulo.SeIntersecaConElCirculo(unCirculo), false);
        }



        // verifica que un circulo este dentro de los limites pasados
        [TestMethod()]
        public void TestElCirculoSeEncuentraDentroDeLosLimitesPasados()
        {
            circulo = new Circulo(3, new Punto(4, 4));

            // asserts
            Assert.AreEqual(circulo.EstaDentroDeLosLimites(new Punto(0, 0), new Punto(8, 8)), true);
        }



        // verifica que un circulo no este dentro de los limites pasados
        [TestMethod()]
        public void TestElCirculoNoSeEncuentraDentroDeLosLimitesPasados()
        {
            circulo = new Circulo(3, new Punto(4, 2));

            // asserts
            Assert.AreEqual(circulo.EstaDentroDeLosLimites(new Punto(0, 0), new Punto(8, 8)), false);
        }
    }
}
