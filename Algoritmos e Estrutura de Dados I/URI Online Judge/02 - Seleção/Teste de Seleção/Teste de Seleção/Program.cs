using System;

namespace Teste_de_Seleção
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, d;

            string[] enter = Console.ReadLine().Split(null);

            a = int.Parse(enter[0]);
            b = int.Parse(enter[1]);
            c = int.Parse(enter[2]);
            d = int.Parse(enter[3]);


            if (((b > c) && (d > a)) && ((c + d) > (a + b)) && (c > 0 && d > 0) && (a % 2 == 0))
            {
                Console.WriteLine("Valores aceitos");
            }
            else
            {
                Console.WriteLine("Valores nao aceitos");
            }

            Console.ReadKey();
        }
    }
}
