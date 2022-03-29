using System;

namespace Verificador_de_Matrícula
{
    class Program
    {
        static void Main(string[] args)
        { 
            string matricula = "";
            int soma, resto, digito, multiplicador;
            
            soma = 0;
            for(int i = 0; i < 8; i++)
            {
                Console.WriteLine("Digite o elemento {0}", i + 1);
                digito = int.Parse(Console.ReadLine());
                matricula += digito.ToString();
                
                
                if((i + 1) == 1 || (i + 1) == 5) {
                    multiplicador = 2;
                }
                else if((i + 1) == 2 || (i + 1) == 4)
                {
                    multiplicador = 3;
                }
                else if ((i + 1) == 3)
                {
                    multiplicador = 4;
                }
                else
                {
                    multiplicador = 1;
                }

                soma += (digito * multiplicador);
            }

            resto = soma % 10;

            Console.WriteLine(resto);

            Console.WriteLine("Matricula é: {0}", matricula + "-" + resto.ToString());

            Console.ReadKey();
        }
    }
}
