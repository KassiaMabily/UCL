using System;
using System.Linq;

namespace MaiorDe4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[4];
            for(int counter = 0; counter < 4; counter++)
            {
                numbers[counter] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Format("Maior numero eh: {0}", numbers.Max()));
        }
    }
}
