using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot1 : Toolbox
{
    public float StartTimeBetweenShots1;
    public GameObject pBulletBoss;
    private Transform pCommander1;
    Vector2 Predictposition;
    _Time timer = new _Time();
    _Time timer2 = new _Time();
    // Start is called before the first frame update
    void Start()
    {
        pCommander1 = ObjectReference("Commander");
        Physics2D.IgnoreLayerCollision(13, 8);
    }

    private void FixedUpdate()
    {
        ModonShoot();
    }
    void ModonShoot()
    {
        Vector2 constantposition = pCommander1.position;
        if (modifclose2(3f))//Here is the prediction algorithm
        {
                if (timer._wait(1))
                {
                    Vector2 pos = (new Vector2(Mathf.Abs(constantposition.x - transform.position.x), Mathf.Abs(constantposition.y - transform.position.y)));
                    Vector2 addposition = (29*pos * (constantposition - Predictposition));
                    Vector2 Enemy1 = constantposition + addposition;
                    Vector2 Enemy = new Vector2((Enemy1.x - transform.position.x), (Enemy1.y - transform.position.y)).normalized * 3;
                    var proj1 = Instantiate(pBulletBoss, transform.position, Quaternion.identity);
                    proj1.GetComponent<Rigidbody2D>().velocity = new Vector2(Enemy.x, Enemy.y);
                }
                Predictposition = pCommander1.position;
        }
        else
        {
            if (GameObject.Find("Friendly(Clone)") != null)
            {
                if (modifclose(3))
                {
                    if (timer2._wait(1))
                    {
                     onShoot(pBulletBoss, "Commander", 3);
                    }

                }
            }


        }
    }
    bool modifclose(float distance)//Allows for reference of a different type then ifclose.
    {
        Transform pCommander = ObjectReference("Friendly(Clone)").transform;
        Transform closestEnemy = FindClosestEnemy("EnemyBug(Clone)").transform;
        float diffx = (pCommander.position.x - closestEnemy.position.x);
        float diffy = (pCommander.position.y - closestEnemy.position.y);
        float magnitude = (Mathf.Sqrt(Mathf.Pow(diffx, 2) + Mathf.Pow(diffy, 2)));
        if (magnitude < distance) return true;
        else return false;
    }
    bool modifclose2(float distance)//Allows for reference of a different type then ifclose.
    {
        Transform pCommander = ObjectReference("Commander").transform;
        Transform closestEnemy = FindClosestEnemy("EnemyBug(Clone)").transform;
        float diffx = (pCommander.position.x - closestEnemy.position.x);
        float diffy = (pCommander.position.y - closestEnemy.position.y);
        float magnitude = (Mathf.Sqrt(Mathf.Pow(diffx, 2) + Mathf.Pow(diffy, 2)));
        if (magnitude < distance) return true;
        else return false;
    }
}
