using System;


class CelestialBody {
    private float posX;
    private float posY;
    private float mass;

    public CelestialBody(float x, float y, float m) {
        posX = x;
        posY = y;
        mass = m;
    }

    public CelestialBody(string line) {
        string[] data = line.Split(";");

        posX = float.Parse(data[0]);
        posY = float.Parse(data[1]);
        mass = float.Parse(data[2]);
    }

    public void print() {
        Console.WriteLine(string.Format("Posição X: {0}\nPosição Y: {1}\nMassa: {2}", posX, posY, mass));
    }
    
}