using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Bombas;
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

        // retorna si el casillero esta vacio
        public override bool EstaVacio()
        {
            return false;
        }

    }
}
