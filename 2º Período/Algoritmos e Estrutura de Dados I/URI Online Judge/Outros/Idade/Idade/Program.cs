using System;

namespace Idade
{
    class Program
    {
        static void Main(string[] args)
        {
            int idade = int.Parse(Console.ReadLine());

            int a = idade / 365;
            idade = idade - a * 365;
            int m = idade / 30;
            idade = idade - m * 30;
            int d = idade;

            Console.WriteLine("{0} ano(s)", a);
            Console.WriteLine("{0} mes(es)", m);
            Console.WriteLine("{0} dia(s)", d);
        }
    }
}
