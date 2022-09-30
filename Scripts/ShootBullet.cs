using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : Toolbox
{
    public GameObject pBullet;//
    public Transform bullet;//
    _Time timer = new _Time();

    public bool howclose;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        TimeBtwShots = 1;
    }

    private void FixedUpdate()
    {
        shoot();
    }
    void shoot()
    {
        if (ifclose(1.5f))
        {
                onShoot(pBullet, "EnemyBug(Clone)", 3f);
        }
    }

}



