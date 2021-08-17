using System;

namespace Animal
{
    class Program
    {
        static void Main(string[] args)
        {
            string resposta = "";
            string x = Console.ReadLine().ToLower();
            string y = Console.ReadLine().ToLower();
            string z = Console.ReadLine().ToLower();

            if(x == "vertebrado")
            {
                if(y == "ave")
                {
                    if(z == "carnivoro")
                    {
                        resposta = "aguia";
                    }else if(z == "onivoro")
                    {
                        resposta = "pomba";
                    }
                }else if(y == "mamifero")
                {
                    if (z == "herbivoro")
                    {
                        resposta = "vaca";
                    }
                    else if (z == "onivoro")
                    {
                        resposta = "homem";
                    }
                }
            }
            else if(x == "invertebrado")
            {
                if (y == "inseto")
                {
                    if (z == "hematofago")
                    {
                        resposta = "pulga";
                    }
                    else if (z == "herbivoro")
                    {
                        resposta = "lagarta";
                    }
                }
                else if (y == "anelideo")
                {
                    if (z == "hematofago")
                    {
                        resposta = "sanguessuga";
                    }
                    else if (z == "onivoro")
                    {
                        resposta = "minhoca";
                    }
                }
            }

            Console.WriteLine("{0}", resposta);
            Console.ReadKey();
        }
    }
}
