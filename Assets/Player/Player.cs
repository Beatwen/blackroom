using System;
using System.Collections.Generic;

public class Player : Entity
{
    // Attributs
    public Inventory PlayerInventory { get; set; }

    // Constructeur
    public Player(string name, int life, int strength, int level, int positionX, int positionY, int mana, Inventory inventory)
        : base(name, life, strength, level, positionX=0, positionY=0)
    {
        Mana = mana;
        PlayerInventory = inventory;
    }

    // Ramasser un objet
    public void PickUpItem(string item)
    {
        Console.WriteLine($"{Name} ramasse {item} et le range dans l'inventaire !");
        PlayerInventory.Items.Add(item);
    }

    // Utiliser un objet
    public void UseItem(string item)
    {
        Console.WriteLine($"{Name} utilise {item} !");
    }

    // Utiliser un sort
    public void CastSpell(Spell spell)
    {
        Console.WriteLine($"{Name} is casting {spell.Name}.");
        // Vérifier si assez de mana
        if (Mana >= spell.ManaCost)
        {
            spell.Cast();
            Mana -= spell.ManaCost;
        }
        else
        {
            Console.WriteLine($"Vous n'avez pas assez de mana pour {spell.Name}.");
        }
    }

    // Gagner de l'expérience
    public void GainExperience(int experiencePoints)
    {
        Console.WriteLine($"{Name} gagne {experiencePoints} points d'expérience !");
    }
}
