using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TP2_Bomberman.src;
using TP2_Bomberman.src.Obstaculos;
using TP2_Bomberman.src.Personajes;
using TP2_Bomberman.src.Elementales;
using TP2_Bomberman.src.Articulos;
using TP2_Bomberman.src.Bombas;

namespace TP2_BombermanGAME
{
    public class Controlador
    {
        private Tablero tablero;
        public int nivelActual;
                
        public void Inicializar()
        {
            tablero = new Tablero(true);
            nivelActual = tablero.NivelActual;
        }

        public void Reset(ContentManager content)
        {
            tablero.Reiniciar();
            CargarTexturas(content);
        }
        
        public void CargarTexturas(ContentManager Content)
        {
            foreach (Casillero casillero in tablero.Mapa)
            {
                casillero.textura = Content.Load<Texture2D>("CasilleroVacio");
                float ancho = casillero.textura.Width;
                float alto = casillero.textura.Height;
                casillero.posicionEnVentana = new Vector2(casillero.Columna * ancho, casillero.Fila * alto);
            }

            foreach (BloqueDeAcero bloque in tablero.ListaDeBloqueDeAcero)
            {
                bloque.textura = Content.Load<Texture2D>("acero");
                float ancho = bloque.textura.Width;
                float alto = bloque.textura.Height;
                bloque.posicionEnVentana = new Vector2(bloque.Posicion.Columna * ancho, bloque.Posicion.Fila *alto);
            }

            foreach (BloqueDeCemento bloque in tablero.ListaDeBloqueDeCemento)
            {
                bloque.textura = Content.Load<Texture2D>("cemento");
                float ancho = bloque.textura.Width;
                float alto = bloque.textura.Height;
                bloque.posicionEnVentana = new Vector2(bloque.Posicion.Columna * ancho, bloque.Posicion.Fila * alto);
            }
            foreach (BloqueDeLadrillos bloque in tablero.ListaDeBloqueDeLadrillos)
            {
                bloque.textura = Content.Load<Texture2D>("ladrillos");
                float ancho = bloque.textura.Width;
                float alto = bloque.textura.Height;
                bloque.posicionEnVentana = new Vector2(bloque.Posicion.Columna * ancho, bloque.Posicion.Fila * alto);
            }
            foreach (Cecilio enemigo in tablero.ListaCecilios)
            {
                enemigo.textura = Content.Load<Texture2D>("cecilio");
                float anchoTextura = enemigo.textura.Width;
                float altoTextura = enemigo.textura.Height;
                float anchoCasillero = enemigo.Posicion.textura.Width;
                float altoCasillero = enemigo.Posicion.textura.Height;
                enemigo.posicionEnVentana = new Vector2(enemigo.Posicion.posicionEnVentana.X + anchoCasillero/2 - anchoTextura/2, enemigo.Posicion.posicionEnVentana.Y + altoCasillero/2 - altoTextura/2);
            }
            foreach (LopezR enemigo in tablero.ListaLopezR)
            {
                enemigo.textura = Content.Load<Texture2D>("lopezR");
                float anchoTextura = enemigo.textura.Width;
                float altoTextura = enemigo.textura.Height;
                float anchoCasillero = enemigo.Posicion.textura.Width;
                float altoCasillero = enemigo.Posicion.textura.Height;
                enemigo.posicionEnVentana = new Vector2(enemigo.Posicion.posicionEnVentana.X + anchoCasillero/2 - anchoTextura/2, enemigo.Posicion.posicionEnVentana.Y + altoCasillero/2 - altoTextura/2 );
            }
            foreach (LopezRAlado enemigo in tablero.ListaLopezRAlado)
            {
                enemigo.textura = Content.Load<Texture2D>("lopezRAlado");
                float anchoTextura = enemigo.textura.Width;
                float altoTextura = enemigo.textura.Height;
                float anchoCasillero = enemigo.Posicion.textura.Width;
                float altoCasillero = enemigo.Posicion.textura.Height;
                enemigo.posicionEnVentana = new Vector2(enemigo.Posicion.posicionEnVentana.X + anchoCasillero/2 - anchoTextura/2, enemigo.Posicion.posicionEnVentana.Y + altoCasillero/2 - altoTextura/2);
            }
            foreach (Articulo articulo in tablero.ListaTimer)
            {
                articulo.textura = Content.Load<Texture2D>("timer");
                float anchoTextura = articulo.textura.Width;
                float altoTextura = articulo.textura.Height;
                float anchoCasillero = articulo.Posicion.textura.Width;
                float altoCasillero = articulo.Posicion.textura.Height;
                articulo.posicionEnVentana = new Vector2(articulo.Posicion.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, articulo.Posicion.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
            }
            foreach (Articulo articulo in tablero.ListaHabano)
            {
                articulo.textura = Content.Load<Texture2D>("habano");
                float anchoTextura = articulo.textura.Width;
                float altoTextura = articulo.textura.Height;
                float anchoCasillero = articulo.Posicion.textura.Width;
                float altoCasillero = articulo.Posicion.textura.Height;
                articulo.posicionEnVentana = new Vector2(articulo.Posicion.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, articulo.Posicion.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
            }
            foreach (Articulo articulo in tablero.ListaBombaToleTole)
            {
                articulo.textura = Content.Load<Texture2D>("bombaToleTole");
                float anchoTextura = articulo.textura.Width;
                float altoTextura = articulo.textura.Height;
                float anchoCasillero = articulo.Posicion.textura.Width;
                float altoCasillero = articulo.Posicion.textura.Height;
                articulo.posicionEnVentana = new Vector2(articulo.Posicion.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, articulo.Posicion.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
            }
            tablero.Bombita.textura = Content.Load<Texture2D>("bombita");
            float anchoBombita = tablero.Bombita.textura.Width;
            float altoBombita = tablero.Bombita.textura.Height;
            tablero.Bombita.posicionEnVentana = new Vector2(tablero.Bombita.Posicion.Columna * anchoBombita, tablero.Bombita.Posicion.Fila * altoBombita);

            tablero.Salida.textura = Content.Load<Texture2D>("salida");
            float anchoSalida = tablero.Salida.textura.Width;
            float altoSalida = tablero.Salida.textura.Height;
            tablero.Salida.posicionEnVentana = new Vector2(tablero.Salida.Posicion.Columna * anchoSalida, tablero.Salida.Posicion.Fila * altoSalida);
            
        }

        public string Actualizar(KeyboardState teclado)
        {
            if (this.nivelActual != tablero.NivelActual)
            {
                nivelActual++;
                return "Pasa de nivel";
            }
            MoverBombita(teclado);
            LanzamientoBombita(teclado);
            MoverEnemigos();
            if(tablero.Bombita.Bomba.EstaActivada && !tablero.Bombita.Bomba.FueDestruido()) tablero.Bombita.Bomba.CuandoPaseElTiempo(0.01);
            //foreach (Bomba bomba in tablero.ListaBombas)
            //{
            //    if (bomba.EstaActivada && !bomba.FueDestruido()) bomba.CuandoPaseElTiempo(0.01);
            //}

            if (!tablero.Bombita.FueDestruido() && tablero.Salida.Posicion != null) return "Nivel: " + tablero.NivelActual + " \nVidas: " + tablero.Bombita.Vidas + " \nCantidad enemigos vivos: " + tablero.CantidadEnemigosVivos();
            if (tablero.Bombita.FueDestruido()) return "Perdio";
            if (this.nivelActual == tablero.CantidadDeNiveles) return "Gano";
            return "";
        }
        
        private void LanzamientoBombita(KeyboardState teclado)
        {
            if (teclado.IsKeyDown(Keys.Space))
            {
                tablero.Bombita.LanzarBomba();
                Bomba bomba = tablero.Bombita.Bomba;
                //foreach (Bomba bomba in tablero.ListaBombas)
                //{
                    Casillero casillero = bomba.Posicion;
                    float anchoTextura = Game1.TexturasBombas[0].Width;
                    float altoTextura = Game1.TexturasBombas[0].Height;
                    float anchoCasillero = casillero.textura.Width;
                    float altoCasillero = casillero.textura.Height;
                    bomba.posicionEnVentana = new Vector2(casillero.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, casillero.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
                //}
            }
        }

        private void MoverEnemigos()
        {
            List<Enemigo> enemigos = new List<Enemigo>();
            foreach (Cecilio cecilio in tablero.ListaCecilios)
            {
                enemigos.Add(cecilio);
            }
            foreach (LopezR lopez in tablero.ListaLopezR)
            {
                enemigos.Add(lopez);
            }
            foreach (LopezRAlado lopez in tablero.ListaLopezRAlado)
            {
                enemigos.Add(lopez);
            }
            
            foreach (Enemigo enemigo in enemigos)
            {
                bool pudoMoverse = false;
                if (bombitaEstaIgual(enemigo)) return;
                
                if (bombitaEstaArriba(enemigo))
                {
                    while (!pudoMoverse)
                    {
                        if (enemigo.posicionEnVentana.Y <= 0) break;
                        Casillero casilleroSup;
                        try
                        {
                            casilleroSup = tablero.ObtenerCasillero(enemigo.Posicion.Fila - 1, enemigo.Posicion.Columna);
                        }
                        catch (Exception)
                        {

                            break;
                        }
                        if (casilleroSup != null && !casilleroSup.EstaVacio()) break;
                        if (casilleroSup != null && casilleroSup.Entidad != null && casilleroSup.Entidad.EsSalida()) break;
                        if ((casilleroSup != null) && (enemigo.posicionEnVentana.Y + enemigo.textura.Height / 2 <= casilleroSup.posicionEnVentana.Y + casilleroSup.textura.Height/2))
                        {
                            enemigo.MoverArriba();
                        }
                        
                        enemigo.posicionEnVentana.Y -= enemigo.Velocidad ;
                        
                        
                        pudoMoverse = true;
                    }
                    
                }

                if (bombitaEstaDerecha(enemigo))
                {
                    while (!pudoMoverse)
                    {
                        if (enemigo.posicionEnVentana.X + enemigo.textura.Width >= tablero.Dimension * enemigo.Posicion.textura.Width) break;
                        Casillero casilleroDerecho;
                        try
                        {
                            casilleroDerecho = tablero.ObtenerCasillero(enemigo.Posicion.Fila, enemigo.Posicion.Columna + 1);
                        }
                        catch (Exception)
                        {
                            
                            break;
                        }
                        
                        if (casilleroDerecho != null && !casilleroDerecho.EstaVacio()) break;
                        if (casilleroDerecho != null && casilleroDerecho.Entidad != null && casilleroDerecho.Entidad.EsSalida()) break;
                        if ((casilleroDerecho != null) && (enemigo.posicionEnVentana.X + enemigo.textura.Width / 2 >= casilleroDerecho.posicionEnVentana.X + casilleroDerecho.textura.Width /2))
                        {
                            enemigo.MoverDerecha();
                        }
                        enemigo.posicionEnVentana.X += enemigo.Velocidad;
                        pudoMoverse = true;
                    }
                }

                if (!bombitaEstaArriba(enemigo))
                {
                    while (!pudoMoverse)
                    {
                        if (enemigo.posicionEnVentana.Y + enemigo.textura.Height >= tablero.Dimension * enemigo.Posicion.textura.Height) break;
                        Casillero casilleroInf;
                        try
                        {
                            casilleroInf = tablero.ObtenerCasillero(enemigo.Posicion.Fila + 1, enemigo.Posicion.Columna);
                        }
                        catch (Exception)
                        {
                            
                            break;
                        }
                        if (casilleroInf != null && !casilleroInf.EstaVacio()) break;
                        if (casilleroInf != null && casilleroInf.Entidad != null && casilleroInf.Entidad.EsSalida()) break;
                        if ((casilleroInf != null) && (enemigo.posicionEnVentana.Y + enemigo.textura.Height / 2 >= casilleroInf.posicionEnVentana.Y + casilleroInf.textura.Height/2))
                        {
                            enemigo.MoverAbajo();
                        }                        
                        enemigo.posicionEnVentana.Y += enemigo.Velocidad ;
                        
                        
                        pudoMoverse = true;
                    }
                }


                
                if (!bombitaEstaDerecha(enemigo))
                {
                    while (!pudoMoverse)
                    {
                        if (enemigo.posicionEnVentana.X <= 0) break;
                        Casillero casilleroIzq;
                        try
                        {
                            casilleroIzq = tablero.ObtenerCasillero(enemigo.Posicion.Fila, enemigo.Posicion.Columna - 1);
                        }
                        catch (Exception)
                        {
                            
                            break;
                        }
                        if (casilleroIzq != null && !casilleroIzq.EstaVacio()) break;
                        if (casilleroIzq != null && casilleroIzq.Entidad != null && casilleroIzq.Entidad.EsSalida()) break;
                        if ((casilleroIzq != null) && (enemigo.posicionEnVentana.X + enemigo.textura.Width / 2 <= casilleroIzq.posicionEnVentana.X + casilleroIzq.textura.Width/2))
                        {
                            enemigo.MoverIzquierda();
                        }

                        
                            enemigo.posicionEnVentana.X -= enemigo.Velocidad ;
                        
                        pudoMoverse = true;
                    }
                }                
            }
        }

        private bool bombitaEstaArriba(Enemigo enemigo)
        {
            if (tablero.Bombita.Posicion.Fila <= enemigo.Posicion.Fila) return true;
            return false;
        }
        
        private bool bombitaEstaDerecha(Enemigo enemigo)
        {
            if (tablero.Bombita.Posicion.Columna >= enemigo.Posicion.Columna) return true;
            return false;
        }
        private bool bombitaEstaIgual(Enemigo enemigo)
        {
            if ((tablero.Bombita.Posicion.Columna == enemigo.Posicion.Columna) || (tablero.Bombita.Posicion.Fila == enemigo.Posicion.Fila)) return true;
            return false;
        }
        

        private void MoverBombita(KeyboardState teclado)
        {
            if (teclado.IsKeyDown(Keys.Right))
            {
                if (tablero.Bombita.posicionEnVentana.X + tablero.Bombita.textura.Width >= tablero.Dimension * tablero.Bombita.Posicion.textura.Width) return;
                Casillero casilleroDerecho;

                try
                {
                    casilleroDerecho = tablero.ObtenerCasillero(tablero.Bombita.Posicion.Fila, tablero.Bombita.Posicion.Columna + 1);
                }
                catch (Exception)
                {
                    casilleroDerecho = null;
                }
                
                if (casilleroDerecho != null && !casilleroDerecho.EstaVacio() && !casilleroDerecho.Entidad.EsArticulo()) return;
                if (casilleroDerecho != null && casilleroDerecho.Entidad != null && casilleroDerecho.Entidad.EsSalida() && tablero.CantidadEnemigosVivos() != 0) return;
                if ((casilleroDerecho != null) && (tablero.Bombita.posicionEnVentana.X + tablero.Bombita.textura.Width / 2 >= casilleroDerecho.posicionEnVentana.X))
                {
                    tablero.Bombita.MoverDerecha();
                }
                tablero.Bombita.posicionEnVentana.X += tablero.Bombita.Velocidad;
            }
            if (teclado.IsKeyDown(Keys.Left))
            {
                if (tablero.Bombita.posicionEnVentana.X <= 0) return;
                Casillero casilleroIzq;
                try
                {
                    casilleroIzq = tablero.ObtenerCasillero(tablero.Bombita.Posicion.Fila, tablero.Bombita.Posicion.Columna - 1);
                }
                catch (Exception)
                {
                    casilleroIzq = null;
                }
                
                if (casilleroIzq != null && !casilleroIzq.EstaVacio() && !casilleroIzq.Entidad.EsArticulo()) return;
                if (casilleroIzq != null && casilleroIzq.Entidad != null && casilleroIzq.Entidad.EsSalida() && tablero.CantidadEnemigosVivos()!=0) return;
                if ((casilleroIzq != null) && (tablero.Bombita.posicionEnVentana.X + tablero.Bombita.textura.Width / 2 <= casilleroIzq.posicionEnVentana.X + casilleroIzq.textura.Width))
                {
                    tablero.Bombita.MoverIzquierda();
                }
                tablero.Bombita.posicionEnVentana.X -= tablero.Bombita.Velocidad;
            }
            if (teclado.IsKeyDown(Keys.Up))
            {
                if (tablero.Bombita.posicionEnVentana.Y <= 0) return;
                Casillero casilleroSup;
                try
                {
                    casilleroSup = tablero.ObtenerCasillero(tablero.Bombita.Posicion.Fila - 1, tablero.Bombita.Posicion.Columna);
                }
                catch (Exception)
                {
                    casilleroSup = null;
                }
                
                if (casilleroSup != null && !casilleroSup.EstaVacio() && !casilleroSup.Entidad.EsArticulo()) return;
                if (casilleroSup != null && casilleroSup.Entidad != null && casilleroSup.Entidad.EsSalida() && tablero.CantidadEnemigosVivos() != 0) return;
                if ((casilleroSup != null) && (tablero.Bombita.posicionEnVentana.Y + tablero.Bombita.textura.Height / 2 <= casilleroSup.posicionEnVentana.Y + casilleroSup.textura.Height))
                {
                    tablero.Bombita.MoverArriba();
                }
                tablero.Bombita.posicionEnVentana.Y -= tablero.Bombita.Velocidad;
            }
            if (teclado.IsKeyDown(Keys.Down))
            {
                if (tablero.Bombita.posicionEnVentana.Y + tablero.Bombita.textura.Height >= tablero.Dimension * tablero.Bombita.Posicion.textura.Height) return;
                Casillero casilleroInf;
                try
                {
                    casilleroInf = tablero.ObtenerCasillero(tablero.Bombita.Posicion.Fila + 1, tablero.Bombita.Posicion.Columna);
                }
                catch (Exception)
                {
                    casilleroInf = null;
                }
                
                if (casilleroInf != null && !casilleroInf.EstaVacio() && !casilleroInf.Entidad.EsArticulo()) return;
                if (casilleroInf != null && casilleroInf.Entidad != null && casilleroInf.Entidad.EsSalida() && tablero.CantidadEnemigosVivos() != 0) return;
                if ((casilleroInf != null) && (tablero.Bombita.posicionEnVentana.Y + tablero.Bombita.textura.Height / 2 >= casilleroInf.posicionEnVentana.Y))
                {
                    tablero.Bombita.MoverAbajo();
                }
                tablero.Bombita.posicionEnVentana.Y += tablero.Bombita.Velocidad;
            }
        }

        
        public void Dibujar(SpriteBatch spriteBatch, List<Texture2D> texturasBombas)
        {
            foreach (Casillero casillero in tablero.Mapa)
            {
                spriteBatch.Draw(casillero.textura, casillero.posicionEnVentana, Color.White);
            }

            if (!tablero.Salida.FueDestruido() && tablero.Salida.Posicion != null)
                spriteBatch.Draw(tablero.Salida.textura, tablero.Salida.posicionEnVentana, Color.White);

            foreach (Articulo articulo in tablero.ListaTimer)
            {
                if (!articulo.FueDestruido() && articulo.Posicion != null)
                    spriteBatch.Draw(articulo.textura, articulo.posicionEnVentana, Color.White);
            }
            foreach (Articulo articulo in tablero.ListaBombaToleTole)
            {
                if (!articulo.FueDestruido() && articulo.Posicion != null)
                    spriteBatch.Draw(articulo.textura, articulo.posicionEnVentana, Color.White);
            } foreach (Articulo articulo in tablero.ListaHabano)
            {
                if (!articulo.FueDestruido() && articulo.Posicion != null)
                    spriteBatch.Draw(articulo.textura, articulo.posicionEnVentana, Color.White);
            }
            foreach (BloqueDeAcero bloque in tablero.ListaDeBloqueDeAcero)
            {
                if(!bloque.FueDestruido())
                    spriteBatch.Draw(bloque.textura, bloque.posicionEnVentana, Color.White);
            }
            foreach (BloqueDeCemento bloque in tablero.ListaDeBloqueDeCemento)
            {
                if (!bloque.FueDestruido())
                    spriteBatch.Draw(bloque.textura, bloque.posicionEnVentana, Color.White);
            }
            foreach (BloqueDeLadrillos bloque in tablero.ListaDeBloqueDeLadrillos)
            {
                if (!bloque.FueDestruido())
                    spriteBatch.Draw(bloque.textura, bloque.posicionEnVentana, Color.White);
            }
            foreach (Cecilio enemigo in tablero.ListaCecilios)
            {
                if (!enemigo.FueDestruido())
                    spriteBatch.Draw(enemigo.textura, enemigo.posicionEnVentana, Color.White);
            }
            foreach (LopezR enemigo in tablero.ListaLopezR)
            {
                if (!enemigo.FueDestruido())
                    spriteBatch.Draw(enemigo.textura, enemigo.posicionEnVentana, Color.White);
            }
            foreach (LopezRAlado enemigo in tablero.ListaLopezRAlado)
            {
                if (!enemigo.FueDestruido())
                    spriteBatch.Draw(enemigo.textura, enemigo.posicionEnVentana, Color.White);
            }
            if (tablero.Bombita.Bomba.EstaActivada && !tablero.Bombita.Bomba.FueDestruido())
            {
            //foreach(Bomba bomba in tablero.ListaBombas)
            //{
                Bomba bomba = tablero.Bombita.Bomba;
                if (!bomba.FueDestruido())
                {
                    if (bomba is Molotov)
                        bomba.textura = texturasBombas[0];
                    else if (bomba is ToleTole)
                        bomba.textura = texturasBombas[1];
                    spriteBatch.Draw(bomba.textura, bomba.posicionEnVentana, Color.White);
                }
            }
            //if (tablero.Bombita.Bomba.FueDestruido()) { }
            

            if (!tablero.Bombita.FueDestruido())
            {
                spriteBatch.Draw(tablero.Bombita.textura, tablero.Bombita.posicionEnVentana, Color.White);
            }

        }
    }
}
