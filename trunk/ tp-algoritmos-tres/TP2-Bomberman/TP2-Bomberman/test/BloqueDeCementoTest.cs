using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Excepciones;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class BloqueDeCementoTest
    {
        [Test]
        public void PruebaLaCreacionDeUnBloqueDeCemento()
        {
            BloqueDeCemento bloque = new BloqueDeCemento();

            Assert.IsNotNull(bloque);
        }

        [Test]
        public void PruebaQueLaResistenciaDeUnBloqueDeCementoSea10()
        {
            BloqueDeCemento bloque = new BloqueDeCemento();

            Assert.AreEqual(10, bloque.Resistencia);
        }

        [Test]
        public void PruebaQueSePosicioneCorrectamenteEnUnTablero()
        {
            BloqueDeCemento bloque = new BloqueDeCemento(new Casillero(0, 29));

            Assert.AreEqual(0, bloque.Posicion.Fila);
            Assert.AreEqual(29, bloque.Posicion.Columna);
        }

        [Test]
        public void PruebaQuePosicionarAlBloqueEnUnaPosicionInvalidaLanceUnaExcepcion()
        {
            Assert.Throws<CasilleroFueraDeRangoException>(() => new BloqueDeCemento(new Casillero(5, -2)));
        }

        [Test]
        public void QueElBloqueSeaDañandoPorUnaMolotovYQuedeConResistencia5()
        {
            BloqueDeCemento bloque = new BloqueDeCemento();

            Molotov molotov = new Molotov();

            bloque.DaniarConMolotov(molotov);

            Assert.IsFalse(bloque.FueDestruido());
            Assert.AreEqual(5, bloque.Resistencia);
        }

        [Test]
        public void QueElBloqueSeaDañandoPorUnaToleToleYSeaDestruido()
        {
            BloqueDeCemento bloque = new BloqueDeCemento();

            ToleTole toleTole = new ToleTole();

            bloque.DaniarConToleTole(toleTole);

            Assert.IsTrue(bloque.FueDestruido());
        }

        [Test]
        public void QueElBloqueNoSeaDañandoPorUnProyectilYQuedeResistencia5()
        {
            BloqueDeCemento bloque = new BloqueDeCemento();

            Proyectil proyectil = new Proyectil();

            bloque.DaniarConProyectil(proyectil);

            Assert.IsFalse(bloque.FueDestruido());
            Assert.AreEqual(5, bloque.Resistencia);
        }

        [Test]
        public void TratarDeSeguirDaniandoAUnBloqueDestruidoLanceUnaExcepcion()
        {
            BloqueDeCemento bloque = new BloqueDeCemento();
            ToleTole toleTole = new ToleTole();
            bloque.DaniarConToleTole(toleTole); //Ya lo destruyo

            Assert.Throws<EntidadYaDestruidaException>(() => bloque.DaniarConToleTole(toleTole));
        }
    }
}
