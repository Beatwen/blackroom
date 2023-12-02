using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FigthMode : Player
{
    public FigthMode(string name, int life, int strength, int level, int positionX, int positionY, int mana, Inventory inventory) : base(name, life, strength, level, positionX, positionY, mana, inventory)
    {
    }

    void Start()
    {

        Vector3 startPosition = Vector3.zero;
        x = startPosition.x;
        y = startPosition.y;
        z = startPosition.z;
        transform.position = new Vector3(x, y, z);

    }

    public override void Move()
    {
        while (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y += 0.01f;
        }
        while (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y -= 0.01f;
        }
        while (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x += 0.01f;
        }
        while (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x -= 0.01f;
        }

    }
    void Update()
    {
        Move();
    }
}