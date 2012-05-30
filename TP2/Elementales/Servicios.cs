using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Fisica;

namespace TP2.Elementales
{
    /// <summary>
    /// Esta clase es utilizada por aquella clase que necesite manejar valores 
    /// constantes; si en un futuro se quiere cambiar algún valor,
    /// la modificacion se realizara en esta clase, dejando intacta todas las otras
    /// </summary>

    public class Servicios
    {
        private static Servicios INSTANCIA = null;
        public double DIRECCION_ESTE = 0;
        public double DIRECCION_NORTE = 90;
        public double DIRECCION_OESTE = 180;
        public double DIRECCION_SUR = 270;

        // constructor privado, solo puede crearse una instancia de esta clase
        private Servicios()
        {
        }

        // siempre que se quiera un servisio, se debera invocar este metodo
        public static Servicios GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new Servicios();
            return (INSTANCIA);
        }
    }
}
