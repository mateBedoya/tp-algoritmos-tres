using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Obstaculos;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class BombaTest
    {
        [Test]
        public void PruebaLaCreacionDeUnaMolotov()
        {
            Molotov molotov = new Molotov();

            Assert.AreEqual(5, molotov.Destruccion);
            Assert.AreEqual(1, molotov.Retardo);
            Assert.AreEqual(3, molotov.Rango);

        }

        [Test]
        public void PruebaCrearOtraMolotov()
        {
            Molotov molotov = new Molotov();

            Assert.AreEqual(5, molotov.Destruccion);
        }

        [Test]
        public void PruebaQueUnProyectilSoloPuedaMoverse4Casilleros()
        {
            Tablero tablero = new Tablero();
            Proyectil proyectil = new Proyectil();
            tablero.AgregarEntidadEnCasillero(proyectil, 0, 0);

            proyectil.MoverAbajo();
            proyectil.MoverAbajo();
            proyectil.MoverAbajo();
            proyectil.MoverAbajo();

            Assert.AreEqual(4, proyectil.Posicion.Fila);
            Assert.AreEqual(0, proyectil.Posicion.Columna);

            Assert.Throws<MovimientoInvalidoException>(() => proyectil.MoverAbajo());

        }

        [Test]
        public void PruebaQueUnProyectilCuandoSeEncuentraUnPersonajeLoDania()
        {
            Tablero tablero = new Tablero();
            Proyectil proyectil = new Proyectil();
            Bombita bombita = new Bombita();
            tablero.AgregarEntidadEnCasillero(proyectil, 0, 0);
            tablero.AgregarEntidadEnCasillero(bombita, 1, 0);

            proyectil.MoverAbajo();

            Assert.AreEqual(2, bombita.Vidas);

        }

        [Test]
        public void PruebaQueUnaMolotovCuandoExplotaLuegoDeQuePaseUnTiempoEsteDestruida()
        {
            Tablero tablero = new Tablero();
            Molotov bomba = new Molotov();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 0);

            bomba.Explotar();

            bomba.CuandoPaseElTiempo(5);

            Assert.IsTrue(bomba.FueDestruido());
        }

        [Test]
        public void PruebaQueUnaMolotovCuandoExplotaYNoPasaTiempoNoEsteDestruida()
        {
            Tablero tablero = new Tablero();
            Molotov bomba = new Molotov();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 0);

            bomba.Explotar();

            bomba.CuandoPaseElTiempo(0);

            Assert.IsFalse(bomba.FueDestruido());
        }

        [Test]
        public void PruebaQueUnaMolotovCuandoExplotaSiSeQuiereVolverAExplotarLanceUnaExcepcion()
        {
            Tablero tablero = new Tablero();
            Molotov bomba = new Molotov();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 0);

            bomba.Explotar();

            bomba.CuandoPaseElTiempo(5);

            Assert.Throws<EntidadYaDestruidaException>(() => bomba.Explotar());
        }

        /*[Test]
        public void PruebaQueUnProyectilCuandoSeEncuentraConUnBloqueLoDania()
        {
            Tablero tablero = new Tablero();
            Proyectil proyectil = new Proyectil();
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();
            tablero.AgregarEntidadEnCasillero(proyectil, 0, 0);
            tablero.AgregarEntidadEnCasillero(bloque, 0, 1);

            proyectil.MoverDerecha();

            Assert.IsTrue(bloque.FueDestruido());
        }*/


        [Test]
        public void PruebaQueUnProyectilPuedaMoverseAUnCasilleroVacio()
        {
            Tablero tablero = new Tablero();
            Proyectil proyectil = new Proyectil();
            tablero.AgregarEntidadEnCasillero(proyectil, 0, 0);

            Assert.Throws<CasilleroFueraDeRangoException>(() => proyectil.PuedeMoverseA(proyectil.Posicion.ObtenerCasilleroIzquierdoDe(tablero)));
            Assert.IsTrue(proyectil.PuedeMoverseA(proyectil.Posicion.ObtenerCasilleroDerechoDe(tablero)));

        }

        [Test]
        public void PruebaQueUnProyectilNoPuedaMoverseAUnCasilleroConUnaEntidad()
        {
            Tablero tablero = new Tablero();
            Proyectil proyectil = new Proyectil();
            BloqueDeAcero bloque = new BloqueDeAcero();
            tablero.AgregarEntidadEnCasillero(proyectil, 0, 0);
            tablero.AgregarEntidadEnCasillero(bloque, 0, 1);

            Assert.IsFalse(proyectil.PuedeMoverseA(proyectil.Posicion.ObtenerCasilleroDerechoDe(tablero)));
            Assert.IsTrue(proyectil.PuedeMoverseA(proyectil.Posicion.ObtenerCasilleroInferiorDe(tablero)));
        }

    }
}
