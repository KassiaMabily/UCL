using System;


class CelestialBody {
    private string name;

    private float posX;
    private float posY;
    private float mass;
    private float radius;
    private float velX;
    private float velY;


    public CelestialBody(string n, float x, float y, float m, float r, float vx, float vy) {
        name = n;
        posX = x;
        posY = y;
        mass = m;
        radius = r;
        velX = vx;
        velY = vy;
    }

    public CelestialBody(string line) {
        string[] data = line.Split(";");

        name = float.Parse(data[0]);
        mass = float.Parse(data[1]);
        radius = float.Parse(data[2]);
        posX = float.Parse(data[3]);
        posY = float.Parse(data[4]);
        velX = float.Parse(data[5]);
        velY = float.Parse(data[6]);
    }

    public float getMass() {
        return mass;
    }

    public float getPosX() {
        return posX;
    }

    public float getPosY() {
        return posY;
    }

    public void print() {
        Console.WriteLine(string.Format("Posição X: {0}\nPosição Y: {1}\nMassa: {2}", posX, posY, mass));
    }
    
}