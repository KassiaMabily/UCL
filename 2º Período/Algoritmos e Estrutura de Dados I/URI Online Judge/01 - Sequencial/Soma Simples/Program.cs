using System;

namespace Soma_Simples
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());

            int soma = x + y;

            Console.WriteLine("SOMA = {0}", soma);

            Console.ReadKey();
        }
    }
}
