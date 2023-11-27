using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : Room
{
    public MainGrid grid;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = grid.SpawnBoss(grid.startRoom);
        Debug.Log($"La position du boss est {transform.position}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
