using System;

namespace Simulado
{
    class Program
    {
        static void Main(string[] args)
        {
            Aeronave B747 = new Aeronave("Boeing 747-8", 1000, 0.8f,5,480, 200);
            Aeronave A380 = new Aeronave("Airbus A380", 1500, 0f, 3, 600, 300);

            Console.WriteLine(B747.PrintAeronave());
            Console.WriteLine(A380.PrintAeronave());
            B747.TransferirCombustivel(A380);
            Console.WriteLine("Aeronaves Atualizadas!\n");        
            Console.WriteLine(B747.PrintAeronave());
            Console.WriteLine(A380.PrintAeronave());        
            
            A380.Voar(20);
            Console.WriteLine(A380.PrintAeronave()); 

        }
    }
}
