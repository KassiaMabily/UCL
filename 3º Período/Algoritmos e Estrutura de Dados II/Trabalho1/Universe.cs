using System;
using System.Collections.Generic;
using System.IO;

double G = 6.674184 * Math.Pow(10, -11);

class Universe {

    private int numberCelestialBodies;
    private int numberIterations;

    private int time;

    public Universe() {}

    /// <summary>
    /// Lê o arquivo de corpos celestes de inicialização do sistema de acordo com a quantidade máxima de corpos definida no arquivo
    /// </summary>
    /// <returns>Lista de corpos celeste</returns>
    public List<CelestialBody> readCelestialBodies() 
    {
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
            // Se for a primeira linha, pega as informações iniciais de execução
            if( counter == 0 ) {
                string[] data = line.Split(";");

                numberCelestialBodies = int.Parse(data[0]);
                numberIterations = int.Parse(data[1]);
                time = int.Parse(data[1]);
            }

            if( counter > 0 && counter <= numberCelestialBodies ) {
                CelestialBody newCelestialBody = new CelestialBody(line);
                celestialBodies.Add(newCelestialBody);
            }

            counter++;
        }

        return celestialBodies;
    }

    public void saveCelestialBodies(List<CelestialBody> celestialBodies, int i)
    {
        string file = "outputBodies.txt"; 

        FileStream myFile = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);

        string firstLine = String.Format("{0};{1}", celestialBodies.Count, i);
        sw.WriteLine(listaTarefas[i].formatLineCSV());

        for(int i = 0; i < celestialBodies.Count; i++) {
            sw.WriteLine(celestialBodies[i].formatOutputFile());
        }

        sw.Close();
        myFile.Close();

    }

    public double calculateEuclidienneDistance(CelestialBody body1, CelestialBody body2) 
    {
        return Math.Sqrt(Math.Pow((body1.getPosX() - body2.getPosX()), 2) + Math.Pow((body1.getPosY() - body2.getPosY()),2));
    }
    
    public double calculateGravitationalForce(CelestialBody body1, CelestialBody body2) 
    {
        double distanceEuclidienne = calculateEuclidienneDistance(body1, body2);
        double force = G * ((body1.getMass() * body2.getMass()) / Math.Pow(distanceEuclidienne, 2));

        return force;
    }

    public void applyForce(CelestialBody body, double Fx, double Fy) 
    {
        double Ax = Fx / body.getMass();
        double Ay = Fy / body.getMass();

        double Vx = body.getVelX() + (Ax * time);
        double Vy = body.getVely() + (Ay * time);

        double Sx = body.getPosX() + body.getVelX() + ((Ax * Math.Pow(time, 2)) / 2);
        double Sy = body.getPosY() + body.getVely() + ((Ay * Math.Pow(time, 2)) / 2);
        
        body.setPosX(Sx);
        body.setPosY(Sy);
        body.setVelX(Vx);
        body.setVelY(Vy);
    }

    public void ApplyGravityForces(CelestialBody body1, CelestialBody body2) 
    {
        double F = calculateGravitationalForce(body1, body2);

        double r = calculateEuclidienneDistance(body1, body2);
        double rx = Math.Abs(body1.getPosX() - body2.getPosX());
        double ry = Math.Abs(body1.getPosY() - body2.getPosY());

        double Fx = F * Math.Cos(r / rx);
        double Fy = F * Math.Sin(r / ry);

        applyForce(body1, Fx, Fy);
        applyForce(body2, Fx * (-1), Fy * (-1));
    }
    

    public void run() 
    {
        List<CelestialBody> celestialBodies = readCelestialBodies();

        if(celestialBodies.Count > 1) {
            for(int iteration = 0; iteration < numberIterations; iteration++) 
            {
                for (var i = 0; i < celestialBodies.Count; ++i)
                {
                    for (var j = i + 1; j < celestialBodies.Count; ++j)
                    {
                        ApplyGravityForces(celestialBodies[i], celestialBodies[j]);
                    }
                }

                saveCelestialBodies(celestialBodies, i);
            }
        }
    }

}