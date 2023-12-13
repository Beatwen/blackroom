using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : Monsters
{
    public Lizard(string name, int life, int level, int positionX, int positionY) : base(name, life, level, positionX, positionY)
    {
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
