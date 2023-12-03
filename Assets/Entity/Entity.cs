using System;
using UnityEngine;

public class Entity : MonoBehaviour
{

    // Attributs
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public float horizontalInput;
    public float verticalInput;
    public int AttackDammage;
    public string Name;
    public int Life;
    public int Mana;
    public int Experience;
    public int Level;
    public int PositionX;
    public int PositionY;

    protected virtual void CharFlipLogic(float direction)
    {
        if (direction < 0)
        {
            spriteRenderer.flipX = true;
            boxCollider.offset = new Vector2(-Mathf.Abs(boxCollider.offset.x), boxCollider.offset.y);
        }
        else if (direction > 0)
        {
            spriteRenderer.flipX = false;
            boxCollider.offset = new Vector2(Mathf.Abs(boxCollider.offset.x), boxCollider.offset.y);
        }
    }
    public void Attack()
    {
            Console.WriteLine($"{Name} Attaque ! ");
    }
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    protected virtual void Update()
    {
        
    }


}
