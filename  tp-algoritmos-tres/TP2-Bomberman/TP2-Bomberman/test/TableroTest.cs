using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;
using System.Collections;
using TP2_Bomberman.src.Obstaculos;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class TableroTest
    {
        [Test]
        public void PruebaCrearUnTableroConDimension1()
        {
            Tablero tablero = new Tablero();

            Assert.AreEqual(30 * 30, tablero.Tamanio);
        }

        [Test]
        public void PruebaQueDevuelvaElCasilleroDeUnaPosicionDada()
        {
            Tablero tablero = new Tablero();

            Casillero casillero = tablero.ObtenerCasillero(1, 2);

            Assert.AreEqual(2, casillero.Columna);
            Assert.AreEqual(1, casillero.Fila);
        }

       
        [Test]
        public void PruebaQueCuandoSeIntentaAccederAUnCasilleroFueraDeRangoLanceUnaExcepcion()
        {
            Tablero tablero = new Tablero();

            Casillero casillero;

            Assert.Throws<CasilleroFueraDeRangoException>(() => casillero = tablero.ObtenerCasillero(35, 1));
        }


        [Test]
        public void PruebaTableroInicializadoConBloquesDeAcero()
        {
            Tablero tablero = new Tablero(true);
            Assert.IsInstanceOf<BloqueDeAcero>(tablero.ObtenerCasillero(1, 1).Entidad);
            Assert.IsInstanceOf<BloqueDeAcero>(tablero.ObtenerCasillero(29, 29).Entidad);
            Assert.IsInstanceOf<BloqueDeAcero>(tablero.ObtenerCasillero(15, 1).Entidad);
            Assert.IsNotInstanceOf<BloqueDeAcero>(tablero.ObtenerCasillero(0, 0).Entidad);
            Assert.IsNotInstanceOf<BloqueDeAcero>(tablero.ObtenerCasillero(2, 24).Entidad);
        }

        [Test]
        public void PruebaAgregarUnaEntidadAUnaCasillaDelTableroYVerificarQueEstaVacioDevuelvaFalse()
        {
            Tablero tablero = new Tablero();
            BloqueDeAcero bloque = new BloqueDeAcero();
            tablero.AgregarEntidadEnCasillero(bloque, 0, 0);

            Assert.IsFalse(bloque.Posicion.EstaVacio());
            Assert.IsFalse(tablero.ObtenerCasillero(0, 0).EstaVacio());
        }

        [Test]
        public void PruebaQueSeGuardeCorrectamenteLaPosicionDeBombita()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 5, 6);

            Casillero casillero = tablero.PosicionBombita;

            Assert.AreEqual(5, casillero.Fila);
            Assert.AreEqual(6, casillero.Columna);
        }

        [Test]
        public void PruebaQueSeGuardeCorrectamenteLaPosicionDeBombitaCuandoSeMueve()
        {
            Tablero tablero = new Tablero();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(bombita, 0, 0);

            bombita.MoverAbajo();
            Casillero casillero = tablero.PosicionBombita;

            Assert.AreEqual(1, casillero.Fila);
            Assert.AreEqual(0, casillero.Columna);
        }

        [Test]
        public void PruebaCrearTableroYEnemigosVivosEsNueve()
        {
            Tablero tablero = new Tablero(true);
            Assert.AreEqual(9, tablero.CantidadEnemigosVivos());
        }

    }
}
