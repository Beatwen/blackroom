using System;
using Systeme.Collections.Generic;

Public class Entity
{

    // Attrubuts
    public string Name { get; set; }
    public int Life { get; set; }
    public int Mana { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    // Constructeur
    public Antity(string Name, int Life, int Mana, int Experience, int Level, int PositionX, int PositionY)
    {
        Name = name;
        Life = life;
        Mana = mana;
        Experience = experience;
        Level = level;
        PositionX = positionX;
        PositionY = positionY;
    }

    // Deplacement 
    public void Move(int newX, int newY)
    {
        Console.writeLine($"{Name se déplace à la position ({newX}, {newY}).");
		PositionX = nexX;
		PositionY = newY;
	}

    // Attaque
    public void Attack()
        {
            Console.WriteLine($"{Name} Attaque ! ");
        }


}