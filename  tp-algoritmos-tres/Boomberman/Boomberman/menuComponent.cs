using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Boomberman
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class menuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {

        public enum anchor
        {
            top_left = 1,
            top_center = 2,
            top_right = 3,

            half_left = 4,
            half_center = 5,
            half_right = 6,

            bottom_left = 7,
            bottom_center = 8,
            bottom_right = 9,

        }; 

        private int number_elements;
        private int element_active = 0;
        private string[] elements;
        private Color selected_color;
        private Color unselected_color;
        private Vector2 free_position = new Vector2(0, 0);
        private SpriteFont font;
        private int separation;
        private Boolean key_Up_press;
        private Boolean key_Down_press;
        private float altoPantalla;
        private float anchoPantalla;


        public menuComponent(Game game, int Num_elements, Color selected_c, Color unselected_c, SpriteFont _font, int _separation,float _anchoPantalla,float _altoPantalla)
            : base(game)
        {
            number_elements = Num_elements;
            element_active = 0;
            elements = new string[number_elements];
            selected_color = selected_c;
            unselected_color = unselected_c;
            font = _font;
            separation = _separation;
            altoPantalla = _altoPantalla;
            anchoPantalla = _anchoPantalla;
        }

        public void posicionar()
        {
            Vector2 dimensionesMenu = size_menu();
            this.free_position = new Vector2(anchoPantalla/2 - dimensionesMenu.X/2, altoPantalla/2 - dimensionesMenu.Y/2);
        }

        public void AddElement(int element_number, string element_name)
        {
            if ((element_number > -1) && (element_number < number_elements))
            {
                elements[element_number] = element_name;
            }
        }

        private void next_item()
        {
            if (element_active < number_elements - 1)
            {
                element_active++;
            }
            else
            {
                element_active = 0;
            }
        }



        private void previus_item()
        {
            if (element_active > 0)
            {
                element_active--;
            }
            else
            {
                element_active = number_elements - 1;
            }
        }

        public void Press_keys(KeyboardState keys)
        {
            if (keys.IsKeyDown(Keys.Up) && key_Up_press)
            {
                this.previus_item();
                key_Up_press = false;
            }
            else
            {
                if (keys.IsKeyUp(Keys.Up))
                {
                    key_Up_press = true;
                }
            }

            if (keys.IsKeyDown(Keys.Down) && key_Down_press)
            {
                this.next_item();
                key_Down_press = false;
            }
            else
            {
                if (keys.IsKeyUp(Keys.Down))
                {
                    key_Down_press = true;
                }
            }
        }

        public int Element_active()
        {
            return element_active + 1;
        }

        private Vector2 size_menu()
        {
            float width = 0, high = 0;

            for (int i = 0; i < number_elements; i++)
            {
                if (font.MeasureString(elements[i].ToString()).X > width) width = font.MeasureString(elements[i]).X;
                if (font.MeasureString(elements[i].ToString()).Y > high) high = font.MeasureString(elements[i]).Y;
            }

            high = high * (number_elements / 2);

            return new Vector2(width, high);

        } 


        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < number_elements; i++)
            {
                if (element_active == i)
                {
                    spriteBatch.DrawString(font, elements[i].ToString(), new Vector2(free_position.X, free_position.Y + (separation * i)), selected_color);
                }
                else
                {
                    spriteBatch.DrawString(font, elements[i].ToString(), new Vector2(free_position.X, free_position.Y + (separation * i)), unselected_color);
                }
            }

        } 
    }
}
