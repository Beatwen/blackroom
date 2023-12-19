using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFightMode : Entity
{
    [SerializeField] private float movementSpeed = 3.0f;
    private float x;
    private float y;
    private float z;
    [SerializeField] public AudioSource attackAudioSource;
    private PlayerData playerData;
    [System.Serializable]

    private class PlayerData
    {
        public int LifeDisplay;
        public int ManaDisplay;
    }
    private void PlayAttackSound()
    {
        attackAudioSource.Play();
    }
    public void SavePlayerState()
    {
        if (File.Exists("PlayerState.json"))
        {
            File.Delete("PlayerState.json");
        }
        playerData = new PlayerData
        {
            LifeDisplay = Life,
            ManaDisplay = Mana

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
            Mana = playerData.ManaDisplay;
            Debug.Log($"Life is restored {playerData.LifeDisplay}");
            Debug.Log($"Life is restored {playerData.ManaDisplay}");
        }
    }
    protected override void Start()
    {
        base.Start();
        attackAudioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        InvokeRepeating("ManaRegen", 1.0f, 2.0f);
        Vector3 startPosition = new Vector3(-6.75f, 2.25f, 0f) ;
        x = startPosition.x;
        y = startPosition.y;
        z = startPosition.z;
        transform.position = new Vector3(x, y, z);
        LoadPlayerState();
        // Additional initialization for the child class
    }
    protected override void Die()
    {
        base.Die();
        Invoke("LoadStartMenu", 3f) ;
    }
    void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void ManaRegen()
    {
        Mana += 1;
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
            PlayAttackSound();
        }
        if (Input.GetMouseButtonDown(1) && Mana >= 20)
        {
            Mana -=20;
            animator.SetTrigger("Attack2");
        }
    }
    void OnDisable()
    {
        SavePlayerState();
    }

}