using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TP2_Bomberman.test
{
    [TestFixture]
    class BombitaTest
    {

        [Test]
        public void CuandoCreoABombitaQueTenga1Vida()
        {
            Bombita bombita = new Bombita();

            Assert.AreEqual(bombita.Resistencia, 1);
        }

        [Test]
        public void CuandoCreoABombitaQueTenga5DeVelocidad() //vemos despues que significa tener "5" de velocidad
        {
            Bombita bombita = new Bombita();

            Assert.AreEqual(5, bombita.GetVelocidad());
        }

        [Test]
        public void CuandoSeMueveBombitaCambiaSuPosicionEnElTablero() // BORRAR COMENTARIO : bombita deberia retornanr su casilla sin importar
        // como esta implementada esta clase (aca le preguntamos a bombita por su columna y su fila y en realidad bombita esta en una casilla,
        // la que tiene fila y columna es la casilla). Entonces si quisieramos saber por la fila y columna de la casilla que contiene a bombita
        // tendriamos que hacer bombita.GetCasilla().Fila y bombita.GetCasilla().Columna, despues lo veo con mas tiempo, pero creo que los metodos
        // para hacerlo asi estan (esto es lo que dicen "encapsulacion")
        {
            Bombita bombita = new Bombita();

            bombita.MoverDerecha();

            //Assert.AreEqual(0, bombita.Columna);
            //Assert.AreEqual(1, bombita.Fila);
        }

    }
}
