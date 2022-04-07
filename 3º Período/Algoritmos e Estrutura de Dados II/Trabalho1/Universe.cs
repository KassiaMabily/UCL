using System;

float G = 6.674184 * Math.Pow(10, -11);

class Universe {

    private int numberCelestialBodies;
    private int numberIterations;

    /// <summary>
    /// Lê o arquivo de corpos celestes de inicialização do sistema de acordo com a quantidade máxima de corpos definida no arquivo
    /// </summary>
    /// <returns>Lista de corpos celeste</returns>
    public List<CelestialBody> readCelestialBodies() {
        List<CelestialBody> celestialBodies = new List<CelestialBody>();
        string file = "inputBodies.txt";  

        // Verifica se o arquivo não existe, se não existir retorna uma quantidade vazia de corpos
        if (!File.Exists(file)) { 
            Console.WriteLine(String.Format("Arquivo {0} não existe", file)); 
            return celestialBodies;
        }  

        string[] lines = File.ReadAllLines(file);  
        int counter = 0;
        foreach (var line in lines)
        {   
            // Se for a primeira linha, pega as informações iniciais
            if( counter == 0 ) {
                string[] data = line.Split(";");

                numberCelestialBodies = int.Parse(data[0]);
                numberCelestialBodies = int.Parse(data[1]);
            }

            if( counter > 0 && counter <= numberCelestialBodies ) {
                CelestialBody newCelestialBody = new CelestialBody(line);
                celestialBodies.Add(newCelestialBody);
            }

            counter++;
        }

        return celestialBodies;
    }

    
    public calculateGravitationalForce(CelestialBody body1, CelestialBody body2) {
        var distanceEuclidienne = Math.Sqrt(Math.Pow((body1.getPosX() - body2.getPosX()), 2) + Math.Pow((body1.getPosY() - body2.getPosY()),2));
        var force = G * ((body1.getMass() * body2.getMass()) / Math.Pow(((byte)distanceEuclidienne), 2));

        
    }

}