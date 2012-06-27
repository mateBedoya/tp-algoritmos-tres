using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BoombermanGame.src.vistas
{
    public class Vista : IDibujable
    {
        private IPosicionable posicionable;

        public Vista(IPosicionable posicionable)
        {
            this.posicionable = posicionable;
        }


        public IPosicionable GetPosicionable()
        {
            return (this.posicionable);
        }


        public void Dibujar(ContentManager content, SpriteBatch sprite)
        {
            Texture2D textura = content.Load<Texture2D>(this.posicionable.GetDescripcion());
            int X = (this.posicionable.X() * (textura.Height));
            int Y = (this.posicionable.Y() * (textura.Width));
            Vector2 posicion = new Vector2(Y, X);
            sprite.Draw(textura, posicion, Color.White);
        }
    }
}
