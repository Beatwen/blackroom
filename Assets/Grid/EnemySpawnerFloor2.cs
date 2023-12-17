using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class EnemySpawnerFloor2 : EnemySpawnerFloor1
    {
    public GameObject medusa;
    public override void Spawner(float x, float y)
    {
        int z = Random.Range(1, 100);
        if ( z <= 30)
        {
            SpawnMedusa(new Vector3(x, y, 1));
        }
        else if ( z <= 100)
        {
            SpawnLezard(new Vector3(x,y,z));
        }
    }
    void SpawnMedusa(Vector3 v) 
    {
        GameObject monster = Instantiate(medusa, v, Quaternion.identity );
        monsters.Add(monster);
    }
}

