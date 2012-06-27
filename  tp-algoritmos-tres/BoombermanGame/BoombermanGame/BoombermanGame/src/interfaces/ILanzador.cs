using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoombermanGame.src.interfaces
{
    public interface ILanzador
    {
        void NotificarExplosion(bool exploto);

        void LanzarExplosivo();
    }
}
