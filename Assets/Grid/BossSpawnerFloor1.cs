using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSpawnerFloor1 : MonoBehaviour
{
    public int maxMonsters;
    public Entity boss;
    public List<GameObject> monsters;
    public List<Lizard> monstersDead;
    private int count;
    
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
    void LoadMapGameScene()
    {
        SceneManager.LoadScene("MapGame");
    }
}
