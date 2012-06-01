using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2.Elementales;
using TP2.Juego.personajes;
using TP2.Juego.obstaculos;
using TP2.Juego.bombas;
using TP2.Juego.articulos;

namespace TP2.tests
{
    /// <summary>
    /// clase que contiene todas las pruebas de la clase Casilla
    /// </summary>

    [TestFixture]
    class CasillaTest
    {
        private Casilla casilla;

        // crea una casilla nula
        [Test]
        public void TestCrearUnaCasillaNula()
        {
            this.casilla = CasillaNull.GetInstancia();

            // asserts
            Assert.AreEqual(casilla.GetFila(), 0);
            Assert.AreEqual(casilla.GetColumna(), 0);
            Assert.AreEqual(casilla.GetPersonaje(), PersonajeNull.GetInstancia());
            Assert.AreEqual(casilla.GetObstaculo(), ObstaculoNull.GetInstancia());
            Assert.AreEqual(casilla.GetBomba(), BombaNull.GetInstancia());
            Assert.AreEqual(casilla.GetArticulo(), ArticuloNull.GetInstancia());
            Assert.AreEqual(casilla.EstaVacia(), false);
        }

        // crea una casilla asignandole la posicion que tendra en el tablero
        [Test]
        public void TestCrerarUnaCasillaConUbicacionDentroDelTablero()
        {
            this.casilla = new Casilla(2, 5);

            // asserts
            Assert.AreEqual(casilla.GetFila(), 2);
            Assert.AreEqual(casilla.GetColumna(), 5);
            Assert.AreEqual(casilla.GetPersonaje(), PersonajeNull.GetInstancia());
            Assert.AreEqual(casilla.GetObstaculo(), ObstaculoNull.GetInstancia());
            Assert.AreEqual(casilla.GetBomba(), BombaNull.GetInstancia());
            Assert.AreEqual(casilla.GetArticulo(), ArticuloNull.GetInstancia());
            Assert.AreEqual(casilla.EstaVacia(), true);
        }


    }
}
