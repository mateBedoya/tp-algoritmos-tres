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
using TP2.src.interfaces;
using Boomberman.src;
using TP2.Elementales;
using Boomberman.src.interfaces;
using TP2.src.Juego.personajes;
using Boomberman.src.elementales;
using TP2.src.Elementales;
using Boomberman.src.vistas;
using Boomberman.src.niveles;

namespace Boomberman
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class JuegoBoomberman : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private static int CICLOS_PARA_ACTUALIZAR_CONTROL_DEL_USUARIO = 5;
        private List<IDibujable> dibujables;
        private List<IActuable> actuables;
        private List<Nivel> niveles;
        private Nivel nivelActual;
        private int contadorDeCiclos;
        //private double segundosHastaElMomento;

        public JuegoBoomberman()
        {
           graphics = new GraphicsDeviceManager(this);
           Content.RootDirectory = "Content";
           this.graphics.PreferredBackBufferWidth = 1050;  // cambia la resolucion de la ventana 
           this.graphics.PreferredBackBufferHeight = 650;
        }


        // permite cargar los niveles que tendra el juego
        private void CargarNiveles()
        {
            this.niveles.Add(new Nivel01(2,2,2,10,5,0));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.dibujables = new List<IDibujable>();
            this.actuables = new List<IActuable>();
            this.contadorDeCiclos = 0;

            Window.Title = "Boomberman- 2012";
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
           
            this.niveles = new List<Nivel>();
            this.CargarNiveles();
            this.nivelActual = niveles[0];
            this.nivelActual.Cargar();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        // metodo encargado de las acciones que el usuario solicita por teclado
        private void ActualizarControlDelUsuario(KeyboardState teclado) 
        {
            Bombita bombita = nivelActual.GetBombita();
            if ((contadorDeCiclos >= (CICLOS_PARA_ACTUALIZAR_CONTROL_DEL_USUARIO - bombita.Velocidad())) && 
                (contadorDeCiclos % (CICLOS_PARA_ACTUALIZAR_CONTROL_DEL_USUARIO - bombita.Velocidad()) == 0))
            {
                if (teclado.IsKeyDown(Keys.Right))
                    bombita.MoverAlEste();

                if (teclado.IsKeyDown(Keys.Left))
                    bombita.MoverAlOeste();

                if (teclado.IsKeyDown(Keys.Up))
                    bombita.MoverAlNorte();

                if (teclado.IsKeyDown(Keys.Down))
                    bombita.MoverAlSur();

                if (teclado.IsKeyDown(Keys.Space))
                    bombita.LanzarExplosivo();
            }
            contadorDeCiclos++;
        }


        // actualiza los dibujables y actuables del juego (observa al modelo y se actualiza)
        private void ActualizarActuablesYDibujables()
        {
            Tablero tablero = nivelActual.GetTablero();
            List<Entidad> entidades = tablero.entidades;
            int indice1 = 0;
            while (indice1 < entidades.Count())
            {
                Entidad entidad = entidades[indice1];
                if(entidad.FueDestruido())
                {
                    this.actuables.Remove(entidad);
                    string descripcion = entidad.GetDescripcion();
                    bool encontrado = false;
                    int indice2 = 0;
                    while (!encontrado)
                    {
                        if(this.dibujables[indice2].GetPosicionable().GetDescripcion() == descripcion &&
                            this.dibujables[indice2].GetPosicionable().DejaDePosisionarse())
                        {
                            this.dibujables.Remove(dibujables[indice2]);
                            encontrado = true;
                        }
                        indice2++;
                    }
                    tablero.RemoverEntidad(entidad);
                }
                else
                {
                    if (!this.actuables.Contains(entidad))
                    {
                        this.actuables.Add(entidad);
                        this.dibujables.Add(new Vista(entidad));
                    }
                    
                }
                indice1++;
            }
        }


        // controla el estado del juego
        private void ActualizarEstado()
        {
            this.nivelActual = niveles[0];
            this.nivelActual.Cargar();
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // se actualiza la accion del usuario ingresada por teclado
            KeyboardState teclado = Keyboard.GetState();
            this.ActualizarControlDelUsuario(teclado);
            this.ActualizarActuablesYDibujables();

            // se actualiza el nivel y se simulan las entidades
            this.nivelActual.Actualizar();
            List<IActuable> copiaDeActuables = this.actuables;
            foreach (IActuable actuable in copiaDeActuables)
            {
                actuable.Actuar();
            }
            // TODO: Add your update logic here
            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.YellowGreen);

            // se dibujan las vistas de las entidades por pantalla
            spriteBatch.Begin();
            //spriteBatch.DrawString(this.Content.Load<SpriteFont>("SpriteFont1"), segundosHastaElMomento.ToString()/*gameTime.TotalGameTime.ToString()*/, new Vector2(0, 0), Color.Black);
            List<IDibujable> copiaDeDibujables = this.dibujables;
            int indice = copiaDeDibujables.Count() -1 ;
            while (indice >= 0)
            {
                IDibujable dibujable = copiaDeDibujables[indice];
                dibujable.Dibujar(this.Content, this.spriteBatch);
                indice--;
            }
            spriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}


