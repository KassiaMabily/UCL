using System;

namespace Extremamente_Básico
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            int x = a + b;

            Console.WriteLine("X = {0}", x);

            Console.ReadKey();
        }
    }
}
