using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot1 : MonoBehaviour
{
    public float StartTimeBetweenShots1;
    private float TimeBtwShots1;
    public GameObject pBulletBoss;
    public GameObject EnemyBug;
    public float radiusx1;
    public float radiusy1;
    public GameObject Enemy2;
    public Transform Enemy1;
    public Transform pCommander1;
    // Start is called before the first frame update
    void Start()
    {
        TimeBtwShots1 = StartTimeBetweenShots1;
        pCommander1 = ObjectReference("Commander");
        Physics2D.IgnoreLayerCollision(13, 8);
    }

    private void FixedUpdate()
    {
        shoot();
    }
    void shoot()
    {
        if (ifclose(2f, 2f))
        {
            if (TimeBtwShots1 <= 0)
            {
                Instantiate(pBulletBoss, transform.position, Quaternion.identity);
                TimeBtwShots1 = StartTimeBetweenShots1;
            }
            else
            {
                TimeBtwShots1 -= Time.deltaTime;
            }
        }

    }
    bool ifclose(float x, float y)
    {
        float radiusx;
        float radiusy;
        radiusx = Mathf.Abs(pCommander1.position.x - transform.position.x);
        radiusy = Mathf.Abs(pCommander1.position.y - transform.position.y);
        if (radiusx < x && radiusy < y)
        {
            return true;
        }
        return false;
    }
    Transform ObjectReference(string Reference)
    {
        if (GameObject.Find(Reference) != null)
        {
            Transform Object = GameObject.Find(Reference).transform;
            return Object;
        }
        return null;

    }
}
