using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("MapGame");
    }
    public void LoadBtn()
    {
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
