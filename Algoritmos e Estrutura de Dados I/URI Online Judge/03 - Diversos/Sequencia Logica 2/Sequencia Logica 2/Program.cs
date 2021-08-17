using System;

namespace Sequencia_Logica_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entered = Console.ReadLine().Split(null);
            int x = Convert.ToInt32(entered[0]);
            int y = Convert.ToInt32(entered[1]);

            if ((1 < x && x < 20) && (x < y && y < 100000))
            {
                for (int i = 1; i <= y; i++)
                {
                    Console.Write(i);
                    if(i % x == 0)
                    {
                        Console.Write("\n");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
                
        }
    }
}
