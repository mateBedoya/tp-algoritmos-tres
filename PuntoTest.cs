using TP2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP__Tests
{

    ///Se trata de una clase de prueba para PuntoTest y se pretende que
    ///contenga todas las pruebas unitarias PuntoTest.
   
    [TestClass()]
    public class PuntoTest
    {
        private Punto punto;

        // verifica la creacion de un punto nulo
        [TestMethod()]
        public void TestCrearUnPuntoNulo()
        {
            punto = new Punto();
           
            // asserts
            Assert.AreEqual(punto.GetX(), 0.0);
            Assert.AreEqual(punto.GetY(), 0.0);
        }



        // verifica la creacion de un punto con coordenadas X e Y
        [TestMethod()]
        public void TestCrearUnPuntoConCoordenadaXeY()
        {
            punto = new Punto(5, 5);

            // asserts
            Assert.AreEqual(punto.GetX(), 5.0);
            Assert.AreEqual(punto.GetY(), 5.0);
        }



        // verifica el desplazamiento de un punto por el plano
        [TestMethod()]
        public void TestDesplazarUnPuntoPorElPlano()
        {
            punto = new Punto(3, 2);
            punto.Desplazar(2, 3);

            // asserts
            Assert.AreEqual(punto.GetX(), 5.0);
            Assert.AreEqual(punto.GetY(), 5.0);
        }
        


        // verifica el calculo de la distancia entre dos puntos
        [TestMethod()]
        public void TestCalculoDeLaDistanciaEntreDosPuntos()
        {
            Punto unPunto = new Punto(3, 3);
            punto = new Punto(7, 6);

            // asserts
            Assert.AreEqual(punto.DistanciaA(unPunto), 5.0);
        }
    }
}
