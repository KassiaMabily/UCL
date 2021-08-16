using System;

namespace Salario_com_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            string vendedor = Console.ReadLine();
            double salario_fixo = Convert.ToDouble(Console.ReadLine());
            double montante = Convert.ToDouble(Console.ReadLine());

            double total = salario_fixo + (montante * 0.15);

            Console.WriteLine("TOTAL = {0:0.00}", total);

            Console.ReadKey();
        }
    }
}
