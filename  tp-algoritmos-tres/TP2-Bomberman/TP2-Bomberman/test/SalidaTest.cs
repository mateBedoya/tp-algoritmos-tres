using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class SalidaTest
    {
        [Test]
        public void PruebaLaCreacionDeUnaSalidaEnUnaPosicionDeterminada()
        {
            Salida articulo = new Salida(new Casillero(4, 6));

            Assert.IsNotNull(articulo);
            Assert.IsFalse(articulo.FueDestruido());
            Assert.AreEqual(4, articulo.Posicion.Fila);
            Assert.AreEqual(6, articulo.Posicion.Columna);
        }
    }
}
