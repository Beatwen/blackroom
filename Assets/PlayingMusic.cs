using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayingMusic : MonoBehaviour
{
    private static PlayingMusic instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MapGame3")
        {
            Destroy(gameObject);
        }
    }
}
