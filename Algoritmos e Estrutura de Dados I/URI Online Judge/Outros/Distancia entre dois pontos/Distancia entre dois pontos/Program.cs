using System;
using System.Globalization;

namespace Distancia_entre_dois_pontos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entered_1 = Console.ReadLine().Split(null);
            string[] entered_2 = Console.ReadLine().Split(null);

            double x1 = double.Parse(entered_1[0], CultureInfo.InvariantCulture);
            double y1 = double.Parse(entered_1[1], CultureInfo.InvariantCulture);

            double x2 = double.Parse(entered_2[0], CultureInfo.InvariantCulture);
            double y2 = double.Parse(entered_2[1], CultureInfo.InvariantCulture);

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));

            Console.WriteLine(distance.ToString("F4", CultureInfo.InvariantCulture));
        }
    }
}
