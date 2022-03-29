using System;
using System.Globalization;

namespace Aumento_de_salário
{
    class Program
    {
        static void Main(string[] args)
        {
            double percentual;
            double salario = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            if (salario <= 400)
            {
                percentual = 0.15;
            }
            else if (salario > 400 && salario <= 800)
            {
                percentual = 0.12;
            }
            else if(salario > 800 && salario <= 1200) 
            {
                percentual = 0.10;
            }
            else if(salario > 1200 && salario <= 2000)
            {
                percentual = 0.07;
            }
            else
            {
                percentual = 0.04;
            }

            double novo_salario = salario * (percentual + 1.00);
            double aumento = novo_salario - salario;

            Console.WriteLine("Novo salario: {0:0.00}", novo_salario);
            Console.WriteLine("Reajuste ganho: {0:0.00}", aumento);
            Console.WriteLine("Em percentual: {0} %", Math.Round(percentual * 100));

            Console.ReadKey();
        }
    }
}
