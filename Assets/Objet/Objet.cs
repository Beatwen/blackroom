using System;
using System.Numerics;
using UnityEngine;

public abstract class Objet : MonoBehaviour
{
    public string Name { get; set; }

    public Objet(string name)
    {
        Name = name;
    }

    // Méthode abstraite pour interagir avec l'objet
    public abstract void Interact(Player player);
}





