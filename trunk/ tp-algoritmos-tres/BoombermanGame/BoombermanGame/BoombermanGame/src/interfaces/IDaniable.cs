using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.bombas;

namespace BoombermanGame.src.interfaces
{
    public interface IDaniable
    {
        void DaniarPorMolotov(Molotov molotov);

        void DaniarPorProyectil(Proyectil proyectil);

        void DaniarPorToletole(ToleTole toletole);
    }
}
