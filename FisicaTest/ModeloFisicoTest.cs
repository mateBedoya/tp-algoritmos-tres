using TP2.Fisica;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TP__Tests
{
    /// <summary>
    ///Se trata de una clase de prueba para ModeloFisicoEstandarTest y se pretende que
    ///contenga todas las pruebas unitarias ModeloFisicoEstandarTest.
    ///</summary>
   
    [TestClass()]
    public class ModeloFisicoEstandarTest
    {
        private ModeloFisicoEstandar modelo;

        // verifica la creacion de un modelo fisico estandar centrado en el origen
        [TestMethod()]
        public void TestCrearUnModeloFisicoEstandarUbicadoEnElOrigen()
        {
            modelo = new ModeloFisicoPersonaje();

            // asserts
            Assert.AreEqual(modelo.GetFigura().GetPosicion().GetX(), 0.0);
            Assert.AreEqual(modelo.GetFigura().GetPosicion().GetY(), 0.0);
        }



        // verifica la creacion de un modelo fisico estandar ubicado en una posicion
        [TestMethod()]
        public void TestCrearUnModeloFisicoEstandarUbicadoEnUnaPosicionDada()
        {
            modelo = new ModeloFisicoPersonaje(new Punto(5, 5));

            // asserts
            Assert.AreEqual(modelo.GetFigura().GetPosicion().GetX(), 5.0);
            Assert.AreEqual(modelo.GetFigura().GetPosicion().GetY(), 5.0);
        }



        // verifica que dos modelos se intersequen
        [TestMethod()]
        public void TestSeIntersecanLosModelos()
        {
            ModeloFisicoEstandar unModelo = new ModeloFisicoPersonaje(new Punto(5, 3));
            modelo = new ModeloFisicoPersonaje(new Punto(1, 3));

            // asserts
            Assert.AreEqual(modelo.SeIntersecaCon(unModelo), true);
        }



        // verifica que dos modelos no se intersequen
        [TestMethod()]
        public void TestNoSeIntersecanLosModelos()
        {
            ModeloFisicoEstandar unModelo = new ModeloFisicoPersonaje(new Punto(10, 10));
            modelo = new ModeloFisicoPersonaje(new Punto(0, 1));

            // asserts
            Assert.AreEqual(modelo.SeIntersecaCon(unModelo), false);
        }
    }
}
