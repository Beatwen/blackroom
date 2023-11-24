using System;

public class Entity
{
    private int strength;

    // Attributs
    public string Name { get; set; }
    public int Life { get; set; }
    public int Mana { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    // Constructeur
    public Entity(string name, int life, int mana, int experience, int level, int positionX, int positionY)
    {
        Name = name;
        Life = life;
        Mana = mana;
        Experience = experience;
        Level = level;
        PositionX = positionX;
        PositionY = positionY;
    }

    public Entity(string name, int life, int strength, int level, int positionX, int positionY)
    {
        Name=name;
        Life=life;
        this.strength=strength;
        Level=level;
        PositionX=positionX;
        PositionY=positionY;
    }

    // Deplacement
    public void Move(int newX, int newY)
    {
        Console.WriteLine($"{Name} se déplace à la position ({newX}, {newY}).");
        PositionX = newX;
        PositionY = newY;
    }

    // Attaque
    public void Attack()
    {
        Console.WriteLine($"{Name} attaque !");
    }
}
