using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : Entity
{
    [SerializedObject] public MainGrid grid;
    public float x;
    public float y;
    public float z;

    public Inventory PlayerInventory { get; set; }
    


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
    public void nepasmarcherla()
    {
        List<Room> rooms = grid.rooms;
        foreach (var room in rooms)
        {
            _ = (room.coordinate);
        }
    }
    public void CastSpell(Spell spell)
    {
        Console.WriteLine($"{Name} is casting {spell.Name}.");
        // V�rifier si assez de mana
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


    // Gagner de l'exp�rience
    public void GainExperience(int experiencePoints)
    {
        Console.WriteLine($"{Name} gagne {experiencePoints} points d'exp�rience !");
    }
    public Transform GetPlayerLocation()
    {
        return transform;
    }

    protected override void Start()
    {
        base.Start();

        Vector3 startPosition = grid.SpawnPlayer();
        x = startPosition.x;
        y = startPosition.y;
        z = startPosition.z;
        transform.position = new Vector3( x, y, z );

    }

    public bool CheckPlayerNeighbourCell(int x, int y)
    {
        return !grid.CheckNeighbourCell(x, y);
    }
    public virtual void Move()
    {
        int newX = (int)x;
        int newY = (int)y;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newY += 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && y > 0)
        {
            newY -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && x < 8)
        {
            newX += 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && x > 0)
        {
            newX -= 1;
        }

        if (CheckPlayerNeighbourCell(newX, newY))
        {
            transform.position = new Vector3(newX, newY, z);
            x = newX;
            y = newY;
        }

    }

    protected override void Update()
    {
        base.Update();
        Move();
    }


}
