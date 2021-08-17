using System;

namespace Fatorial
{
    class Program
    {
        static int Fatorial(int n)
        {
            if (n == 1)
            {
                return n;
            }
            else
            {
                return n * Fatorial(n - 1);
            }
        }
        static void Main(string[] args)
        {
            int x = Convert.ToInt32(Console.ReadLine());
            if(0 < x && x < 13)
            {
                Console.WriteLine(Fatorial(x));
            }
            
        }
    }
}
