using System;

namespace Conversao_de_tempo
{
    class Program
    {
        static void Main(string[] args)
        {
            int segundos = int.Parse(Console.ReadLine());

            int h = segundos / 3600;
            segundos = segundos - h * 3600;
            int m = segundos / 60;
            segundos = segundos - m * 60;
            int s = segundos;

            Console.WriteLine("{0}:{1}:{2}", h, m, s);
        }
    }
}
