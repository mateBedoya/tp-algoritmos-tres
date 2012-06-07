using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src
{
    // La implementan los elementos que dependen del tiempo para realizar una accion
    public interface IDependienteDelTiempo
    {
        void CuandoPaseElTiempo(int tiempo);
    }
}
