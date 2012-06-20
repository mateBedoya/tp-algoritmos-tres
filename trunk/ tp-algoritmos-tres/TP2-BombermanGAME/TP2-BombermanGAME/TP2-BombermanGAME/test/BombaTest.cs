using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Elementales;

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

            proyectil.CuandoPaseElTiempo(0);

            Assert.IsTrue(proyectil.FueDestruido());

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
            proyectil.CuandoPaseElTiempo(0);

            Assert.AreEqual(2, bombita.Vidas);

        }

        [Test]
        public void PruebaQueUnaMolotovCuandoSeActivaLuegoDeQuePaseUnTiempo1EsteDestruida()
        {
            Tablero tablero = new Tablero();
            Molotov bomba = new Molotov();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 0);

            bomba.ActivarBomba();

            bomba.CuandoPaseElTiempo(1);

            Assert.IsTrue(bomba.FueDestruido());
        }

        [Test]
        public void PruebaQueUnProyectilCuandoSeActivaLuegoDeQuePaseUnTiempo0EsteDestruida()
        {
            Tablero tablero = new Tablero();
            Proyectil bomba = new Proyectil();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 0);

            bomba.ActivarBomba();

            bomba.CuandoPaseElTiempo(0);

            Assert.IsTrue(bomba.FueDestruido());
        }

        [Test]
        public void PruebaQueUnaToleToleCuandoSeActivaLuegoDeQuePaseUnTiempo5EsteDestruida()
        {
            Tablero tablero = new Tablero();
            ToleTole bomba = new ToleTole();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 0);

            bomba.ActivarBomba();

            bomba.CuandoPaseElTiempo(2);

            Assert.IsFalse(bomba.FueDestruido());

            bomba.CuandoPaseElTiempo(3);

            Assert.IsTrue(bomba.FueDestruido());
        }

        [Test]
        public void PruebaQueUnaMolotovCuandoSeActivaYNoPasaTiempoNoEsteDestruida()
        {
            Tablero tablero = new Tablero();
            Molotov bomba = new Molotov();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 0);

            bomba.ActivarBomba();

            bomba.CuandoPaseElTiempo(0);

            Assert.IsFalse(bomba.FueDestruido());
        }

        [Test]
        public void PruebaQueUnaMolotovCuandoSeActivaSiSeQuiereVolverAExplotarLanceUnaExcepcion()
        {
            Tablero tablero = new Tablero();
            Molotov bomba = new Molotov();
            tablero.AgregarEntidadEnCasillero(bomba, 0, 0);

            bomba.ActivarBomba();

            bomba.CuandoPaseElTiempo(5);

            Assert.Throws<EntidadYaDestruidaException>(() => bomba.ActivarBomba());
        }

        [Test]
        public void PruebaQueUnProyectilCuandoSeEncuentraConUnBloqueLoDania()
        {
            Tablero tablero = new Tablero();
            Proyectil proyectil = new Proyectil();
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();
            tablero.AgregarEntidadEnCasillero(proyectil, 0, 0);
            tablero.AgregarEntidadEnCasillero(bloque, 0, 1);

            proyectil.MoverDerecha();
            proyectil.CuandoPaseElTiempo(0);

            Assert.IsTrue(bloque.FueDestruido());
        }


        [Test]
        public void PruebaQueUnProyectilPuedaMoverseAUnCasilleroVacio()
        {
            Tablero tablero = new Tablero();
            Proyectil proyectil = new Proyectil();
            tablero.AgregarEntidadEnCasillero(proyectil, 0, 0);

            Assert.Throws<CasilleroFueraDeRangoException>(() => proyectil.PuedeMoverseA(proyectil.Posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(Entidad.OESTE, tablero)));
            Assert.IsTrue(proyectil.PuedeMoverseA(proyectil.Posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(Entidad.ESTE, tablero)));

        }

        [Test]
        public void PruebaQueUnProyectilNoPuedaMoverseAUnCasilleroConUnaEntidad()
        {
            Tablero tablero = new Tablero();
            Proyectil proyectil = new Proyectil();
            BloqueDeAcero bloque = new BloqueDeAcero();
            tablero.AgregarEntidadEnCasillero(proyectil, 0, 0);
            tablero.AgregarEntidadEnCasillero(bloque, 0, 1);

            Assert.IsFalse(proyectil.PuedeMoverseA(proyectil.Posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(Entidad.ESTE, tablero)));
            Assert.IsTrue(proyectil.PuedeMoverseA(proyectil.Posicion.ObtenerCasilleroAdyacenteEnLaDireccionYElTablero(Entidad.SUR, tablero)));
        }

    }
}
