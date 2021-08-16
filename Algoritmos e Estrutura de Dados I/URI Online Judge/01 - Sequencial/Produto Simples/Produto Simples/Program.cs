using System;

namespace Produto_Simples
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, prod;

            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            prod = x * y;

            Console.WriteLine("PROD = {0}", prod);
        }
    }
}
