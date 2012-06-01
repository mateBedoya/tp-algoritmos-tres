using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.Juego.obstaculos
{
    /// <summary>
    /// Esta clase solo es utilizada para inicializar un objeto
    /// de tipo obstaculo en nulo (patron null object)
    /// </summary>
    public class ObstaculoNull : Obstaculo
    {
         private static ObstaculoNull INSTANCIA = null;

        // solo puede crearse una sola instancia de esta clase
         private ObstaculoNull()
            : base() { }

        // retorna la instancia
         public static ObstaculoNull GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new ObstaculoNull();
            return (INSTANCIA);
        }
    }
}
