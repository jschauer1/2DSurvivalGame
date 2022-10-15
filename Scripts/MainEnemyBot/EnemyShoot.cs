using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Toolbox
{   
    [SerializeField]
     GameObject pBullet1;
    _Time timer = new _Time();

    // Start is called before the first frame update
    void Start()
    {
        TimeBtwShots = 0f;
        Physics2D.IgnoreLayerCollision(9, 8);
    }
    

    private void FixedUpdate()
    {
        timer._startmodify(1);
        shoot(1, 1, 2f);
        shoot(.4f, .4f, 1f);
    }
    void shoot(float x1,float y1,float timex)
    {
        
        if (ifclose(x1, "Commander"))
        {
           if (timer._wait(timex))
            {
                onShoot(pBullet1, "Commander", 2.5f);
            }

        }
    }


}


