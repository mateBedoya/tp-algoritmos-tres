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
    class BloqueDeAceroTest
    {
        [Test]
        public void PruebaLaCreacionDeUnBloqueDeAcero()
        {
            BloqueDeAcero bloque = new BloqueDeAcero();

            Assert.IsNotNull(bloque);
        }

        [Test]
        public void PruebaQueSePosicioneCorrectamenteEnUnTablero()
        {
            BloqueDeAcero bloque = new BloqueDeAcero(new Casillero(29, 29));

            Assert.AreEqual(29, bloque.Posicion.Fila);
            Assert.AreEqual(29, bloque.Posicion.Columna);
        }

        [Test]
        public void PruebaQuePosicionarAlBloqueEnUnaPosicionInvalidaLanceUnaExcepcion()
        {
            Assert.Throws<CasilleroFueraDeRangoException>(() => new BloqueDeAcero(new Casillero(80, 80)));
        }

        [Test]
        public void QueElBloqueNoSeaDañandoPorUnaMolotov()
        {
            BloqueDeAcero bloque = new BloqueDeAcero();
            int resistenciaAnterior = bloque.Resistencia;

            Molotov molotov = new Molotov();

            bloque.DaniarConMolotov(molotov);

            Assert.IsFalse(bloque.FueDestruido());
            Assert.AreEqual(resistenciaAnterior, bloque.Resistencia);
        }

        [Test]
        public void QueElBloqueSeaDañandoPorUnaToleToleYSeaDestruido()
        {
            BloqueDeAcero bloque = new BloqueDeAcero();
            int resistenciaAnterior = bloque.Resistencia;

            ToleTole toleTole = new ToleTole();

            bloque.DaniarConToleTole(toleTole);

            Assert.IsTrue(bloque.FueDestruido());
            Assert.AreNotEqual(resistenciaAnterior, bloque.Resistencia);
        }

        [Test]
        public void QueElBloqueNoSeaDañandoPorUnProyectil()
        {
            BloqueDeAcero bloque = new BloqueDeAcero();
            int resistenciaAnterior = bloque.Resistencia;

            Proyectil proyectil = new Proyectil();

            bloque.DaniarConProyectil(proyectil);

            Assert.IsFalse(bloque.FueDestruido());
            Assert.AreEqual(resistenciaAnterior, bloque.Resistencia);
        }

        [Test]
        public void TratarDeSeguirDaniandoAUnBloqueDestruidoLanceUnaExcepcion()
        {
            BloqueDeAcero bloque = new BloqueDeAcero();
            ToleTole toleTole = new ToleTole();
            bloque.DaniarConToleTole(toleTole); //Ya lo destruyo

            Assert.Throws<EntidadYaDestruidaException>(() => bloque.DaniarConToleTole(toleTole));
        }
    }
}
