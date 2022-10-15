using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : Toolbox
{
    public GameObject Prefab;
    static int trackeridmaker;
    Vector2 startposition;
    Vector2 compareposition;
    Vector2 compareposition2;
    int trackeridcomp;
    _Time timer = new _Time();
    int amountofenemies;

    // Start is called before the first frame update
    void Start()
    {
        amountofenemies = 3;
        trackeridmaker = trackeridmaker + 1;
        trackeridcomp = trackeridmaker;
        startposition = transform.position;
        compareposition = new Vector2(startposition.x + 5, startposition.y + 5);
        compareposition2 = new Vector2(startposition.x - 5, startposition.y - 5);
        timer._startmodify(10);
        spawn(Prefab, amountofenemies);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (countid() < amountofenemies)
       {
            if (timer._wait(10))
            {
                spawn(Prefab, 1);
            }
       }
    }
    void spawn(GameObject Prefab, int howmany)
    {
        Vector2 SpawnPosition;
        for (int i = 0; i < howmany; i++)
        {
            SpawnPosition = random(compareposition2.x, compareposition.x, compareposition2.y,compareposition.y);
            var proj1 = Instantiate(Prefab, SpawnPosition, Quaternion.identity);
            proj1.GetComponent<trackid>().trackerid = trackeridcomp;
        }
    }
    int countid()
    {  
        int increaseonfind = 0;
        GameObject[] enemylist = GameObject.FindGameObjectsWithTag("EnemyBug(Clone)");
        foreach (GameObject enemy in enemylist)
        {
                int Trackchecker = enemy.GetComponent<trackid>().trackerid;
                if (Trackchecker == trackeridcomp)
                {
                    increaseonfind++;
                }
            
        }
        return increaseonfind;
    }
}
