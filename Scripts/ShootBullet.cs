using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : Toolbox
{
    public GameObject pBullet;//
    public Transform bullet;//


    public bool howclose;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        TimeBtwShots = 3;
    }

    private void FixedUpdate()
    {
        shoot();
    }
    void shoot()
    {
        if (ifclose(1,1))
        {
            if (time(1))
            {
                Instantiate(pBullet, transform.position, Quaternion.identity);
            }
        }
    }

}



