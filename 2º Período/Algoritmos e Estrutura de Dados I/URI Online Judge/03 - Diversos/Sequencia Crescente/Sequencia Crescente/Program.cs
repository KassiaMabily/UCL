using System;

namespace Sequencia_Crescente
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isZero = false;
            while (isZero == false)
            {
                string entered = Console.ReadLine();
                if (entered.Equals("0")){
                    isZero = true;
                }

                int x = Convert.ToInt32(entered);
                for(int i = 1; i <= x; i++)
                {
                    Console.Write(i);
                    if(i < x)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\n");
                    }
                }
            }

            isZero = true;
            // Console.ReadKey();
        }
    }
}
