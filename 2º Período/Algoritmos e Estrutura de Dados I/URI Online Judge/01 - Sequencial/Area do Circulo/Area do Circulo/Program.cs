using System;

namespace Area_do_Circulo
{
    class Program
    {
        static void Main(string[] args)
        {
            double pi = 3.14159;

            double raio = Convert.ToDouble(Console.ReadLine());

            double area = pi * (raio * raio);

            Console.WriteLine("A={0:0.0000}", area);
        }
    }
}
