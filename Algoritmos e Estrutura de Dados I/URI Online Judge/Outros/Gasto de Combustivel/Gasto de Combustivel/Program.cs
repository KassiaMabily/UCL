using System;
using System.Globalization;

namespace Gasto_de_Combustivel
{
    class Program
    {
        static void Main(string[] args)
        {
            int duracao = int.Parse(Console.ReadLine());
            int velocidade = int.Parse(Console.ReadLine());

            double gasto = (velocidade * duracao) / 12.0;

            Console.WriteLine(gasto.ToString("F3", CultureInfo.InvariantCulture));
        }
    }
}
