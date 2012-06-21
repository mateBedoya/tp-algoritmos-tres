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

namespace TP2_BombermanGAME
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        enum gameState {pause, playing, gameOver, won };
        gameState estado;
        Controlador controlador;
        public static Dictionary<string,Texture2D> TexturasBombas = new Dictionary<string,Texture2D>();
        public static Dictionary<string, Texture2D> TexturasBombita = new Dictionary<string, Texture2D>();
        //Texture2D explosionTexture;
        SpriteFont formatoTexto;
        string salida;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            controlador = new Controlador();
            controlador.Inicializar();
            estado = gameState.playing;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            controlador.CargarTexturas(Content);
            TexturasBombas["molotov"]=(Content.Load<Texture2D>("molotov4"));
            TexturasBombas["toleTole"]=(Content.Load<Texture2D>("toleTole"));
            TexturasBombas["proyectil"]=(Content.Load<Texture2D>("bala"));
            TexturasBombas["explosion"] = (Content.Load<Texture2D>("explosion"));

            TexturasBombita["arriba"] = (Content.Load<Texture2D>("arriba"));
            TexturasBombita["abajo"] = (Content.Load<Texture2D>("bombita"));
            TexturasBombita["derecha"] = (Content.Load<Texture2D>("derecha"));
            TexturasBombita["izquierda"] = (Content.Load<Texture2D>("izquierda"));

            formatoTexto = this.Content.Load<SpriteFont>("SpriteFont1");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Permite salir del juego presionando la tecla Escape
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();


            KeyboardState teclado = Keyboard.GetState();
            //salida = controlador.Actualizar(teclado); 
            //controlador.Actualizar(teclado);

            if (estado == gameState.gameOver)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    this.Exit();
            }

            if (estado == gameState.pause)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    estado = gameState.playing;
                    controlador.Reset(Content);
                }
            }
            if (estado == gameState.playing)
            {
                salida = controlador.Actualizar(teclado);
                if (salida == "Perdio")
                {
                    estado = gameState.gameOver;
                }
                if (salida == "Pasa de nivel")
                {
                    estado = gameState.pause;
                }
                if (salida == "Gano")
                {
                    estado = gameState.won;
                }
            }
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Snow);

            spriteBatch.Begin();
            controlador.Dibujar(spriteBatch);
            if (estado == gameState.gameOver)
            {
                spriteBatch.DrawString(formatoTexto,"HA PERDIDO, PRESIONE LA TECLA ESCAPE PARA SALIR",new Vector2(0,375),Color.Black);
            }
            else if (estado == gameState.pause)
            {
                spriteBatch.DrawString(formatoTexto, "HA PASADO Al NIVEL "+controlador.nivelActual+", PRESIONE ENTER PARA CONTINUAR", new Vector2(0, 375), Color.Black);
            }
            else if (estado == gameState.won)
            {
                spriteBatch.DrawString(formatoTexto, "HA GANADO, JUEGO TERMINADO", new Vector2(0, 375), Color.Red);
            }
            else if (estado == gameState.playing)
            {
                spriteBatch.DrawString(formatoTexto, salida, new Vector2(0, 375), Color.Black);
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
