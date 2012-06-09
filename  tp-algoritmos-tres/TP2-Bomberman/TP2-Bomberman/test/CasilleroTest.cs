using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;

namespace TP2_Bomberman.test
{
    [TestFixture]
    public class CasilleroTest
    {
        [Test]
        public void PruebaLaCreacionDeUnCasillero()
        {
            Casillero casillero = new Casillero(1, 5);

            Assert.AreEqual(casillero.Fila, 1);
            Assert.AreEqual(casillero.Columna, 5);

        }

        [Test]
        public void PruebaQueCuandoSeCreaUnCasilleroEsteVacio()
        {
            Casillero casillero = new Casillero(1, 5);

            Assert.IsTrue(casillero.EstaVacio());
        }

        [Test]
        public void PruebaPosicionarUnPersonajeEnLaCasilla()
        {
            Casillero casillero = new Casillero(0, 0);

            Personaje personaje = new Bombita();

            casillero.Entidad = personaje;

            Assert.IsNotNull(casillero.Entidad);
        }

        [Test]
        public void PruebaPosicionarUnPersonajeEnLaCasillaYQueTienePersonajeDevuelvaTrue()
        {
            Casillero casillero = new Casillero(0, 0);

            Bombita personaje = new Bombita();

            casillero.Entidad = personaje;

            Assert.IsTrue(casillero.TienePersonaje());
        }

        [Test]
        public void PruebaPosicionarUnBloqueEnLaCasillaYQueTienePersonajeDevuelvaFalse()
        {
            Casillero casillero = new Casillero(0, 0);

            BloqueDeAcero bloque = new BloqueDeAcero();

            casillero.Entidad = bloque;

            Assert.IsFalse(casillero.TienePersonaje());
        }

        [Test]
        public void PruebaPosicionarUnaBombaEnLaCasilla()
        {
            Casillero casillero = new Casillero(0, 0);

            Molotov bomba = new Molotov();

            casillero.Entidad = bomba;

            Assert.IsNotNull(casillero.Entidad);
        }

        [Test]
        public void PruebaPosicionarUnObstaculoEnLaCasilla()
        {
            Casillero casillero = new Casillero(0, 0);

            Obstaculo bloque = new BloqueDeAcero();

            casillero.Entidad = bloque;

            Assert.IsNotNull(casillero.Entidad);
        }

        [Test]
        public void PruebaPosicionarUnArticuloEnLaCasilla()
        {
            Casillero casillero = new Casillero(0, 0);

            Articulo articulo = new Habano();

            casillero.Entidad = articulo;

            Assert.IsNotNull(casillero.Entidad);
        }

        [Test]
        public void PruebaObtenerLaCasillaPosicionadaALaDerecha()
        {
            Tablero tablero = new Tablero();
            Casillero casilleroActual = tablero.ObtenerCasillero(1, 1);

            Casillero casilleroDerecho = casilleroActual.ObtenerCasilleroDerechoDe(tablero);

            Assert.AreEqual(1, casilleroDerecho.Fila);
            Assert.AreEqual(2, casilleroDerecho.Columna);

        }

        [Test]
        public void PruebaObtenerLaCasillaPosicionadaArriba()
        {
            Tablero tablero = new Tablero();
            Casillero casilleroActual = tablero.ObtenerCasillero(1, 1);

            Casillero casilleroArriba = casilleroActual.ObtenerCasilleroSuperiorDe(tablero);

            Assert.AreEqual(0, casilleroArriba.Fila);
            Assert.AreEqual(1, casilleroArriba.Columna);

        }

        [Test]
        public void PruebaObtenerLaCasillaPosicionadaALaIzquierda()
        {

            Tablero tablero = new Tablero();
            Casillero casilleroActual = tablero.ObtenerCasillero(1, 1);

            Casillero casilleroIzquierdo = casilleroActual.ObtenerCasilleroIzquierdoDe(tablero);

            Assert.AreEqual(1, casilleroIzquierdo.Fila);
            Assert.AreEqual(0, casilleroIzquierdo.Columna);

        }

        [Test]
        public void PruebaObtenerLaCasillaPosicionadaAbajo()
        {

            Tablero tablero = new Tablero();
            Casillero casilleroActual = tablero.ObtenerCasillero(1, 1);

            Casillero casilleroAbajo = casilleroActual.ObtenerCasilleroInferiorDe(tablero);

            Assert.AreEqual(2, casilleroAbajo.Fila);
            Assert.AreEqual(1, casilleroAbajo.Columna);

        }

