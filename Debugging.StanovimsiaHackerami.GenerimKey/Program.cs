using System;

namespace Debugging.StanovimsiaHackerami.GenerimKey
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyGenerator = new KeyGenerator();
            var key = keyGenerator.Key();

            Console.WriteLine($"Vot tvoi klu4:{key}");

            Console.ReadKey(true);

        }
    }
}
