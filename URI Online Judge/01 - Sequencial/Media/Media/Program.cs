using System;
using System.Globalization;

namespace Media
{
    class Program
    {
        static void Main(string[] args)
        {
            double nota_a = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            double nota_b = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            double media = (nota_a * 3.5 + nota_b * 7.5) / (3.5 + 7.5);

            Console.WriteLine("MEDIA = {0:0.00000}", media);

            Console.ReadKey();
        }
    }
}
.