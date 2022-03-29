using System;

namespace MaiorAB
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entered = Console.ReadLine().Split(null);

            int a = int.Parse(entered[0]);
            int b = int.Parse(entered[1]);
            int c = int.Parse(entered[2]);

            int maior = (a + b + Math.Abs(a - b)) / 2;
            maior = (maior + c + Math.Abs(maior - c)) / 2;

            Console.WriteLine("{0} eh o maior", maior);
        }
    }
}
