using System;
using System.Globalization;

namespace Baskara
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entered = Console.ReadLine().Split(null);
            double a = double.Parse(entered[0], CultureInfo.InvariantCulture);
            double b = double.Parse(entered[1], CultureInfo.InvariantCulture);
            double c = double.Parse(entered[2], CultureInfo.InvariantCulture);

            if(a != 0.0)
            {
                double delta = (b * b) - (4 * a * c);
                if(delta > 0)
                {
                    double x1 = ((b * (-1)) + Math.Sqrt(delta)) / (2 * a);
                    double x2 = ((b * (-1)) - Math.Sqrt(delta)) / (2 * a);

                    Console.WriteLine("R1 = " + x1.ToString("F5", CultureInfo.InvariantCulture));
                    Console.WriteLine("R2 = " + x2.ToString("F5", CultureInfo.InvariantCulture));
                }
                else
                {
                    Console.WriteLine("Impossivel calcular");
                }
            }
            else
            {
                Console.WriteLine("Impossivel calcular");
            }
        }
    }
}
