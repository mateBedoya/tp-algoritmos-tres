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
using TP2_BombermanGAME.src.Bombas;

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
            tablero.Reiniciar(tablero.Bombita);
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
                bloque.posicionEnVentana = new Vector2(bloque.Posicion.Columna * ancho, bloque.Posicion.Fila * alto);
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
                enemigo.posicionEnVentana = new Vector2(enemigo.Posicion.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, enemigo.Posicion.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
            }
            foreach (LopezR enemigo in tablero.ListaLopezR)
            {
                enemigo.textura = Content.Load<Texture2D>("lopezR");
                float anchoTextura = enemigo.textura.Width;
                float altoTextura = enemigo.textura.Height;
                float anchoCasillero = enemigo.Posicion.textura.Width;
                float altoCasillero = enemigo.Posicion.textura.Height;
                enemigo.posicionEnVentana = new Vector2(enemigo.Posicion.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, enemigo.Posicion.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
            }
            foreach (LopezRAlado enemigo in tablero.ListaLopezRAlado)
            {
                enemigo.textura = Content.Load<Texture2D>("lopezRAlado");
                float anchoTextura = enemigo.textura.Width;
                float altoTextura = enemigo.textura.Height;
                float anchoCasillero = enemigo.Posicion.textura.Width;
                float altoCasillero = enemigo.Posicion.textura.Height;
                enemigo.posicionEnVentana = new Vector2(enemigo.Posicion.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, enemigo.Posicion.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
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
            int vidasAntes = tablero.Bombita.Vidas;
            MoverBombita(teclado);
            LanzamientoBombita(teclado);
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
            LanzamientoEnemigos(enemigos);
            MoverEnemigos();
            if (tablero.Bombita.Bomba.EstaActivada && !tablero.Bombita.Bomba.FueDestruido())
            {
                tablero.Bombita.Bomba.CuandoPaseElTiempo(0.01);
            }
            foreach (Bomba bomba in tablero.ListaBombas)
            {
                if (bomba.EstaActivada && !bomba.FueDestruido()) bomba.CuandoPaseElTiempo(0.01);
            }
            foreach (Bomba bomba in tablero.ListaBombas)
            {
                foreach (Explosion explosion in bomba.ListaExplosiones)
                {
                    if (explosion.Posicion != null)
                    {
                        explosion.CuandoPaseElTiempo(0.01);
                    }
                }
            }
            if (vidasAntes > tablero.Bombita.Vidas)
            {
                return "vidaPerdida";
            }
            if (!tablero.Bombita.FueDestruido()) return "Nivel: " + tablero.NivelActual + " \nVidas: " + tablero.Bombita.Vidas + " \nCantidad enemigos vivos: " + tablero.CantidadEnemigosVivos();// +" \nPosicion enemigo: " + tablero.ListaCecilios[0].Posicion.Fila + "," + tablero.ListaCecilios[0].Posicion.Columna;
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
                Casillero casillero = bomba.Posicion;
                float anchoTextura = Game1.TexturasBombas["molotov"].Width;
                float altoTextura = Game1.TexturasBombas["molotov"].Height;
                float anchoCasillero = casillero.textura.Width;
                float altoCasillero = casillero.textura.Height;
                bomba.posicionEnVentana = new Vector2(casillero.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, casillero.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);

                
            }
        }

        private void LanzamientoEnemigos(List<Enemigo> enemigos)
        {
            /*
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
            }*/
            foreach (Enemigo enemigo in enemigos)
            {
                if (BombitaEstaCerca(enemigo) && !enemigo.FueDestruido())
                    enemigo.LanzarBomba();
                
            }
            foreach (Bomba bomba in tablero.ListaBombas)
            {
                if (!(bomba is Proyectil) && !bomba.Duenio.FueDestruido())
                {
                    Casillero casillero = bomba.Posicion;
                    float anchoTextura = Game1.TexturasBombas["molotov"].Width;
                    float altoTextura = Game1.TexturasBombas["molotov"].Height;
                    float anchoCasillero = casillero.textura.Width;
                    float altoCasillero = casillero.textura.Height;
                    bomba.posicionEnVentana = new Vector2(casillero.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, casillero.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
                }
                else if (bomba is Proyectil)
                {
                    Casillero casillero = bomba.Posicion;
                    float anchoTextura = Game1.TexturasBombas["proyectil"].Width;
                    float altoTextura = Game1.TexturasBombas["proyectil"].Height;
                    float anchoCasillero = casillero.textura.Width;
                    float altoCasillero = casillero.textura.Height;
                    bomba.posicionEnVentana = new Vector2(casillero.posicionEnVentana.X + anchoCasillero / 2 - anchoTextura / 2, casillero.posicionEnVentana.Y + altoCasillero / 2 - altoTextura / 2);
                    MoverProyectil((Proyectil)bomba);
                }
            }
        }

        private bool BombitaEstaCerca(Enemigo enemigo)
        {
            int filaBombita = tablero.Bombita.Posicion.Fila;
            int columnaBombita = tablero.Bombita.Posicion.Columna;
            int filaEnemigo = enemigo.Posicion.Fila;
            int columnaEnemigo = enemigo.Posicion.Columna;
            int rango = enemigo.Bomba.Rango;
            if (((filaBombita == filaEnemigo) && (Math.Abs(columnaBombita - columnaEnemigo) <= rango)) || ((columnaBombita == columnaEnemigo) && (Math.Abs(filaBombita - filaEnemigo) <= rango)))
            {
                return true;
            }
            return false;
        }

        private void MoverProyectil(Proyectil proyectil)
        {
            if (proyectil.Duenio.Direccion == "este")
            {
                if (proyectil.posicionEnVentana.X + Game1.TexturasBombas["proyectil"].Width >= tablero.Dimension * proyectil.Posicion.textura.Width) return;
                Casillero casilleroSup;
                try
                {
                    casilleroSup = tablero.ObtenerCasillero(proyectil.Posicion.Fila, proyectil.Posicion.Columna + 1);
                }
                catch (Exception)
                {
                    return;
                }

                if ((casilleroSup != null) && (proyectil.posicionEnVentana.X + Game1.TexturasBombas["proyectil"].Width / 2 >= casilleroSup.posicionEnVentana.X + casilleroSup.textura.Width / 2))
                {
                    proyectil.MoverDerecha();
                }

                proyectil.posicionEnVentana.X += proyectil.Velocidad;
                
            }
            if (proyectil.Duenio.Direccion == "oeste")
            {
                if (proyectil.posicionEnVentana.X <= 0) return;
                Casillero casilleroSup;
                try
                {
                    casilleroSup = tablero.ObtenerCasillero(proyectil.Posicion.Fila , proyectil.Posicion.Columna -1);
                }
                catch (Exception)
                {
                    return;
                }
                if ((casilleroSup != null) && (proyectil.posicionEnVentana.X + Game1.TexturasBombas["proyectil"].Width / 2 <= casilleroSup.posicionEnVentana.X + casilleroSup.textura.Width / 2))
                {
                    proyectil.MoverIzquierda();
                }

                proyectil.posicionEnVentana.X -= proyectil.Velocidad;
                
            }
            if (proyectil.Duenio.Direccion == "norte")
            {
                if (proyectil.posicionEnVentana.Y <= 0) return;
                Casillero casilleroSup;
                try
                {
                    casilleroSup = tablero.ObtenerCasillero(proyectil.Posicion.Fila - 1, proyectil.Posicion.Columna);
                }
                catch (Exception)
                {
                    return;
                }
                if ((casilleroSup != null) && (proyectil.posicionEnVentana.Y + Game1.TexturasBombas["proyectil"].Height / 2 <= casilleroSup.posicionEnVentana.Y + casilleroSup.textura.Height / 2))
                {
                    proyectil.MoverArriba();
                }

                proyectil.posicionEnVentana.Y -= proyectil.Velocidad;

                
            }
            if (proyectil.Duenio.Direccion == "sur")
            {
                if (proyectil.posicionEnVentana.Y + Game1.TexturasBombas["proyectil"].Height >= tablero.Dimension * proyectil.Posicion.textura.Height) return;
                Casillero casilleroSup;
                try
                {
                    casilleroSup = tablero.ObtenerCasillero(proyectil.Posicion.Fila + 1, proyectil.Posicion.Columna);
                }
                catch (Exception)
                {
                    return;
                }

                if ((casilleroSup != null) && (proyectil.posicionEnVentana.Y + Game1.TexturasBombas["proyectil"].Height / 2 >= casilleroSup.posicionEnVentana.Y + casilleroSup.textura.Height / 2))
                {
                    proyectil.MoverAbajo();
                }

                proyectil.posicionEnVentana.Y += proyectil.Velocidad;
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
                /*      
                      Casillero casilleroAMoverse;

                      casilleroAMoverse = enemigo.Posicion;
                     // if (bombitaEstaDerecha(enemigo))
                      //{
                          if (enemigo.posicionEnVentana.X + enemigo.textura.Width / 2 == casilleroAMoverse.posicionEnVentana.X + casilleroAMoverse.textura.Width / 2)
                          {
                              try
                              {
                                  enemigo.MoverDerecha();
                              }
                              catch (Exception) { return; }

                          }
                          else
                          {
                              enemigo.posicionEnVentana.X += enemigo.Velocidad;
                          }
                      //}
                      //if (!bombitaEstaDerecha(enemigo))
                      //{
                          if (enemigo.posicionEnVentana.X + enemigo.textura.Width / 2 == casilleroAMoverse.posicionEnVentana.X + casilleroAMoverse.textura.Width / 2)
                          {
                              try
                              {
                                  enemigo.MoverIzquierda();
                              }
                              catch (Exception) { return; }

                          }
                          else
                          {
                              enemigo.posicionEnVentana.X -= enemigo.Velocidad;
                          }
                      }
                      if (bombitaEstaArriba(enemigo))
                      {
                          if (enemigo.posicionEnVentana.Y + enemigo.textura.Height / 2 == casilleroAMoverse.posicionEnVentana.Y + casilleroAMoverse.textura.Height / 2)
                          {
                              try
                              {
                                  enemigo.MoverArriba();
                              }
                              catch (Exception) { return; }
                              enemigo.posicionEnVentana.Y -= enemigo.Velocidad;
                              return;
                          }
                          else
                          {
                              enemigo.posicionEnVentana.Y -= enemigo.Velocidad;
                          }
                      }
                      if (!bombitaEstaArriba(enemigo))
                      {
                          if (enemigo.posicionEnVentana.Y + enemigo.textura.Height / 2 == casilleroAMoverse.posicionEnVentana.Y + casilleroAMoverse.textura.Height / 2)
                          {
                              try
                              {
                                  enemigo.MoverAbajo();
                              }
                        
                              catch (Exception) { return; }
                              enemigo.posicionEnVentana.Y += enemigo.Velocidad;
                              return;
                          }
                          else
                          {
                              enemigo.posicionEnVentana.Y += enemigo.Velocidad;
                          }
                      }
            
      */


                if (!enemigo.FueDestruido())
                {
                    bool pudoMoverse = false;


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
                            if ((casilleroSup != null) && (enemigo.posicionEnVentana.Y + enemigo.textura.Height / 2 <= casilleroSup.posicionEnVentana.Y + casilleroSup.textura.Height / 2))
                            {
                                enemigo.MoverArriba();
                            }

                            enemigo.posicionEnVentana.Y -= enemigo.Velocidad;


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
                            if ((casilleroDerecho != null) && (enemigo.posicionEnVentana.X + enemigo.textura.Width / 2 >= casilleroDerecho.posicionEnVentana.X + casilleroDerecho.textura.Width / 2))
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
                            if ((casilleroInf != null) && (enemigo.posicionEnVentana.Y + enemigo.textura.Height / 2 >= casilleroInf.posicionEnVentana.Y + casilleroInf.textura.Height / 2))
                            {
                                enemigo.MoverAbajo();
                            }
                            enemigo.posicionEnVentana.Y += enemigo.Velocidad;


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
                            if ((casilleroIzq != null) && (enemigo.posicionEnVentana.X + enemigo.textura.Width / 2 <= casilleroIzq.posicionEnVentana.X + casilleroIzq.textura.Width / 2))
                            {
                                enemigo.MoverIzquierda();
                            }


                            enemigo.posicionEnVentana.X -= enemigo.Velocidad;

                            pudoMoverse = true;
                        }
                    }
                }
            }
        }




        /*
        private void MoverHaciaBombita(Enemigo enemigo)
        {
            int restaFila = enemigo.Posicion.Fila - tablero.Bombita.Posicion.Fila;
            int restaColumna = enemigo.Posicion.Columna - tablero.Bombita.Posicion.Columna;

            
            //if (Math.Abs(restaFila) > Math.Abs(restaColumna)) //derecha o izquierda
            //{
            try
            {
                if (Math.Abs(restaFila) > Math.Abs(restaColumna)) //derecha o izquierda
                {
                    if (restaFila < 0)
                    {
                        enemigo.MoverDerecha();
                    }
                    else
                    {
                        enemigo.MoverIzquierda();
                    }
                }
                else
                {
                    if (restaColumna < 0)
                    {
                        enemigo.MoverAbajo();
                    }
                    else
                    {
                        enemigo.MoverArriba();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }



                    
            
    
        }
        
        private void MoverEnPantalla(Enemigo enemigo)
        {
            Casillero casilleroAMoverse;
            casilleroAMoverse = tablero.ObtenerCasillero(enemigo.Posicion.Fila, enemigo.Posicion.Columna);
            while (enemigo.posicionEnVentana.X + enemigo.textura.Width / 2 > casilleroAMoverse.posicionEnVentana.X + casilleroAMoverse.textura.Width / 2)
            {
                enemigo.posicionEnVentana.X -= enemigo.Velocidad;
            }
        }
        */

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
                    return;
                }
                if (movimientoEsInvalido(casilleroDerecho)) return;
                if ((tablero.Bombita.posicionEnVentana.X + tablero.Bombita.textura.Width / 2 >= casilleroDerecho.posicionEnVentana.X))
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
                    return;
                }

                if (movimientoEsInvalido(casilleroIzq)) return;
                if ((tablero.Bombita.posicionEnVentana.X + tablero.Bombita.textura.Width / 2 <= casilleroIzq.posicionEnVentana.X + casilleroIzq.textura.Width))
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
                    return;
                }
                if (movimientoEsInvalido(casilleroSup)) return;
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
                    return;
                }
                if (movimientoEsInvalido(casilleroInf)) return;
                if ((casilleroInf != null) && (tablero.Bombita.posicionEnVentana.Y + tablero.Bombita.textura.Height / 2 >= casilleroInf.posicionEnVentana.Y))
                {
                    tablero.Bombita.MoverAbajo();
                }
                tablero.Bombita.posicionEnVentana.Y += tablero.Bombita.Velocidad;
            }
        }

        private bool movimientoEsInvalido(Casillero casilleroADesplazarse)
        {
            if (!casilleroADesplazarse.EstaVacio() && !casilleroADesplazarse.Entidad.EsArticulo()) return true;
            if (casilleroADesplazarse.Entidad != null && casilleroADesplazarse.Entidad.EsSalida() && tablero.CantidadEnemigosVivos() != 0) return true;
            return false;
        }


        public void Dibujar(SpriteBatch spriteBatch)
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
                if (!bloque.FueDestruido())
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

            foreach (Bomba bomba in tablero.ListaBombas)
            {
                if (bomba.EstaActivada && !bomba.FueDestruido())
                {
                    if (!bomba.FueDestruido() && !bomba.Duenio.FueDestruido())
                    {
                        if (bomba is Molotov)
                            bomba.textura = Game1.TexturasBombas["molotov"];
                        else if (bomba is ToleTole)
                            bomba.textura = Game1.TexturasBombas["toleTole"];
                        else if (bomba is Proyectil)
                            bomba.textura = Game1.TexturasBombas["proyectil"];
                        spriteBatch.Draw(bomba.textura, bomba.posicionEnVentana, Color.White);
                    }
                }
            }

            foreach (Bomba bomba in tablero.ListaBombas)
            {
                foreach (Explosion explosion in bomba.ListaExplosiones)
                {
                    
                    if (explosion.Posicion != null)
                    {
                        float ancho = Game1.TexturasBombas["explosion"].Width;
                        float alto = Game1.TexturasBombas["explosion"].Height;
                        float anchoC = explosion.Posicion.textura.Width;
                        float altoC = explosion.Posicion.textura.Height;
                        explosion.posicionEnVentana = new Vector2(explosion.Posicion.posicionEnVentana.X + anchoC / 2 - ancho / 2, explosion.Posicion.posicionEnVentana.Y + altoC / 2 - alto / 2);
                        explosion.textura = Game1.TexturasBombas["explosion"];
                        spriteBatch.Draw(explosion.textura, explosion.posicionEnVentana, Color.White);
                    }
                }
            }
            

            if (!tablero.Bombita.FueDestruido())
            {
                if(tablero.Bombita.Direccion == "")
                    spriteBatch.Draw(tablero.Bombita.textura, tablero.Bombita.posicionEnVentana, Color.White);
                if(tablero.Bombita.Direccion == "oeste")
                    spriteBatch.Draw(Game1.TexturasBombita["izquierda"], tablero.Bombita.posicionEnVentana, Color.White);
                if(tablero.Bombita.Direccion == "norte")
                    spriteBatch.Draw(Game1.TexturasBombita["arriba"], tablero.Bombita.posicionEnVentana, Color.White);
                if(tablero.Bombita.Direccion == "sur")
                    spriteBatch.Draw(Game1.TexturasBombita["abajo"], tablero.Bombita.posicionEnVentana, Color.White);
                if(tablero.Bombita.Direccion == "este")
                    spriteBatch.Draw(Game1.TexturasBombita["derecha"], tablero.Bombita.posicionEnVentana, Color.White);
            }

        }

        public void DibujarVidaPerdida(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.TexturasBombita["muerto"], tablero.Bombita.posicionEnVentana, Color.White);
        }
        
    }
}
