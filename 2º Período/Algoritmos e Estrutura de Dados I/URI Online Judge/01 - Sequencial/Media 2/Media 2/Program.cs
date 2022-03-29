using System;
using System.Globalization;

namespace Media_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double nota_a = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            double nota_b = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            double nota_c = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            double media = ((nota_a * 2) + (nota_b * 3) + (nota_c * 5)) / (2 + 3 + 5);

            Console.WriteLine("MEDIA = {0:0.0}", media);

            Console.ReadKey();
        }
    }
}
