using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Bombas;

namespace TP2_Bomberman.src.Interfaces
{
    //Interfaz que implementa el patrón doble dispatch
    // La implementan los elementos a los cuales una bomba puede daniar
    public interface IDaniable
    {
        void DaniarConMolotov(Molotov molotov);
        void DaniarConToleTole(ToleTole toleTole);
        void DaniarConProyectil(Proyectil proyectil);
    }
}
