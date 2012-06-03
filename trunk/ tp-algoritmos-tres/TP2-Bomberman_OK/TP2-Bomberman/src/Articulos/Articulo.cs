using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Interfaces;

namespace TP2_Bomberman.src.Articulos
{
    public abstract class Articulo: Entidad, IDaniable, IDestruible
    {
        public abstract void DaniarConMolotov(Molotov molotov);
        public abstract void DaniarConToleTole(Bombas.ToleTole toleTole);
        public abstract void DaniarConProyectil(Bombas.Proyectil proyectil);
        public abstract bool FueDestruido();

    }
}
