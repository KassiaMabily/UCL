using System;
using System.Globalization;

namespace _1038
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entered = Console.ReadLine().Split(null);
            int codigo = int.Parse(entered[0]);
            int quantidade = int.Parse(entered[1]);

            double total = 0.0;

            switch (codigo)
            {
                case 1:
                    total = quantidade * 4.00;
                    break;
                case 2:
                    total = quantidade * 4.50;
                    break;
                case 3:
                    total = quantidade * 5.00;
                    break;
                case 4:
                    total = quantidade * 2.00;
                    break;
                case 5:
                    total = quantidade * 1.50;
                    break;
                default:
                    total = 0;
                    break;
            }

            Console.WriteLine("Total: R$ {0:0.00}", total.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
