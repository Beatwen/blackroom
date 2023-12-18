using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeDisplay : MonoBehaviour
{
    public int Life;
    public PlayerFightMode player;
    public TMP_InputField textField;

    void Start()
    {
        // If this is the first instance of the LifeDisplay, keep it between scenes
        if (FindObjectsOfType<LifeDisplay>().Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        Life = player.Life;

        if (textField != null)
        {
            textField.text = "Life: " + Life.ToString();
        }
    }
}

