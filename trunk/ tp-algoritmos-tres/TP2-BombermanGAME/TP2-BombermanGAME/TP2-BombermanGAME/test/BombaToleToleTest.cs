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
    class BombaToleToleTest
    {
        [Test]
        public void PruebaLaCreacionDeUnBombaToleTole()
        {
            BombaToleTole articulo = new BombaToleTole();

            Assert.IsNotNull(articulo);
            Assert.IsFalse(articulo.FueDestruido());
        }

        [Test]
        public void PruebaLaCreacionDeUnBombaToleToleEnUnaPosicionDeterminada()
        {
            BombaToleTole articulo = new BombaToleTole(new Casillero(4, 6));

            Assert.IsNotNull(articulo);
            Assert.IsFalse(articulo.FueDestruido());
            Assert.AreEqual(4, articulo.Posicion.Fila);
            Assert.AreEqual(6, articulo.Posicion.Columna);
        }

        [Test]
        public void PruebaQueDaniarUnBombaToleToleConUnaMolotovLoDestruya()
        {
            BombaToleTole articulo = new BombaToleTole();

            articulo.DaniarConMolotov(new Molotov());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void PruebaQueDaniarUnBombaToleToleConUnaToleToleLoDestruya()
        {
            BombaToleTole articulo = new BombaToleTole();

            articulo.DaniarConToleTole(new ToleTole());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void PruebaQueDaniarUnBombaToleToleConUnProyectilLoDestruya()
        {
            BombaToleTole articulo = new BombaToleTole();

            articulo.DaniarConProyectil(new Proyectil());

            Assert.IsTrue(articulo.FueDestruido());
        }

        [Test]
        public void CuandoSeTrateDeDaniarUnBombaToleToleYaDestruidoLanceUnaExcepcion()
        {
            BombaToleTole articulo = new BombaToleTole();

            articulo.DaniarConMolotov(new Molotov());

            Assert.Throws<EntidadYaDestruidaException>(() => articulo.DaniarConMolotov(new Molotov()));
        }

        [Test]
        public void CuandoUnBombitaUtiliceUnBombaToleToleSusBombasSeanDelTipoToleTole()
        {
            BombaToleTole articulo = new BombaToleTole();
            Bombita bombita = new Bombita();
            int destruccionInicial = bombita.Bomba.Destruccion;

            articulo.UtilizarArticuloEn(bombita);

            int destruccionFinal = bombita.Bomba.Destruccion;

            Assert.Greater(destruccionFinal, destruccionInicial);
        }

        [Test]
        public void PruebaQueElEfectoDelBombaToleToleLeDureHastaQueMuera()
        {
            BombaToleTole articulo = new BombaToleTole();
            Bombita bombita = new Bombita();
            Assert.IsInstanceOf<Molotov>(bombita.Bomba);

            bombita.AgarrarArticulo(articulo);
            Assert.IsInstanceOf<ToleTole>(bombita.Bomba);

            bombita.DaniarConToleTole(new ToleTole());

            Assert.IsInstanceOf<Molotov>(bombita.Bomba);

        }
    }
}
