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


    // Attributs
    public Inventory PlayerInventory { get; set; }

    // Constructeur
    public Player(string name, int life, int strength, int level, int positionX, int positionY, int mana, Inventory inventory)
        : base(name, life, strength, level, positionX=0, positionY=0)
    {
        Mana = mana;
        PlayerInventory = inventory;
    }

    public Player(string name, int life, int strength, int level, int v1, int v2) : base(name, life, strength, level, v1, v2)
    {
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
    public void nepasmarcherla()
    {
        List<Room> rooms = grid.rooms;
        foreach (var room in rooms)
        {
            (float x, float y) coordonneesDeMaPremierePiece = (room.coordinate);
        }
    }
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
    public Transform GetPlayerLocation()
    {
        return transform;
    }

    void Start()
    {
        
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

     void Update()
    {
        Move();
    }


}
