// implemente um programa que identifica se
// um número de CPF informado pelo usuário é
// ou não válido.

using System;

namespace Validador_de_CPF
{
    class Program
    {
        static void Main(string[] args)
        {
            int soma, resto, digito_1, digito_2;
            string cpf, entered, digito;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Console.WriteLine("Digite o CPF");
            // cpf = Console.ReadLine();

            entered = "111.444.777-35";
            entered = entered.Trim().Replace(".", "").Replace("-", "");

            soma = 0;
            cpf = "";
            for (int i = 8; i > 0; i--)
            {
                cpf += entered[i].ToString();
                soma += int.Parse(cpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;
            if (resto < 2)
                digito_1 = 0;
            else
                digito_1 = 11 - resto;

            digito = digito_1.ToString();
            soma = 0;
            cpf += digito_1;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicador2[i];
            }


            resto = soma % 11;
            if (resto < 2)
                digito_2 = 0;
            else
                digito_2 = 11 - resto;

            digito += digito_2.ToString();
            if (entered.EndsWith(digito))
                Console.WriteLine("É válido");
            else
                Console.WriteLine("Não é válido");




        }
    }
}
