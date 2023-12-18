using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerFightMode : Entity
{
    [SerializeField] private float movementSpeed = 3.0f;
    private float x;
    private float y;
    private float z;
    private PlayerData playerData;
    [System.Serializable]
    private class PlayerData
    {
        public int LifeDisplay;
    }
    public void SavePlayerState()
    {
        if (File.Exists("PlayerState.json"))
        {
            File.Delete("PlayerState.json");
        }
        playerData = new PlayerData
        {
            LifeDisplay = this.Life
        };

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText("PlayerState.json", json);
    }


    public void LoadPlayerState()
    {
        if (File.Exists("PlayerState.json"))
        {

            Debug.Log("Loading data !");
            string json = File.ReadAllText("PlayerState.json");
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Life = playerData.LifeDisplay;
            Debug.Log($"Life is restored {playerData.LifeDisplay}");
        }
    }
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Vector3 startPosition = new Vector3(-6.75f, 2.25f, 0f) ;
        x = startPosition.x;
        y = startPosition.y;
        z = startPosition.z;
        transform.position = new Vector3(x, y, z);
        LoadPlayerState();
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

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack2");
        }
    }
    void OnDisable()
    {
        SavePlayerState();
    }

}