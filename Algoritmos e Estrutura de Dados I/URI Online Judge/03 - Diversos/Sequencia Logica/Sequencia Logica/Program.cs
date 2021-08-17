using System;

namespace Sequencia_Logica
{
    class Program
    {
        static void Main(string[] args)
        {
            int n_linhas = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i < (n_linhas + 1); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("{0} {1} {2}", i, (i * i) + j, (i * i * i) + j);
                }
                    
            }

            Console.ReadKey();
        }
    }
}
