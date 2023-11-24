using System;
using System.Collections.Generic;

public class Spell
{
    // Attrubuts
    public string Name { get; set; }
    public int ManaCost { get; set; }

    // Constructeur
    public Spell(string name, int manaCost)
    {
        Name = name;
        ManaCost = manaCost;
    }

    // Lancer un sort
    public void Cast()
    {
        Console.WriteLine($"{Name} utilise  (Mana Cost: {ManaCost}).");
    }
}