using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
