using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BoombermanGame.src.elementales;
using BoombermanGame.src.bombas;
using BoombermanGame.src.personajes;

namespace BoombermanGame.tests.bombas
{
    [TestFixture]
    public class ProyectilTest
    {
        private Tablero tablero = Tablero.GetInstancia();

        [Test]
        public void TestCreaUnProyectil()
        {
            Bomba proyectil = new Proyectil();

            // asserts
            Assert.IsFalse(proyectil.EsArticulo());
            Assert.IsTrue(proyectil.EsBomba());
            Assert.IsFalse(proyectil.EsBombita());
            Assert.IsFalse(proyectil.EsEnemigo());
            Assert.IsFalse(proyectil.EsObstaculo());
            Assert.IsFalse(proyectil.EsPersonaje());
            Assert.IsFalse(proyectil.FueDestruido());
            Assert.IsFalse(proyectil.PuedeSuperponerse());
        }



        [Test]
        public void TestElProyectilComienzaAMoverseEnSuDireccionPredeterminadaYNoPuedeMoverseEnOtraDireccion()
        {
            Proyectil proyectil = new Proyectil();
            tablero.AgregarEntidad(proyectil, 1, 1);

            proyectil.Mover();

            // asserts
            Assert.AreEqual(proyectil.Posicion().X, 1);
            Assert.AreEqual(proyectil.Posicion().Y, 2);

            // limpia el tablero
            Tablero.Vaciar();
        }



        [Test]
        public void TestElProyectilComienzaAMoverseHastaQueEnSuProximaPosicionSeEncuentraConBombitaYExplotaDestruyendolo()
        {
            Proyectil proyectil = new Proyectil();
            tablero.AgregarEntidad(proyectil, 1, 1);

            Bombita bombita = Bombita.GetInstancia();
            tablero.AgregarEntidad(bombita, 1, 4);

            proyectil.Mover();
            Assert.AreEqual(proyectil.Posicion().X, 1);
            Assert.AreEqual(proyectil.Posicion().Y, 2);
            proyectil.Explotar();
            // el proyectil todavia no explota porque no encontro en su proxima posicion a otra entidad
            Assert.IsFalse(proyectil.FueDestruido());
            Assert.IsFalse(bombita.FueDestruido());

            proyectil.Mover();
            Assert.AreEqual(proyectil.Posicion().X, 1);
            Assert.AreEqual(proyectil.Posicion().Y, 3);
            proyectil.Explotar();
            // el proyectil explota porque en su proxima posicion esta bombita
            Assert.IsTrue(proyectil.FueDestruido());
            Assert.IsTrue(bombita.FueDestruido());

            // limpia el tablero
            tablero.Actualizar();
        }



        [Test]
        public void TestElProyectilExplotaPorqueSuProximaPosicionEstaFueraDeRango()
        {
            Proyectil proyectil = new Proyectil();
            tablero.AgregarEntidad(proyectil, 0, 0);

            // esto se hace para que el proyectil apunte hacia arriba
            int[] arriba = { -1, 0 };
            proyectil.Direccionar(arriba);

            // el proyectil explota porque se estrella contra la pared del tablero
            // (su proxima casilla esta fuera del tablero)
            proyectil.Explotar();
            // asserts
            Assert.IsTrue(proyectil.FueDestruido());

            // limpia el tablero
            tablero.Actualizar();
        }
    }
}
