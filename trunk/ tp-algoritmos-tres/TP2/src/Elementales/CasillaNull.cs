using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
