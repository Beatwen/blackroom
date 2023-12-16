using System;
using UnityEngine;
using UnityEngine.AI;

public class Monsters : Entity
{
    public LayerMask WhatIsPlayer;

    public bool isDead = false;
    public float moveSpeed = 1f;
    private bool facingRight = true; // Indicateur pour savoir dans quelle direction le monstre fait face

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    private Vector3 previousPosition;
    public Vector3 walkPoint;
    private Transform playerPos;
    public float sightRange = 2;
    public float attackRange = 1;
    public bool playerIsVisible, playerIsClose;
    public int counter = 0;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Start()
    {
        base.Start();
        previousPosition = transform.position;
    }

    protected override void Update()
    {
        base.Update();

        playerIsVisible = Physics2D.OverlapCircle(transform.position, sightRange, WhatIsPlayer);
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

    void Patrol()
    {
        // Logique de patrouille à implémenter
        animator.SetFloat("Velocity", 0f);
    }

    void ChasePlayer()
    {
        animator.SetFloat("Velocity", 1f);
        Vector3 direction = (playerPos.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        CharFlipLogic(direction.x);
    }

    void CharFlipLogic(float directionX)
    {
        if (directionX > 0 && !facingRight || directionX < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void AttackPlayer()
    {
        animator.SetFloat("Velocity", 0f);
        if (!alreadyAttacked)
        {
            // Implémentez la logique d'attaque ici
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

    public Monsters(string name, int life, int level, int positionX, int positionY)
    {
        Name = name;
        Life = life;
        Level = level;
        PositionX = positionX;
        PositionY = positionY;
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
        if (collide.CompareTag("Enemy"))
        {
            Debug.Log(++counter);
            PlayerFightMode player = collide.GetComponentInParent<PlayerFightMode>();
            TakeDamage(player.AttackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    // Ajoutez d'autres méthodes et logiques nécessaires ici
}