        [Test]
        public void PruebaQueElCasilleroEsteVacioDevuelvaTrueCuandoEsteVacio()
        {
            Casillero casillero = new Casillero(5, 5);

            Assert.IsTrue(casillero.EstaVacio());

        }

        [Test]
        public void PruebaQueCasilleroEstaVacioDevuelvaFalseCuandoTieneUnCecilioAdentroCuandoSeLoPasoEnUnSetter()
        {
            Casillero casillero = new Casillero(5, 6);
            Cecilio cecilio = new Cecilio();
            casillero.Entidad = cecilio;

            Assert.IsFalse(casillero.EstaVacio());
            Assert.AreEqual(5, cecilio.Posicion.Fila);
            Assert.AreEqual(6, cecilio.Posicion.Columna);
        }

        [Test]
        public void PruebaQueCasilleroEstaVacioDevuelvaFalseCuandoTieneUnCecilioAdentroCuandoLePasoLaPosicionDesdeCecilio()
        {
            Casillero casillero = new Casillero(5, 4);
            Cecilio cecilio = new Cecilio(casillero);
            
            Assert.IsFalse(casillero.EstaVacio());
            Assert.AreEqual(5, cecilio.Posicion.Fila);
            Assert.AreEqual(4, cecilio.Posicion.Columna);
        }

        [Test]
        public void PruebaQueCasilleroEstaVacioDevuelvaFalseCuandoTieneUnaMolotovAdentroCuandoSeLoPasoEnUnSetter()
        {
            Casillero casillero = new Casillero(5, 6);
            Bomba bomba = new Molotov();
            casillero.Entidad = bomba;

            Assert.IsFalse(casillero.EstaVacio());
            Assert.AreEqual(5, bomba.Posicion.Fila);
            Assert.AreEqual(6, bomba.Posicion.Columna);
        }

        [Test]
        public void PruebaQueCasilleroEstaVacioDevuelvaFalseCuandoTieneUnaMolotovAdentroCuandoLePasoLaPosicionDesdeMOLOTOV()
        {
            Casillero casillero = new Casillero(5, 4);
            Bomba bomba = new Molotov(casillero);

            Assert.IsFalse(casillero.EstaVacio());
            Assert.AreEqual(5, bomba.Posicion.Fila);
            Assert.AreEqual(4, bomba.Posicion.Columna);
        }

        [Test]
        public void PruebaQueCasilleroEstaVacioDevuelvaFalseCuandoTieneUnTimerAdentroCuandoSeLoPasoEnUnSetter()
        {
            Casillero casillero = new Casillero(5, 6);
            Timer timer = new Timer();
            casillero.Entidad = timer;

            Assert.IsFalse(casillero.EstaVacio());
            Assert.AreEqual(5, timer.Posicion.Fila);
            Assert.AreEqual(6, timer.Posicion.Columna);
        }

        [Test]
        public void PruebaQueCasilleroEstaVacioDevuelvaFalseCuandoTieneUnTimerAdentroCuandoLePasoLaPosicionDesdeTimer()
        {
            Casillero casillero = new Casillero(5, 4);
            Timer timer = new Timer(casillero);

            Assert.IsFalse(casillero.EstaVacio());
            Assert.AreEqual(5, timer.Posicion.Fila);
            Assert.AreEqual(4, timer.Posicion.Columna);
        }

        [Test]
        public void PruebaQueCasilleroEstaVacioDevuelvaFalseCuandoTieneUnBloqueDeAceroAdentroCuandoSeLoPasoEnUnSetter()
        {
            Casillero casillero = new Casillero(5, 6);
            Obstaculo bloque = new BloqueDeAcero();
            casillero.Entidad = bloque;

            Assert.IsFalse(casillero.EstaVacio());
            Assert.AreEqual(5, bloque.Posicion.Fila);
            Assert.AreEqual(6, bloque.Posicion.Columna);
        }

        [Test]
        public void PruebaQueCasilleroEstaVacioDevuelvaFalseCuandoTieneUnBloqueDeAceroAdentroCuandoLePasoLaPosicionDesdeElBloque()
        {
            Casillero casillero = new Casillero(5, 4);
            Obstaculo bloque = new BloqueDeAcero(casillero);

            Assert.IsFalse(casillero.EstaVacio());
            Assert.AreEqual(5, bloque.Posicion.Fila);
            Assert.AreEqual(4, bloque.Posicion.Columna);
        }



    }
}
