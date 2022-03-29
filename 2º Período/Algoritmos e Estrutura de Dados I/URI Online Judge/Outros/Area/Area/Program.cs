using System;
using System.Globalization;

namespace Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double triangulo, circulo, trapezio, quadrado, retangulo;

            string[] entered = Console.ReadLine().Split(null);

            double a = double.Parse(entered[0], CultureInfo.InvariantCulture);
            double b = double.Parse(entered[1], CultureInfo.InvariantCulture);
            double c = double.Parse(entered[2], CultureInfo.InvariantCulture);

            triangulo = (a * c) / 2;
            circulo = 3.14159 * Math.Pow(c, 2.0);
            trapezio = ((a + b) * c) / 2;
            quadrado = b * b;
            retangulo = a * b;

            Console.WriteLine("TRIANGULO: " + triangulo.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("CIRCULO: " + circulo.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("TRAPEZIO: " + trapezio.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("QUADRADO: " + quadrado.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("RETANGULO: " + retangulo.ToString("F3", CultureInfo.InvariantCulture));
        }
    }
}
