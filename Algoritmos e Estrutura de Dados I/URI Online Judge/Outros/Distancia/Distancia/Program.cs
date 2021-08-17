using System;

namespace Distancia
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());

            int tempo = (60 * x) / 30;

            Console.WriteLine(tempo.ToString() + " minutos");
        }
    }
}
