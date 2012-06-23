using System;

namespace Boomberman
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (JuegoBoomberman game = new JuegoBoomberman())
            {

                game.Run();
            }
        }
    }
#endif
}

