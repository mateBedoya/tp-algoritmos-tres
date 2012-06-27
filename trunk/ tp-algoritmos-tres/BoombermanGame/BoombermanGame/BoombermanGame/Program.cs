using System;

namespace BoombermanGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Controlador game = new Controlador())
            {
                game.Run();
            }
        }
    }
#endif
}

