using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot1 : Toolbox
{
    public float StartTimeBetweenShots1;
    private float TimeBtwShots1;
    public GameObject pBulletBoss;
    private Transform pCommander1;
    // Start is called before the first frame update
    void Start()
    {
        TimeBtwShots = 0;
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
            if (time(.2f))
            {
                Instantiate(pBulletBoss, transform.position, Quaternion.identity);
            }
        }

    }
}
