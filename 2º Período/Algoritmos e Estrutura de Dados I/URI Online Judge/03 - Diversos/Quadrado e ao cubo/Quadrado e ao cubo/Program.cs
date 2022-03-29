using System;

namespace Quadrado_e_ao_cubo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n_linhas = Convert.ToInt32(Console.ReadLine());

            for(int i = 1; i < (n_linhas + 1); i++)
            {
                Console.WriteLine("{0} {1} {2}", i, i * i, i * i * i);
            }

            Console.ReadKey();
        }
    }
}
