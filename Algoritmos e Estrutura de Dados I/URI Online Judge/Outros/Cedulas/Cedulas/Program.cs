using System;

namespace Cedulas
{
    class Program
    {
        static void Main(string[] args)
        {
            int troco, cem, cinquenta, vinte, dez, cinco, dois, um = 0;
            int valor = int.Parse(Console.ReadLine());

            cem = valor / 100;
            troco = valor % 100;

            cinquenta = troco / 50;
            troco = troco % 50;

            vinte = troco / 20;
            troco = troco % 20;

            dez = troco / 10;
            troco = troco % 10;

            cinco = troco / 5;
            troco = troco % 5;

            dois = troco / 2;
            troco = troco % 2;

            um = troco / 1;

            Console.WriteLine(valor);
            Console.WriteLine("{0} nota(s) de R$ 100,00", cem);
            Console.WriteLine("{0} nota(s) de R$ 50,00", cinquenta);
            Console.WriteLine("{0} nota(s) de R$ 20,00", vinte);
            Console.WriteLine("{0} nota(s) de R$ 10,00", dez);
            Console.WriteLine("{0} nota(s) de R$ 5,00", cinco);
            Console.WriteLine("{0} nota(s) de R$ 2,00", dois);
            Console.WriteLine("{0} nota(s) de R$ 1,00", um);

        }
    }
}
