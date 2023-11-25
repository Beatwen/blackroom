using System;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public MainGrid grid;
    // Constructeur
    public string Name { get; set; }
    public int Life { get; set; }
    public int Level { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int Strength { get; set; }

    // Constructor
    public Monsters(string name, int life, int level, int positionX, int positionY, int strength)
    {
        Name = name;
        Life = life;
        Level = level;
        PositionX = positionX;
        PositionY = positionY;
        Strength = strength;
    }

    // Donner de l'expérience
    public void GiveExperience(int experiencePoints)
    {
        Console.WriteLine($"{Name} gives {experiencePoints} experience points.");
        // Ajoutez le code pour donner de l'expérience selon vos besoins
    }

    // Donner un objet
    public void GiveItem(string item)
    {
        Console.WriteLine($"{Name} gives {item}.");
        // Ajoutez le code pour donner un objet selon vos besoins
    }
    void Start()
    {
        transform.position = grid.SpawnBoss(grid.startRoom);
        Debug.Log($"La position du boss est {transform.position}");

    }
}