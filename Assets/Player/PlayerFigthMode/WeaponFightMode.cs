using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponFightMode : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public float horizontalInput;
    public float verticalInput;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) 
        {
            Debug.Log("Player hit the enemy !");
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

        void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            boxCollider.offset = new Vector2(-boxCollider.offset.x, boxCollider.offset.y);
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
            boxCollider.offset = new Vector2(Mathf.Abs(boxCollider.offset.x), boxCollider.offset.y);
        }
    }
}