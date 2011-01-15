//#define __FROBULOUS__
using System;
using LibFrobulous;

namespace Frobulous
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
#if __FROBULOUS__
            using (Frobulous game = new Frobulous())
            {

                game.Run();
            }
#else

            using (Fshmaup game = new Fshmaup())
            {
                game.Run();
            }
#endif

        }
    }
#endif
}

