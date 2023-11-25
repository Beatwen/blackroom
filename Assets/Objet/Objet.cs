using System;
using System.Numerics;

public abstract class Objet
{
    public string Name { get; set; }

    public Objet(string name)
    {
        Name = name;
    }

    // Méthode abstraite pour interagir avec l'objet
    public abstract void Interact(Player player);
}

public class XP : Objet
{
    public int ExperiencePoints { get; set; }

    public XP(string name, int experiencePoints) : base(name)
    {
        ExperiencePoints = experiencePoints;
    }

    public override void Interact(Player player)
    {
        player.GainExperience(ExperiencePoints);
        Console.WriteLine($"{player.Name} a gagné {ExperiencePoints} points d'expérience!");
    }
}

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
