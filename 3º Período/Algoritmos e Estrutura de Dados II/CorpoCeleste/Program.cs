using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace CorpoCeleste
{
    class Program
    {

        /// <summary>
        /// Lê o arquivo de corpos celestes de inicialização do sistema de acordo com a quantidade máxima de corpos definida no arquivo
        /// </summary>
        /// <returns>Lista de corpos celeste</returns>
        static public List<CelestialBody> readCelestialBodies() {
            List<CelestialBody> celestialBodies = new List<CelestialBody>();
            string file = "corpos.txt";  
            int numberCelestialBodies = 0;

            if (!File.Exists(file)) { 
                Console.WriteLine(String.Format("Arquivo {0} não existe", file)); 
                return celestialBodies;
            }  

            string[] lines = File.ReadAllLines(file);  
            int counter = 0;
            foreach (var line in lines)
            {
                if( counter == 0 ) numberCelestialBodies = int.Parse(line);

                if( counter > 0 && counter <= numberCelestialBodies ) {
                    CelestialBody newCelestialBody = new CelestialBody(line);
                    celestialBodies.Add(newCelestialBody);
                }

                counter++;
            }

            return celestialBodies;
        }

        static void Main(string[] args)
        {
            List<CelestialBody> celestialBodies = readCelestialBodies();

            foreach (var celestialBody in celestialBodies)
            {
                celestialBody.print();
            }
        }
    }
}
