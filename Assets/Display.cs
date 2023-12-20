using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Display : MonoBehaviour
{
    public int Life;
    public int Mana;
    public PlayerFightMode player;
    public TMP_InputField textField;

    void Start()
    {
        if (FindObjectsOfType<Display>().Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        Life = player.Life;
        Mana = player.Mana;

        if (textField != null)
        {
            textField.text = "Life: " + Life.ToString() +"\nMana:" + Mana.ToString();
        }
    }
}

