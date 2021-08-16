using System;
using System.Globalization;

namespace Calculo_Simples
{
    public class Produto
    {
        private int codigo, quantidade;
        private double valor;

        // Constructor that takes one argument:
        public Produto(int productCodigo, int productQuantidade, double productValor)
        {
            codigo = productCodigo;
            quantidade = productQuantidade;
            valor = productValor;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public double Valor { get => valor; set => valor = value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] line_1, line_2;
            double soma;

            line_1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            line_2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var produto_1 = new Produto(int.Parse(line_1[0]), int.Parse(line_1[1]), double.Parse(line_1[2].ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture));
            var produto_2 = new Produto(int.Parse(line_2[0]), int.Parse(line_2[1]), double.Parse(line_2[2].ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture));


            soma = (produto_1.Quantidade * produto_1.Valor) + (produto_2.Quantidade * produto_2.Valor);

            Console.WriteLine(String.Format("VALOR A PAGAR: R$ {0:0.00}", soma));

            Console.ReadKey();
        }
    }
}
