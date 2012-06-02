using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TP2_Bomberman.src;

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
        public void PruebaPosicionarUnPersonajeEnLaCasilla()
        {
            Casillero casillero = new Casillero(0, 0);

            //Personaje personaje = new Personaje();  BORRAR COMENTARIO : personaje deberia ser asbtracta ya que de esta clase heredan todos
            // los otros personajes (Cecilio, Bombita..); no deberia poder instanciarse un personaje que no sea Cecilio, Bombita, etc,
            // es decir un personaje de tipo "Personaje"

            // casillero.Personaje = personaje;

            // Assert.IsNotNull(casillero.Personaje);
        }

        [Test]
        public void PruebaObtenerLaCasillaPosicionadaALaDerecha()
        {
            Tablero tablero = new Tablero();

            Casillero casilleroActual = tablero.ObtenerCasillero(1, 1);

            Casillero casilleroDerecho = casilleroActual.ObtenerCasilleroDerecho();

            Assert.AreEqual(1, casilleroDerecho.Fila);
            Assert.AreEqual(2, casilleroDerecho.Columna);

        }

        [Test]
        public void PruebaObtenerLaCasillaPosicionadaArriba()
        {
            Tablero tablero = new Tablero();

            Casillero casilleroActual = tablero.ObtenerCasillero(1, 1);

            Casillero casilleroArriba = casilleroActual.ObtenerCasilleroSuperior();

            Assert.AreEqual(0, casilleroArriba.Fila);
            Assert.AreEqual(1, casilleroArriba.Columna);

        }

        [Test]
        public void PruebaObtenerLaCasillaPosicionadaALaIzquierda()
        {
            Tablero tablero = new Tablero();

            Casillero casilleroActual = tablero.ObtenerCasillero(1, 1);

            Casillero casilleroIzquierdo = casilleroActual.ObtenerCasilleroIzquierdo();

            Assert.AreEqual(1, casilleroIzquierdo.Fila);
            Assert.AreEqual(0, casilleroIzquierdo.Columna);

        }

        [Test]
        public void PruebaObtenerLaCasillaPosicionadaAbajo()
        {
            Tablero tablero = new Tablero();

            Casillero casilleroActual = tablero.ObtenerCasillero(1, 1);

            Casillero casilleroAbajo = casilleroActual.ObtenerCasilleroInferior();

            Assert.AreEqual(2, casilleroAbajo.Fila);
            Assert.AreEqual(1, casilleroAbajo.Columna);

        }
    }
}
