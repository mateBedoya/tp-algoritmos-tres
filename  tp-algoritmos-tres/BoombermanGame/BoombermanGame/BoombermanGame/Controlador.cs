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
using BoombermanGame.src.interfaces;
using BoombermanGame.src.elementales;
using BoombermanGame.src.vistas;
using BoombermanGame.src.niveles;
using BoombermanGame.src.personajes;
using System.IO;
using System.Xml.Serialization;
using BoombermanGame.src.obstaculos;

namespace BoombermanGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Controlador : Microsoft.Xna.Framework.Game
    {
        enum EstadoDelJuego { iniciando, jugando, perdido, ganado, pausado };

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private static int ANCHO = 1250;
        private static int ALTO = 650;
        private static int CICLOS_PARA_ACTUALIZAR_CONTROL_DEL_USUARIO = 5;
        private int VIDAS_POSIBLES = 3;
        private int contadorDeCiclos;
        private int vidas;
        private List<IDibujable> dibujables;
        private List<IActuable> actuables;
        private List<Nivel> niveles;
        private Nivel nivelActual;
        EstadoDelJuego estado;
        Menu menuPrincipal;
        List<Entidad> listaEntidades;


        public Controlador()
        {
           graphics = new GraphicsDeviceManager(this);
           Content.RootDirectory = "Content";
           this.graphics.PreferredBackBufferWidth = ANCHO;  // cambia la resolucion de la ventana 
           this.graphics.PreferredBackBufferHeight = ALTO;
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
            this.vidas = VIDAS_POSIBLES;

            Window.Title = "Boomberman- 2012";
            this.estado = EstadoDelJuego.iniciando;

            this.menuPrincipal = new Menu(4, Color.Red, Color.Yellow, ANCHO, ALTO, Content.Load<SpriteFont>("SpriteFont2"));
            this.menuPrincipal.AgregarItem("Nuevo Juego", 0);
            this.menuPrincipal.AgregarItem("Cargar", 1);
            this.menuPrincipal.AgregarItem("Guardar", 2);
            this.menuPrincipal.AgregarItem("Salir", 3);

            base.Initialize();
        }


        // permite cargar los niveles que tendra el juego
        private void CargarNiveles()
        {
            this.niveles.Add(new Nivel(1, 0, 0, 0, 0, 0));
            this.niveles.Add(new Nivel(0, 2, 1, 0, 2, 0));
            this.niveles.Add(new Nivel(2, 0, 0, 2, 0, 0));
            this.niveles.Add(new Nivel(2, 2, 1, 0, 2, 3));
            this.niveles.Add(new Nivel(1, 0, 5, 5, 5, 0));
            this.niveles.Add(new Nivel(5, 5, 5, 5, 5, 5));
            for (int i = 0; i < niveles.Count; i++)
            {
                niveles[i].Numero = i + 1;
            }
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


        // permite pasar de nivel
        private void PasarDeNivel()
        {
            this.nivelActual = this.niveles[nivelActual.Numero];
            this.dibujables = new List<IDibujable>();
            this.actuables = new List<IActuable>();
            this.nivelActual.Cargar();
            this.estado = EstadoDelJuego.jugando;
        }
        


        // permite cargar nuevamente el nivel por haberlo perdido
        private void ReiniciarNivel()
        {
            this.vidas--;
            if (this.vidas == 0)
                this.estado = EstadoDelJuego.perdido;
            else
            {
                this.dibujables = new List<IDibujable>();
                this.actuables = new List<IActuable>();
                this.nivelActual.Cargar();
            }
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        // actualiza el menu principal segun el estado del juego
        private void ActualizarMenuPrincipal(KeyboardState teclado) 
        {
            this.menuPrincipal.ActualizarControlDelUsuario(teclado);

            if (teclado.IsKeyDown(Keys.Enter))
            {
                if (this.menuPrincipal.ItemActivado() == 0)
                {
                    this.estado = EstadoDelJuego.jugando;
                    this.menuPrincipal.AgregarItem("Continuar", 0);
                }

                if (this.menuPrincipal.ItemActivado() == 1) 
                {
                    try
                    {
                        CargarJuego();
                    }
                    catch (FileNotFoundException)
                    { }
                    estado = EstadoDelJuego.jugando;
                }

                if (this.menuPrincipal.ItemActivado() == 2) 
                {
                    GuardarJuego();
                    this.Exit();
                }

                if (this.menuPrincipal.ItemActivado() == 3) 
                    this.Exit();
            }
        }

        public void GuardarJuego()
        {
            XmlSerializer formateador = new XmlSerializer(nivelActual.GetType());

            formateador.Serialize(File.OpenWrite("juego.xml"), nivelActual);
        }

        public void CargarJuego()
        {
            XmlSerializer formatter = new XmlSerializer(nivelActual.GetType());
            Nivel nivelGuardado = (Nivel)formatter.Deserialize(File.OpenRead("juego.xml"));
            
            dibujables = new List<IDibujable>();
            actuables = new List<IActuable>();
            List<Entidad> nuevaLista = new List<Entidad>();
            nuevaLista.Add(nivelGuardado.Tablero.Entidades[0]);
            for (int i = 1; i < nivelGuardado.Tablero.Entidades.Count/2; i++)
            {
                nuevaLista.Add(nivelGuardado.Tablero.Entidades[i]);
            }

            this.nivelActual = nivelGuardado;
            listaEntidades = nuevaLista;
            nivelActual.CargarseGuardado(nivelGuardado.Bombita.PosicionActual, nivelGuardado.Tablero.ObstaculoQueOcultaSalida, listaEntidades);
        }

        // controla el estado del juego
        private void ActualizarEstadoDelJuego()
        {
            if (estado == EstadoDelJuego.jugando)
            {
                this.nivelActual.Actualizar();
                if (this.nivelActual.Perdido())
                    this.ReiniciarNivel();
                if (this.nivelActual.Ganado())
                {
                    if (nivelActual.Numero == niveles.Count())
                        this.estado = EstadoDelJuego.ganado;
                    else
                        this.estado = EstadoDelJuego.pausado;
                }
            }
        }


        // metodo encargado de las acciones que el usuario solicita por teclado
        private void ActualizarControlDelUsuario(KeyboardState teclado) 
        {
            Bombita bombita = nivelActual.Bombita;
            if ((this.contadorDeCiclos >= (CICLOS_PARA_ACTUALIZAR_CONTROL_DEL_USUARIO - bombita.Velocidad())) &&
                ((this.contadorDeCiclos % (CICLOS_PARA_ACTUALIZAR_CONTROL_DEL_USUARIO - bombita.Velocidad())) == 0))
            {

                if (this.estado == EstadoDelJuego.pausado || this.estado == EstadoDelJuego.iniciando)
                {
                    if (this.nivelActual.Ganado())
                    {
                        if (teclado.IsKeyDown(Keys.Enter))
                            this.PasarDeNivel();
                    }
                    else
                        this.ActualizarMenuPrincipal(teclado);
                }
                if (this.estado == EstadoDelJuego.jugando)
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

                    if (teclado.IsKeyDown(Keys.P))
                        this.estado = EstadoDelJuego.pausado;
                }
                
                if (this.estado == EstadoDelJuego.ganado || this.estado == EstadoDelJuego.perdido)
                {
                    if (teclado.IsKeyDown(Keys.Enter))
                        this.Initialize();
                }
            }       
            contadorDeCiclos++;
        }


        // actualiza los dibujables y actuables del juego (observa al modelo y se actualiza)
        private void ActualizarActuablesYDibujables()
        {              
            Tablero tablero = nivelActual.Tablero;
            List<Entidad> entidades = tablero.entidades;
            int indice1 = 0;
            while (indice1 < entidades.Count())
            {
                Entidad entidad = entidades[indice1];
                if (entidad.FueDestruido())
                {
                    this.actuables.Remove(entidad);
                    string descripcion = entidad.GetDescripcion();
                    bool encontrado = false;
                    int indice2 = 0;
                    while (!encontrado)
                    {
                        if (this.dibujables[indice2].GetPosicionable().GetDescripcion() == descripcion &&
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

            // se actualiza el estado del juego
            KeyboardState teclado = Keyboard.GetState();
            this.ActualizarControlDelUsuario(teclado);
            this.ActualizarActuablesYDibujables();
            this.ActualizarEstadoDelJuego();
  
            // se simulan las entidades

            if (this.estado == EstadoDelJuego.jugando)
            {
                List<IActuable> copiaDeActuables = this.actuables;
                foreach (IActuable actuable in copiaDeActuables)
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
            this.DibujarEstadoDelJuego();
            spriteBatch.Begin();
           
            if (this.estado == EstadoDelJuego.jugando)
            {
                List<IDibujable> copiaDeDibujables = this.dibujables;
                int indice = copiaDeDibujables.Count() - 1;
                while (indice >= 0)
                {
                    IDibujable dibujable = copiaDeDibujables[indice];
                    dibujable.Dibujar(this.Content, this.spriteBatch);
                    indice--;
                }
            }

            spriteBatch.End();

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }


        // dibuja la imagen para indicar en que estado se encuentra el juego
        private void DibujarEstadoDelJuego()
        {
            
            spriteBatch.Begin();

            if (this.estado == EstadoDelJuego.iniciando)
            {
                GraphicsDevice.Clear(Color.YellowGreen);
                this.menuPrincipal.Draw(spriteBatch);
            }

            if (this.estado == EstadoDelJuego.jugando) 
            {
                Texture2D texturaBordeHorizontal = Content.Load<Texture2D>("BordeHorizontal");
                spriteBatch.Draw(texturaBordeHorizontal, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(texturaBordeHorizontal, new Vector2(0, ALTO - texturaBordeHorizontal.Height), Color.White);

                Texture2D texturaBordeVertical = Content.Load<Texture2D>("BordeVertical");
                spriteBatch.Draw(texturaBordeVertical, new Vector2(0, texturaBordeVertical.Width), Color.White);
                spriteBatch.Draw(texturaBordeVertical, new Vector2((this.nivelActual.Tablero.Ancho() * texturaBordeVertical.Width) - texturaBordeVertical.Width, texturaBordeVertical.Width), Color.White);

                spriteBatch.DrawString(Content.Load<SpriteFont>("SpriteFont1"), "Nivel: " + this.nivelActual.Numero, new Vector2(1100, 0), Color.Black);
                spriteBatch.DrawString(Content.Load<SpriteFont>("SpriteFont1"), "Vidas: " + this.vidas, new Vector2(1100, 50), Color.Black);
                spriteBatch.DrawString(Content.Load<SpriteFont>("SpriteFont1"), "P: Menu", new Vector2(1100, 600), Color.Black);
            }

            if (this.estado == EstadoDelJuego.pausado)
            {
                if (this.nivelActual.Ganado())
                {
                    Texture2D texturaSiguienteNivel = Content.Load<Texture2D>("NextLevel");
                    Vector2 posicionSiguienteNivel = new Vector2(ANCHO / 2 - texturaSiguienteNivel.Width / 2, ALTO / 2 - texturaSiguienteNivel.Height / 2);
                    spriteBatch.Draw(texturaSiguienteNivel, posicionSiguienteNivel, Color.White);
                }
                else
                {
                    Texture2D texturaPause = Content.Load<Texture2D>("Pause");
                    Vector2 posicionPause = new Vector2(ANCHO / 2 - texturaPause.Width / 2, ALTO / 4 - texturaPause.Height / 2);
                    spriteBatch.Draw(texturaPause, posicionPause, Color.White);
                    GraphicsDevice.Clear(Color.YellowGreen);
                    this.menuPrincipal.Draw(spriteBatch);
                }
            }

            if (this.estado == EstadoDelJuego.ganado)
            {
                Texture2D texturaGanado = Content.Load<Texture2D>("YouWin");
                Vector2 posicionGanado = new Vector2(ANCHO / 2 - texturaGanado.Width / 2, ALTO / 2 - texturaGanado.Height / 2);
                spriteBatch.Draw(texturaGanado, posicionGanado, Color.White);
            }

            if (this.estado == EstadoDelJuego.perdido)
            {
                Texture2D texturaPerdido = Content.Load<Texture2D>("GameOver");
                Vector2 posicionPerdido = new Vector2(ANCHO / 2 - texturaPerdido.Width / 2, ALTO / 2 - texturaPerdido.Height / 2);
                spriteBatch.Draw(texturaPerdido, posicionPerdido, Color.White);
            }

            spriteBatch.End();
        }
    }
}
