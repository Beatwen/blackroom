using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawnerFloor1 : MonoBehaviour
{
    public Entity boss;
    public int nextLevel;
    
    void Update()
    {
        CheckEnemy();
    }
    void CheckEnemy()
    {
        if (boss.Life <= 0)
        {
            Invoke("LoadMapGameScene", 3f);
        }
    }
    public virtual void LoadMapGameScene()
    {
        File.Delete("GridState.json");
        SceneManager.LoadScene($"MapGame{nextLevel}");
    }
}
