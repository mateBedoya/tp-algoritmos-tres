using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Juego.personajes;
using TP2.Juego.obstaculos;
using TP2.Juego.bombas;
using TP2.Juego.articulos;

namespace TP2.Elementales
{
    /// <summary>
    /// Esta clase solo es utilizada para inicializar un objeto
    /// de tipo casilla en nulo (patron null object)
    /// </summary>
    public class CasillaNull : Casilla
    {
        private static CasillaNull INSTANCIA = null;

        // solo puede crearse una sola instancia de esta clase
        private CasillaNull()
            : base(0, 0) { }

        // retorna la instancia
        public static CasillaNull GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new CasillaNull();
            return (INSTANCIA);
        }

        // retorna la propia instancia
        public override Casilla GetCasillaSuperior()
        {
            return (INSTANCIA);
        }

        // retorna la propia instancia
        public override Casilla GetCasillaInferior()
        {
            return (INSTANCIA);
        }

        // retorna la propia instancia
        public override Casilla GetCasillaDerecha()
        {
            return (INSTANCIA);
        }

        // retorna la propia instancia
        public override Casilla GetCasillaIzquierda()
        {
            return (INSTANCIA);
        }

        // retorna la lista vacia (sin casillas adyacentes)
        public override List<Casilla> GetCasillasAdyacentes()
        {
            return (new List<Casilla>());
        }

        // retorna si la casilla esta vacia
        public override bool EstaVacia()
        {
            return false;
        }

        // sin implementacion
        public override void AgregarPersonaje(Personaje personaje) { }

        // sin implementacion
        public override void AgregarObstaculo(Obstaculo obstaculo) { }

        // sin implementacion
        public override void AgregarBomba(Bomba bomba) { }

        // sin implementacion
        public override void AgregarArticulo(Articulo articulo) { }

        // retorna el personaje 
        public override Personaje GetPersonaje()
        {
            return (PersonajeNull.GetInstancia());
        }

        // retorna el obstaculo nulo
        public override Obstaculo GetObstaculo()
        {
            return (ObstaculoNull.GetInstancia());
        }

        // retorna la bomba 
        public override Bomba GetBomba()
        {
            return (BombaNull.GetInstancia());
        }

        // retorna el articulo
        public override Articulo GetArticulo()
        {
            return (ArticuloNull.GetInstancia());
        }

     
    }
}
