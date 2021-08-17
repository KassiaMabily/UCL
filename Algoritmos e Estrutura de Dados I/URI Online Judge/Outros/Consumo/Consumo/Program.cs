using System;
using System.Globalization;

namespace Consumo
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double consumo = x / y;
            Console.WriteLine("{0} km/l", consumo.ToString("F3", CultureInfo.InvariantCulture));
        }
    }
}
