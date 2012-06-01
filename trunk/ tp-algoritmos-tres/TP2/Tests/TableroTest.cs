using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Collections;

namespace TP2.Tests
{
    [TestFixture]
    class TableroTest
    {
        [Test]
        public void PruebaCrearUnTableroConDimension1()
        {
            Tablero tablero = new Tablero(1, 1);

            Assert.AreEqual(1, tablero.Tamanio);
        }

        [Test]
        public void PruebaQueDevuelvaElCasilleroDeUnaPosicionDada()
        {
            Tablero tablero = new Tablero(4, 4);

            Casillero casillero = tablero.ObtenerCasillero(1, 2);

            Assert.AreEqual(2,casillero.Columna);
            Assert.AreEqual(1,casillero.Fila);
        }

        [Test]
        public void PruebaQueDevuelvaLosAdyacentesDeUnCasillero()
        {
            Tablero tablero = new Tablero(4, 4);

            ArrayList listaDeAdyacentes = tablero.ObtenerAdyacentes(2, 2); // izq,arriba,der,abajo

            Casillero izquierda = (Casillero)listaDeAdyacentes[0];
            Casillero arriba = (Casillero)listaDeAdyacentes[1];
            Casillero derecha = (Casillero)listaDeAdyacentes[2];
            Casillero abajo = (Casillero)listaDeAdyacentes[3];

            Assert.AreEqual(1, izquierda.Columna);
            Assert.AreEqual(2, izquierda.Fila);
            Assert.AreEqual(2, arriba.Columna);
            Assert.AreEqual(1, arriba.Fila);
            Assert.AreEqual(3, derecha.Columna);
            Assert.AreEqual(2, derecha.Fila);
            Assert.AreEqual(2, abajo.Columna);
            Assert.AreEqual(3, abajo.Fila);
        }
    }
}

//  0 1 2 3
//0 1 1 1 1
//1 1 1 1 1
//2 1 1 1 1
//3 1 1 1 1