using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
=======
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
>>>>>>> 9fdc55f7bd1d33e5a572488045620c9720bb5c55

public class Player : Entity
{
    public MainGrid grid;
    public float x;
    public float y;
    public float z;

    public Inventory PlayerInventory { get; set; }
    public Room bossRoom;



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

    public void LoadBossRoom()
    {
        Room bossRoom = grid.BossRoom;
        SceneManager.LoadScene("LevelOne");
    }

    public void SetBossRoomReference(MainGrid mainGrid)
    {
        grid = mainGrid;
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
            Debug.Log($"Checking room at ({newX}, {newY}): {grid.rooms.FirstOrDefault(room => room.coordinate == (newX, newY))?.RoomCat}");

            transform.position = new Vector3(newX, newY, z);
            x = newX;
            y = newY;

            if (grid.rooms.Any(room => room.coordinate == (newX, newY) && room.RoomCat == "FightRoom"))
            {
                SceneManager.LoadScene($"Floor{grid.floorLevel}");
            }
        }


        if ((x, y) == bossRoom.coordinate)
        {
            LoadBossRoom();
        }
    }


    protected override void Update()
    {
        base.Update();
        Move();
    }


}
