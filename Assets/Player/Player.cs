using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

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


    public void SetGridReference(MainGrid gridReference)
    {
        grid = gridReference;
    }
    public void GainExperience(int experiencePoints)
    {
        Console.WriteLine($"{Name} gagne {experiencePoints} points d'expérience !");
    }
    public Transform GetPlayerLocation()
    {
        return transform;
    }

    protected override void Start()
    {
        base.Start();

        if (File.Exists("GridState.json"))
        {

            grid.LoadGridState();
            if (grid.player.transform.position != null)
            {
                transform.position = grid.player.transform.position;
            }
            else
            {
                transform.position = new Vector3(x, y, z);
            }
        }
        else
        {
            Vector3 startPosition = grid.SpawnPlayer();
            x = startPosition.x;
            y = startPosition.y;
            z = startPosition.z;
        }
    }

    public bool CheckPlayerNeighbourCell(int x, int y)
    {
        return !grid.CheckNeighbourCell(x, y);
    }
    public virtual void Move()
    {
        int newX = (int)x;
        int newY = (int)y;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            newY += 1;
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && y > 0)
        {
            newY -= 1;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && x < 8)
        {
            newX += 1;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && x > 0)
        {
            newX -= 1;
        }

        if (CheckPlayerNeighbourCell(newX, newY))
        {
            transform.position = new Vector3(newX, newY, z);
            x = newX;
            y = newY;

            if (grid.rooms.Any(room => room.coordinate == (newX, newY) && room.RoomCat == "FightRoom"))
            {
                Room r = grid.rooms.Find(room => room.coordinate == (newX, newY) && room.RoomCat == "FightRoom");
                r.RoomCat = "Defeated";
                grid.SaveGridState();
                Debug.Log("Fightroom !!!!");
                SceneManager.LoadScene($"Floor{grid.floorLevel}");
            }
            else if (grid.rooms.Any(room => room.coordinate == (newX, newY) &&  room.RoomCat == "BossRoom"))
            {
                SceneManager.LoadScene($"Boss{grid.floorLevel}");
            }
        }

    }

    protected override void Update()
    {
        base.Update();
        Move();
    }
}
