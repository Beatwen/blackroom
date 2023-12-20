using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public float delay = 12f;

    void Start()
    {
        StartCoroutine(SwitchSceneAfterDelay(delay));
    }

    IEnumerator SwitchSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("StartMenu"); 
    }
}
