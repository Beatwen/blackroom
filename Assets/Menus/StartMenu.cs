using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartBtn()
    {
        File.Delete("GridState.json");
        SceneManager.LoadScene("MapGame1");
    }
    public void LoadBtn()
    {
        int floorLevel = 1;
        SceneManager.LoadScene($"MapGame{floorLevel}");
    }
    public void SettingsBtn()
    {
        SceneManager.LoadScene("Settings");
    }
    public void QuitBtn()
    {
        Application.Quit();
    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
