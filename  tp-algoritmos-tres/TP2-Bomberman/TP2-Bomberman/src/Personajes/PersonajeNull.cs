using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Personajes
{
    /// <summary>
    /// Esta clase solo es utilizada para inicializar un objeto
    /// de tipo personaje en nulo (patron null object)
    /// </summary>
    public class PersonajeNull : Personaje
    {
        private static PersonajeNull INSTANCIA = null;

        // solo puede crearse una sola instancia de esta clase
        private PersonajeNull()
            : base(0)
        {
            this.velocidad = 0;
        }

        // retorna la instancia
        public static PersonajeNull GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new PersonajeNull();
            return (INSTANCIA);
        }

        // retorna siempre que fue destruido
        public override bool FueDestruido()
        {
            return true;
        }
    }
}
