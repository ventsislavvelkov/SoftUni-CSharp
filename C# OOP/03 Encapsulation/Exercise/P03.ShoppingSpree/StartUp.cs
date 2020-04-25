using System;
using P03.ShoppingSpree.Core;

namespace P03.ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Engine engine = new Engine();
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
    }
}
