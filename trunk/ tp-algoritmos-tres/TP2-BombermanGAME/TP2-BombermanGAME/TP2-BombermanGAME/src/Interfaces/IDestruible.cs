using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Interfaces
{
    //La implementan los elementos que pueden ser destruidos por una bomba o un personaje
    public interface IDestruible
    {
        bool FueDestruido();
    }
}
