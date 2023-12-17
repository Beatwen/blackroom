
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;

public class Monsters : Entity
{
    public LayerMask WhatIsPlayer;

    public bool isDead = false;
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    float enemySpeedX;
    float direction;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    private Vector3 previousPosition;
    public Vector3 walkPoint;
    private Transform playerPos;
    public float sightRange = 2;
    public float attackRange = 1;
    public bool playerIsVisible, playerIsClose;
    public int counter = 0;
    public Monsters(string name, int life, int level, int positionX, int positionY)
    {
        Name = name;
        Life = life;
        Level = level;
        PositionX = positionX;
        PositionY = positionY;
    }

    void Patrol()
    {
        //Faut que je change ceci, ca peut pas marcher lorsqu'on va rajouter une patrouille
        animator.SetFloat("Velocity", 0f);
    }
    void ChasePlayer()
    {
        animator.SetFloat("Velocity", 1f);
        // Translate towards the player
        Vector3 direction = (playerPos.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        CharFlipLogic(direction.x);

        // Look at the player
        //Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
    void AttackPlayer()
    {
        animator.SetFloat("Velocity", 0f);
        if (!alreadyAttacked)
        {
            Invoke(nameof(AttackPlayerLogic), 0.2f);
            animator.SetTrigger("Attack");
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }
    }
    void AttackPlayerLogic()
    {

        PlayerFightMode player = playerPos.GetComponent<PlayerFightMode>();
        if (player != null)
        {
            player.TakeDamage(AttackDamage);
        }
    }
    private void ResetAttack()
    {

        alreadyAttacked = false;
    }
    private void Awake()
    {
        playerPos = GameObject.Find("Player").transform;
    }


    public void GiveExperience(int experiencePoints)
    {
        Debug.Log($"{Name} gives {experiencePoints} experience points.");
    }

    public void GiveItem(string item)
    {
        Console.WriteLine($"{Name} gives {item}.");
    }
    private void OnTriggerEnter2D(Collider2D collide)
    {

        if (collide.CompareTag("Weapon") && hasAlreadyHit == false)
        {
            Debug.Log(++counter);
            PlayerFightMode player = collide.GetComponentInParent<PlayerFightMode>();
            TakeDamage(player.AttackDamage);
            hasAlreadyHit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            hasAlreadyHit = false;
        }
    }

    protected override void Start()
    {
        base.Start();
        previousPosition = transform.position;
    }
    protected override void Update()
    {
        base.Update();

        // This is how I check if the player if around
        Collider2D hit = Physics2D.OverlapCircle(transform.position, sightRange, WhatIsPlayer);
        playerIsVisible = hit != null;
        playerIsClose = Physics2D.OverlapCircle(transform.position, attackRange, WhatIsPlayer);

        if (!playerIsVisible && !playerIsClose)
        {
            Patrol();
        }
        else if (playerIsVisible && !playerIsClose)
        {
            ChasePlayer();
        }
        else if (playerIsVisible && playerIsClose)
        {
            AttackPlayer();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}