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
    class HabanoTest
    {
        [Test]
        public void PruebaLaCreacionDeUnHabano()
        {
            Habano articulo = new Habano();

            Assert.IsNotNull(articulo);
            Assert.IsFalse(articulo.FueDestruido());
        }

        [Test]
        public void PruebaLaCreacionDeUnHabanoEnUnaPosicionDeterminada()
        {
            Habano articulo = new Habano(new Casillero(4, 5));

            Assert.IsNotNull(articulo);
            Assert.IsFalse(articulo.FueDestruido());
            Assert.AreEqual(4, articulo.Posicion.Fila);
            Assert.AreEqual(5, articulo.Posicion.Columna);
        }

        [Test]
        public void PruebaQueDaniarUnHabanoConUnaMolotovLoDestruya()
        {
            Habano articulo = new Habano();

            articulo.DaniarConMolotov(new Molotov());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void PruebaQueDaniarUnHabanoConUnaToleToleLoDestruya()
        {
            Habano articulo = new Habano();

            articulo.DaniarConToleTole(new ToleTole());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void PruebaQueDaniarUnHabanoConUnProyectilLoDestruya()
        {
            Habano articulo = new Habano();

            articulo.DaniarConProyectil(new Proyectil());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void CuandoSeTrateDeDaniarUnHabanoYaDestruidoLanceUnaExcepcion()
        {
            Habano articulo = new Habano();

            articulo.DaniarConMolotov(new Molotov());

            Assert.Throws<EntidadYaDestruidaException>(() => articulo.DaniarConMolotov(new Molotov()));
        }

        [Test]
        public void CuandoUnBombitaUtiliceUnHabanoAumenteSuVelocidad()
        {
            Habano articulo = new Habano();
            Bombita bombita = new Bombita();
            int velocidadInicial = bombita.Velocidad;

            articulo.UtilizarArticuloEn(bombita);
            int velocidadFinal = bombita.Velocidad;

            Assert.Greater(velocidadFinal, velocidadInicial);
        }

        [Test]
        public void PruebaQueElEfectoDelHabanoLeDureHastaQueMuera()
        {
            Habano articulo = new Habano();
            Bombita bombita = new Bombita();
            int velocidadInicial = bombita.Velocidad;

            bombita.AgarrarArticulo(articulo);
            int velocidadIntermedia = bombita.Velocidad;

            bombita.DaniarConToleTole(new ToleTole());
            int velocidadFinal = bombita.Velocidad;

            Assert.AreEqual(velocidadInicial, velocidadFinal);
            Assert.Greater(velocidadIntermedia, velocidadInicial);
            Assert.Greater(velocidadIntermedia, velocidadFinal);
        }
    }
}
