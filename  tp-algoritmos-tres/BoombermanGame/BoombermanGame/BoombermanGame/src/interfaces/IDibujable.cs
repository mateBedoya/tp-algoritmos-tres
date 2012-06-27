using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BoombermanGame.src.interfaces
{
    public interface IDibujable
    {
        IPosicionable GetPosicionable();

        void Dibujar(ContentManager content, SpriteBatch sprite);
    }
}
