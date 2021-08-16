using System;

namespace Salario
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero = Convert.ToInt32(Console.ReadLine());
            int horas_trabalhadas = Convert.ToInt32(Console.ReadLine());
            double valor_hora = Convert.ToDouble(Console.ReadLine());

            double salario = horas_trabalhadas * valor_hora;

            Console.WriteLine("NUMBER = {0}", numero);
            Console.WriteLine("SALARY = U$ {0:0.00}", salario);

            Console.ReadKey();
        }
    }
}
