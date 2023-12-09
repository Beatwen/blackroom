using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFightMode : Entity
{
    [SerializeField] private float movementSpeed = 3.0f;
    private float x;
    private float y;
    private float z;


    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Vector3 startPosition = Vector3.zero;
        x = startPosition.x;
        y = startPosition.y;
        z = startPosition.z;
        transform.position = new Vector3(x, y, z);
        // Additional initialization for the child class
    }

    protected override void Update()
    {
        base.Update();

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        CharFlipLogic(horizontalInput);


        Vector3 horizontalMovement = Vector3.right.normalized * horizontalInput * Time.deltaTime * 5;
        Vector3 verticalMovement = Vector3.up.normalized * verticalInput * Time.deltaTime * 5;
        Vector3 totalMovement = horizontalMovement + verticalMovement;
        totalMovement.Normalize();
        transform.Translate(horizontalMovement + verticalMovement);
        animator.SetFloat("Speed", horizontalInput);
        animator.SetFloat("SpeedY", verticalInput);


        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack2");
        }
    }
}