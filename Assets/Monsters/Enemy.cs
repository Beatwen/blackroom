using System;
using System.Collections.Generic;

{
    public MainGrid grid;
    // Constructeur
    public Monster(string name, int life, int level, int positionX, int positionY, int strength)
        : base(name, life, level, positionX, positionY, strength)
    {

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
    public Start()
    {
    transform.position = grid.SpawnBoss();
    }
}