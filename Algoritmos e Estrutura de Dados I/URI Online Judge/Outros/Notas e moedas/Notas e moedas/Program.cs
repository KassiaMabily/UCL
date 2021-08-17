using System;
using System.Globalization;

namespace Notas_e_moedas
{
    class Program
    {
        static void Main(string[] args)
        {
            int cem, cinquenta, vinte, dez, cinco, dois, um, m_cinquenta, m_vintecinco, m_dez, m_cinco, m_um = 0;
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double troco = valor;

            cem = (int)(valor / 100);
            troco = valor % 100;

            cinquenta = (int)(troco / 50);
            troco = troco % 50;

            vinte = (int)(troco / 20);
            troco = troco % 20;

            dez = (int)(troco / 10);
            troco = troco % 10;

            cinco = (int)(troco / 5);
            troco = troco % 5;

            dois = (int)(troco / 2);
            troco = troco % 2;

            um = (int)(troco / 1);
            troco = troco % 1;

            m_cinquenta = (int)(troco / 0.5);
            troco = troco % 0.50;

            m_vintecinco = (int)(troco / 0.25);
            troco = troco % 0.25;

            m_dez = (int)(troco / 0.10);
            troco = troco % 0.10;

            m_cinco = (int)(troco / 0.05);
            troco = Math.Round(troco % 0.05, 2);

            m_um = (int)(troco / 0.01);
            troco = troco % 0.01;

            Console.WriteLine("NOTAS:");
            Console.WriteLine("{0} nota(s) de R$ 100.00", Convert.ToInt32(cem));
            Console.WriteLine("{0} nota(s) de R$ 50.00", Convert.ToInt32(cinquenta));
            Console.WriteLine("{0} nota(s) de R$ 20.00", Convert.ToInt32(vinte));
            Console.WriteLine("{0} nota(s) de R$ 10.00", Convert.ToInt32(dez));
            Console.WriteLine("{0} nota(s) de R$ 5.00", Convert.ToInt32(cinco));
            Console.WriteLine("{0} nota(s) de R$ 2.00", Convert.ToInt32(dois));
            Console.WriteLine("MOEDAS:");
            Console.WriteLine("{0} moeda(s) de R$ 1.00", Convert.ToInt32(um));
            Console.WriteLine("{0} moeda(s) de R$ 0.50", Convert.ToInt32(m_cinquenta));
            Console.WriteLine("{0} moeda(s) de R$ 0.25", Convert.ToInt32(m_vintecinco));
            Console.WriteLine("{0} moeda(s) de R$ 0.10", Convert.ToInt32(m_dez));
            Console.WriteLine("{0} moeda(s) de R$ 0.05", Convert.ToInt32(m_cinco));
            Console.WriteLine("{0} moeda(s) de R$ 0.01", Convert.ToInt32(m_um));
        }
    }
}
