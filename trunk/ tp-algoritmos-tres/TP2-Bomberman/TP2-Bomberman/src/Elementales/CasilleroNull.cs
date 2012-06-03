using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Bombas;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Elementales;

namespace TP2_Bomberman.src.Elementales
{
    /// <summary>
    /// Esta clase solo es utilizada para inicializar un objeto
    /// de tipo casillero en nulo (patron null object)
    /// </summary>
    public class CasilleroNull : Casillero
    {
        private static CasilleroNull INSTANCIA = null;

        // solo puede crearse una sola instancia de esta clase
        private CasilleroNull()
            : base(0, 0) { }

        // retorna la instancia
        public static CasilleroNull GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new CasilleroNull();
            return (INSTANCIA);
        }

        // retorna la propia instancia
        public override Casillero ObtenerCasilleroSuperior()
        {
            return (INSTANCIA);
        }

        // retorna la propia instancia
        public override Casillero ObtenerCasilleroInferior()
        {
            return (INSTANCIA);
        }

        // retorna la propia instancia
        public override Casillero ObtenerCasilleroDerecho()
        {
            return (INSTANCIA);
        }

        // retorna la propia instancia
        public override Casillero ObtenerCasilleroIzquierdo()
        {
            return (INSTANCIA);
        }

        // retorna la lista vacia (sin casilleros adyacentes)
        public override List<Casillero> ObtenerCasillerosAdyacentes()
        {
            return (new List<Casillero>());
        }

        // retorna si el casillero esta vacio
        public override bool EstaVacio()
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
