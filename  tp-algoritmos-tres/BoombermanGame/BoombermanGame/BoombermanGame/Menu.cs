using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoombermanGame
{
    public class Menu
    {
        private int cantidadItems;
        private Color colorItemSeleccionado;
        private Color colorItemNoSeleccionado;
        private int anchoPantalla;
        private int altoPantalla;
        private string[] textoItems;
        private int itemActivado;
        private SpriteFont sprite;


        public Menu(int cantidadItems, Color colorSeleccionado, Color colorNoSeleccionados,
            int anchoPantalla, int altoPantalla, SpriteFont sprite)
        {
            this.cantidadItems = cantidadItems;
            this.colorItemSeleccionado = colorSeleccionado;
            this.colorItemNoSeleccionado = colorNoSeleccionados;
            this.anchoPantalla = anchoPantalla;
            this.altoPantalla = altoPantalla;
            this.textoItems = new string[cantidadItems];
            this.itemActivado = 0;
            this.sprite = sprite;
        }


        // permite agregar un item al menu
        public void AgregarItem(string textoItem, int numeroItem)
        {
            if (numeroItem >= 0 && numeroItem < this.cantidadItems)
                this.textoItems[numeroItem] = textoItem;
        }


        // permite seleccionar el proximo item
        public void ItemPosterior()
        {
            if (this.itemActivado >= this.cantidadItems - 1)
                this.itemActivado = 0;
            else
                this.itemActivado++;
        }


        // permite seleccionar el anterior item
        public void ItemAnterior()
        {
            if (this.itemActivado == 0)
                this.itemActivado = this.cantidadItems - 1;
            else
                this.itemActivado--;
        }


        // permite actualizar el estado del menu en base a lo que desee el usuario
        public void ActualizarControlDelUsuario(KeyboardState teclado)
        {
            if (teclado.IsKeyDown(Keys.Up))
                this.ItemAnterior();
            if (teclado.IsKeyDown(Keys.Down))
                this.ItemPosterior();
        }


        // retorna el item activado
        public int ItemActivado()
        {
            return (this.itemActivado);
        }


        // muestra por pantalla los items del menu para que el usuario pueda elegir la opcion deseada
        public void Draw(SpriteBatch spriteBatch)
        {
            int separadorDeLineas = 50;
            for (int i = 0; i < this.textoItems.Length; i++)
            {
                int ancho = this.anchoPantalla / 3 + separadorDeLineas;
                int alto = ((this.altoPantalla / 3) + (separadorDeLineas * i));
                if (i == this.itemActivado)
                    spriteBatch.DrawString(this.sprite, this.textoItems[i], new Vector2(ancho, alto), this.colorItemSeleccionado);
                else
                    spriteBatch.DrawString(this.sprite, this.textoItems[i], new Vector2(ancho, alto), this.colorItemNoSeleccionado);
            }
        }
    }
}
