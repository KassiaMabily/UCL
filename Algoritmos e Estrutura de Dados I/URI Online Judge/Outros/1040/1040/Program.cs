using System;
using System.Globalization;

namespace _1040
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entered = Console.ReadLine().Split(null);

            float n1 = float.Parse(entered[0], CultureInfo.InvariantCulture);
            float n2 = float.Parse(entered[1], CultureInfo.InvariantCulture);
            float n3 = float.Parse(entered[2], CultureInfo.InvariantCulture);
            float n4 = float.Parse(entered[3], CultureInfo.InvariantCulture);

            float media = ((n1 * 2) + (n2 * 3) + (n3 * 4) + (n4 * 1)) / 10;

            if (media >= 7.0)
            {
                Console.WriteLine("Media: " + Math.Round(media, 1).ToString("F1", CultureInfo.InvariantCulture));
                Console.WriteLine("Aluno aprovado.");
            }
            else if (media >= 5.0 && media <= 6.9)
            {
                float exame = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Media: " + Math.Round(media, 1).ToString("F1", CultureInfo.InvariantCulture));
                Console.WriteLine("Aluno em exame.");

                Console.WriteLine("Nota do exame: " + Math.Round(exame, 1).ToString("F1", CultureInfo.InvariantCulture));
                media = (media + exame) / 2;
                if (media >= 5.0)
                {
                    Console.WriteLine("Aluno aprovado.");
                }
                else
                {
                    Console.WriteLine("Aluno reprovado.");
                }

                Console.WriteLine("Media final: " + Math.Round(media, 1).ToString("F1", CultureInfo.InvariantCulture));
            }
            else if (media < 5.0)
            {
                Console.WriteLine("Media: " + Math.Round(media, 1).ToString("F1", CultureInfo.InvariantCulture));
                Console.WriteLine("Aluno reprovado.");
            }
        }
    }
}
