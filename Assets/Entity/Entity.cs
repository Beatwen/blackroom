using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private int strength;
    private int v1;
    private int v2;

    // Attributs
    public string Name { get; set; }
    public int Life { get; set; }
    public int Mana { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    // public int Strength { get; set; }

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

    public Entity(string name, int life, int strength, int level, int v1, int v2)
    {
        this.name = name;
        Life = life;
        this.strength = strength;
        Level = level;
        this.v1 = v1;
        this.v2 = v2;
    }
    public void Attack()
        {
            Console.WriteLine($"{Name} Attaque ! ");
        }


    }
