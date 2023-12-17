using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponFightMode : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public PlayerFightMode fightMode;
    private bool enableAttack = true;
    public float horizontalInput;
    public float verticalInput;
    private float attackCooldown = 0.6f;
    private float timeSinceAttack = 0f; 
    void OnTriggerEnter2D(Collider2D attack)
    {
        if (attack.CompareTag("Enemy") && enableAttack) 
        {
            Debug.Log("Player hit the enemy !");
            enableAttack = false;
            Invoke(nameof(ResetAttackCooldown), attackCooldown);
            
        }

    }
    void ResetAttackCooldown()
    {
        enableAttack = true;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0f) 
        {
            boxCollider.offset = new Vector2(Math.Abs(boxCollider.offset.x), boxCollider.offset.y);
        }
        else if (horizontalInput < 0f) 
        {
            boxCollider.offset = new Vector2(-Mathf.Abs(boxCollider.offset.x), boxCollider.offset.y);
        }
        //if (Input.GetMouseButtonDown(0) && Time.time - timeSinceAttack > attackCooldown )
        //{
        //    fightMode.animator.SetTrigger("Attack");
        //    timeSinceAttack = Time.time;
        //}
    }
}