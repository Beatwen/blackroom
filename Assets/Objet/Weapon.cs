using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Objet
{
    public int Damage { get; set; }

    public Weapon(string name, int damage) : base(name)
    {
        Damage = damage;
    }

    public override void Interact(Player player)
    {
        // Logique pour ajouter l'arme à l'inventaire du joueur
        Console.WriteLine($"{player.Name} a trouvé l'arme {Name} avec {Damage} de dégâts!");
    }
}

