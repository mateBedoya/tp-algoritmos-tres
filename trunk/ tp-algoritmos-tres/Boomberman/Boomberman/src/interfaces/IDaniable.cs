using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.src.Juego.bombas;

namespace TP2.src.Interfaces
{
    public interface IDaniable : IDestruible
    {
        void DaniarPorMolotov(Molotov molotov);

        void DaniarPorProyectil(Proyectil proyectil);
        
        void DaniarPorToletole(ToleTole toletole);
    }
}
