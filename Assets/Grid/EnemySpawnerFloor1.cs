using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerFloor1 : MonoBehaviour
{
    public GameObject Lezard;
    public int maxMonsters;
    public List<GameObject> monsters;
    public List<Lizard> monstersDead;
    // Start is called before the first frame update
    public void Spawner()
    {
        float x = Random.Range(0.52f, 7.57f);
        float y = Random.Range(-3f, 3f);
        SpawnLezard(new Vector3(x, y, 0));

    }
    public void SetNbMonsters()
    {
        int nbEnemy = Random.Range(1, maxMonsters+1);
        for (int i = 0; i < nbEnemy; i++)
        {
            Spawner();
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
    void CheckEnemy()
    {
        Debug.Log(monsters.Count);
        foreach(GameObject monster in monsters) 
        {
            Lizard lizard = monster.GetComponent<Lizard>();
            Debug.Log(lizard.Life);
            if (lizard.Life <= 0)
            {
                monsters.Remove(monster);
                monstersDead.Add(lizard);
            }
        }
        if (monsters.Count == monstersDead.Count)
        {
            SceneManager.LoadScene("MapGame");
        }
    }
}
