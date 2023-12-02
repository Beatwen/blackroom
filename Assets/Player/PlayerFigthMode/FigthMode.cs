using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FigthMode : Entity
{
    [SerializeField] private float movementSpeed = 3.0f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float horizontalInput;
    public float verticalInput;
    private float x;
    private float y;
    private float z;

    public FigthMode(string name, int life, int mana, int experience, int level, int positionX, int positionY) : base(name, life, mana, experience, level, positionX, positionY)
    {
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Vector3 startPosition = Vector3.zero;
        x = startPosition.x;
        y = startPosition.y;
        z = startPosition.z;
        transform.position = new Vector3(x, y, z);

    }

        void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 horizontalMovement = Vector3.right.normalized * horizontalInput * Time.deltaTime * 5;
        Vector3 verticalMovement = Vector3.up.normalized * verticalInput * Time.deltaTime * 5;
        Vector3 totalMovement = horizontalMovement + verticalMovement;
        totalMovement.Normalize();
        transform.Translate(horizontalMovement + verticalMovement);
        animator.SetFloat("Speed", horizontalInput);
        animator.SetFloat("SpeedY", verticalInput);
        if (horizontalInput < 0)
        {
            // Face left
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            // Face right
            spriteRenderer.flipX = false;
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            animator.SetTrigger("Attack");
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack2");
        }
    }
}