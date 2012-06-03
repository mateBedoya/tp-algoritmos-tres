using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Bombas
{
    /// <summary>
    /// Esta clase solo es utilizada para inicializar un objeto
    /// de tipo bomba en nulo (patron null object)
    /// </summary>
    public class BombaNull : Bomba
    {
        private static BombaNull INSTANCIA = null;

        // solo puede crearse una sola instancia de esta clase
        private BombaNull()
            : base() { }

        // retorna la instancia
        public static BombaNull GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new BombaNull();
            return (INSTANCIA);
        }

        //sin implementacion
        public override void Daniar(Interfaces.IDaniable daniable) { }
        public override void Explotar() { }

    }
}
