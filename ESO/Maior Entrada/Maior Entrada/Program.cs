// Implemente um programa que recebe 3
// números do usuário e informa o maior deles

using System;

namespace Maior_Entrada
{
    class Program
    {
        static void Main(string[] args)
        {
            int number_1, number_2, number_3, max;

            Console.WriteLine("Entre com o primeiro número >>");
            number_1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Entre com o segundo número >>");
            number_2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Entre com o terceiro número >>");
            number_3 = Convert.ToInt32(Console.ReadLine());

            max = number_1 - ((number_1 - number_2) & ((number_1 - number_2) >> 31));
            max = max - ((max - number_3) & ((max - number_3) >> 31));


            Console.WriteLine("O maior valor é: {0:g}", max);

            Console.ReadKey();
        }
    }
}
