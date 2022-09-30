using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : Toolbox
{
    public GameObject SpawnEnemyPrefab;
    public GameObject SpawnBoss1Prefab;

    void Start()
    {
        spawn(SpawnEnemyPrefab,2,-6.95f, 6.56f, 8.67f, 2.52f);
        spawn(SpawnEnemyPrefab, 2, 8.97f,2.52f, 3.8f, -6.21f);
        spawn(SpawnEnemyPrefab, 2, 3.8f, -6.21f, 8.67f, 2.52f);
        spawn(SpawnEnemyPrefab, 2, -6.82f, -2.74f, -2.3f, 3.6f);
        spawn(SpawnEnemyPrefab, 2, -6.03f, -1.6f, 5.88f, -5.69f);
        spawn(SpawnBoss1Prefab, 1, -.015f, 9.61f, -.015f, 9.61f);
    }
   void spawn(GameObject Prefab, int howmany, float x1, float y1, float x2, float y2)
    {
        Vector2 SpawnPosition;
        for (int i = 0; i < howmany; i++)
        {
            SpawnPosition = random(x1, x2, y1, y2);
            Instantiate(Prefab, SpawnPosition, Quaternion.identity);
        }

    }
}
