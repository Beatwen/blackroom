using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerFloor1 : MonoBehaviour
{
    public int floorLevel = 1;
    public GameObject Lezard;
    public int maxMonsters;
    public List<GameObject> monsters;
    public List<Monsters> monstersDead;
    private int count;

    public virtual void SetNbMonsters()
    {
        int nbEnemy = Random.Range(1, maxMonsters +1);
        count = nbEnemy;
        for (int i = 0; i < nbEnemy; i++)
        {
            float x = Random.Range(0.52f, 7.57f);
            float y = Random.Range(-3f, 3f);
            Spawner(x,y);
        }
    }
    public virtual void Spawner(float x, float y)
    {
        int z = Random.Range(1, 100);
        if (z <= 100)
        {
            SpawnLezard(new Vector3(x, y, 0));
        }
    }

    public void SpawnLezard(Vector3 position)
    {
        GameObject monstre = Instantiate(Lezard, position,Quaternion.identity);
        monsters.Add(monstre);
    }
    void Start()
    {
        SetNbMonsters();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemy();
    }
    public virtual void CheckEnemy()
    {
        foreach (GameObject monster in monsters) 
        {
            Monsters enemy  = monster.GetComponent<Monsters>();
            if (enemy.Life <= 0 && !monstersDead.Contains(enemy))
            {
                monstersDead.Add(enemy);
            }
        }
        if (monstersDead.Count == count)
        {
            Invoke("LoadMapGameScene", 3f);
        }
    }
    public virtual void LoadMapGameScene()
    {
        SceneManager.LoadScene($"MapGame{floorLevel}");
    }
}
