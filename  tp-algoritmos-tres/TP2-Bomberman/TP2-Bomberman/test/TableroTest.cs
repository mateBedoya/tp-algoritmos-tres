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
        public void PruebaQueDevuelvaLosAdyacentesDeUnCasillero()
        {
            Tablero tablero = new Tablero();

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

        [Test]
        public void PruebaQueCuandoSeIntentaAccederAUnCasilleroFueraDeRangoLanceUnaExcepcion()
        {
            Tablero tablero = new Tablero();

            Casillero casillero;

            Assert.Throws<CasilleroFueraDeRangoException>(() => casillero = tablero.ObtenerCasillero(35, 1));
        }

        [Test]
        public void PruebaQueDevuelvaLosAdyacentesDeUnCasilleroQueEsteEnElBorde()
        {
            Tablero tablero = new Tablero();

            ArrayList listaDeAdyacentes = tablero.ObtenerAdyacentes(0, 0); // izq,arriba,der,abajo

            Casillero izquierda = (Casillero)listaDeAdyacentes[0];
            Casillero arriba = (Casillero)listaDeAdyacentes[1];
            Casillero derecha = (Casillero)listaDeAdyacentes[2];
            Casillero abajo = (Casillero)listaDeAdyacentes[3];

            Assert.IsNull(izquierda);
            Assert.IsNull(arriba);
            Assert.IsNotNull(derecha);
            Assert.IsNotNull(abajo);
        }

        [Test]
        public void PruebaQueLanceUnaExcepcionCuandoQuieraObtenerLosAdyacentesDeUnCasilleroFueraDeRango()
        {

            Tablero tablero = new Tablero();

            ArrayList listaDeAdyacentes;

            Assert.Throws<CasilleroFueraDeRangoException>(() => listaDeAdyacentes = tablero.ObtenerAdyacentes(-5, 8));
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
            Assert.AreEqual(tablero.EnemigosVivos, 9);
        }

    }
}
