using System;
using Systeme.Collections.Generic;

public class Player : Entity
{

    // Attrubuts
    public int Mana { get; set; }
    public Inventory PlayerInvetory { get; set; }

    // Constructeur
    public Player(string Name, int Life, int Strength int Level, int PositionX, int PositionY, int Mana, Inventory inventory)
        : base(name, life, level, positionX, positionY)
    {
        Mana = mana;
        PlayerIventory = inventory;
    }

    // Ramasser un objet
    public void PickUpItem(string item)
    {
        Console.WriteLine($"{Name} Ramasse {Item} et le range dans l'inventaire !")
        Player.Iventory.Item.Add(item);
    }

    // Utiliser un objet
    public void UseItem(string item)
    {
        Console.WriteLine($"{Name} utilise {Item}!")
    }

    // Utiliser un sort
    public void CastSpell(Spell spell)
    {
        Console.WriteLine($"{Name} is casting {spell.Name}.");
        // Verifier si assez de mana
        if (Mana >= spell.ManaCost)
        {
            spell.Cast();
            Mana -= spell.ManaCost;
        }
        else
        {
            Console.WriteLine($"Vous n'avez pas assez de mana {spell.Name}.");
        }
    }

    // Gagner de l'expérience
    public void GainExperience(int experiencePoints)
    {
        Console.WriteLine($"{Name} gagne {experiencePoints} point d'expérience !");
    }

}