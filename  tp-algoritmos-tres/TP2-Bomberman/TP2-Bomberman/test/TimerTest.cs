using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class TimerTest
    {
        [Test]
        public void PruebaLaCreacionDeUnTimer()
        {
            Timer articulo = new Timer();

            Assert.IsNotNull(articulo);
            Assert.IsFalse(articulo.FueDestruido());
        }

        [Test]
        public void PruebaLaCreacionDeUnTimerEnUnaPosicionDeterminada()
        {
            Timer articulo = new Timer(new Casillero(4,6));

            Assert.IsNotNull(articulo);
            Assert.IsFalse(articulo.FueDestruido());
            Assert.AreEqual(4, articulo.Posicion.Fila);
            Assert.AreEqual(6, articulo.Posicion.Columna);
        }

        [Test]
        public void PruebaQueDaniarUnTimerConUnaMolotovLoDestruya()
        {
            Timer articulo = new Timer();

            articulo.DaniarConMolotov(new Molotov());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void PruebaQueDaniarUnTimerConUnaToleToleLoDestruya()
        {
            Timer articulo = new Timer();

            articulo.DaniarConToleTole(new ToleTole());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void PruebaQueDaniarUnTimerConUnProyectilLoDestruya()
        {
            Timer articulo = new Timer();

            articulo.DaniarConProyectil(new Proyectil());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void CuandoSeTrateDeDaniarUnTimerYaDestruidoLanceUnaExcepcion()
        {
            Timer articulo = new Timer();

            articulo.DaniarConMolotov(new Molotov());

            Assert.Throws<EntidadYaDestruidaException>(() => articulo.DaniarConMolotov(new Molotov()));
        }

        [Test]
        public void CuandoUnBombitaUtiliceUnTimerSusBombasTenganUnRetardoQuincePorcientoMenor()
        {
            Timer articulo = new Timer();
            Bombita bombita = new Bombita();
            double porcentajeInicial = bombita.PorcentajeDeRetardo;

            articulo.UtilizarArticuloEn(bombita);
            double porcentajeFinal = bombita.PorcentajeDeRetardo;

            Assert.AreEqual(porcentajeFinal, porcentajeInicial*0.85  );
        }

        [Test]
        public void PruebaQueElEfectoDelTimerLeDureHastaQueMuera()
        {
            Timer articulo = new Timer();
            Bombita bombita = new Bombita();
            Assert.AreEqual(1,bombita.PorcentajeDeRetardo);

            bombita.AgarrarArticulo(articulo);
            Assert.AreEqual(0.85, bombita.PorcentajeDeRetardo);

            bombita.DaniarConToleTole(new ToleTole());

            Assert.AreEqual(1, bombita.PorcentajeDeRetardo);

        }
    }
}
