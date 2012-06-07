using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;
using TP2_Bomberman.src.Articulos;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class BloqueDeLadrillosTest
    {

        [Test]
        public void PruebaLaCreacionDeUnBloqueDeLadrillos()
        {
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();

            Assert.IsNotNull(bloque);
        }

        [Test]
        public void PruebaQueLaResistenciaDeUnBloqueDeLadrillosSea5()
        {
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();

            Assert.AreEqual(5, bloque.Resistencia);
        }

        [Test]
        public void PruebaQueSePosicioneCorrectamenteEnUnTablero()
        {
            BloqueDeLadrillos bloque = new BloqueDeLadrillos(new Casillero(29,29));

            Assert.AreEqual(29, bloque.Posicion.Fila);
            Assert.AreEqual(29, bloque.Posicion.Columna);
        }

        [Test]
        public void PruebaQuePosicionarAlBloqueEnUnaPosicionInvalidaLanceUnaExcepcion()
        {
            Assert.Throws<CasilleroFueraDeRangoException>(() => new BloqueDeLadrillos(new Casillero(-3, 80)));
        }

        [Test]
        public void QueElBloqueSeaDañandoPorUnaMolotovYSeaDestruido()
        {
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();

            Molotov molotov = new Molotov();

            bloque.DaniarConMolotov(molotov);

            Assert.IsTrue(bloque.FueDestruido());
        }

        [Test]
        public void QueElBloqueSeaDañandoPorUnaToleToleYSeaDestruido()
        {
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();

            ToleTole toleTole = new ToleTole();

            bloque.DaniarConToleTole(toleTole);

            Assert.IsTrue(bloque.FueDestruido());
        }

        [Test]
        public void QueElBloqueSeaDañandoPorUnProyectilYSeaDestruido()
        {
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();

            Proyectil proyectil = new Proyectil();

            bloque.DaniarConProyectil(proyectil);

            Assert.IsTrue(bloque.FueDestruido());
        }

        [Test]
        public void TratarDeSeguirDaniandoAUnBloqueDestruidoLanceUnaExcepcion()
        {
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();
            ToleTole toleTole = new ToleTole();
            bloque.DaniarConToleTole(toleTole); //Ya lo destruyo

            Assert.Throws<EntidadYaDestruidaException>(() => bloque.DaniarConToleTole(toleTole));
        }

        [Test]
        public void QueUnBloqueDeLadrillosSeaDestruidoYDejeUnArticulo()
        {
            Tablero tablero = new Tablero();
            BloqueDeLadrillos bloque = new BloqueDeLadrillos();
            tablero.AgregarEntidadEnCasillero(bloque, 0, 0);
            Timer timer = new Timer();
            bloque.Articulo = timer;

            Assert.IsNull(timer.Posicion);

            bloque.DaniarConToleTole(new ToleTole());//Lo destruyo

            Assert.AreEqual(tablero.ObtenerCasillero(0, 0).Entidad, timer);
            Assert.AreEqual(0,timer.Posicion.Fila);
            Assert.AreEqual(0, timer.Posicion.Columna);

        }

    }
}
