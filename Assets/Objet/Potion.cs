using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Objet
{
    public int HealthRestore { get; set; }

    public Potion(string name, int healthRestore) : base(name)
    {
        HealthRestore = healthRestore;
    }

    public override void Interact(Player player)
    {
        // Logique pour utiliser la potion
        Console.WriteLine($"{player.Name} a utilisé la potion {Name} et a restauré {HealthRestore} points de vie!");
    }
}
