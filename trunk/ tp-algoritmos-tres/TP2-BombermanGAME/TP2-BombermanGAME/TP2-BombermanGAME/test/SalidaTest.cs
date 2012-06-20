using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Obstaculos;

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

        [Test]
        public void PruebaLaCreacionDeUnaSalidaEnUnaPosicionDeterminadaEnUnTablero()
        {
            Tablero tablero = new Tablero();
            Salida salida = new Salida();
            tablero.AgregarEntidadEnCasillero(salida, 5, 5);

            Assert.IsNotNull(salida);
            Assert.IsFalse(salida.FueDestruido());
            Assert.AreEqual(5, salida.Posicion.Fila);
            Assert.AreEqual(5, salida.Posicion.Columna);
        }

        [Test]
        public void PruebaQueUnaMolotovNoLoDestruya()
        {
            Tablero tablero = new Tablero();
            Salida salida = new Salida();
            tablero.AgregarEntidadEnCasillero(salida, 5, 5);
            Molotov bomba = new Molotov();
            tablero.AgregarEntidadEnCasillero(bomba, 5, 6);

            bomba.ActivarBomba();

            bomba.CuandoPaseElTiempo(5);

            Assert.IsFalse(salida.FueDestruido());
        }

        [Test]
        public void PruebaQueDaniarloNoLoDestruya()
        {
            Tablero tablero = new Tablero();
            Salida salida = new Salida();
            tablero.AgregarEntidadEnCasillero(salida, 5, 5);

            salida.DaniarConMolotov(new Molotov());
            Assert.IsFalse(salida.FueDestruido());

            salida.DaniarConProyectil(new Proyectil());
            Assert.IsFalse(salida.FueDestruido());

            salida.DaniarConToleTole(new ToleTole());
            Assert.IsFalse(salida.FueDestruido());
        }

        [Test]
        public void PruebaQueCuandoBombitaLoAgarrePaseDeNivel()
        {
            Tablero tablero = new Tablero();
            Salida salida = new Salida();
            tablero.AgregarEntidadEnCasillero(salida, 5, 5);
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 6, 5);

            bombita.MoverArriba();

            Assert.AreEqual(2, tablero.NivelActual);
        }

        [Test]
        public void PruebaQueUnBloqueTengaUnaSalidaYCuandoSeaDestruidoLaDejeEnElTablero()
        {
            Tablero tablero = new Tablero();
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();
            tablero.AgregarEntidadEnCasillero(bloque, 3, 4);
            Salida salida = new Salida();
            bloque.Articulo = salida;

            bloque.DaniarConToleTole(new ToleTole());

            Assert.AreEqual(3, salida.Posicion.Fila);
            Assert.AreEqual(4, salida.Posicion.Columna);

        }

    }
}
